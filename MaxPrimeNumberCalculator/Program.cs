using System;
using MaxPrimeNumberCalculator.PrimeCheckers;
using MaxPrimeNumberCalculator.PrimeNumberFinders;
using MaxPrimeNumberCalculator.Web_Service;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace MaxPrimeNumberCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Use dependency injection to inject the ILargestPrimeFinder and IPrimeChecker implementations at runtime
            GlobalHost.DependencyResolver.Register(
                typeof(PrimeNumberSignalRHub),
                //Use a step size of 1000000000000 for now
                () => new PrimeNumberSignalRHub(new StepPrimeFinder(1000000000000, new TrialDivisionPrimeChecker())));

            //To host the client code static files
            app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = true
            });

            //To map the PrimeNumberSignalRHub
            app.MapSignalR();
        }
    }
}
