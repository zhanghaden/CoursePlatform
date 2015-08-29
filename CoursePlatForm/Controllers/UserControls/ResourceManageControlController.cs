using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CoursePlatForm.Controllers.ViewControls
{
    /// <summary>
    /// 资源库管理视图控件控制器类
    /// </summary>
    public class ResourceManageControlController : Controller
    {
        //
        // GET: /ResourceManageControl/

        DBEntities db = new DBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult UCResourceListAndFilter( string category,int id = 1)
        {
            ViewData["category"] = category;
            PagedList<Tb_SoftList> orders = db.Tb_SoftList.OrderBy(o => o.SoftID).ToPagedList(id, 5);
            return PartialView("UCResourceListAndFilter", orders);
        }


        /// <summary>
        /// 用于显示swf文件
        /// </summary>
        /// <param name="SwfFileName"></param>
        /// <returns></returns>
        public PartialViewResult UCSwfDisplay(string SwfFilePath)
        {
            ViewBag.swfurl = "UpLoadFiles/SWF/" + SwfFilePath;
            return PartialView();
        }


        public PartialViewResult UCFileUpload()
        {
            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



    }
}
