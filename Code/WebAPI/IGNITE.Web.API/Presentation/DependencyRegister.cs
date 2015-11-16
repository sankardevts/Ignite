using IGNITE.Core.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OSV = IGNITE.Services;
namespace IGNITE.Web.API
{
    public class DependencyRegister
    {
        public virtual void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            ////data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            container.RegisterType<IgniteObjectContext>(
            new HierarchicalLifetimeManager());
            container.RegisterType<IDbContext>(
                new HierarchicalLifetimeManager(),
                new InjectionFactory(c => c.Resolve<IgniteObjectContext>(new ResolverOverride[]
                                   {
                                       new ParameterOverride("nameOrConnectionString", dataProviderSettings.DataConnectionString)
                                   })));

            container.RegisterType<OSV.User.IUserService, OSV.User.UserService>();
            config.DependencyResolver = new DependencyResolver(container);
            // Other Web API configuration not shown.
        }
    }
}