using System;

using Octokit;

using R5T.D0082.T000;


namespace R5T.D0082.I001
{
    public sealed class GitHubRepository : IGitHubRepository
    {
        private Repository Repository { get; }

        public string Description => this.Repository.Description;
        public string Name => this.Repository.Name;
        public bool IsPrivate => this.Repository.Private;


        public GitHubRepository(
            Repository repository)
        {
            this.Repository = repository;
        }
    }
}
