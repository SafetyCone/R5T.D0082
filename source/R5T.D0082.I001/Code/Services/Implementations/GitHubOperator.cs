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

        public async Task<long> CreateRepository(GitHubRepositorySpecification gitHubRepositorySpecification)
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

            return createdRepository.Id;
        }

        public async Task DeleteRepository(string owner, string name)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            await gitHubClient.Repository.Delete(owner, name);
        }
    }
}