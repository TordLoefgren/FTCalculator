using FTCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTCalculator.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        public static readonly DependencyProperty CalculatorProperty = DependencyProperty.Register(nameof(Calculator), typeof(CalculatorViewModel), typeof(CalculatorView));

        public CalculatorViewModel Calculator
        {
            get => (CalculatorViewModel)GetValue(CalculatorProperty);
            set => SetValue(CalculatorProperty, value);
        }

        public CalculatorView()
        {
            InitializeComponent();
        }
    }
}
