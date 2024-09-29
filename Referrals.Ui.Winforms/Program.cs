using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Referrals.Library.Configuration;
using Referrals.Library.Repositories;
using Referrals.Library.Services;
using System.Data.Common;

namespace Referrals.Ui.Winforms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var host = Host.CreateApplicationBuilder();
            ConfigureServices(host.Services);
            var serviceProvider = host.Services.BuildServiceProvider();

            
            host.Build();

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<Dashboard>());
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Data Source=referrals.db";
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(provider => new DbConnectionFactory(connectionString));
            services.AddSingleton<IReferralsRepository, ReferralsRepository>();
            services.AddSingleton<IReferralsService, ReferralsService>();
            services.AddSingleton<INotesRepository, NotesRepository>();
            services.AddSingleton<Dashboard>();
        }
    }
}