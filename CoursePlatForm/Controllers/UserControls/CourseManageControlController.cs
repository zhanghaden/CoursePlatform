using Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers.ViewControls
{
    /// <summary>
    /// 课程管理模块视图控件控制器
    /// </summary>
    public class CourseManageControlController : Controller
    {
        

        DBEntities db = new DBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CityDynamic()
        {
            return View();
        }

        public string GetCityList(string nodeid, string type1)
        {
            string paramnodeid = Universal.ConvertNullToEmpty(nodeid);
            int nodeid_d = int.Parse(paramnodeid);
            string paramtype1 = Universal.ConvertNullToEmpty(type1);
            string json = "";
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(nodeid))
            {
                StringBuilder strList = new StringBuilder();
                List<Tb_City> citys = new List<Tb_City>();
                if (paramtype1 == "region")
                {
                    var queryNode =
                        from n in db.Tb_City
                        where n.Area == nodeid_d
                        orderby n.CityID
                        select n;
                    citys = queryNode.ToList<Tb_City>();//查区域用
                }
                else
                {
                    var queryNode =
                        from n in db.Tb_City
                        where n.ParentID == nodeid_d
                        orderby n.CityID
                        select n;
                    citys = queryNode.ToList<Tb_City>();//查其他用
                }

                if (!string.IsNullOrEmpty(paramtype1))
                {
                    if (paramtype1 == "region")
                    {
                        paramtype1 = "province";
                    }
                    else if (paramtype1 == "province")
                    {
                        paramtype1 = "city";
                    }
                    else if (paramtype1 == "city")
                    {
                        paramtype1 = "area";
                    }
                }
                if (citys != null && citys.Count > 0)
                {
                    foreach (Tb_City item in citys)
                    {
                        strList.Append("<option nodeid=\"" + item.CityID + "\" class='chkip'  type1='" + paramtype1 + "'>" + item.CityName + "</option>");
                    }
                }
                ht.Add("success", true);
                ht.Add("msg", "操作成功");
                ht.Add("content", strList.ToString());
                json = JsonConvert.SerializeObject(ht);
                ViewBag.json = json;
            }
            return json;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
