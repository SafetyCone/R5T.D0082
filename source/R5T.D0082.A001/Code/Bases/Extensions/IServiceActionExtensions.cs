using System;

using R5T.Suebia;

using R5T.T0062;
using R5T.T0063;

using R5T.D0082.D001.I001;
using R5T.D0082.D002.I001;
using R5T.D0082.D003.I001;
using R5T.D0082.I001;


namespace R5T.D0082.A001
{
    public static class IServiceActionExtensions
    {
        public static IServiceActionAggregation AddGitHubOperatorServiceActions(this IServiceAction services,
               IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            // Level 0.
            var gitHubProductHeaderValueProvider = services.AddHardCodedProductHeaderValueProviderAction();

            // Level 1.
            var gitHubAuthenticationProviderAction = services.AddGitHubAuthenticationProviderAction(
                secretsDirectoryFilePathProviderAction);

            // Level 2.
            var gitHubClientProvider = services.AddGitHubClientProviderAction(
                gitHubAuthenticationProviderAction,
                gitHubProductHeaderValueProvider);

            // Level 3.
            var gitHubOperator = services.AddGitHubOperatorAction(
                gitHubClientProvider);

            var output = new ServiceActionAggregation
            {
                GitHubAuthenticationProviderAction = gitHubAuthenticationProviderAction,
                GitHubClientProviderAction = gitHubClientProvider,
                GitHubOperatorAction = gitHubOperator,
                ProductHeaderValueProviderAction = gitHubProductHeaderValueProvider,
            };

            return output;
        }
    }
}
