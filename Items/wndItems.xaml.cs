using GroupProject3280;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
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

namespace DummyWPF.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        private wndMain mainWindow;
        private clsItemsLogic logic;
        private clsErrorHandling errorHandler;
        //private clsItemsLogic clsLogic;
        public wndItems(wndMain mainWindow)
        {
            errorHandler = new clsErrorHandling();
            try
            {
                //clsItemsLogic = new clsItemsLogic();
                InitializeComponent();
                this.mainWindow = mainWindow; //Main window is passed in as a parameter
                logic = new clsItemsLogic();
                dgItems.ItemsSource = logic.getItemDescs();
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
        /// Handles item desc submit action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItems.SelectedItem = null;
                if (tbCode.Text != "")
                {
                    if(decimal.TryParse(tbCost.Text, out decimal cost) == false)
                    {
                        //Show a message box if the cost value is invalid
                        if (cost < 0)
                        {
                            MessageBox.Show("Cost must be a positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            //Tell the user the input is not a number
                            MessageBox.Show("Cost must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                    }

                    logic.submitLineItem(tbCode.Text, tbDescription.Text, tbCost.Text);
                    dgItems.ItemsSource = logic.getItemDescs();
                    this.mainWindow.reset();

                    // Clear the other textboxes
                    tbDescription.Text = "";
                    tbCost.Text = "";
                    tbCode.Text = "";

                    //Enable code textbox
                    tbCode.IsEnabled = true;
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
        /// Handles item desc delete action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItems.SelectedItem = null;
                if (tbCode.Text != "")
                {
                    logic.deleteLineItem(tbCode.Text);
                    dgItems.ItemsSource = logic.getItemDescs();

                    // Clear the other textboxes
                    tbDescription.Text = "";
                    tbCost.Text = "";
                    tbCode.Text = "";

                    //Enable code textbox
                    tbCode.IsEnabled = true;
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
        /// Handles item desc read action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItems.SelectedItem = null;
                //Clear the other textboxes
                tbCode.Text = "";
                tbCode.IsEnabled = true;
                tbCost.Text = "";
                tbDescription.Text = "";
             
                
                //if (tbCode.Text != "")
                //{
                //    tbCost.Text = "";
                //    tbDescription.Text = "";
                //    string code = tbCode.Text;
                //    modItemDesc info = clsItemsLogic.getInfoForSpecificLineItem(code);
                //    tbCost.Text = info.getCost();
                //    if (tbCost.Text == "-1")
                //    {
                //        tbCost.Text = "";
                //    }
                //    tbDescription.Text = info.ItemDesc;
                //}
            }
            catch (Exception ex)
            {
                errorHandler.sClass = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                errorHandler.sMethod = MethodInfo.GetCurrentMethod().Name;
                errorHandler.sMessage = ex.Message;
                errorHandler.displayErrorMessage();
            }
        }

        private void dgItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Set the textboxes to the selected item
            try
            {
                if (dgItems.SelectedItem != null)
                {
                    modItemDesc selected = (modItemDesc)dgItems.SelectedItem;
                    tbCode.Text = selected.ItemCode;
                    tbDescription.Text = selected.ItemDesc;
                    tbCost.Text = selected.ItemCost.ToString();

                    //Disable Code textbox
                    tbCode.IsEnabled = false;

                    
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

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string code = tbCode.Text;
                modItemDesc info = clsItemsLogic.getInfoForSpecificLineItem(code);
                if (info != null)
                {
                    //Tell user it is already taken
                    labelCode.Content = "Code already exists now overwriting";
                    labelCode.Foreground = Brushes.Red;

                    //Fill the textboxed with the existing info
                    tbDescription.Text = info.ItemDesc;
                    tbCost.Text = info.ItemCost.ToString();
                }
                else
                {
                    //Reset the textbox border color to the default gray
                    labelCode.Content = "Code";
                    labelCode.Foreground = Brushes.Black;

                    //clear the other textboxes
                    tbDescription.Text = "";
                    tbCost.Text = "";

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
    }
}
