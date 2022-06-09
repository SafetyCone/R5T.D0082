using System;
using System.Linq;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;

using R5T.D0082.D002;
using R5T.D0082.T000;


namespace R5T.D0082.I001
{
    [ServiceImplementationMarker]
    public class GitHubOperator : IGitHubOperator, IOctokitBasedGitHubOperator, IServiceImplementation
    {
        private IGitHubClientProvider GitHubClientProvider { get; }

        IGitHubOperator IHasGitHubOperator.GitHubOperator => this;


        public GitHubOperator(
            IGitHubClientProvider gitHubClientProvider)
        {
            this.GitHubClientProvider = gitHubClientProvider;
        }

        protected async Task<T> GetFromRepository<T>(
            string owner,
            string name,
            Func<Repository, Task<T>> repositoryFunction)
        {
            var gitHubClient = await this.GetGitHubClient();

            var repository = await this.GetRepository(gitHubClient,
                owner, name);

            var output = await repositoryFunction(repository);
            return output;
        }

        protected async Task<T> GetFromRepository<T>(
            string owner,
            string name,
            Func<Repository, GitHubClient, Task<T>> repositoryFunction)
        {
            var gitHubClient = await this.GetGitHubClient();

            var repository = await this.GetRepository(gitHubClient,
                owner, name);

            var output = await repositoryFunction(repository, gitHubClient);
            return output;
        }

        protected async Task InRepository(
            string owner,
            string name,
            Func<Repository, Task> repositoryAction)
        {
            var gitHubClient = await this.GetGitHubClient();

            var repository = await this.GetRepository(gitHubClient,
                owner, name);

            await repositoryAction(repository);
        }

        protected async Task InRepository(
            string owner,
            string name,
            Func<Repository, GitHubClient, Task> repositoryAction)
        {
            var gitHubClient = await this.GetGitHubClient();

            var repository = await this.GetRepository(gitHubClient,
                owner, name);

            await repositoryAction(repository, gitHubClient);
        }


        public async Task<long> CreateRepository_NonIdempotent(GitHubRepositorySpecification gitHubRepositorySpecification)
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

        public async Task DeleteRepository_NonIdempotent(string owner, string name)
        {
            var gitHubClient = await this.GitHubClientProvider.GetGitHubClient();

            await gitHubClient.Repository.Delete(owner, name);
        }

        public async Task<string> GetDescription(string owner, string name)
        {
            var description = await this.GetFromRepository(owner, name,
                repository =>
                {
                    var output = repository.Description;

                    return Task.FromResult(output);
                });

            return description;
        }

        public async Task<string> GetRepositoryCloneUrl(string owner, string name)
        {
            var checkoutURL = await this.GetFromRepository(owner, name,
                repository =>
                {
                    var output = repository.CloneUrl;

                    return Task.FromResult(output);
                });

            return checkoutURL;
        }

        public async Task<long> GetRepositoryID(string owner, string name)
        {
            var repositoryID = await this.GetFromRepository(owner, name,
                repository =>
                {
                    var output = repository.Id;

                    return Task.FromResult(output);
                });

            return repositoryID;
        }

        public async Task<bool> IsPrivate(string owner, string name)
        {
            var isPrivate = await this.GetFromRepository(owner, name,
                repository =>
                {
                    var output = repository.Private;

                    return Task.FromResult(output);
                });

            return isPrivate;
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

        public Task<GitHubClient> GetGitHubClient()
        {
            return this.GitHubClientProvider.GetGitHubClient();
        }

        public Task<Repository> GetRepository(GitHubClient gitHubClient,
            string owner,
            string name)
        {
            return gitHubClient.Repository.Get(owner, name);
        }

        public async Task<IGitHubRepository> GetGitHubRepository(string owner, string name)
        {
            var gitHubClient = await this.GetGitHubClient();

            var repository = await this.GetRepository(gitHubClient,
                owner, name);

            var output = new GitHubRepository(repository);
            return output;
        }
    }
}