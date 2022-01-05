using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0082.D001;
using R5T.D0082.D003;


namespace R5T.D0082.D002.I001
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubClientProvider"/> implementation of <see cref="IGitHubClientProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubClientProvider(this IServiceCollection services,
            IServiceAction<IGitHubAuthenticationProvider> gitHubAuthenticationProviderAction,
            IServiceAction<IProductHeaderValueProvider> productHeaderValueProviderAction)
        {
            services.AddSingleton<IGitHubClientProvider, GitHubClientProvider>()
                .Run(gitHubAuthenticationProviderAction)
                .Run(productHeaderValueProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubClientProvider"/> implementation of <see cref="IGitHubClientProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubClientProvider> AddGitHubClientProviderAction(this IServiceCollection services,
            IServiceAction<IGitHubAuthenticationProvider> gitHubAuthenticationProviderAction,
            IServiceAction<IProductHeaderValueProvider> productHeaderValueProviderAction)
        {
            var serviceAction = ServiceAction.New<IGitHubClientProvider>(() => services.AddGitHubClientProvider(
                gitHubAuthenticationProviderAction,
                productHeaderValueProviderAction));

            return serviceAction;
        }
    }
}