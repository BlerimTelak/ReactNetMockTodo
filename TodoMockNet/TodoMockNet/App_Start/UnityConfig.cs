using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMockNet.Services;
using TodoMockNet.Services.Interfaces;
using Unity;

namespace TodoMockNet.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ITodoManager, TodoManager>();
            return container;
        }
    }
}