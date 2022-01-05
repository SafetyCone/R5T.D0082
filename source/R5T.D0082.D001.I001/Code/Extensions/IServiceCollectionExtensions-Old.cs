using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;


namespace R5T.D0082.D001.I001
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubAuthenticationProvider"/> implementation of <see cref="IGitHubAuthenticationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubAuthenticationProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services.AddSingleton<IGitHubAuthenticationProvider, GitHubAuthenticationProvider>()
                .Run(secretsDirectoryFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubAuthenticationProvider"/> implementation of <see cref="IGitHubAuthenticationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubAuthenticationProvider> AddGitHubAuthenticationProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<IGitHubAuthenticationProvider>(() => services.AddGitHubAuthenticationProvider(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}