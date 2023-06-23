using FTCalculator.Commands;
using FTCalculator.Enums;
using FTCalculator.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FTCalculator.ViewModels
{
    /// <summary>
    /// Represents a Calculator ViewModel.
    /// </summary>
    public class CalculatorViewModel : ViewModelBase
    {
        private string _activeOperand = "0";

        /// <summary>
        /// Gets the active operand.
        /// </summary>
        /// <returns>The active operand.</returns>
        public string ActiveOperand
        {
            get { return _activeOperand; }
            private set
            {
                _activeOperand = value;
                OnPropertyChanged(nameof(ActiveOperand));
            }
        }

        private string _previousOperand = "";

        /// <summary>
        /// Gets the previous operand.
        /// </summary>
        /// <returns>The previous operand.</returns>
        public string PreviousOperand
        {
            get { return _previousOperand; }
            private set
            {
                _previousOperand = value;
                OnPropertyChanged(nameof(PreviousOperand));
            }
        }

        private string _activeOperations = "";

        /// <summary>
        /// Gets the active operations.
        /// </summary>
        /// <returns>The active operations.</returns>
        public string ActiveOperations
        {
            get { return _activeOperations; }
            private set
            {
                _activeOperations = value;
                OnPropertyChanged(nameof(ActiveOperations));
            }
        }

        private Operator _activeOperator = Operator.NoOperator;
        
        /// <summary>
        /// Gets the active operator value.
        /// </summary>
        /// <returns>The active operator value.</returns>
        /// <remarks>When the operator is set, the current operand is stored as part of the active operations.</remarks>
        public Operator ActiveOperator
        {
            get { return _activeOperator; }
            private set
            {
                _activeOperator = value;
                OnPropertyChanged(nameof(ActiveOperator));
                PreviousOperand = ActiveOperand;
                ActiveOperations = PreviousOperand;
                ActiveOperand = "";
            }
        }

        private readonly IOperationService _operationService;
        public ICommand ComputeCommand { get; private set; } 
        public ICommand AddOperatorCommand { get; private set; }
        public ICommand AddNumberCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        /// <summary>
        /// Initializes a new CalculatorViewModel instance.
        /// </summary>
        public CalculatorViewModel() 
        {
            _operationService = new OperationService();
            ComputeCommand = new RelayCommand(_ => Compute());
            AddOperatorCommand = new RelayCommand(op => ActiveOperator = OperatorConverter.StringToOperator((string)op));
            AddNumberCommand = new RelayCommand(AddNumber);
            ClearCommand = new RelayCommand(_ => Clear());
        }

        public void Compute()
        {
            double valueOne = double.Parse(PreviousOperand);
            double valueTwo = double.Parse(ActiveOperand);
            double result = 0;

            switch (ActiveOperator)
            {
                case Operator.NoOperator:
                    break;
                case Operator.Add:
                    result = _operationService.Add(valueOne, valueTwo);
                    break;
                case Operator.Subtract:
                    result = _operationService.Subtract(valueOne, valueTwo);
                    break;
                case Operator.Multiply:
                    result = _operationService.Multiply(valueOne, valueTwo);
                    break;
                case Operator.Divide:
                    result = _operationService.Divide(valueOne, valueTwo);
                    break;
                default:
                    throw new ArgumentException("Invalid argument.");
            }
            ActiveOperand = result.ToString();
        }

        public void AddOperator(object op)
        {
            Operator enumOp = (Operator)op;

            ActiveOperator = enumOp;

        }

        public void AddNumber(object number)
        {
            if (ActiveOperand == "0")
            {
                ActiveOperand = number.ToString();
            }
            else
            {
                ActiveOperand += number.ToString();
            }
        }

        public void Clear()
        {
            ActiveOperand = "0";
            PreviousOperand = "";
            ActiveOperations = "";
            ActiveOperator = Operator.NoOperator;
        }
    }
}
