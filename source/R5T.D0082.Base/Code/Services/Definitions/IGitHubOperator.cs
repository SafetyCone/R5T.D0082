using System;
using System.Threading.Tasks;

using R5T.Dacia;

using R5T.D0082.T000;


namespace R5T.D0082
{
    [ServiceDefinitionMarker]
    public interface IGitHubOperator
    {
        Task<long> CreateRepositoryNonIdempotent(GitHubRepositorySpecification gitHubRepositorySpecification);
        Task DeleteRepository(string owner, string name);
        Task<string> GetRepositoryCloneUrl(string owner, string name);
        Task<long> GetRepositoryID(string owner, string name);
        Task<bool> RepositoryExists(string owner, string name);
    }
}