using System;
using System.Linq;
using System.Threading.Tasks;

using Octokit;

using R5T.Dacia;

using R5T.D0082.D002;
using R5T.D0082.T000;


namespace R5T.D0082.I001
{
    [ServiceImplementationMarker]
    public class GitHubOperator : IGitHubOperator
    {
        private IGitHubClientProvider GitHubClientProvider { get; }


        public GitHubOperator(
            IGitHubClientProvider gitHubClientProvider)
        {
            this.GitHubClientProvider = gitHubClientProvider;
        }

        public async Task<bool> RepositoryExists(string owner, string name)
        {
            var output = await this.GitHubClientProvider.InClientContext(async gitHubClient =>
            {
                var searchRequest = new SearchRepositoriesRequest(name)
                {
                    User = owner,
                };

                var searchResult = await gitHubClient.Search.SearchRepo(searchRequest);

                var exists = searchResult.Items
                    .Where(x => x.Name == name)
                    .Any();

                return exists;
            });

            return output;
        }

        public async Task<long> CreateRepositoryNonIdempotent(GitHubRepositorySpecification gitHubRepositorySpecification)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            var autoInit = gitHubRepositorySpecification.InitializeWithReadMe;

            var licenseTemplate = gitHubRepositorySpecification.License.GetLicenseIdentifier();

            var @private = gitHubRepositorySpecification.Visibility.IsPrivate();

            var newRepository = new NewRepository(gitHubRepositorySpecification.Name)
            {
                AutoInit = autoInit,
                Description = gitHubRepositorySpecification.Description,
                LicenseTemplate = licenseTemplate,
                Private = @private, // Default is public (private = false).
            };

            var createdRepository = await gitHubClient.Repository.Create(
                gitHubRepositorySpecification.Organization,
                newRepository);

            // Wait a few seconds to allow any following operations that request the repository to succeed.
            await Task.Delay(5000);

            return createdRepository.Id;
        }

        public async Task DeleteRepositoryNonIdempotent(string owner, string name)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            await gitHubClient.Repository.Delete(owner, name);
        }

        public async Task<string> GetRepositoryCloneUrl(string owner, string name)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            var repository = await gitHubClient.Repository.Get(owner, name);

            var checkoutURL = repository.CloneUrl;
            return checkoutURL;
        }

        public async Task<long> GetRepositoryID(string owner, string name)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            var repository = await gitHubClient.Repository.Get(owner, name);

            var repositoryID = repository.Id;
            return repositoryID;
        }
    }
}