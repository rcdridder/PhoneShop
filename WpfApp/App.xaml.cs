using Business.Domain.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection()
                .AddSingleton<MainWindow>()
                .AddScoped<IPhoneService, PhoneService>();
            services.AddRepositories();
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
