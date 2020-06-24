using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Business
{
    public static class ServiceRegister
    {
        public static IServiceCollection BlogServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IArticleService), typeof(ArticleService));
            return services;
        }
    }
}