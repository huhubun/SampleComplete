using log4net.Config;
using Owin;

namespace OwinSelfHostLogging.Logging
{
    public static class AppBuilderLoggerExtensions
    {
        public static void CreateLog4NetLogger(this IAppBuilder app)
        {
            // This code will load log4net configure from App.config
            XmlConfigurator.Configure();
        }
    }
}
