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
        /// Main Logic Class
        /// </summary>
        clsMainLogic MainLogic = new clsMainLogic();

        /// <summary>
        /// Item list to store values for main list
        /// </summary>
        List<modItemDesc> ItemList = new List<modItemDesc>();

        /// <summary>
        /// Current Invoice object
        /// </summary>
        modInvoice currentInvoice;
        
        /// <summary>
        /// Main Window Constructor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            errorHandler = new clsErrorHandling();

            //Here for testing
            InvoiceNum = 0;
            
            dateSelector.SelectedDate = DateTime.Now;
            btnAddItem.IsEnabled = false;
            btnDeleteItem.IsEnabled = false;
            refreshFields();
            getInvoiceLineItems(InvoiceNum);
            calculateTotal();
            
            
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
        public void passFromSearch(modInvoice invoice)
        {

            //Implement the logic to update the fields based on the invoice number
            InvoiceNum = invoice.InvoiceNum;

            //Update Everything
            dateSelector.SelectedDate = DateTime.Now;
            btnAddItem.IsEnabled = false;
            btnDeleteItem.IsEnabled = false;
            refreshFields();
            getInvoiceLineItems(InvoiceNum);
            calculateTotal();
        }

        /// <summary>
        /// Setup to receive data from the items window
        /// </summary>
        public void passFromItems()
        {
            //Implement the logic to update the fields based on the invoice number
            //Just need to tell the main window to update its fields
            dateSelector.SelectedDate = DateTime.Now;
            btnAddItem.IsEnabled = false;
            btnDeleteItem.IsEnabled = false;
            refreshFields();
            getInvoiceLineItems(InvoiceNum);
            calculateTotal();
        }

        /// <summary>
        /// Get Invoice Line Items
        /// </summary>
        /// <param name="invoiceNumber"></param>
        private void getInvoiceLineItems(int invoiceNumber)
        {
            try
            {
                //Get the invoice line items
                clsMainLogic clsMainLogic = new clsMainLogic();
                ItemList = clsMainLogic.getItemsInInvoice(invoiceNumber);
                InvoicesList.ItemsSource = ItemList;
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
        /// Refresh the displayed fields
        /// </summary>
        private void refreshFields()
        {
            try
            {
                //Implement the logic to refresh the fields
                clsMainLogic mainLogic = new clsMainLogic();
                currentInvoice = mainLogic.getInvoiceById(InvoiceNum);

                

                InvoicesList.ItemsSource = ItemList;
                if (InvoiceNum == 0)
                {
                    txtInvoiceNumber.Content = "New Invoice";
                }
                else {
                    txtInvoiceNumber.Content = InvoiceNum.ToString(); 
                }
                //InvoicesList.ItemsSource = mainLogic.getItemsInInvoice(5000);

                //Clear combo box
                cboItemDesc.SelectedItem = null;
                cboItemDesc.ItemsSource = mainLogic.getAllItems();

                //Set the date field from the db
                if (currentInvoice.InvoiceNum != 0)
                {
                    dateSelector.SelectedDate = currentInvoice.InvoiceDate;
                    dateSelector.DisplayDate = currentInvoice.InvoiceDate;
                }
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
            try
            {
                //Check if field is not null
                if (cboItemDesc.SelectedItem != null)
                {
                    btnAddItem.IsEnabled = true;
                    clsMainLogic clsMainLogic = new clsMainLogic();
                    List<modItemDesc> ItemList = clsMainLogic.getAllItems();

                    int index = cboItemDesc.SelectedIndex;
                    //Format to currency
                    txtItemCost.Text = ItemList[index].ItemCost.ToString("C");
                }
            }
            catch(Exception ex)
            {
                errorHandler.sClass = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                errorHandler.sMethod = MethodInfo.GetCurrentMethod().Name;
                errorHandler.sMessage = ex.Message;
                errorHandler.displayErrorMessage();
            }
        }

        

        /// <summary>
        /// Save/Update Changes to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Loop through the items and remove all items and replace them with the new items
                List<modItemDesc> items = MainLogic.getItemsInInvoice(InvoiceNum);

                //Calculate the total cost of the items
                int totalCost = 0;
                foreach (modItemDesc item in ItemList)
                {
                    //Convert to decimal nearest interger
                    int newcost = Convert.ToInt32(item.ItemCost);
                    totalCost += newcost;
                }

                //Create new invoice if the invoice number is zero

                if (InvoiceNum == 0)
                {
                    InvoiceNum = MainLogic.createInvoice((DateTime)dateSelector.SelectedDate, totalCost);
                }
                
                //Update the invoice with the new total cost
                MainLogic.saveInvoice(ItemList, InvoiceNum);
                MainLogic.updateInvoice(totalCost,  InvoiceNum);
                

                refreshFields();
                txtItemCost.Text = "";
                btnAddItem.IsEnabled = false;

                lblInvoiceTotal.Content = "Total: $" + totalCost + ".00";
                

                
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
        /// Delete the invoice from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MainLogic.deleteInvoice(InvoiceNum);
            InvoiceNum = 0;
            txtInvoiceNumber.Content = "New Invoice";
            InvoicesList.ItemsSource = null;
            ItemList.Clear();
        }

        
        /// <summary>
        /// When an item is selected from the list enable the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Enable the delete button
            btnDeleteItem.IsEnabled = true;
        }

        /// <summary>
        /// Add an item to the list of items from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get the selected item
                modItemDesc item = (modItemDesc)cboItemDesc.SelectedItem;

                //Add Item to list
               
                ItemList.Add(item);

                //Clear the list
                InvoicesList.ItemsSource = null;
                InvoicesList.ItemsSource = ItemList;

                calculateTotal();
                
            }
            catch(Exception ex)
            {
                errorHandler.sClass = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                errorHandler.sMethod = MethodInfo.GetCurrentMethod().Name;
                errorHandler.sMessage = ex.Message;
                errorHandler.displayErrorMessage();
            }
        }


        /// <summary>
        /// Delete an item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get selected item from the list
                modItemDesc item = (modItemDesc)InvoicesList.SelectedItem;
                ItemList.Remove(item);

                //Update the main list
                InvoicesList.ItemsSource = null;
                InvoicesList.ItemsSource = ItemList;

                refreshFields();

                //Disable the delete button
                btnDeleteItem.IsEnabled = false;
                txtItemCost.Text = string.Empty;
                btnAddItem.IsEnabled = false;

                calculateTotal();
                
            }
            catch(Exception ex)
            {
                errorHandler.sClass = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                errorHandler.sMethod = MethodInfo.GetCurrentMethod().Name;
                errorHandler.sMessage = ex.Message;
                errorHandler.displayErrorMessage();
            }
        }

        /// <summary>
        /// Calculate the invoices total
        /// </summary>
        private void calculateTotal()
        {
            int totalCost = 0;
            foreach (modItemDesc item in ItemList)
            {
                //Convert to decimal nearest interger
                int newcost = Convert.ToInt32(item.ItemCost);
                totalCost += newcost;
            }

            lblInvoiceTotal.Content = "Total: $" + totalCost + ".00";

        }
    }
}
