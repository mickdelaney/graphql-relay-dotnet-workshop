using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Core.Framework.Settings;
using Workshop.Core.Settings;

namespace Workshop.Core.DB
{
    public static class ConnectionStringInstaller
    {
        public static IServiceCollection AddConnectionStrings
        (
            this IServiceCollection services, 
            IConfiguration config,
            string applicationName
        )
        {
            services.AddSettings<ConnectionStrings>(config, sectionName: nameof(ConnectionStrings));
            services.Configure<ConnectionStrings>(opts =>
            {
                opts.PostgresDatabase = AppendApplicationName(opts.PostgresDatabase, applicationName);
            });
            return services;
        }

        static string AppendApplicationName(string connectionString, string applicationName)
        {
            if (string.IsNullOrEmpty(connectionString) || connectionString.Contains("ApplicationName"))
            {
                return connectionString;
            }
            return connectionString.EndsWith(";")
                ? $"{connectionString}ApplicationName={applicationName};"
                : $"{connectionString};ApplicationName={applicationName};";
        }
    }
}