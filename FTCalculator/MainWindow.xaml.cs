using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float _storedNumber;
        public float StoredNumber
        {
            get { return _storedNumber; }
            set { _storedNumber = value; }
        }

        public MainWindow()
        {
            IServiceContainer container = new ServiceContainer();

            InitializeComponent();
        }


        /*public AddOperation_Click(object sender, RoutedEventArgs e)
        {

        }

        public Calculate_Click(object sender, RoutedEventArgs e)
        {
            
        }
        */
    }
}
