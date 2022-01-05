using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;

using R5T.D0082.D002;


namespace R5T.D0082.I001
{
    public static partial class IServiceCollectionExtensions
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
    }
}