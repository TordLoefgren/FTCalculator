using System;
using System.Windows;
using FTCalculator.Services;
using FTCalculator.ViewModels;
using FTCalculator.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FTCalculator
{
    /// <summary>
    /// Represents a Windows Presentation Foundation application.
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            MainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<ICalculatorViewModel>(),
            };
            MainWindow.Show();
            
            base.OnStartup(e); 
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Required services added here
            services.AddSingleton<IGenericBinaryOperationService, GenericBinaryOperationService>();
            services.AddSingleton<IGenericUnaryOperationService, GenericUnaryOperationService>();
            services.AddSingleton<IOperatorConversionService, OperatorConversionService>();

            services.AddTransient<ICalculatorViewModel, CalculatorViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
