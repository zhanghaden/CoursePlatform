using CommonClassLibrary;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers.User
{
    public class GeneralUserFunController : Controller
    {
        DBEntities db = new DBEntities();
        ModelHelpers mHelp = new ModelHelpers();





        #region 登入登出功能区

        #region 登陆首页 httpget模式
        //登陆首页action 
        [HttpGet]
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
                        return View("ApplyTable");
                    }
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

    }
}
