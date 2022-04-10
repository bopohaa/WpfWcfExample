using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity;

namespace ServerExample.Common.Wcf.Hosting
{
    public abstract class UnityServiceHostFactory : ServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = new UnityContainer();

            ConfigureContainer(container);

            var serviceBehavior = (ServiceBehaviorAttribute)serviceType.GetCustomAttributes(false).Where(a => a is ServiceBehaviorAttribute).SingleOrDefault();
            var isSingleton = serviceBehavior?.InstanceContextMode == InstanceContextMode.Single;

            return isSingleton ?
                new UnityServiceHost(container, container.Resolve(serviceType), baseAddresses) :
                new UnityServiceHost(container, serviceType, baseAddresses);
        }

        public ServiceHost CreateUnityServiceHost<T>(params Uri[] baseAddresses) where T : class
            => CreateServiceHost(typeof(T), baseAddresses);
    }
}
