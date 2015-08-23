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
    //该controller用于申请表字段的编辑，不允许删除和新建，只允许修改名称，修改是否显示
    [CheckAccount(Roles="admin")]
    public class AdminTableFieldController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /AdminTableField/

        public ActionResult Index()
        {
            return View(db.Tb_FieldTable.Where(m=>m.IsUse==1).ToList());
        }

        //
        // GET: /AdminTableField/Details/5

        public ActionResult Create()
        {
            //查找到第一个isuse为0的字段，把它显示出去供管理员编辑
            Tb_FieldTable tb_fieldtable = db.Tb_FieldTable.Where(m=>m.IsUse==0).FirstOrDefault();
            if (tb_fieldtable == null)
            {
                return HttpNotFound();
            }
            return View(tb_fieldtable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_FieldTable tb_fieldtable)
        {
            if (ModelState.IsValid)
            {
                tb_fieldtable.IsUse = 1;
                db.Entry(tb_fieldtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_fieldtable);
        }

        //
        // GET: /AdminTableField/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_FieldTable tb_fieldtable = db.Tb_FieldTable.Find(id);
            if (tb_fieldtable == null)
            {
                return HttpNotFound();
            }
            return View(tb_fieldtable);
        }

        //
        // POST: /AdminTableField/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_FieldTable tb_fieldtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_fieldtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_fieldtable);
        }
        //get
        public ActionResult Delete(int id = 0)
        {
            Tb_FieldTable tb_fieldtable = db.Tb_FieldTable.Find(id);
            if (tb_fieldtable == null)
            {
                return HttpNotFound();
            }
            else
            {
                tb_fieldtable.IsUse = 0;
                db.Entry(tb_fieldtable).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}