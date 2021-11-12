using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;
using Unity;

namespace TodoMockNet.Middleware
{
    public class SetUserMiddleware : OwinMiddleware
    {
        public SetUserMiddleware(OwinMiddleware next) : base(next)
        {
            _next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            // Get container that we set to OwinContext using common key
            var container = context.Get<IUnityContainer>(HttpApplicationKey.OwinPerRequestUnityContainerKey);

            await _next.Invoke(context);
        }

        private readonly OwinMiddleware _next;
    }

    public static class SetUserMiddlewareExtensions
    {
        public static IAppBuilder UseSetUserMiddlewareMiddleware(this IAppBuilder app)
        {
            app.Use(typeof(SetUserMiddleware));
            return app;
        }
    }
}