using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers.SC
{
    public class SCmainController : Controller
    {
        //
        // GET: /SCmain/

        DBEntities db = new DBEntities();
        ModelHelpers mHelp = new ModelHelpers();

        public ActionResult Index()
        {

            ViewBag.apptable= db.Tb_ApplyTable.ToList<Tb_ApplyTable>();

            
            //return View();
            return RedirectToAction("index","SCmain");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
