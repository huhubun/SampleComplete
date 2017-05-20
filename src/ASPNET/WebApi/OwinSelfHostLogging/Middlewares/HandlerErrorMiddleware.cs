using log4net;
using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace OwinSelfHostLogging.Middlewares
{
    public class HandlerErrorMiddleware : OwinMiddleware
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(HandlerErrorMiddleware));

        public HandlerErrorMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
