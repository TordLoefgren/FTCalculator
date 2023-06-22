using System;
using System.Windows;
using System.Windows.Controls;

using FTCalculator.Enums;
using FTCalculator.Services;

namespace FTCalculator
{
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
            private set 
            { 
                _activeOperator = value; 
            }
        }

        public MainWindow(IOperationService operationService)
        {
            _operationService = operationService;
            InitializeComponent();
        }

        public void NumberButton_Click(object sender, RoutedEventArgs e)
        {
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
            double number;
            
            bool result = double.TryParse(PreviousOperand, out number);

            if (result)
            {
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
