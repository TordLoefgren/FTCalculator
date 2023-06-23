using System;
using System.Windows;
using FTCalculator.Services;
using FTCalculator.ViewModels;
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

            /* Window window = new MainWindow();

             // Required services created here.
             window.DataContext = serviceProvider.GetRequiredService<ViewModelBase>();

             window.Show();*/

            MainWindow = new MainWindow
            {
                //DataContext = serviceProvider.GetRequiredService<ViewModelBase>()
                DataContext = new CentralViewModel()
            };
            MainWindow.Show();
            
            base.OnStartup(e); 
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Required services added here
            services.AddSingleton<IOperationService, OperationService>();
            services.AddSingleton<ViewModelBase, CentralViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
