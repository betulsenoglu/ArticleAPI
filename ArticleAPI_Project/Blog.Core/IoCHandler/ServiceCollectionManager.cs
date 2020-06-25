using System;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Core.IoCHandler
{
    public sealed class ServiceCollectionManager
        //: IIoCHandler
    {
        private readonly IServiceProvider _provider;
        private static ServiceCollectionManager _instance;
        private static object _lockObj = new object();

        public static ServiceCollectionManager CurrentInstance
        {
            get { return GetCurrentInstance(); }
        }
        
        internal ServiceCollectionManager(IServiceCollection services)
        {
            _provider = services
                .BuildServiceProvider();
        }

        public static ServiceCollectionManager GetCurrentInstance()
        {
            if (_instance == null)
            {
                throw new ArgumentNullException($"{_instance} is null.");
            }
            return _instance;
        }

        public static void Initialize(IServiceCollection services)
        {
            lock (_lockObj)
            {
                if (_instance == null)
                {
                    _instance = new ServiceCollectionManager(services);
                }
            }
        }

        public T Resolve<T>()
        {
            return _provider.GetService<T>();
        }
    }
}