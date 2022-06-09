using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0082.T000;


namespace R5T.D0082
{
    [ServiceDefinitionMarker]
    public interface IGitHubOperator : IServiceDefinition, IHasGitHubOperator
    {
        Task<long> CreateRepository_NonIdempotent(GitHubRepositorySpecification gitHubRepositorySpecification);
        Task DeleteRepository_NonIdempotent(string owner, string name);
        Task<string> GetDescription(string owner, string name);
        Task<string> GetRepositoryCloneUrl(string owner, string name);
        Task<long> GetRepositoryID(string owner, string name);
        Task<bool> IsPrivate(string owner, string name);
        Task<bool> RepositoryExists(string owner, string name);

        Task<IGitHubRepository> GetGitHubRepository(string owner, string name);
    }
}