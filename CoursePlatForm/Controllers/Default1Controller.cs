using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CoursePlatForm.Controllers
{
    public class Default1Controller : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Tb_ApplySoftList.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            if (tb_applysoftlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_applysoftlist);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_ApplySoftList tb_applysoftlist)
        {
            if (ModelState.IsValid)
            {
                db.Tb_ApplySoftList.Add(tb_applysoftlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_applysoftlist);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            if (tb_applysoftlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_applysoftlist);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_ApplySoftList tb_applysoftlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_applysoftlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_applysoftlist);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            if (tb_applysoftlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_applysoftlist);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            db.Tb_ApplySoftList.Remove(tb_applysoftlist);
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