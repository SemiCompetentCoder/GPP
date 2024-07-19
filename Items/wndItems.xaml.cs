using System;
using System.Collections.Generic;
using System.Linq;
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
        //private clsItemsLogic clsLogic;
        public wndItems(wndMain mainWindow)
        {
            //clsItemsLogic = new clsItemsLogic();
            InitializeComponent();
            this.mainWindow = mainWindow; //Main window is passed in as a parameter
        }

        public void getModifiedLineItems() 
        { 
            // method to be called by the window that created this window
            // will simply serve as a wrapper for a method which will be implemented in the business logic class
        }

        private void bSubmit_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        //When this.Close is called tell the main window to refresh.
        //Method Definition HERE
        //{
        //    mainWindow.refreshFields();
        //    this.Close();
        //}
    }
}
