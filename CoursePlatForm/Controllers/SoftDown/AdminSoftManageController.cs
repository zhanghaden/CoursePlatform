using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CoursePlatForm.Controllers.SoftDown
{
    [CheckAccount(Roles = "admin")]
    public class AdminSoftManageController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /AdminSoftManage/

        public ActionResult Index()
        {
            return View(db.Tb_SoftList.ToList());
        }

        //
        // GET: /AdminSoftManage/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_SoftList tb_softlist = db.Tb_SoftList.Find(id);
            if (tb_softlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_softlist);
        }

        //
        // GET: /AdminSoftManage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminSoftManage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_SoftList tb_softlist)
        {
            if (ModelState.IsValid)
            {
                db.Tb_SoftList.Add(tb_softlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_softlist);
        }

        //
        // GET: /AdminSoftManage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_SoftList tb_softlist = db.Tb_SoftList.Find(id);
            if (tb_softlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_softlist);
        }

        //
        // POST: /AdminSoftManage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_SoftList tb_softlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_softlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_softlist);
        }

        //
        // GET: /AdminSoftManage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_SoftList tb_softlist = db.Tb_SoftList.Find(id);
            if (tb_softlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_softlist);
        }

        //
        // POST: /AdminSoftManage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_SoftList tb_softlist = db.Tb_SoftList.Find(id);
            db.Tb_SoftList.Remove(tb_softlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}