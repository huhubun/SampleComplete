using log4net;
using Microsoft.Owin;
using Owin;
using OwinSelfHostLogging.Logging;
using OwinSelfHostLogging.Middlewares;
using System.Web.Http;

[assembly: OwinStartup(typeof(OwinSelfHostLogging.Startup))]

namespace OwinSelfHostLogging
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreateLog4NetLogger();

            // via http://stackoverflow.com/questions/30918649/unhandled-exception-global-handler-for-owin-katana
            // Must be the FIRST middleware
            app.Use<HandlerErrorMiddleware>();

            var startupLogger = LogManager.GetLogger(typeof(Startup));
            startupLogger.Info("Log4net Info");

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new LoggingRequestHandler());

            app.UseWebApi(config);
        }
    }
}
