using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Workshop.Core.Validation;

namespace Workshop.Core.Framework.Settings
{
    public static class SettingsInstallerExtensions
    {
        /// <summary>
        /// Configures settings using a lambda
        /// Allows you to inject an instance of <typeparamref name="TClass"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TOptions}"/>
        /// </summary>
        public static IServiceCollection AddSettings<TClass>(
            this IServiceCollection services,
            Action<TClass> configureAction)
            where TClass : class, new()
        {
            services.Configure(configureAction);
            return AddAdditionalRegistrations<TClass, TClass>(services);
        }
        
        /// <summary>
        /// Configures settings using a lambda
        /// Allows you to inject an instance of <typeparamref name="TClass"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TClass}"/>
        /// </summary>
        public static IServiceCollection AddNamedSettings<TClass>(
            this IServiceCollection services,
            string name,
            Action<TClass> configureAction)
            where TClass : class, new()
        {
            services.Configure(name, configureAction);
            return AddAdditionalRegistrations<TClass, TClass>(services);
        }
        
        /// <summary>
        /// Infers the name of the settings section to bind to a <typeparamref name="TClass"/> object, 
        /// and configures it as a singleton with the DI container. 
        /// Allows you to inject an instance of <typeparamref name="TClass"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TClass}"/>
        /// The section name is "Elevate:CLASS" where CLASS is <typeparamref name="TClass" /> with any "Settings" suffix removed
        /// </summary>
        public static IServiceCollection AddSettings<TClass>(
            this IServiceCollection services,
            IConfiguration config)
            where TClass : class, new()
        {
            return services.AddSettings<TClass, TClass>(config);
        }
        /// <summary>
        /// Binds the configuration section in <paramref name="sectionName"/> to a <typeparamref name="TClass"/> object, 
        /// and configures it as a singleton with the DI container. 
        /// Allows you to inject an instance of <typeparamref name="TClass"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TClass}"/>
        /// </summary>
        public static IServiceCollection AddSettings<TClass>(
            this IServiceCollection services,
            IConfiguration config,
            string sectionName)
            where TClass : class, new()
        {
            return services.AddSettings<TClass, TClass>(config, sectionName);
        }

        /// <summary>
        /// Infers the name of the settings section to bind to a <typeparamref name="TClass"/> object, 
        /// and configures it as a <typeparamref name="TInterface"/> singleton with the DI container
        /// Allows you to inject an instance of <typeparamref name="TInterface"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TInterface}"/>
        /// The section name is "Elevate:CLASS" where CLASS is <typeparamref name="TClass" /> with any "Settings" suffix removed
        /// </summary>
        public static IServiceCollection AddSettings<TInterface, TClass>(
            this IServiceCollection services,
            IConfiguration config)
            where TClass : class, TInterface, new() where TInterface : class
        {
            const string settings = "Settings";
            var sectionName = $"Elevate:{typeof(TClass).Name}";
            if (sectionName.EndsWith(settings))
            {
                sectionName = sectionName.Substring(0, sectionName.Length - settings.Length);
            }

            return services.AddSettings<TInterface, TClass>(config, sectionName);
        }

        /// <summary>
        /// Binds the configuration section in <paramref name="sectionName"/> to a <typeparamref name="TClass"/> object, 
        /// and configures it as a <typeparamref name="TInterface"/> singleton with the DI container
        /// Allows you to inject an instance of <typeparamref name="TInterface"/> directly into your services, instead of having
        /// to inject <see cref="IOptions{TInterface}"/>
        /// </summary>
        public static IServiceCollection AddSettings<TInterface, TClass>(
            this IServiceCollection services,
            IConfiguration config,
            string sectionName)
            where TClass : class, TInterface, new()
            where TInterface : class
        {
            services.Configure<TClass>(config.GetSection(sectionName));
            return AddAdditionalRegistrations<TInterface, TClass>(services);
        }

        public static IServiceCollection AddSettingsConfiguration<TConfigure, TClass>(this IServiceCollection services)
            where TConfigure : class, IConfigureOptions<TClass>
            where TClass : class, new()
        {
            return services.AddSettingsConfiguration<TConfigure, TClass, TClass>();
        }

        public static IServiceCollection AddSettingsConfiguration<TConfigure, TInterface, TClass>(this IServiceCollection services)
            where TConfigure : class, IConfigureOptions<TClass>
            where TClass : class, TInterface, new()
            where TInterface : class
        {
            services.AddSingleton<IConfigureOptions<TClass>, TConfigure>();
            return AddAdditionalRegistrations<TInterface, TClass>(services);
        }

        static IServiceCollection AddAdditionalRegistrations<TInterface, TClass>(IServiceCollection services)
            where TClass : class, TInterface, new()
            where TInterface : class
        {
            services.AddSingleton<TClass>(cfg => cfg.GetService<IOptions<TClass>>().Value);

            var concreteType = typeof(TClass);
            var interfaceType = typeof(TInterface);
            if (concreteType != interfaceType)
            {
                services.AddSingleton<TInterface>(cfg => cfg.GetService<TClass>());
            }

            // To enable auto-validation of settings
            if (typeof(IValidatable).IsAssignableFrom(concreteType))
            {
                // we know the type can be cast at this point
                services.AddSingleton(cfg => (IValidatable)cfg.GetService<TClass>());
            }

            return services;
        }
    }
}