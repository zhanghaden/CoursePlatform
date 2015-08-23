using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers.SoftDown
{
    public class SCController : Controller
    {
        //
        // GET: /SC/

        public PartialViewResult SCpartial()
        {
            ViewBag.sc = "你好，世界！";
            return PartialView("SCpartial");
            //return view();
        }

        public PartialViewResult SCpartial2()
        {
            ViewBag.sc = "你好，世界2！";
            return PartialView("SCpartial");
            //return view();
        }

        public ActionResult jiben()
        {
            
            return View();
            //return view();
        }

        public ActionResult jiben2()
        {

            return View();
            //return view();
        }

    }
}
