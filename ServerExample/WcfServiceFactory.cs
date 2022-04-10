using ServerExample.Bl;
using ServerExample.Common;
using ServerExample.Common.Wcf.Hosting;
using ServerExample.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace ServerExample
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container
                .RegisterType<IGetDataService, DataService>()
                .RegisterType<IDataDal, DatabaseContext>()
                .RegisterFactory<SimpleFactory<IDataDal>>(c => new SimpleFactory<IDataDal>(() => c.Resolve<IDataDal>()))
                ;
        }
    }
}
