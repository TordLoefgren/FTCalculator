using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FTCalculator.Commands
{
    /// <summary>
    /// Represents a generic command relay delegation class. 
    /// </summary>
    /// <remarks>
    /// <para>Inspiration from: https://www.c-sharpcorner.com/UploadFile/20c06b/icommand-and-relaycommand-in-wpf/</para>
    /// Implements the ICommand interface.
    /// </remarks>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T>? _canExecute;

        /// <summary>
        /// Initializes a new generic RelayCommand instance.
        /// </summary>
        /// <param name="execute">The command action to be executed.</param>
        /// <param name="canExecute">The predicate that determines if the command action can be executed.</param>
        /// <exception cref="ArgumentNullException">The command action cannot be null.</exception>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            ArgumentNullException.ThrowIfNull(execute);

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new generic RelayCommand instance.
        /// </summary>
        /// <param name="execute">The command action to be executed.</param>
        /// <exception cref="ArgumentNullException">The command action cannot be null.</exception>
        public RelayCommand(Action<T> execute)
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
            return _canExecute is null ? true : _canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke((T)parameter);
        }
    }
}
