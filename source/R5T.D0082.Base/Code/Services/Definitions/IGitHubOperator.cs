using System;
using System.Threading.Tasks;

using R5T.Dacia;

using R5T.D0082.T000;


namespace R5T.D0082
{
    [ServiceDefinitionMarker]
    public interface IGitHubOperator
    {
        Task<long> CreateRepository(GitHubRepositorySpecification gitHubRepositorySpecification);
        Task DeleteRepository(string owner, string name);
        Task<bool> RepositoryExists(string owner, string name);
    }
}