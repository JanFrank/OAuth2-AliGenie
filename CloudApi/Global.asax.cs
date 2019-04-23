using InsiCloudApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CloudApi.Providers;

namespace CloudApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 启动 全局服务
            AppGlobalServerStart.Register();


            AreaRegistration.RegisterAllAreas();
            

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            var format = GlobalConfiguration.Configuration.Formatters;
            //清除默认xml
            format.XmlFormatter.SupportedMediaTypes.Clear();


            GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilterAttribute());




            if (System.Configuration.ConfigurationManager.AppSettings["IsRedis"] + "" == "0")
            {//将数据缓存到Redis中，当然，如果你不用Redis，自行处理iis回收之后，缓存丢失的问题也是可以的.
                RedisCacheSaveThread.Instance.Start();
            }

            new CloudApi.Dueros.ThreadCheckModel().StartThread();


        }
    }
}