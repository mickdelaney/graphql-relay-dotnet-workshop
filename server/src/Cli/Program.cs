using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oakton;

namespace Cli
{
    public class Program
    {
        static IHost _host;
        static IServiceProvider _services;
        
        public static async Task<int> Main(string[] args)
        {
            _host = CreateHostBuilder(args).Build();
            _services = _host.Services;
            
            using var scope = _services.CreateScope();
            
            var executor = CommandExecutor.For(_ =>
            {
                // Find and apply all command classes discovered
                // in this assembly
                _.RegisterCommands(typeof(Program).GetTypeInfo().Assembly);
            });

            return await executor.ExecuteAsync(args);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        internal static T Resolve<T>()
        {
            return _services.GetRequiredService<T>();
        } 
        
    }
}