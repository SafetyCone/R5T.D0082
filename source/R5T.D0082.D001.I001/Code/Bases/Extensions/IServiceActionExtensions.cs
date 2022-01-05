using System;

using R5T.Suebia;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0082.D001.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubAuthenticationProvider"/> implementation of <see cref="IGitHubAuthenticationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitHubAuthenticationProvider> AddGitHubAuthenticationProviderAction(this IServiceAction _,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = _.New<IGitHubAuthenticationProvider>(services => services.AddGitHubAuthenticationProvider(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}
