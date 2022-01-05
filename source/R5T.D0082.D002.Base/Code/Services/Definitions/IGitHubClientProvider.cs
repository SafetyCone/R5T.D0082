using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;


namespace R5T.D0082.D002
{
    [ServiceDefinitionMarker]
    public interface IGitHubClientProvider : IServiceDefinition
    {
        Task<GitHubClient> GetGitHubClient();
    }
}