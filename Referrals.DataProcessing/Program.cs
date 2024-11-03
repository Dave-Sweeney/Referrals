using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Referrals.DataProcessing.Configuration;
using Referrals.DataProcessing.Repositories;
using System.Data;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration(builder =>
    {
        
    })
    .ConfigureServices((context, services) =>
    {
        //SqlConnectionOptions options = new();
        //context.Configuration.GetSection(nameof(SqlConnectionOptions))
        //    .Bind(options);
        services.Configure<SqlConnectionOptions>(context.Configuration.GetSection(nameof(SqlConnectionOptions)));
       
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IFileReader, FileReader>();
        services.AddScoped<IReferralsRepository, ReferralsRepository>();
    })
    .Build();


host.Run();
