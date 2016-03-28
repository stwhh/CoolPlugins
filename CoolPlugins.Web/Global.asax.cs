using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CoolPlugins.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// 404等错误页面处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(Object sender, EventArgs e)
        {
            //当路径出错，无法找到控制器时，不会执行FilterConfig中的OnException，而会在这里捕获。
            //当发生404错误时，执行完OnException后，还会执行到这里。
            //当发生其他错误，会执行OnException，但在base.OnException中已经处理完错误，不会再到这里执行。
            var lastError = HttpContext.Current.Server.GetLastError();
            if (lastError != null)
            {
                var httpError = lastError as HttpException;

                if (httpError != null)
                {
                    //Server.ClearError();
                    switch (httpError.GetHttpCode())
                    {
                        case 403:
                            HttpContext.Current.Response.Redirect("/home/errorPage");
                            break;
                        case 404:
                            HttpContext.Current.Response.Redirect("/home/errorPage");
                            break;
                        case 500:
                            HttpContext.Current.Response.Redirect("/home/errorPage");
                            break;
                    }
                }
            }
        }
    }
}