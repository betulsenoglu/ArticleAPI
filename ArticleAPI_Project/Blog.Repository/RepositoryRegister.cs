using Blog.Repository.Abstract;
using Blog.Repository.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Repository
{
    public static class RepositoryRegister
    {
        public static IServiceCollection BlogRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));
            return services;
        }
    }
}