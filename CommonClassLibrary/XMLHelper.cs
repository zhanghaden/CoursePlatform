using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonClassLibrary
{
    class XMLHelper
    {
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="strTarget">节点名</param>
        /// <returns></returns>
        public static string readparamConfig(string strTarget)
        {
            string rstr = "";
            string xmlPath = HttpContext.Current.Server.MapPath("~/xml/sys/base.config");
            FileInfo finfo = new FileInfo(xmlPath);
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(strTarget);
            rstr += elemList[0].InnerXml;
            return rstr;
        }


        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="strTarget">接点名</param>
        /// <returns></returns>
        public static void SaveXmlConfig(string strTarget, string strValue, string strSource)
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/" + strSource);
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(strTarget);
            elemList[0].InnerXml = strValue;
            xdoc.Save(xmlPath);
        }

    }
}
