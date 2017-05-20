using log4net;
using Microsoft.Owin.Hosting;
using System;

namespace OwinSelfHostLogging
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9099";

            using (WebApp.Start(baseAddress))
            {
                _logger.Info($"Now listened on {baseAddress}");
                _logger.Info("Press [enter] key to quit");

                Console.ReadLine();
            }
        }
    }
}
