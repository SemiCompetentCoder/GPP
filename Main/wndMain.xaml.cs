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

        //Error Handling
        private clsErrorHandling errorHandler;

        //main logic
        
        



        public wndMain()
        {
            InitializeComponent();
            errorHandler = new clsErrorHandling();
            refreshFields();
            
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndSearch wndSearch = new wndSearch(this);
            wndSearch.ShowDialog();
        }

        private void mnSearchforItems_Click(object sender, RoutedEventArgs e)
        {
            wndItems wndItems = new wndItems(this);
            wndItems.ShowDialog();
        }

        public void passInvoiceNum(int invoiceNum)
        {
            InvoiceNum = invoiceNum;
            
            //Implement the logic to update the fields based on the invoice number
        }


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
