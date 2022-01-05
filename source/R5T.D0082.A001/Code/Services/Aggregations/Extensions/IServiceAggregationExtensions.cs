using System;


namespace R5T.D0082.A001
{
    public static class IServiceAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceAggregation other)
            where T : IServiceAggregation
        {
            aggregation.GitHubAuthenticationProviderAction = other.GitHubAuthenticationProviderAction;
            aggregation.GitHubClientProviderAction = other.GitHubClientProviderAction;
            aggregation.GitHubOperatorAction = other.GitHubOperatorAction;
            aggregation.ProductHeaderValueProviderAction = other.ProductHeaderValueProviderAction;

            return aggregation;
        }
    }
}
