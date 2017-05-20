using log4net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OwinSelfHostLogging.Logging
{
    public class LoggingRequestHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestUrl = request.RequestUri;
            var requestMethod = request.Method;

            var requestLogger = LogManager.GetLogger($"{requestMethod} {requestUrl} Request ");
            requestLogger.Info(await request.Content.ReadAsStringAsync());

            var response = await base.SendAsync(request, cancellationToken);

            var responseLogger = LogManager.GetLogger($"{requestMethod} {requestUrl} Response");
            responseLogger.Info(await response.Content.ReadAsStringAsync());

            return response;
        }
    }
}
