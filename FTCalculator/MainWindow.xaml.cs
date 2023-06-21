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
        private readonly IOperationService _operationService;

        private float _storedNumber;
        public float StoredNumber
        {
            get { return _storedNumber; }
            set { _storedNumber = value; }
        }

        private Operator _currentOperator;
        public Operator CurrentOperator
        {
            get { return _currentOperator; }
            set { _currentOperator = value; }
        }

        public MainWindow(IOperationService operationService)
        {
            _operationService = operationService;
            InitializeComponent();
        }

        public void AddOperation_Click(object sender, RoutedEventArgs e)
        {
            // Activates if operator is enum Add
        }

        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Calculate current operation
        }
    }
}
