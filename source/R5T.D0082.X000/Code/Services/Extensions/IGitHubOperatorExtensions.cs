using System;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.D0082.T000;

using Instances = R5T.D0082.X000.Instances;


namespace System
{
    public static class IGitHubOperatorExtensions
    {
        public static async Task DeleteRepository_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            await gitHubOperator.DeleteRepository(
                Instances.GitHubOrganization.SafetyCone(),
                repositoryName);
        }

        public static async Task<string> GetRepositoryCloneUrl_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var organizationName = Instances.GitHubOrganization.SafetyCone();

            var output = await gitHubOperator.GetRepositoryCloneUrl(
                organizationName,
                repositoryName);

            return output;
        }

        public static async Task<string> GetDescription_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var organizationName = Instances.GitHubOrganization.SafetyCone();

            var output = await gitHubOperator.GetDescription(
                organizationName,
                repositoryName);

            return output;
        }

        public static Task InGitHubRepository_SafetyCone(this IGitHubOperator gitHubOperator,
            string name,
            Func<IGitHubRepository, Task> gitHubRepositoryAction)
        {
            return gitHubOperator.InGitHubRepository(
                Instances.GitHubOrganization.SafetyCone(),
                name,
                gitHubRepositoryAction);   
        }

        public static Task<bool> IsPrivate_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            return gitHubOperator.IsPrivate(
                Instances.GitHubOrganization.SafetyCone(),
                repositoryName);
        }

        /// <summary>
        /// Uses the Safety Cone organization.
        /// </summary>
        public static async Task<bool> RepositoryExists_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var output = await gitHubOperator.RepositoryExists(
                Instances.GitHubOrganization.SafetyCone(),
                repositoryName);

            return output;
        }

        public static async Task VerifyCanCreateRepository_SafetyCone(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var gitHubRepositoryExists = await gitHubOperator.RepositoryExists_SafetyCone(repositoryName);
            if (gitHubRepositoryExists)
            {
                throw new InvalidOperationException($"'{repositoryName}': cannot create GitHub repository because repository already exists.");
            }
        }
    }
}