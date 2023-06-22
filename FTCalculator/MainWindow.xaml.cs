using FTCalculator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FTCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IOperationService _operationService;

        private string _activeOperand;
        public string ActiveOperand
        {
            get { return _activeOperand; }
            private set 
            { 
                _activeOperand = value;
                CalculationResultField.Text = value.ToString();
            }
        }

        private string _previousOperand;
        public string PreviousOperand
        {
            get { return _previousOperand; }
            private set
            {
                _previousOperand = value;
                CalculationResultField.Text = value.ToString();
            }
        }

        private string _activeOperations;
        public string ActiveOperations
        {
            get { return _activeOperations; }
            private set
            {
                _activeOperations = value;
                CurrentOperationsField.Text = value;
            }
        }

        private Operator _activeOperator;
        public Operator ActiveOperator
        {
            get { return _activeOperator; }
            private set { 
                _activeOperator = value; 
                // Add method to convert enum and set field
            }
        }

        public MainWindow(IOperationService operationService)
        {
            _operationService = operationService;
            InitializeComponent();
        }

        public void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Adds value to the current string value
            Button button = (Button)sender;

            ActiveOperand =  ActiveOperand + button.Tag.ToString();
        }

        public void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Operator enumOperator;

            bool result = Enum.TryParse(button.Tag.ToString(), out enumOperator);

            if (result)
            {
                ActiveOperator = enumOperator;
                string operatorSymbol;

                switch (enumOperator)
                {
                    case Operator.NoOperator: operatorSymbol = ""; break;
                    case Operator.Add: operatorSymbol = " + "; break;
                    case Operator.Subtract: operatorSymbol = " - "; break;
                    case Operator.Multiply: operatorSymbol = " * "; break;
                    case Operator.Divide: operatorSymbol = " / "; break;
                    case Operator.Factorial: operatorSymbol = $"fact({ActiveOperand})"; break;
                    default: throw new ArgumentException("Invalid argument.");
                }
                CurrentOperationsField.Text = operatorSymbol;
            }
        }

        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Calculate current operation
            float number;
            
            bool result = float.TryParse(PreviousOperand, out number);

            if (result)
            {
                // Test
                CalculationResultField.Text = number.ToString();
            }
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            ActiveOperand = "";
            PreviousOperand = "";
            ActiveOperations = "";
            ActiveOperator = Operator.NoOperator;
        }
    }
}
