using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.Plymouth;
using R5T.Plymouth.ProgramAsAService;

using R5T.D0082.D001;


namespace R5T.D0082.Construction
{
    class Program : ProgramAsAServiceBase
    {
        #region Main

        static Task Main()
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .UseProgramAsAService<Program>()
                .UseT0027_T009_TwoStageStartup<Startup>()
                .BuildProgramAsAServiceHost()
                .Run();
        }

        #endregion


        private IServiceProvider ServiceProvider { get; }


        public Program(IApplicationLifetime applicationLifetime,
            IServiceProvider serviceProvider)
            : base(applicationLifetime)
        {
            this.ServiceProvider = serviceProvider;
        }

        protected override Task ServiceMain(CancellationToken stoppingToken)
        {
            return this.RunMethod();
            //return this.RunOperation();
        }

        private async Task RunMethod()
        {
            await this.TestGitHubOperator_DeleteRepository();
            //await this.TestGitHubOperator_CreateRepository();
            //await this.TestGitHubOperator_RepositoryExists();
            //await this.TestGetGitHubAuthentication();
        }

        public async Task TestGitHubOperator_DeleteRepository()
        {
            var gitHubOperator = this.ServiceProvider.GetRequiredService<IGitHubOperator>();

            await gitHubOperator.DeleteRepository(Instances.GitHubOrganization.SafetyCone(), "Test");
        }

        public async Task TestGitHubOperator_CreateRepository()
        {
            /// Inputs.
            bool isPrivate = true;


            /// Run.
            var repositorySpecification = Instances.GitHubRepositorySpecificationGenerator.GetSafetyConeDefault("Test", "Test Description", isPrivate);

            var gitHubOperator = this.ServiceProvider.GetRequiredService<IGitHubOperator>();

            await gitHubOperator.CreateRepository(repositorySpecification);
        }

        public async Task TestGitHubOperator_RepositoryExists()
        {
            var gitHubOperator = this.ServiceProvider.GetRequiredService<IGitHubOperator>();

            var exists = await gitHubOperator.RepositoryExists(Instances.GitHubOrganization.SafetyCone(), "R5T.F0075");

            Console.WriteLine($"Repository exists: {exists}");
        }

        public async Task TestGetGitHubAuthentication()
        {
            var gitHubAuthenticationProvider = this.ServiceProvider.GetRequiredService<IGitHubAuthenticationProvider>();

            var gitHubAuthentication = await gitHubAuthenticationProvider.GetGitHubAuthentication();

            Console.WriteLine(gitHubAuthentication.Username);
        }

        //private async Task RunOperation()
        //{
        //    //await this.ServiceProvider.Run<O010_Test_AddNewServiceImplementationLibraryToSolution>();
        //}
    }
}
