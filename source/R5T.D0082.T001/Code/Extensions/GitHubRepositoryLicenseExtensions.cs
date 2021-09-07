using System;

using R5T.Magyar;

using R5T.D0082.T000;

using Instances = R5T.D0082.T001.Instances;


namespace System
{
    public static class GitHubRepositoryLicenseExtensions
    {
        public static string GetLicenseIdentifier(this GitHubRepositoryLicense gitHubRepositoryLicense)
        {
            return gitHubRepositoryLicense switch
            {
                GitHubRepositoryLicense.MIT => Instances.GitHubLicenseIdentifier.MIT(),
                _ => throw EnumerationHelper.SwitchDefaultCaseException(gitHubRepositoryLicense),
            };
        }
    }
}
