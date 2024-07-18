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
        

        public wndItems(wndMain mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow; //Main window is passed in as a parameter
        }


        //When this.Close is called tell the main window to refresh.
        //Method Definition HERE
        //{
        //    mainWindow.refreshFields();
        //    this.Close();
        //}
    }
}
