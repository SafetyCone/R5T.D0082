using System;
using System.Threading.Tasks;

using R5T.Aalborg;

using R5T.T0064;


namespace R5T.D0082.D001
{
    [ServiceDefinitionMarker]
    public interface IGitHubAuthenticationProvider
    {
        Task<IAuthentication> GetGitHubAuthentication();
    }
}