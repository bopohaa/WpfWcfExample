using ClientExample.Bl;
using ClientExample.Common;
using ClientExample.Internal;
using ClientExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ClientExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly IServicesResolver Resolver;
        static App()
        {
            Resolver = InitializeServices();
        }

        private static IServicesResolver InitializeServices()
        {
            return new ServicesContainerBuilder()
                .Register<IDataService, DataService>()
                .RegisterSingleton<Func<ServerSample.IGetDataService>>(() => new ServerSample.GetDataServiceClient())
                .Register<ClientContainer<ServerSample.IGetDataService>>()
                .RegisterSingleton<DataViewModel>()
                .Build();
        }
    }
}
