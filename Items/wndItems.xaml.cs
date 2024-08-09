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
                if (tbCode.Text != "")
                {
                    logic.submitLineItem(tbCode.Text, tbDescription.Text, tbCost.Text);
                    dgItems.ItemsSource = logic.getItemDescs();
                    this.mainWindow.reset();
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
                if (tbCode.Text != "")
                {
                    logic.deleteLineItem(tbCode.Text);
                    dgItems.ItemsSource = logic.getItemDescs();
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
                if (tbCode.Text != "")
                {
                    tbCost.Text = "";
                    tbDescription.Text = "";
                    string code = tbCode.Text;
                    modItemDesc info = clsItemsLogic.getInfoForSpecificLineItem(code);
                    tbCost.Text = info.getCost();
                    if (tbCost.Text == "-1")
                    {
                        tbCost.Text = "";
                    }
                    tbDescription.Text = info.ItemDesc;
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
