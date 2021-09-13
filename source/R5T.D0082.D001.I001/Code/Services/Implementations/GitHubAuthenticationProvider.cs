using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using R5T.Aalborg;
using R5T.Dacia;
using R5T.Suebia;


namespace R5T.D0082.D001.I001
{
    [ServiceImplementationMarker]
    public class GitHubAuthenticationProvider : IGitHubAuthenticationProvider
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public GitHubAuthenticationProvider(
            ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public async Task<IAuthentication> GetGitHubAuthentication()
        {
            var authenticationJsonFilePath = await this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(
                Instances.FileName.GitHubAuthenticationJson());

            var authentication = await JsonFileHelper.LoadFromFile<Authentication>(
                authenticationJsonFilePath,
                "GitHubAuthentication");

            return authentication;
        }
    }
}