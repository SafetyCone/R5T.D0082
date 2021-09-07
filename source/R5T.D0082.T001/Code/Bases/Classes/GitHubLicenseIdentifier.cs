using System;


namespace R5T.D0082.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class GitHubLicenseIdentifier : IGitHubLicenseIdentifier
    {
        #region Static

        public static GitHubLicenseIdentifier Instance { get; } = new();

        #endregion
    }
}