using CoursePlatForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CoursePlatForm.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult ShowIndex()
        {

            //Log4NetHelper.WriteLog(typeof(IndexController), "测试Log4Net日志是否写入");
            return View();
        }

        public PartialViewResult LeftMenu_Partial()
        {
            string s = "return好了";
            ViewBag.s = s;
            return PartialView();
        }

        public ActionResult index()
        {
            return View();
        }
    }
}
