using System;
using System.ServiceModel;
using Unity;

namespace ServerExample.Common.Wcf.Hosting
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
                            : base(serviceType, baseAddresses)
        {
            Initialize(container);
        }

        public UnityServiceHost(IUnityContainer container, object singletonInstance, params Uri[] baseAddresses)
            :base(singletonInstance, baseAddresses)
        {
            Initialize(container);
        }

        private void Initialize(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            HostingUtils.ApplyServiceBehaviors(Description.Behaviors, container);
            HostingUtils.ApplyContractBehaviors(ImplementedContracts, container);
            HostingUtils.ApplyUnityContractBehavior(ImplementedContracts, container);
        }

    }
}
