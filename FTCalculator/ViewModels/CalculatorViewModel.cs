using FTCalculator.Commands;
using FTCalculator.Enums;
using FTCalculator.Services;
using System;
using System.Diagnostics;
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

        private readonly IGenericBinaryOperationService _genericBinaryOperationService;
        private readonly IOperatorConversionService _operatorConversionService;
        private readonly IGenericUnaryOperationService _unaryOperationService;

        public ICommand ComputeCommand { get; private set; } 
        public ICommand ComputeFactorialCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand SetDecimalCommand { get; private set; }
        public ICommand SetOperatorCommand { get; private set; }
        public ICommand SetNumberCommand { get; private set; }

        /// <summary>
        /// Initializes a new CalculatorViewModel instance.
        /// </summary>
        /// <param name="genericOperationService">A service that provides basic calculator operations.</param>
        /// <param name="operatorConversionService">A service that provides Operator-String conversions.</param>
        public CalculatorViewModel(
            IGenericBinaryOperationService genericOperationService, 
            IOperatorConversionService operatorConversionService,
            IGenericUnaryOperationService unaryOperationService) 
        {
            _genericBinaryOperationService = genericOperationService;
            _operatorConversionService = operatorConversionService;
            _unaryOperationService = unaryOperationService;

            ComputeCommand = new RelayCommand(_ => Compute());
            ComputeFactorialCommand = new RelayCommand(_ => ComputeFactorial());
            ClearCommand = new RelayCommand(_ => Clear());
            SetDecimalCommand = new RelayCommand(_ => SetDecimal());
            SetOperatorCommand = new RelayCommand<Operator>(SetOperator);
            SetNumberCommand = new RelayCommand<string>(SetNumber);
        }

        /// <summary>
        /// Calculates the result of applying the current operator method to the active operands.
        /// </summary>
        /// <remarks>If the current operator is null, the method will do nothing.</remarks>
        public void Compute()
        {
            if (ActiveOperator is not null) 
            {
                var valueOne = double.Parse(PreviousOperand);
                var valueTwo = double.Parse(ActiveOperand);

                var result = _genericBinaryOperationService.ComputeByOperator((Operator)ActiveOperator, valueOne, valueTwo);

                ActiveOperator = null;
                ActiveOperations += ActiveOperand;
                ActiveOperand = result.ToString();
                PreviousOperand = "";
            }
        }

        /// <summary>
        /// Computes the factorial of the current operand.
        /// </summary>
        /// <remarks>This method can only calculate integer factorials.</remarks>
        public void ComputeFactorial()
        {
            ActiveOperations = $"fact({ActiveOperand})";
            var result = _unaryOperationService.Factorial(int.Parse(ActiveOperand));
            ActiveOperand = result.ToString();
        }

        /// <summary>
        /// Sets the current operator to the operator pressed on the CalculatorView.
        /// </summary>
        /// <param name="op">The new active operator.</param>
        public void SetOperator(Operator op)
        {
            if (op != ActiveOperator)
            {
                ActiveOperator = op;
                ActiveOperations = ActiveOperand + _operatorConversionService.OperatorToSymbolString((Operator)ActiveOperator);
            }

            if (ActiveOperand != "")
            {
                PreviousOperand = ActiveOperand;
                ActiveOperand = "";
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

        /// <summary>
        /// Sets a decimal point delimiter.
        /// </summary>
        public void SetDecimal()
        {
            var activeOperand = double.Parse(ActiveOperand);

            if (activeOperand % 1 == 0 || !ActiveOperand.Contains('.'))
            {
                ActiveOperand += ".";
            }
        }
    }
}
