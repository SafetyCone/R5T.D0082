using System;
using System.Threading.Tasks;

using Octokit;

using R5T.Dacia;


namespace R5T.D0082.D003
{
    [ServiceDefinitionMarker]
    public interface IProductHeaderValueProvider
    {
        Task<ProductHeaderValue> GetProductHeaderValue();
    }
}