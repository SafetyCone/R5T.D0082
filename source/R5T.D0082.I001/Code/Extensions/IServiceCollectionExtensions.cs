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
            services
                .Run(gitHubClientProviderAction)
                .AddSingleton<IGitHubOperator, GitHubOperator>()
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> implementation of <see cref="IOctokitBasedGitHubOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator_OctokitBased(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services
                .Run(gitHubClientProviderAction)
                .AddSingleton<IOctokitBasedGitHubOperator, GitHubOperator>()
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> class directly as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator_Direct(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services
                .Run(gitHubClientProviderAction)
                .AddSingleton<GitHubOperator>()
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> class directly, and the <see cref="IGitHubOperator"/> interface, as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator_DirectAndInterface(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services
                .AddGitHubOperator_Direct(
                    gitHubClientProviderAction)
                .AddSingleton<IGitHubOperator>(sp => sp.GetRequiredService<GitHubOperator>())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> class directly, and the <see cref="IOctokitBasedGitHubOperator"/> interface, as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator_DirectAndOctokitBased(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services
                .AddGitHubOperator_Direct(
                    gitHubClientProviderAction)
                .AddSingleton<IOctokitBasedGitHubOperator>(sp => sp.GetRequiredService<GitHubOperator>());
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> implementation of <see cref="IGitHubOperator"/> and <see cref="IOctokitBasedGitHubOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitHubOperator_DirectAndInterfaceAndOctokitBased(this IServiceCollection services,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            services
                .AddGitHubOperator_DirectAndInterface(
                    gitHubClientProviderAction)
                .AddSingleton<IOctokitBasedGitHubOperator>(sp => sp.GetRequiredService<GitHubOperator>());
            ;

            return services;
        }
    }
}