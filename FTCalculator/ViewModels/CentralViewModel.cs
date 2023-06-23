using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.ViewModels
{
    /// <summary>
    /// Represents a ViewModel that keeps track of other viewmodels.
    /// </summary>
    public class CentralViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the current active ViewModel instance.
        /// </summary>
        /// <returns>The current active ViewModel instance.</returns>
        public ViewModelBase CurrentViewModel { get; }

        /// <summary>
        /// Initializes a new CentralViewModel instance.
        /// </summary>
        public CentralViewModel()
        {
            CurrentViewModel = new CalculatorViewModel();
        }
    }
}
