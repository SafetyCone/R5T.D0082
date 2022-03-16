using System;

using R5T.D0082.T000;


namespace System
{
    public static class GitHubRepositorySpecificationExtensions
    {
        public static void IsPrivate(this GitHubRepositorySpecification repositorySpecification,
            bool isPrivate)
        {
            if(isPrivate)
            {
                repositorySpecification.Visibility = GitHubRepositoryVisibility.Private;
            }
            else
            {
                repositorySpecification.Visibility = GitHubRepositoryVisibility.Public;
            }
        }
    }
}
