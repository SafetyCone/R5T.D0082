using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0082.D002;


namespace R5T.D0082.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> implementation of <see cref="IGitHubOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services.AddSingleton<IGitHubOperator, GitHubOperator>()
                .Run(gitHubClientProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> implementation of <see cref="IGitHubOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubOperator> AddGitHubOperatorAction(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            var serviceAction = ServiceAction.New<IGitHubOperator>(() => services.AddGitHubOperator(
                gitHubClientProviderAction));

            return serviceAction;
        }
    }
}