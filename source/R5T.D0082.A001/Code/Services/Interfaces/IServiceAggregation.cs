using System;

using R5T.Dacia;

using R5T.D0082.D001;
using R5T.D0082.D002;
using R5T.D0082.D003;


namespace R5T.D0082.A001
{
    public interface IServiceAggregation
    {
        IServiceAction<IGitHubAuthenticationProvider> GitHubAuthenticationProviderAction { get; set; }
        IServiceAction<IGitHubClientProvider> GitHubClientProviderAction { get; set; }
        IServiceAction<IGitHubOperator> GitHubOperatorAction { get; set; }
        IServiceAction<IProductHeaderValueProvider> ProductHeaderValueProviderAction { get; set; }
    }
}
