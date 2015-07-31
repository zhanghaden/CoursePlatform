using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary
{
    /// <summary>
    /// 本类是关于文件的相关方法
    /// </summary>
    class FileHelper
    {

        /// <summary>
        /// 删除文件夹,文件
        /// </summary>
        /// <param name="DirPath">文件夹路径</param>
        /// <param name="FilePath">文件路径</param>
        /// <returns>删除</returns>
        /// /// CreateTime:2007-03-28 Code By DengXi    
        public static void DelFile(string DirPath, string FilePath)
        {
            try
            {
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                if (System.IO.Directory.Exists(DirPath))
                {
                    System.IO.Directory.Delete(DirPath);
                }
            }
            catch { }
        }
    }
}
