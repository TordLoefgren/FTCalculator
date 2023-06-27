using FTCalculator.Commands;
using FTCalculator.Enums;
using FTCalculator.Services;
using System;
using System.Windows.Input;

namespace FTCalculator.ViewModels
{
    /// <summary>
    /// Represents a Calculator ViewModel.
    /// </summary>
    public class CalculatorViewModel : ViewModelBase, ICalculatorViewModel
    {
        private string _activeOperand = "0";

        /// <summary>
        /// Gets the active operand.
        /// </summary>
        /// <returns>The active operand.</returns>
        public string ActiveOperand
        {
            get => _activeOperand;
            private set => SetField(ref _activeOperand, value);
        }

        private string _previousOperand = "";

        /// <summary>
        /// Gets the previous operand.
        /// </summary>
        /// <returns>The previous operand.</returns>
        public string PreviousOperand
        {
            get => _previousOperand;
            private set => SetField(ref _previousOperand, value);
        }

        private string _activeOperations = "";

        /// <summary>
        /// Gets the active operations.
        /// </summary>
        /// <returns>The active operations.</returns>
        public string ActiveOperations
        {
            get => _activeOperations;
            private set => SetField(ref _activeOperations, value);
        }

        private Operator? _activeOperator = null;
        
        /// <summary>
        /// Gets the active operator value.
        /// </summary>
        /// <returns>The active operator value.</returns>
        public Operator? ActiveOperator
        {
            get => _activeOperator;
            private set => SetField(ref _activeOperator, value);
        }

        private readonly IGenericOperationService _genericOperationService;
        private readonly IOperatorConversionService _operatorConversionService;

        public ICommand ComputeCommand { get; private set; } 
        public ICommand ComputeFactorialCommand { get; private set; }
        public ICommand SetOperatorCommand { get; private set; }
        public ICommand SetNumberCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        /// <summary>
        /// Initializes a new CalculatorViewModel instance.
        /// </summary>
        /// <param name="genericOperationService">A service that provides basic calculator operations.</param>
        /// <param name="operatorConversionService">A service that provides Operator-String conversions.</param>
        public CalculatorViewModel(IGenericOperationService genericOperationService, IOperatorConversionService operatorConversionService) 
        {
            _genericOperationService = genericOperationService;
            _operatorConversionService = operatorConversionService;

            ComputeCommand = new RelayCommand(_ => Compute());
            ComputeFactorialCommand = new RelayCommand(_ => ComputeFactorial());
            SetOperatorCommand = new RelayCommand(op => SetOperator(operatorConversionService.StringToOperator(op.ToString())));
            SetNumberCommand = new RelayCommand(number => SetNumber(number.ToString()));
            ClearCommand = new RelayCommand(_ => Clear());
        }

        /// <summary>
        /// Calculates the result of applying the current operator method to the active operands.
        /// </summary>
        /// <remarks>If the current operator is null, the method will do nothing.</remarks>
        public void Compute()
        {
            Operator? currentOperator = ActiveOperator;

            if (currentOperator is not null) 
            {
                double valueOne = double.Parse(PreviousOperand);
                double valueTwo = double.Parse(ActiveOperand);

                double result = _genericOperationService.ComputeByOperator(currentOperator, valueOne, valueTwo);

                ActiveOperand = result.ToString();
            }
        }

        /// <summary>
        /// Computes the factorial of the current operand.
        /// </summary>
        /// <remarks>This method can only calculate integer factorials.</remarks>
        public void ComputeFactorial()
        {
            // Not yet implemented. WIP.
        }

        /// <summary>
        /// Sets the current operator to the operator pressed on the CalculatorView.
        /// </summary>
        /// <param name="op">The new active operator.</param>
        public void SetOperator(Operator op)
        {
            ActiveOperator = op;
            if (ActiveOperator is not null)
            {
                ActiveOperations = ActiveOperand + _operatorConversionService.OperatorToSymbolString(ActiveOperator);
                PreviousOperand = ActiveOperand;
                ActiveOperand = "0";
            }
        }

        /// <summary>
        /// Sets the current number to include the number pressed on the CalculatorView.
        /// </summary>
        /// <param name="number">The number to included.</param>
        /// <remarks>If the current number is zero, the given number will replace it.</remarks>
        public void SetNumber(string number)
        {
            if (ActiveOperand == "0" || ActiveOperand == "")
            {
                ActiveOperand = number;
            }
            else
            {
                ActiveOperand += number;
            }
        }

        /// <summary>
        /// Clears the active operations field, by resetting the current calculator history.
        /// </summary>
        public void Clear()
        {
            ActiveOperand = "0";
            PreviousOperand = "";
            ActiveOperations = "";
            ActiveOperator = null;
        }
    }
}
