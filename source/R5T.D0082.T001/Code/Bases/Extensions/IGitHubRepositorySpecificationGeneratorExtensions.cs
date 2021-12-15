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
            string description,
            bool isPrivate)
        {
            var visibility = isPrivate
                ? GitHubRepositoryVisibility.Private
                : GitHubRepositoryVisibility.Public
                ;

            var gitHubRepository = new GitHubRepositorySpecification()
            {
                Organization = organization,
                Name = name,
                Description = description,

                InitializeWithReadMe = true,
                Visibility = visibility,
                License = GitHubRepositoryLicense.MIT,
            };

            return gitHubRepository;
        }

        public static GitHubRepositorySpecification GetSafetyConeDefault(this IGitHubRepositorySpecificationGenerator _,
            string name,
            string description,
            bool isPrivate)
        {
            var organization = Instances.GitHubOrganization.SafetyCone();

            return _.GetDefault(
                organization,
                name,
                description,
                isPrivate);
        }
    }
}
