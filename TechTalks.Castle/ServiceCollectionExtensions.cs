using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        //Intercepted
        public static IServiceCollection AddScoped<TInterface, TImpl, TIntercepter>(this IServiceCollection services)
            where TInterface : class
            where TImpl : class, TInterface
            where TIntercepter : class, IInterceptor
        {
            services.AddSingleton<IProxyGenerator, ProxyGenerator>();
            services.AddScoped<TImpl>();
            services.TryAddTransient<TIntercepter>();
            return services.AddScoped(provider =>
            {
                var proxy = provider.GetRequiredService<IProxyGenerator>();
                var impl = provider.GetRequiredService<TImpl>();
                var interceptor = provider.GetRequiredService<TIntercepter>();
                return proxy.CreateInterfaceProxyWithTarget<TInterface>(impl, interceptor);
            });
        }

        //public static IServiceCollection Decorate<TService, TImplementation, TDecorator>(this IServiceCollection services)
        //    where TService : class 
        //    where TImplementation : class, TService
        //    where TDecorator : class, TService
        //{
        //    services.AddScoped(typeof(TImplementation));
        //    services.AddScoped<TService>(p => new TDecorator());
        //    return services;
        //}
    }
}
