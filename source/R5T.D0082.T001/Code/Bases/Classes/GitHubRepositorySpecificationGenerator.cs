using System;


namespace R5T.D0082.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class GitHubRepositorySpecificationGenerator : IGitHubRepositorySpecificationGenerator
    {
        #region Static

        public static GitHubRepositorySpecificationGenerator Instance { get; } = new();

        #endregion
    }
}