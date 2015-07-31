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
            //显示文章类别菜单管理
            //var queryColumns =
            //    from n in qs.T_Columns
            //    where n.parentID == -1
            //    select n;
            //ViewBag.cols = queryColumns.ToList<T_Columns>();

            //显示配置菜单管理

            base.OnActionExecuted(filterContext);
        }
    }
}
