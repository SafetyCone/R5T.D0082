using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;

using R5T.D0082.D001;
using R5T.D0082.D003;


namespace R5T.D0082.D002.I001
{
    [ServiceImplementationMarker]
    public class GitHubClientProvider : IGitHubClientProvider, IServiceImplementation
    {
        private IGitHubAuthenticationProvider GitHubAuthenticationProvider { get; }
        private IProductHeaderValueProvider ProductHeaderValueProvider { get; }


        public GitHubClientProvider(
            IGitHubAuthenticationProvider gitHubAuthenticationProvider,
            IProductHeaderValueProvider productHeaderValueProvider)
        {
            this.GitHubAuthenticationProvider = gitHubAuthenticationProvider;
            this.ProductHeaderValueProvider = productHeaderValueProvider;
        }

        public async Task<GitHubClient> GetGitHubClient()
        {
            var productHeaderValue = await this.ProductHeaderValueProvider.GetProductHeaderValue();

            var gitHubClient = new GitHubClient(productHeaderValue);

            var gitHubAuthentication = await this.GitHubAuthenticationProvider.GetGitHubAuthentication();

            var basicAuthentication = new Credentials(gitHubAuthentication.Username, gitHubAuthentication.Password);

            gitHubClient.Credentials = basicAuthentication;

            return gitHubClient;
        }
    }
}