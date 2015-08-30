using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using CoursePlatForm.Common;

namespace CoursePlatForm.Controllers
{
    public class ResourceManageController : Controller
    {
        //
        // GET: /ResourceManage/


        DBEntities db = new DBEntities();
        ModelHelpers mhelp = new ModelHelpers();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResourceListAndFilter(int id = 1)
        {
            if (Request.IsAjaxRequest())
                return RedirectToAction("UCResourceListAndFilter", "ResourceManageControl", new { id=id });
            return View();
        }
        public ActionResult TestUpFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestUpFile(FormCollection form)
        {
            HttpFileCollectionBase hfc = Request.Files;
            UpLoad.MutifileUp(hfc);
            
            return View();
        }
        //
        //用于执行上传文件时的ajax操作，生成一条资源信息，存储资源并转换
        public void ajaxUpFile()
        {
            HttpFileCollectionBase hfc = Request.Files;
            Tb_Resource model = UpLoad.MutifileUp(hfc);
            if (model != null)
            {
                mhelp.Add<Tb_Resource>(model);
            }
            else
            { 
                
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
