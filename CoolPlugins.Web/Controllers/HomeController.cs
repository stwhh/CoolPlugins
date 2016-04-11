using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolPlugins.BLL;
using CoolPlugins.Public;

namespace CoolPlugins.Web.Controllers
{
    //[LogException]        
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userModel = TestBLL.GetModel();
            var userList = TestBLL.GetList();
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        //忘记密码
        public ActionResult ForgetPassword()
        {
            return View();
        }

        /// <summary>
        /// 错误页面处理
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorPage()
        {
            return View();
        }

    }
}
