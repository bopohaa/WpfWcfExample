using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace ServerExample.Common.Wcf.Context
{
    public class UnityInstanceContextInitializer : IInstanceContextInitializer
    {
        public void Initialize(InstanceContext instanceContext, Message message) => instanceContext.Extensions.Add(new UnityInstanceContextExtension());
    }
}
