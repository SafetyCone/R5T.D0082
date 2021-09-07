using System;


namespace R5T.D0082.T001
{
    public static class Instances
    {
        public static IGitHubLicenseIdentifier GitHubLicenseIdentifier { get; } = T001.GitHubLicenseIdentifier.Instance;
        public static IGitHubOrganization GitHubOrganization { get; } = T001.GitHubOrganization.Instance;
    }
}
