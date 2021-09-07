using System;


namespace R5T.D0082.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class GitHubOrganization : IGitHubOrganization
    {
        #region Static

        public static GitHubOrganization Instance { get; } = new();

        #endregion
    }
}