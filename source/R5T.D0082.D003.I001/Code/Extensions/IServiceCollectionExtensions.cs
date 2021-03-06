using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;


namespace R5T.D0082.D003.I001
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedProductHeaderValueProvider"/> implementation of <see cref="IProductHeaderValueProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHardCodedProductHeaderValueProvider(this IServiceCollection services)
        {
            services.AddSingleton<IProductHeaderValueProvider, HardCodedProductHeaderValueProvider>();

            return services;
        }
    }
}