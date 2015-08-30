using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Models;

namespace CoursePlatForm.Common
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
            string path = "../ExcelFile/" + System.Guid.NewGuid().ToString() + extentionName;
            string serverPath = HttpContext.Current.Request.MapPath(path);
            hpf.SaveAs(serverPath);
            return serverPath;
        }

        /// <summary>
        /// 用于多文件上传的操作
        /// </summary>
        /// <param name="hfc"></param>
        /// <returns></returns>
        public static Tb_Resource MutifileUp(HttpFileCollectionBase hfc)
        {
            ModelHelpers mhelp = new ModelHelpers();
            if (hfc.Count > 0)
            {
                Tb_Resource model = new Tb_Resource();
                try
                {
                    #region 对上传的文件进行初始化的新建文件夹操作，包括建立当前日期的三个文件夹，origin，pdf，swf
                    //下面一句用于生成一个带日期的文件夹
                    string BasePath = HttpContext.Current.Server.MapPath("~") + "file\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                    string PDFFoldPath = "PDF\\";//存放PDF文件的文件夹路径
                    string swfFoldPath = "swf\\";//存放swf文件的文件夹路径
                    //判断文件夹是否存在并创建文件夹
                    if (!Directory.Exists(BasePath + "origin\\"))
                    {
                        Directory.CreateDirectory(BasePath + "origin\\");
                    }
                    if (!Directory.Exists(BasePath + "PDF\\"))
                    {
                        Directory.CreateDirectory(BasePath + "PDF\\");
                    }
                    if (!Directory.Exists(BasePath + "swf\\"))
                    {
                        Directory.CreateDirectory(BasePath + "swf\\");
                    }
                    #endregion

                    Tb_ResourceType modelType = new Tb_ResourceType();

                    string pdfpath;
                    string swfpath;
                    string fileName;
                    string strType = "";
                    HttpPostedFileBase hpf = hfc[0];
                    string extension = Path.GetExtension(hpf.FileName).ToLower();
                    if (extension != ".mp4" && extension != ".wmv" && extension != ".avi" && extension != ".rmvb" && extension != ".mov" && extension != ".mpeg" && extension != ".mpg" && extension != ".qt" && extension != ".ram" && extension != ".ram" && extension != ".asf")//如果是视频文件，禁止上传
                    {
                        if (hpf.ContentLength > 0 && hpf.ContentLength <= 3 * 1024 * 1024)//如果文件为空或大小过长3M禁止上传
                        {
                            string name = hpf.FileName;
                            if (!string.IsNullOrEmpty(name))
                            {
                                if (name.Contains("."))//如果有后缀
                                {
                                    //判断是office文件，就执行下面操作
                                    if (extension == ".doc" || extension == ".docx" || extension == ".xls" || extension == ".xls" || extension == ".xlsx" || extension == ".ppt" || extension == ".pptx" || extension == ".pdf")
                                    {
                                        fileName = System.Guid.NewGuid().ToString();
                                        PDFFoldPath = BasePath + PDFFoldPath;
                                        swfFoldPath = BasePath + swfFoldPath;
                                        BasePath += "origin\\" + fileName + extension;
                                        hpf.SaveAs(BasePath);
                                        pdfpath = PDFFoldPath + fileName + ".pdf";
                                        swfpath = swfFoldPath + fileName + ".swf";
                                        //将model字段赋值
                                        model.PDFPath = pdfpath;
                                        model.swfPath = swfpath;
                                        model.ResourcePath = BasePath;
                                        model.RecordTime = DateTime.Now;
                                        model.ResourceName = name;
                                        
                                        //下面判断是哪种office文件后执行转换操作
                                        if (extension == ".doc" || extension == ".docx")
                                        {
                                            strType = "Word";
                                            Office2Pdf.DOCConvertToPDF(BasePath, pdfpath);
                                            Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                                        }
                                        else if (extension == ".ppt" || extension == ".pptx")
                                        {
                                            strType = "PPT";
                                            Office2Pdf.PPTConvertToPDF(BasePath, pdfpath);
                                            Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                                        }
                                        else if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            strType = "Excel";
                                            Office2Pdf.XLSConvertToPDF(BasePath, pdfpath);
                                            Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                                        }
                                        else if (extension == ".pdf")
                                        {
                                            strType = "PDF";
                                            Pdf2Swf.PDFToSWF(BasePath, swfpath);
                                        }
                                        model.IsConvertFinish = true;
                                    }
                                    else//如果不是office文件，不用经过转换，直接存储
                                    {
                                        fileName = System.Guid.NewGuid().ToString();
                                        BasePath += "origin\\" + fileName + extension;
                                        hpf.SaveAs(BasePath);
                                        //将model字段赋值
                                        model.ResourcePath = BasePath;
                                        model.RecordTime = DateTime.Now;
                                        model.ResourceName = name;
                                        model.IsConvertFinish = false;
                                        strType = extension.Substring(extension.IndexOf('.')+1);
                                    }
                                    modelType = (Tb_ResourceType)mhelp.GetModelBy<Tb_ResourceType>(m => m.ResourceType == strType);

                                    if (modelType != null)
                                    {
                                        model.ResourceTypeID = modelType.ResourceTypeID;
                                    }

                                    return model;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;

        }



    }
}