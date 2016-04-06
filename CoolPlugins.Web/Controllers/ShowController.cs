using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolPlugins.Public;

namespace CoolPlugins.Web.Controllers
{
    //插件详情展示
    //[LogException]        
    public class ShowController : Controller
    {
        /// <summary>
        /// 插件详情页面
        /// </summary>
        /// <param name="id">插件id</param>
        /// <returns>详情页</returns>
        public ActionResult Detail(int id)
        {
            return View();
        }


    }
}
