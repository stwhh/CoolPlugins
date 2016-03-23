using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoolPlugins.Public
{
    public class LogExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string controllerName = (string) filterContext.RouteData.Values["controller"];
            string actionName = (string) filterContext.RouteData.Values["action"];
            HandleErrorInfo info = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            string broser = request.Browser.Browser;
            string broserVersion = request.Browser.Version;
            string system = request.Browser.Platform;
            string errBaseInfo =
                string.Format("UserId={0},Broser={1},BroserVersion={2},System={3},Controller={4},Action={5}",
                    "AuthAttribute.GetUserId()", broser, broserVersion, system, controllerName, actionName);
            //LogUtil.Error(errBaseInfo, filterContext.Exception, Website.LOG_ID);

            if (!filterContext.ExceptionHandled)
            {
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    filterContext.HttpContext.Response.Clear();
                    HttpException httpex = filterContext.Exception as HttpException;
                    if (httpex != null)
                    {
                        filterContext.HttpContext.Response.StatusCode = httpex.GetHttpCode();
                        info = new HandleErrorInfo(new Exception(), controllerName, actionName);
                        switch (httpex.GetHttpCode())
                        {
                            case 403:
                                HttpContext.Current.Response.Redirect("/Home/ErrorPage");
                                break;
                            case 404:
                                HttpContext.Current.Response.Redirect("/Home/ErrorPage");
                                break;
                            default:
                                base.OnException(filterContext);
                                break;
                        }
                    }
                    else
                    {
                        filterContext.HttpContext.Response.StatusCode = 500;
                    }

                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(info)
                    };
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
                else
                {
                    //base.OnException(filterContext);
                    // return;
                    //当customErrors=Off时
                    //当customErrors = RemoteOnly，且在本地调试时
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "/Views/Shared/ErrorDetails.cshtml",
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(info)
                    };
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
            }
        }
    }
}
