using GroupProject3280;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DummyWPF.Search
{

    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        /// <summary>
        /// Error handling functions
        /// </summary>
        clsErrorHandling errorhnd = new clsErrorHandling();

        /// <summary>
        /// Contains window logic
        /// </summary>
        clsSearchLogic searchLogic;

        /// <summary>
        /// To pass invoice to main window
        /// </summary>
        private wndMain mainWindow;

        /// <summary>
        /// Fill comboboxes and datagrid
        /// </summary>
        /// <param name="mainWindow"></param>
        public wndSearch(wndMain mainWindow)
        {
            try
            {
                InitializeComponent();


                searchLogic = new clsSearchLogic();
                dgSearchInvoice.ItemsSource = searchLogic.RetrieveInvoices();
                cbSearchInvoiceNumber.ItemsSource = searchLogic.RetrieveInvoiceNums();
                cbSearchInvoiceDate.ItemsSource = searchLogic.RetrieveInvoiceDates();
                cbSearchTotalCharge.ItemsSource = searchLogic.RetrieveInvoiceCosts();
                

                this.mainWindow = mainWindow; //Main window is passed in as a parameter
            }
            catch (Exception ex)
            {
                errorhnd.displayErrorMessage(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Reset combobox options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cbSearchInvoiceNumber.SelectedIndex = -1;
                cbSearchInvoiceDate.SelectedIndex = -1;
                cbSearchTotalCharge.SelectedIndex = -1;

                dgSearchInvoice.ItemsSource = searchLogic.RetrieveInvoices();
            }
            catch (Exception ex)
            {
                errorhnd.displayErrorMessage(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Pass invoice object and close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSearchInvoice.SelectedItem is modInvoice selectedInvoice)
                {
                    mainWindow.passFromSearch(selectedInvoice);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select an invoice", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                errorhnd.displayErrorMessage(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }


        }
        /// <summary>
        /// Changes datagrid depending on searched options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object invoiceNum = cbSearchInvoiceNumber.SelectedItem;
                object invoiceDate = cbSearchInvoiceDate.SelectedItem;
                object invoiceCost = cbSearchTotalCharge.SelectedItem;

                if (invoiceNum != null && invoiceDate != null && invoiceCost != null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(invoiceNum.ToString(), invoiceDate.ToString(), invoiceCost.ToString());
                }
                if (invoiceNum != null && invoiceDate == null && invoiceCost == null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(clsSearchLogic.Selection.NUM, invoiceNum.ToString());
                }
                if (invoiceNum == null && invoiceDate != null && invoiceCost == null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(clsSearchLogic.Selection.DATE, invoiceDate.ToString());
                }
                if (invoiceNum == null && invoiceDate == null && invoiceCost != null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(clsSearchLogic.Selection.COST, invoiceCost.ToString());
                }
                if (invoiceNum != null && invoiceDate != null && invoiceCost == null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(clsSearchLogic.Selection.NUM_DATE, invoiceNum.ToString(), invoiceDate.ToString());
                }
                if (invoiceNum == null && invoiceDate != null && invoiceCost != null)
                {
                    dgSearchInvoice.ItemsSource = searchLogic.RetrieveSearch(clsSearchLogic.Selection.DATE_COST, invoiceDate.ToString(), invoiceCost.ToString());
                }
            }
            catch (Exception ex)
            {
                errorhnd.displayErrorMessage(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
           
        }
    }
}
