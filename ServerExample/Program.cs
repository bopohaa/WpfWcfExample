using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using ServerExample.Common;
using ServerExample.Bl;

namespace ServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<Dal.DatabaseContext, Migrations.Configuration>());

            var factory = new WcfServiceFactory();
            //netsh http add urlacl url=http://+:8080/DataService/ user=\Nikolay

            using (var host = factory.CreateUnityServiceHost<DataService>(new Uri("http://localhost:8080/DataService/")))
            {
                host.AddServiceEndpoint(typeof(IGetDataService), new WSHttpBinding(), "Get");
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

                host.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
