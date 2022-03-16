using System;
using System.Threading.Tasks;

using R5T.D0082;

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

        /// <summary>
        /// Uses the Safety Cone organization.
        /// </summary>
        public static async Task<bool> RepositoryExists(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var output = await gitHubOperator.RepositoryExists(
                Instances.GitHubOrganization.SafetyCone(),
                repositoryName);

            return output;
        }

        public static async Task VerifyCanCreateRepository(this IGitHubOperator gitHubOperator,
            string repositoryName)
        {
            var gitHubRepositoryExists = await gitHubOperator.RepositoryExists(repositoryName);
            if (gitHubRepositoryExists)
            {
                throw new InvalidOperationException($"'{repositoryName}': cannot create GitHub repository because repository already exists.");
            }
        }
    }
}