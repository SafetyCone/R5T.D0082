using System;


namespace R5T.D0082.A001
{
    public static class IServiceActionAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregation other)
            where T : IServiceActionAggregation
        {
            aggregation.GitHubAuthenticationProviderAction = other.GitHubAuthenticationProviderAction;
            aggregation.GitHubClientProviderAction = other.GitHubClientProviderAction;
            aggregation.GitHubOperatorAction = other.GitHubOperatorAction;
            aggregation.ProductHeaderValueProviderAction = other.ProductHeaderValueProviderAction;

            return aggregation;
        }
    }
}
