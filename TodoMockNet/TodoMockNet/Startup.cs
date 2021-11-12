using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using TodoMockNet.App_Start;
using TodoMockNet.Middleware;
using Unity.AspNet.WebApi;

[assembly: OwinStartup(typeof(TodoMockNet.Startup))]

namespace TodoMockNet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Use our own IHttpControllerActivator implementation 
            // (to prevent DefaultControllerActivator's behaviour of creating child containers per request)
            //config.Services.Replace(typeof(IHttpControllerActivator), new ControllerActivator());


            // Register our middleware, that should create ChildContainer and set it to OwinContext
            app.UseUnityContainerPerRequest(container);
            app.UseSetUserMiddlewareMiddleware();
            app.UseWebApi(config);
        }
    }
}
