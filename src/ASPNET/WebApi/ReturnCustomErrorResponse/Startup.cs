using Microsoft.Owin;
using Owin;
using ReturnCustomErrorResponse.Attributes;
using System.Web.Http;

[assembly: OwinStartup(typeof(ReturnCustomErrorResponse.Startup))]

namespace ReturnCustomErrorResponse
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ExceptionHandlingAttribute());

            app.UseWebApi(config);
        }
    }
}
