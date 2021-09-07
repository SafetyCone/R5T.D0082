using System;


namespace R5T.D0082.T000
{
    public class GitHubRepositorySpecification
    {
        public string Organization { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool InitializeWithReadMe { get; set; }
        public GitHubRepositoryVisibility Visibility { get; set; }
        public GitHubRepositoryLicense License { get; set; }
    }
}
