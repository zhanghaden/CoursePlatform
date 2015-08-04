using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Web.Routing;
using System.Text;
using CommonClassLibrary;
//using CoursePlatForm.Common;

namespace CoursePlatForm.Controllers
{
    [CheckAccount(Roles="admin")]
    public class TestController : Controller
    {

        DBEntities db = new DBEntities();
        ModelHelpers mHelp = new ModelHelpers();

        /// <summary>
        /// 所有软件列表，供选择
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SoftList()
        {
            List<Tb_SoftList> listSoft = mHelp.GetAll<Tb_SoftList>();
            ViewBag.listSoft = listSoft;
            return View();
        }

        /// <summary>
        /// 选择软件后的提交执行程序   post
        /// </summary>
        /// <param name="CheckSoft"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SoftList(string[] CheckSoft)
        {
            StringBuilder softs = new StringBuilder();
            foreach (string item in CheckSoft)
            {
                softs.Append(item + ",");
            }

            return RedirectToAction("SoftUse", new { dict = softs.ToString().Substring(0, softs.ToString().Length - 1) });
            //return View();
        }


        /// <summary>
        /// 显示已选择的软件，并生成表单
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public ActionResult SoftUse(string dict)
        {
            //int courseId = Convert.ToInt32(id); //从用户请求中取出课程的id

            //List<Tb_SoftList> listSoft = mHelp.GetAll<Tb_SoftList>();
            //ViewBag.listSoft = listSoft;
            ViewBag.softs = dict.Split(',');
            ViewBag.dict = dict;
            return View();
        }

        /// <summary>
        /// 用于执行要申请软件列表的表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SoftUse(FormCollection form)
        {
            string strIDs = form["hideSoftsIDs"].ToString();
            //Session["strIDs"] = strIDs;
            foreach (string item in strIDs.Split(','))
            {
                Tb_ApplySoftList applySoftListModel = new Tb_ApplySoftList();
                applySoftListModel.SoftCourseName = form["CourseName&" + item];
                applySoftListModel.TrainNumPerYear = int.Parse(form["StuNum&" + item].ToString());
                applySoftListModel.ApplyNum = int.Parse(form["ApplyNum&" + item].ToString());
                applySoftListModel.SoftID = int.Parse(item);
                applySoftListModel.ApplyID = int.Parse(Session["ApplyID"].ToString());
                mHelp.Add<Tb_ApplySoftList>(applySoftListModel);
            }
            return RedirectToAction("AddSoftCourse");
        }


        /// <summary>
        /// 显示申请表表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplyTable()
        {
            return View();
        }

        /// <summary>
        /// 执行申请表表单的提交
        /// </summary>
        /// <param name="ApplyTable"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyTable(Tb_ApplyTable ApplyTable)
        {
            ApplyTable.RecordTime = DateTime.Today;
            ApplyTable.UserID = int.Parse(TakeCookie.GetCookie("userId"));
            ApplyTable.IsPass = 0;
            if (ModelState.IsValid)
            {
                if (mHelp.Add<Tb_ApplyTable>(ApplyTable) > 0)
                {
                    Session["ApplyID"] = ApplyTable.ApplyID;
                    return RedirectToAction("SoftList", new { id = ApplyTable.ApplyID });
                }
                else
                {
                    return View();
                }
            }
            return View("index");
        }


        /// <summary>
        /// 显示申请的列表，管理员页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplyList()
        {
            List<Tb_ApplyTable> ApplyTablelist = mHelp.GetAll<Tb_ApplyTable>();
            ViewBag.ApplyTablelist = ApplyTablelist;
            return View();
        }


        /// <summary>
        /// 显示某申请表的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ApplyDetail(int id)
        {
            //用于显示申请表的信息
            Tb_ApplyTable applyTableModel = db.Tb_ApplyTable.Where(c => c.ApplyID == id).FirstOrDefault();
            //用于显示申请的软件列表的信息
            var queryApplySoftList =
                from n in db.Tb_ApplySoftList
                where n.ApplyID == id
                select n;
            ViewBag.ApplySoftList = queryApplySoftList;
            //用于显示课程设置列表的信息
            var querySoftCourseList =
                from n in db.Tb_SoftCourse
                where n.ApplyID == id
                select n;
            ViewBag.SoftCourseList = querySoftCourseList;
            return View(applyTableModel);
        }
        /// <summary>
        /// 修改审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangePass(int id)
        {
            if (id != 0)
            {
                Tb_ApplyTable modelTable = db.Tb_ApplyTable.Find(id);
                modelTable.IsPass = 1;
                db.SaveChanges();
            }
            return RedirectToAction("ApplyList");
        }

        /// <summary>
        /// 用于显示软件列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SoftDownList()
        {
            int UserID = int.Parse(TakeCookie.GetCookie("userId"));
            Tb_ApplyTable modelTable = (Tb_ApplyTable)mHelp.GetModelBy<Tb_ApplyTable>(m => m.UserID == UserID);
            if (modelTable != null)
            {
                List<Tb_ApplySoftList> list = mHelp.GetListBy<Tb_ApplySoftList>(m => m.ApplyID == modelTable.ApplyID);
                if (list != null)
                {
                    List<Tb_SoftList> listSoft = new List<Tb_SoftList>();
                    foreach (Tb_ApplySoftList item in list)
                    {
                        Tb_SoftList soft = (Tb_SoftList)mHelp.GetModelBy<Tb_SoftList>(m => m.SoftID == item.SoftID);
                        if (soft != null)
                            listSoft.Add(soft);
                    }
                    if (listSoft != null)
                    {
                        ViewBag.listSoft = listSoft;
                        return View();
                    }
                }
            }
            return View("index");
            //List<Tb_SoftList> listSoft = mHelp.GetAll<Tb_SoftList>();


        }



        /// <summary>
        /// 显示课程设置表项的提交表单
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSoftCourse()
        {
            return View();
        }

        /// <summary>
        /// 执行课程设置表项的提交表单
        /// </summary>
        /// <param name="ApplyTable"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSoftCourse(FormCollection form)
        {
            string[] keys = form.AllKeys;
            if (form["CourseName&1"] != "" && form["CourseName&1"] != null)
            {
                for (int i = 1; i <= 20; i++)//默认只能有二十门课程
                {
                    if (keys.Contains<string>("CourseName&" + i))
                    {
                        Tb_SoftCourse softCourse = new Tb_SoftCourse()
                        {
                            CourseName = form["CourseName&" + i],
                            SoftPlatform = form["SoftPlatform&" + i],
                            StuNum = int.Parse(form["StuNum&" + i].ToString()),
                            ApplyID = int.Parse(Session["ApplyID"].ToString())
                        };
                        db.Tb_SoftCourse.Add(softCourse);

                    }
                }
                db.SaveChanges();
                return View("ApplySuccess");
            }
            else
            {
                return View();
            }

        }


        //
        // GET: /Admin/

        #region 登陆首页 httpget模式
        //登陆首页action 
        [HttpGet]
        //[Common.Skip]
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        #region 登陆首页 处理登陆收据+httppost
        /// <summary>
        /// 登陆首页
        /// </summary>
        /// <param name="userModel">接受页面的值</param>
        /// <returns></returns>
        [HttpPost]
        //[Common.Skip]
        public ActionResult Index(Tb_SoftUser userModel)
        {
            //根据页面传来的值，调用GetUser方法
            Tb_SoftUser user = GetUser(userModel);
            if (user == null)
            {
                return View();
            }
            else
            {
                //保存user 到cookie 
                TakeCookie.SetCookie("userId", user.UserID.ToString());
                if (user.UserType == 0)//普通用户
                {
                    Tb_ApplyTable modelTable = (Tb_ApplyTable)mHelp.GetModelBy<Tb_ApplyTable>(m => m.UserID == user.UserID);
                    if (modelTable != null)//如果已经有过申请，不得再次申请
                    {
                        if (modelTable.IsPass == 0)//如果申请未通过，则进入未通过界面
                            return View("ApplySuccess");
                        else//如果通过，则进入软件下载界面
                            return RedirectToAction("SoftDownList");
                    }
                    else//如果没有申请，进入申请界面
                    {
                        return View("ApplyTable");
                    }
                }
                else//管理员用户
                {
                    return RedirectToAction("ApplyList");
                }
            }


            //跳转到ApplyList方法

        }
        #endregion

        #region 获取USER的通用方法+GetUser
        /// <summary>
        /// 获取user的通用方法
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public Tb_SoftUser GetUser(Tb_SoftUser userModel)
        {
            Tb_SoftUser user = db.Tb_SoftUser.Where(a => a.UserName == userModel.UserName && a.PassWord == userModel.PassWord).FirstOrDefault();
            return user;
        }
        #endregion

        #region 退出登录+loginOut
        public ActionResult loginOut()
        {
            TakeCookie.DelCookie("userId");
            return View("Index");
        }
        #endregion


        //#region 根据教师ID 获取他所有的课程信息+Courses
        //public ActionResult SoftList()
        //{
        //    //获取用户(教师)cookie，cookie存储是ID
        //    string teacherId = TakeCookie.GetCookie("userId");
        //    List<Course> listCourse = db.Course.Where(c => c.TeacherId == new Guid(teacherId)).ToList();
        //    ViewBag.Course = listCourse;
        //    return View();
        //}
        //#endregion

        //#region 根据课程Id 进入课程的每一个模块。如果是新建课程 则 每个模块 都是未完成状态+CoursesDetail
        //public ActionResult CoursesDetail(string[] id)
        //{
        //    int courseId = Convert.ToInt32(id[0]); //从用户请求中取出课程的id
        //    List<Module> listModule = db.Module.Where(m => m.CourseId == courseId).ToList();
        //    //完成课程的信息显示
        //        foreach (var lm in listModule)
        //        {
        //            if (lm.ModuleTag == 1)
        //                ViewBag.lm1 = lm;
        //            if (lm.ModuleTag == 2)
        //                ViewBag.lm2 = lm;
        //            if (lm.ModuleTag == 3)
        //                ViewBag.lm3 = lm;
        //            if (lm.ModuleTag == 4)
        //                ViewBag.lm4 = lm;
        //            if (lm.ModuleTag == 5)
        //                ViewBag.lm5 = lm;
        //        }

        //    return View();
        //}
        //#endregion

        //#region 新建课程+CourseNew ---增加课程简介
        ///// <summary>
        ///// 新建课程
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult CourseNew()
        //{
        //    return View();
        //}

        //public ActionResult AddNewCourse(Course course)
        //{
        //    string teacherId = TakeCookie.GetCookie("userId");
        //    course.CourseStatus = 0;
        //    course.TeacherId = new Guid(teacherId);
        //    ModelHelpers mHelp = new ModelHelpers();
        //    mHelp.Add<Course>(course);
        //    return RedirectToAction("CoursesDetail", new { id = course.Id });
        //}
        //#endregion

        //#region 删除课程+CoursesDelete
        //public ActionResult CoursesDelete(string[] id)
        //{
        //    int courseId = Convert.ToInt32(id[0]); //从用户请求中取出课程的id
        //    //完成课程的删除
        //    Course course = db.Course.Where(c => c.Id == courseId).FirstOrDefault();
        //    db.Set<Course>().Remove(course);
        //    db.SaveChanges();
        //    //返回Courses视图
        //    return RedirectToAction("Courses");
        //}
        //#endregion

    }
}
