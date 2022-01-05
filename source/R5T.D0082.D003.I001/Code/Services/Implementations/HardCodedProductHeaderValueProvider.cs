using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;


namespace R5T.D0082.D003.I001
{
    [ServiceImplementationMarker]
    public class HardCodedProductHeaderValueProvider : IProductHeaderValueProvider, IServiceImplementation
    {
        public static string RivetGitHubProductHeaderValue => "Rivet";


        public Task<ProductHeaderValue> GetProductHeaderValue()
        {
            var productHeaderValue = ProductHeaderValue.Parse(HardCodedProductHeaderValueProvider.RivetGitHubProductHeaderValue);

            return Task.FromResult(productHeaderValue);
        }
    }
}