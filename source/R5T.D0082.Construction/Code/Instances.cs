using System;

using R5T.D0082.T001;


namespace R5T.D0082.Construction
{
    public static class Instances
    {
        public static IGitHubOrganization GitHubOrganization { get; } = T001.GitHubOrganization.Instance;
        public static IGitHubRepositorySpecificationGenerator GitHubRepositorySpecificationGenerator { get; } = T001.GitHubRepositorySpecificationGenerator.Instance;
    }
}
