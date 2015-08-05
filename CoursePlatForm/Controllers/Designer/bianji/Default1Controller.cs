using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CoursePlatForm.Controllers.Designer.bianji
{
    public class union
    {
        public Tb_ApplySoftList nn{get;set;}
        public Tb_ApplyTable mm { get; set; }
    }
    public class Default1Controller : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var querylist =
                from n in db.Tb_ApplySoftList
                from m in db.Tb_ApplyTable
                where n.ApplyID == m.ApplyID
                select new union(){ 
                    nn=n,mm=m
                };
            
            //List<Tb_ApplyTable> list = new List<Tb_ApplyTable>();
            return View(querylist.ToList<union>());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_SoftCourse tb_softcourse = db.Tb_SoftCourse.Find(id);
            if (tb_softcourse == null)
            {
                return HttpNotFound();
            }
            return View(tb_softcourse);
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
        public ActionResult Create(Tb_SoftCourse tb_softcourse)
        {
            if (ModelState.IsValid)
            {
                db.Tb_SoftCourse.Add(tb_softcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_softcourse);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_SoftCourse tb_softcourse = db.Tb_SoftCourse.Find(id);
            if (tb_softcourse == null)
            {
                return HttpNotFound();
            }
            return View(tb_softcourse);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_SoftCourse tb_softcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_softcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_softcourse);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_SoftCourse tb_softcourse = db.Tb_SoftCourse.Find(id);
            if (tb_softcourse == null)
            {
                return HttpNotFound();
            }
            return View(tb_softcourse);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_SoftCourse tb_softcourse = db.Tb_SoftCourse.Find(id);
            db.Tb_SoftCourse.Remove(tb_softcourse);
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