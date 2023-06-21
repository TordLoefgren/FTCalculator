using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace FTCalculator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            // Required services created here.

            Window window = new MainWindow();
            window.Show();
            
            base.OnStartup(e); 
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IOperationService, OperationService>();
            // Required services added here

            return services.BuildServiceProvider();
        }
    }
}
