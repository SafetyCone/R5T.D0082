using System;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.D0082.T000;


namespace System
{
    public static class IGitHubOperatorExtensions
    {
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
                var repositoryID = await gitHubOperator.CreateRepositoryNonIdempotent(gitHubRepositorySpecification);
                return repositoryID;
            }
        }
    }
}
