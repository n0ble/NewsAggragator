﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using NewsAggregator.DAL;

namespace NewsAggregator
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new UnityContainer();
			container
				.RegisterType<INewsRepository, EFNewsRepository>()
				.RegisterType<AppContext>(
						  new ContainerControlledLifetimeManager(),
						  new InjectionConstructor());

		var finder = container.Resolve<NewsFinder>();
			
		}
	}
}
