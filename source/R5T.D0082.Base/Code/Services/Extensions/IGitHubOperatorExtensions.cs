using System;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.D0082.T000;


namespace System
{
    public static class IGitHubOperatorExtensions
    {
        public static async Task InGitHubRepository(this IGitHubOperator gitHubOperator,
            string owner, string name,
            Func<IGitHubRepository, Task> gitHubRepositoryAction)
        {
            var gitHubRepository = await gitHubOperator.GetGitHubRepository(owner, name);

            await gitHubRepositoryAction(gitHubRepository);
        }

        public static async Task<T> GetFromGitHubRepository<T>(this IGitHubOperator gitHubOperator,
            string owner, string name,
            Func<IGitHubRepository, Task<T>> gitHubRepositoryAction)
        {
            var gitHubRepository = await gitHubOperator.GetGitHubRepository(owner, name);

            var output = await gitHubRepositoryAction(gitHubRepository);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="CreateRepositoryIdempotent(IGitHubOperator, GitHubRepositorySpecification)"/> as the default.
        /// </summary>
        public static Task<long> CreateRepository(this IGitHubOperator gitHubOperator,
            GitHubRepositorySpecification gitHubRepositorySpecification)
        {
            return gitHubOperator.CreateRepositoryIdempotent(gitHubRepositorySpecification);
        }

        public static async Task<long> CreateRepositoryIdempotent(this IGitHubOperator gitHubOperator,
            GitHubRepositorySpecification gitHubRepositorySpecification)
        {
            var repositoryExists = await gitHubOperator.RepositoryExists(gitHubRepositorySpecification.Organization, gitHubRepositorySpecification.Name);
            if(repositoryExists)
            {
                var repositoryID = await gitHubOperator.GetRepositoryID(gitHubRepositorySpecification.Organization, gitHubRepositorySpecification.Name);
                return repositoryID;
            }
            else
            {
                var repositoryID = await gitHubOperator.CreateRepository_NonIdempotent(gitHubRepositorySpecification);
                return repositoryID;
            }
        }

        /// <summary>
        /// Takes longer due to needing to first check if the repository exists. Only if the repository does exist is it deleted.
        /// </summary>
        public static async Task DeleteRepositoryIdempotent(this IGitHubOperator gitHubOperator,
            string owner,
            string repositoryName)
        {
            var exists = await gitHubOperator.RepositoryExists(owner, repositoryName);
            if(exists)
            {
                await gitHubOperator.DeleteRepository_NonIdempotent(owner, repositoryName);
            }
        }

        /// <summary>
        /// Selects <see cref="DeleteRepositoryIdempotent(IGitHubOperator, string, string)"/> as the default.
        /// </summary>
        public static Task DeleteRepository(this IGitHubOperator gitHubOperator,
            string owner,
            string repositoryName)
        {
            return gitHubOperator.DeleteRepositoryIdempotent(owner, repositoryName);
        }
    }
}
