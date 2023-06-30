using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.ViewModels
{
    /// <summary>
    /// Represents the ViewModel base class.
    /// </summary>
    /// <remarks>This class implements the INotifyPropertyChanged interface.</remarks>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// When called, this method will raise the PropertyChanged event within the current class. 
        /// </summary>
        /// <param name="propertyName">The name of the Property that has changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Performs a simple check on whether the value of the given field already
        /// equals the given value, and if not, it will update the field.
        /// </summary>
        /// <typeparam name="T">Type of the field to be updated.</typeparam>
        /// <param name="field">Field to be updated.</param>
        /// <param name="value">New value.</param>
        /// <param name="propertyName">Name of the matching property that changed (defaults to the name of the caller)</param>
        /// <returns>Boolean indicating whether the field was updated.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }
    }
}
