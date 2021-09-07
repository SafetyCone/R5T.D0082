using System;

using R5T.D0082.T000;
using R5T.D0082.T001;


namespace System
{
    public static class IGitHubRepositorySpecificationGeneratorExtensions
    {
        public static GitHubRepositorySpecification GetDefault(this IGitHubRepositorySpecificationGenerator _,
            string organization,
            string name,
            string description)
        {
            var gitHubRepository = new GitHubRepositorySpecification()
            {
                Organization = organization,
                Name = name,
                Description = description,

                InitializeWithReadMe = true,
                Visibility = GitHubRepositoryVisibility.Public,
                License = GitHubRepositoryLicense.MIT,
            };

            return gitHubRepository;
        }

        public static GitHubRepositorySpecification GetSafetyConeDefault(this IGitHubRepositorySpecificationGenerator _,
            string name,
            string description)
        {
            var organization = Instances.GitHubOrganization.SafetyCone();

            return _.GetDefault(
                organization,
                name,
                description);
        }
    }
}
