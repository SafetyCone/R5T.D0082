using System;

using R5T.Dacia;

using R5T.D0082.D001;
using R5T.D0082.D002;
using R5T.D0082.D003;


namespace R5T.D0082.A001
{
    public class ServiceAggregation : IServiceAggregation
    {
        public IServiceAction<IGitHubAuthenticationProvider> GitHubAuthenticationProviderAction { get; set; }
        public IServiceAction<IGitHubClientProvider> GitHubClientProviderAction { get; set; }
        public IServiceAction<IGitHubOperator> GitHubOperatorAction { get; set; }
        public IServiceAction<IProductHeaderValueProvider> ProductHeaderValueProviderAction { get; set; }
    }
}
