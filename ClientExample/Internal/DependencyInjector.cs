using Unity;
using Unity.Lifetime;

namespace ClientExample.Internal
{
    public interface IServicesResolver
    {
        T Resolve<T>();
        I BuildUp<I>(I instance);
    }

    internal class ServicesContainerBuilder
    {
        private UnityContainer _unityContainer = new UnityContainer();

        private class ServicesResolver : IServicesResolver
        {
            private readonly UnityContainer _container;
            public ServicesResolver(UnityContainer container)
            {
                _container = container;
            }

            public I BuildUp<I>(I instance)
            {
                return _container.BuildUp<I>(instance);
            }

            public T Resolve<T>()
            {
                return _container.Resolve<T>();
            }
        }

        public ServicesContainerBuilder Register<I, T>() where T : I
        {
            _unityContainer.RegisterType<I, T>();
            return this;
        }

        public ServicesContainerBuilder Register<I>()
        {
            _unityContainer.RegisterType<I>();
            return this;
        }

        public ServicesContainerBuilder RegisterSingleton<I>()
        {
            _unityContainer.RegisterType<I>(TypeLifetime.Singleton);
            return this;
        }
        public ServicesContainerBuilder RegisterSingleton<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
            return this;
        }


        public IServicesResolver Build()
        {
            var result = new ServicesResolver(_unityContainer);
            _unityContainer = null;
            return result;
        }
    }
}
