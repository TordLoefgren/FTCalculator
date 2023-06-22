using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FTCalculator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FTCalculator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            // Required services created here.

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            
            base.OnStartup(e); 
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Required services added here
            services.AddSingleton<IOperationService, OperationService>();
            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}
