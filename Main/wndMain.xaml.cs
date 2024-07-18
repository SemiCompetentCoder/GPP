using DummyWPF.Items;
using DummyWPF.Main;
using DummyWPF.Search;
using GroupProject3280;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DummyWPF
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// Invoice Number from the search window (Needs getters and setters)
        /// So that the application window can update the fields based on inputed data.
        /// </summary>
        private int InvoiceNum { get; set; }

        /// <summary>
        /// Error Handling
        /// </summary>
        private clsErrorHandling errorHandler;
        
        /// <summary>
        /// Main Window Constructor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            errorHandler = new clsErrorHandling();
            refreshFields();
            
            
        }

        /// <summary>
        /// Invoice Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndSearch wndSearch = new wndSearch(this);
            wndSearch.ShowDialog();
        }

        /// <summary>
        /// Update Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnSearchforItems_Click(object sender, RoutedEventArgs e)
        {
            wndItems wndItems = new wndItems(this);
            wndItems.ShowDialog();
        }

        /// <summary>
        /// Pass the invoice number to the main window
        /// </summary>
        /// <param name="invoiceNum"></param>
        public void passInvoiceNum(int invoiceNum)
        {
            InvoiceNum = invoiceNum;
            
            //Implement the logic to update the fields based on the invoice number
        }


        /// <summary>
        /// Setup to receive data from the search window
        /// </summary>
        public void passFromSearch()
        {

           //Implement the logic to update the fields based on the invoice number
        }

        /// <summary>
        /// Setup to receive data from the items window
        /// </summary>
        public void passFromItems()
        {
            //Implement the logic to update the fields based on the invoice number
        }

        /// <summary>
        /// Refresh the displayed fields
        /// </summary>
        public void refreshFields()
        {
            try
            {
                //Implement the logic to refresh the fields
                clsMainLogic mainLogic = new clsMainLogic();
                InvoicesList.ItemsSource = mainLogic.getInvoices();
                cboItemDesc.ItemsSource = mainLogic.getAllItems();
            }
            catch (Exception ex)
            {
                errorHandler.sClass = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                errorHandler.sMethod = MethodInfo.GetCurrentMethod().Name;
                errorHandler.sMessage = ex.Message;
                errorHandler.displayErrorMessage();
            }

            
        }

        /// <summary>
        /// Update the price based on the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboItemDesc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsMainLogic clsMainLogic = new clsMainLogic();
            List<modItemDesc> ItemList = clsMainLogic.getAllItems();

            int index = cboItemDesc.SelectedIndex;
            //Format to currency
            txtItemCost.Text = ItemList[index].ItemCost.ToString("C");
        }

    }
}
