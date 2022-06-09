using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;


namespace R5T.D0082.I001
{
    [ServiceDefinitionMarker]
    public interface IOctokitBasedGitHubOperator : IGitHubOperator, IServiceDefinition
    {
        Task<GitHubClient> GetGitHubClient();

        Task<Repository> GetRepository(GitHubClient gitHubClient,
            string owner,
            string name);
    }
}
