using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Web.Routing;
using System.Text;
using CommonClassLibrary;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using CoursePlatForm.Common;
using System.IO;
using CourseCenter.Common;

namespace CoursePlatForm.Controllers
{
    /// <summary>
    /// 该类是用于软件捐赠系统的全部控制器
    /// </summary>
    public class SoftDownController : Controller
    {
        //下面两行用于数据库的操作，第一行为数据库对象实体，第二行为模型帮助类，两个均可以实现数据库的操作，在action之外声明，方便所有方法调用，避免多次new
        DBEntities db = new DBEntities();
        ModelHelpers mHelp = new ModelHelpers();

        #region 普通用户功能区



        #region 第一步，填写申请表
        /// <summary>
        /// 显示申请表表单
        /// </summary>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
        public ActionResult ApplyTable()
        {
            //这句用于选择出要用的字段项
            var listShowAppTable =
                from n in db.Tb_FieldTable
                where n.IsUse == 1
                select n;
            ViewBag.list = listShowAppTable.ToList<Tb_FieldTable>();
            ////下面的sql用于拼接为查询字符串，从而滤掉不用的字段，实现字段编辑效果
            //string strSql = "select ";
            //mHelp.SqlQuery<Tb_ApplyTable>("", new SqlParameter("@Id", id));
            return View();
        }

        /// <summary>
        /// 执行申请表表单的提交
        /// </summary>
        /// <param name="ApplyTable"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [CheckAccount(Roles = "user")]
        public ActionResult ApplyTable(Tb_ApplyTable ApplyTable)
        {
            ApplyTable.RecordTime = DateTime.Today;
            ApplyTable.UserID = int.Parse(TakeCookie.GetCookie("userId"));
            ApplyTable.IsPass = 0;
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

        #endregion


        #region 第二步，选择软件项
        /// <summary>
        /// 所有软件列表，供用户选择
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
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
        [CheckAccount(Roles = "user")]
        public ActionResult SoftList(string[] CheckSoft)
        {
            StringBuilder softs = new StringBuilder();
            foreach (string item in CheckSoft)
            {
                softs.Append(item + ",");
            }

            return RedirectToAction("SoftUse", new { dict = softs.ToString().Substring(0, softs.ToString().Length - 1) });
        }
        #endregion


        #region 第三步，填写用软件开设的课程
        /// <summary>
        /// 显示已选择的软件，并生成表单
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
        public ActionResult SoftUse(string dict)
        {
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
        [CheckAccount(Roles = "user")]
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
            return View("AddSoftCourse");
        }

        #endregion


        #region 第四步，填写已有的信息技术课程

        /// <summary>
        /// 显示课程设置表项的提交表单
        /// </summary>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
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
        [CheckAccount(Roles = "user")]
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
                return RedirectToAction("ApplySuccess");
                //return View("ApplySuccess");
            }
            else
            {
                return View();
            }

        }

        #endregion

        #region 第五步，软件申请成功后等待审核的页面+管理已添加的申请表功能
        /// <summary>
        /// 软件申请成功后等待审核的页面
        /// </summary>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
        public ActionResult ApplySuccess()
        {
            int id = int.Parse(TakeCookie.GetCookie("userId"));
            Tb_ApplyTable model = (Tb_ApplyTable)mHelp.GetModelBy<Tb_ApplyTable>(m => m.UserID == id);
            if (model != null)
            {
                ViewBag.appID = model.ApplyID;
            }
            return View();
        }


        #region 功能一:编辑已填写的申请表

        /// <summary>
        /// 显示某用户申请表的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ApplyDetail(int id)
        {
            //用于显示申请表的信息
            //先把字段列清楚
            var listShowAppTable =
                    from n in db.Tb_FieldTable
                    where n.IsUse == 1
                    select n;
            ViewBag.listShowAppTable = listShowAppTable.ToList<Tb_FieldTable>();
            Tb_ApplyTable applyTableModel = db.Tb_ApplyTable.Where(c => c.ApplyID == id).FirstOrDefault();
            //applyTableModel
            //调用对象转dictionary方法完成转换
            Dictionary<string, object> dic = ConvertDict.ToMap(applyTableModel);
            ViewBag.dic = dic;
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

        //
        // GET: 

        public ActionResult EditApplyTable(int id = 0)
        {
            //先把字段列清楚
            var listShowAppTable =
                    from n in db.Tb_FieldTable
                    where n.IsUse == 1
                    select n;
            ViewBag.listShowAppTable = listShowAppTable.ToList<Tb_FieldTable>();
            Tb_ApplyTable applyTableModel = db.Tb_ApplyTable.Where(c => c.ApplyID == id).FirstOrDefault();
            //applyTableModel
            //调用对象转dictionary方法完成转换
            Dictionary<string, object> dic = ConvertDict.ToMap(applyTableModel);
            ViewBag.dic = dic;
            if (applyTableModel == null)
            {
                return HttpNotFound();
            }
            return View(applyTableModel);
        }

        //
        // POST: 

        [HttpPost]
        public ActionResult EditApplyTable(Tb_ApplyTable tb_applytable)
        {
            //对于不能由用户填写的字段手动赋值
            tb_applytable.RecordTime = DateTime.Now;
            tb_applytable.IsPass = 0;
            tb_applytable.UserID = int.Parse(TakeCookie.GetCookie("userId"));
            db.Entry(tb_applytable).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ApplySuccess", "SoftDown");
        }
        #endregion


        #region 功能二:编辑已选择的软件信息  增删改


        //
        // GET: /Default1/Create

        public ActionResult CreateSelectSoft(int id)
        {
            ViewBag.appID = id;
            ViewData["SoftID"] = new SelectList(db.Tb_SoftList, "SoftID", "SoftName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSelectSoft(Tb_ApplySoftList tb_applysoftlist)
        {
            //tb_applysoftlist.ApplyID=Request.Form["ApplyID"]
            if (ModelState.IsValid)
            {
                db.Tb_ApplySoftList.Add(tb_applysoftlist);
                db.SaveChanges();
                return RedirectToAction("ApplyedSoftList", new { id = tb_applysoftlist.ApplyID });
            }

            return View(tb_applysoftlist);
        }


        /// <summary>
        /// 用于申请成功后显示已申请的软件，供用户编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ApplyedSoftList(int id = 0)
        {
            var queryApplySoftList =
                    from n in db.Tb_ApplySoftList
                    from m in db.Tb_SoftList
                    where n.ApplyID == id && n.SoftID == m.SoftID
                    select new ApplyDetail()
                    {
                        appSoftModel = n,
                        SoftModel = m
                    };
            ViewBag.appID = id;
            return View(queryApplySoftList.ToList<ApplyDetail>());
        }


        //
        // GET: /Default1/Edit/5

        public ActionResult EditApplySoftList(int id = 0)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            if (tb_applysoftlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.appID = tb_applysoftlist.ApplyID;
            return View(tb_applysoftlist);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditApplySoftList(Tb_ApplySoftList tb_applysoftlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_applysoftlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ApplyedSoftList", new { id = tb_applysoftlist.ApplyID });
            }
            return View(tb_applysoftlist);
        }


        public ActionResult DeleteApplySoftList(int id)
        {
            Tb_ApplySoftList tb_applysoftlist = db.Tb_ApplySoftList.Find(id);
            db.Tb_ApplySoftList.Remove(tb_applysoftlist);
            db.SaveChanges();
            return RedirectToAction("ApplyedSoftList", new { id = tb_applysoftlist.ApplyID });
        }
        #endregion

        #region 功能三:用户添加的课程列表的增删改

        /// <summary>
        /// 已添加课程列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SoftCourseList(int id)
        {
            var querySoftCourseList =
                from n in db.Tb_SoftCourse
                where n.ApplyID == id
                select n;
            ViewBag.appID = id;
            //ViewBag.SoftCourseList = querySoftCourseList;
            return View(querySoftCourseList.ToList<Tb_SoftCourse>());
        }



        //
        // GET: /Default1/Create

        public ActionResult CreateSoftCourse(int id)
        {
            ViewBag.appID = id;
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSoftCourse(Tb_SoftCourse tb_softcourse)
        {
            if (ModelState.IsValid)
            {
                db.Tb_SoftCourse.Add(tb_softcourse);
                db.SaveChanges();
                return RedirectToAction("SoftCourseList", new { id = tb_softcourse.ApplyID });
            }

            return View(tb_softcourse);
        }


        //
        // GET: /Default1/Edit/5

        public ActionResult EditSoftCourse(int id = 0)
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
        public ActionResult EditSoftCourse(Tb_SoftCourse tb_softcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_softcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SoftCourseList", new { id = tb_softcourse.ApplyID });
            }
            return View(tb_softcourse);
        }


        public ActionResult DeleteSoftCourse(int id)
        {
            Tb_SoftCourse tb_softcourse = db.Tb_SoftCourse.Find(id);
            db.Tb_SoftCourse.Remove(tb_softcourse);
            db.SaveChanges();
            return RedirectToAction("SoftCourseList", new { id = tb_softcourse.ApplyID });
        }
        #endregion

        #endregion

        #region 第六步，经过管理员审核后，显示可供下载的软件列表
        /// <summary>
        /// 用于显示软件下载列表
        /// </summary>
        /// <returns></returns>
        [CheckAccount(Roles = "user")]
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

        #endregion


        #endregion

        #region admin功能区+ApplyList()+ApplyDetail(int id)+ChangePass(int id)
        /// <summary>
        /// 显示申请的列表，管理员页面
        /// </summary>
        /// <returns></returns>
        /// 
        [CheckAccount(Roles = "admin")]
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
        public ActionResult AdminApplyDetail(int id)
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
        [CheckAccount(Roles = "admin")]
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
        /// 导入excel表数据
        /// </summary>
        /// <returns></returns>
        ///get
        [CheckAccount(Roles = "admin")]
        public ActionResult ImportApplyData()
        {
            return View();
        }

        public bool CheckFileType(string fileName)//判断类型是否是excel
        {
            string ext = Path.GetExtension(fileName);
            if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 导入excel表数据（1.读取excel 2.获得数据表条数 3.按照表格中的数据条数生成User账户 4.写入ApplyTable数据表数据）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CheckAccount(Roles = "admin")]
        public ActionResult ImportApplyData(FormCollection form)
        {
            UpLoad upFile = new UpLoad();
            string fileName = Request.Files["fileExcel"].FileName;

            if (CheckFileType(fileName))//检查上传文件的类型
            {
                string path = upFile.SaveFile(Request.Files["fileExcel"]);

                NPOIHelper.path = path;
                //获取到excel的行数
                int rowNum = NPOIHelper.getRowNum();
                //循环行数次，添加相同数量账户进user表
                for (int i = 1; i <= rowNum; i++)
                {
                    try
                    {
                        Tb_SoftUser SoftUser = new Tb_SoftUser()
                        {
                            UserName = GenerateUser.RandomLoginName(),
                            PassWord = GenerateUser.RandomPassword(),
                            UserType = 2
                        };
                        db.Tb_SoftUser.Add(SoftUser);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                //SaveChanges方法可以在上面多次执行数据库操作时缓存，最后一次性写入数据库
                db.SaveChanges();
                //在保存入数据库后，获得了userID，可以进一步把数据存入ApplyTable，按照最新添加的记录条数来看
                List<Tb_SoftUser> listNewUser = mHelp.GetListBy<Tb_SoftUser>(m => m.UserType == 2);
                //获得最后添加的UserType=2的，rowNum行数据，认为是新添加的user
                listNewUser = listNewUser.GetRange(listNewUser.Count - rowNum, rowNum);
                var listShowAppTable =
                    from n in db.Tb_FieldTable
                    where n.IsUse == 1
                    select n;
                List<Tb_FieldTable> listField = listShowAppTable.ToList<Tb_FieldTable>();
                int rowAffact = NPOIHelper.RenderToDb(listField, listNewUser);
                if (rowAffact != 0)
                {
                    return RedirectToAction("ApplyList");
                }
                else
                    return View();
            }
            return View();
            
        }

        #endregion

        #region 登入登出功能区

        #region 登陆首页 httpget模式
        //登陆首页action 
        [HttpGet]
        //[Common.Skip]
        public ActionResult Index()
        {
            TakeCookie.DelCookie("userId");
            TakeCookie.DelCookie("userRole");
            ViewBag.title = "登陆页面";
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
                    TakeCookie.SetCookie("userRole", "user");
                    Tb_ApplyTable modelTable = (Tb_ApplyTable)mHelp.GetModelBy<Tb_ApplyTable>(m => m.UserID == user.UserID);
                    if (modelTable != null)//如果已经有过申请，不得再次申请
                    {
                        if (modelTable.IsPass == 0)//如果申请未通过，则进入未通过界面
                            return RedirectToAction("ApplySuccess");
                        else//如果通过，则进入软件下载界面
                            return RedirectToAction("SoftDownList");
                    }
                    else//如果没有申请，进入申请界面
                    {
                        return RedirectToAction("ApplyTable");
                    }
                }
                else if (user.UserType == 2)//导入的用户
                {
                    TakeCookie.SetCookie("userRole", "user");
                    Tb_ApplyTable modelTable = (Tb_ApplyTable)mHelp.GetModelBy<Tb_ApplyTable>(m => m.UserID == user.UserID);
                    if (modelTable != null)//如果不为空，意味着可以编辑
                    {
                        if (modelTable.IsPass == 0)//如果申请未通过，则进入编辑界面
                            return RedirectToAction("EditApplyTable", new { id = modelTable.ApplyID });
                        else//如果通过，则进入软件下载界面
                            return RedirectToAction("SoftDownList");
                    }
                    else
                        return View("Index");
                }
                else//管理员用户
                {
                    TakeCookie.SetCookie("userRole", "admin");
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
            TakeCookie.DelCookie("userRole");
            return View("Index");
        }
        #endregion

        #endregion


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }


}
