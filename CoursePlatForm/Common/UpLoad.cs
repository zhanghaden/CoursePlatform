using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CourseCenter.Common
{
    public class UpLoad
    {
        /// <summary>
        /// 上传文件方法
        /// </summary>
        /// <param name="hfc">http上传文件集合</param>
        /// <returns>返回上传路径</returns>
        public string SaveFile(HttpPostedFileBase hpf)
        {
            string extentionName = Path.GetExtension(hpf.FileName);
            string path = "../ExcelFile/" + System.Guid.NewGuid().ToString() +extentionName;
            string serverPath = HttpContext.Current.Request.MapPath(path);
            hpf.SaveAs(serverPath);
            return serverPath;
        }
    }
}