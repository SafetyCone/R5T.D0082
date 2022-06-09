using System;

using R5T.T0062;
using R5T.T0063;

using R5T.D0082.D001;
using R5T.D0082.D003;


namespace R5T.D0082.D002.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubClientProvider"/> implementation of <see cref="IGitHubClientProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubClientProvider> AddGitHubClientProviderAction(this IServiceAction _,
            IServiceAction<IGitHubAuthenticationProvider> gitHubAuthenticationProviderAction,
            IServiceAction<IProductHeaderValueProvider> productHeaderValueProviderAction)
        {
            var serviceAction = _.New<IGitHubClientProvider>(services => services.AddGitHubClientProvider(
                gitHubAuthenticationProviderAction,
                productHeaderValueProviderAction));

            return serviceAction;
        }
    }
}
