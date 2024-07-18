using DummyWPF.Items;
using DummyWPF.Search;
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



        public wndMain()
        {
            InitializeComponent();
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
            //Implement the logic to refresh the fields
            
        }

        
    }
}
