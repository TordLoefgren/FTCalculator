using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FTCalculator.Commands
{
    /// <summary>
    /// Represents a command relay delegation class. 
    /// </summary>
    /// <remarks>
    /// <para>Inspiration from: https://www.c-sharpcorner.com/UploadFile/20c06b/icommand-and-relaycommand-in-wpf/</para>
    /// Implements the ICommand interface.
    /// </remarks>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object>? _canExecute;

        /// <summary>
        /// Initializes a new RelayCommand instance.
        /// </summary>
        /// <param name="execute">The command action to be executed.</param>
        /// <param name="canExecute">The predicate that determines if the command action can be executed.</param>
        /// <exception cref="ArgumentNullException">The command action cannot be null.</exception>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            ArgumentNullException.ThrowIfNull(execute);

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new RelayCommand instance.
        /// </summary>
        /// <param name="execute">The command action to be executed.</param>
        /// <exception cref="ArgumentNullException">The command action cannot be null.</exception>
        public RelayCommand(Action<object> execute)
        {
            ArgumentNullException.ThrowIfNull(execute);

            _execute = execute;
            _canExecute = null;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute is null)
            {
                return true;
            }
            else
            {
                return _canExecute(parameter);
            }
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                _execute.Invoke(parameter);
            }
        }
    }
}
