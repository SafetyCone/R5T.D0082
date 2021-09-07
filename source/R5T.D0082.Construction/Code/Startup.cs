using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;

using R5T.T0027.T008;

using R5T.D0082.A001;


namespace R5T.D0082.Construction
{
    public class Startup : T0027.T009.Startup
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        public override async Task ConfigureConfiguration(
            IConfigurationBuilder configurationBuilder,
            IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);
        }

        protected override async Task ConfigureServicesWithProvidedServices(
            IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction,
            IServiceProvider startupServicesProvider,
            IProvidedServices providedServices)
        {
            await base.ConfigureServicesWithProvidedServices(
                services,
                configurationAction,
                startupServicesProvider,
                providedServices);

            // Services.
            // Level 0.
            var gitHubOperatorServiceActions = services.AddGitHubOperatorServiceActions(
                providedServices.SecretsDirectoryFilePathProviderAction);

            // Operations.
            // Level 1.


            services
                .Run(gitHubOperatorServiceActions.GitHubOperatorAction)
                ;
        }
    }
}
