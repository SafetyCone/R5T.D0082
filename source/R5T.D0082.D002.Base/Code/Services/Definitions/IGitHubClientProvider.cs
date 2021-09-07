using System;
using System.Threading.Tasks;

using Octokit;

using R5T.Dacia;


namespace R5T.D0082.D002
{
    [ServiceDefinitionMarker]
    public interface IGitHubClientProvider
    {
        Task<GitHubClient> GetGitHubClient();
    }
}