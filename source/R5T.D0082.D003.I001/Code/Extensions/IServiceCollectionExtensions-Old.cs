using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0082.D003.I001
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedProductHeaderValueProvider"/> implementation of <see cref="IProductHeaderValueProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProductHeaderValueProvider> AddHardCodedProductHeaderValueProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IProductHeaderValueProvider>(() => services.AddHardCodedProductHeaderValueProvider());
            return serviceAction;
        }
    }
}