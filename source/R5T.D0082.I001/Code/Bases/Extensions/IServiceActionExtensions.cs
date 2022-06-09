using System;

using R5T.T0062;
using R5T.T0063;

using R5T.D0082.D002;


namespace R5T.D0082.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubOperator"/> implementation of <see cref="IGitHubOperator"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubOperator> AddGitHubOperatorAction(this IServiceAction _,
            IServiceAction<IGitHubClientProvider> gitHubClientProviderAction)
        {
            var serviceAction = _.New<IGitHubOperator>(services => services.AddGitHubOperator(
                gitHubClientProviderAction));

            return serviceAction;
        }
    }
}
