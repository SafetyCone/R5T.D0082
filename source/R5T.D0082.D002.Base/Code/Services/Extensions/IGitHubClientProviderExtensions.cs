using System;
using System.Threading.Tasks;

using Octokit;

using R5T.D0082.D002;


namespace System
{
    public static class IGitHubClientProviderExtensions
    {
        public static async Task InClientContext(this IGitHubClientProvider gitHubClientProvider,
            Func<GitHubClient, Task> gitHubClientAction)
        {
            var gitHubClient = await gitHubClientProvider.GetGitHubClient();

            await gitHubClientAction(gitHubClient);
        }

        public static async Task<T> InClientContext<T>(this IGitHubClientProvider gitHubClientProvider,
            Func<GitHubClient, Task<T>> gitHubClientAction)
        {
            var gitHubClient = await gitHubClientProvider.GetGitHubClient();

            var output = await gitHubClientAction(gitHubClient);
            return output;
        }
    }
}
