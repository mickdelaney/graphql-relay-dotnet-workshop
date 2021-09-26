using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Workshop.Core.Framework.IO;

namespace Workshop.Core.Framework.Settings
{
    public static class SharedSettingsConfig
    {
        public static IConfigurationBuilder AddSharedSettings(this IConfigurationBuilder builder, HostBuilderContext context)
        {
            ConfigureAppConfiguration(builder, context.HostingEnvironment);
            return builder;
        }
        
        static IConfigurationBuilder ConfigureAppConfiguration(IConfigurationBuilder builder, IHostEnvironment hostingEnvironment)
        {
            var srcFolder = PathUtils.MoveUp(hostingEnvironment.ContentRootPath, 4);
            var sharedFolder = Path.Combine(srcFolder, "Shared");
            
            //check both current and parent folder so works in local and dev etc
            builder
                .AddJsonFile(Path.Combine(sharedFolder, "sharedsettings.json"), optional: true)
                .AddJsonFile("sharedsettings.json", optional: true)
                .AddJsonFile(Path.Combine(sharedFolder, $"sharedsettings.{hostingEnvironment.EnvironmentName}.json"), optional: true)
                .AddJsonFile($"sharedsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            return builder;
        }
    }
    
    
}