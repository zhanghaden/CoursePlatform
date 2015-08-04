using CommonClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /App/

        //用于启动控制器时显示菜单信息
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            int UserID = int.Parse(TakeCookie.GetCookie("userId"));
            if (UserID != 0)
            {
                base.OnActionExecuted(filterContext);
            }
            else
            {
                
            }
            
        }
    }
}
