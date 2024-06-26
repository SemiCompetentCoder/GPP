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
        public wndMain()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndSearch wndSearch = new wndSearch();
            wndSearch.ShowDialog();
        }

        private void mnSearchforItems_Click(object sender, RoutedEventArgs e)
        {
            wndItems wndItems = new wndItems();
            wndItems.ShowDialog();
        }
    }
}
