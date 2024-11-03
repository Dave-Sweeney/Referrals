using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Referrals.Ui.Wpf.Configuration;
using Referrals.Ui.Wpf.Repositories;
using System.Data;
using System.IO;
using System.Windows;

namespace Referrals.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json");
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();
        }
        
        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string not found in configuration");
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(provider => new DbConnectionFactory(connectionString));
            services.AddScoped<IReferralsRepository, ReferralsRepository>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ReferralsViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            await _host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
