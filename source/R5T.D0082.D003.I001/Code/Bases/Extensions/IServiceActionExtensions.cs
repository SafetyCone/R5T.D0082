using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0082.D003.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedProductHeaderValueProvider"/> implementation of <see cref="IProductHeaderValueProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProductHeaderValueProvider> AddHardCodedProductHeaderValueProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IProductHeaderValueProvider>(services => services.AddHardCodedProductHeaderValueProvider());
            return serviceAction;
        }
    }
}
