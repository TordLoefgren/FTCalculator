using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
