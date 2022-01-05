using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0064;


namespace R5T.D0082.D003
{
    [ServiceDefinitionMarker]
    public interface IProductHeaderValueProvider : IServiceDefinition
    {
        Task<ProductHeaderValue> GetProductHeaderValue();
    }
}