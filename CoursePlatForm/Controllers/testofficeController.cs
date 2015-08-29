using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CoursePlatForm.Common;

namespace CoursePlatForm.Controllers
{

    public class testofficeController : Controller
    {
        private int UploadFileLimit = 1;//上传文件数量限制

        private string _msg = "上传成功！";//返回信息

        string saveName = "";
        string savePath = "";

        //
        // GET: /testoffice/

        public ActionResult Index()
        {
            int iTotal = Request.Files.Count;

            if (iTotal == 0)
            {
                _msg = "没有数据";
            }
            else
            {
                Session.Clear();
                HttpPostedFileBase file = Request.Files[0];
                string path = "\\Manage\\WenKu2\\file\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                string ArticlePath = Server.MapPath("~") + path;
                if (file.ContentLength > 0 || !string.IsNullOrEmpty(file.FileName))
                {
                    //建立图片主文件夹
                    if (!Directory.Exists(ArticlePath))
                    {
                        Directory.CreateDirectory(ArticlePath);
                    }
                    saveName = Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    string fileName = DateTime.Now.ToString("HH-mm-ss") + extension;
                    ArticlePath += fileName;
                    //保存文件
                    file.SaveAs(ArticlePath);
                    string pdfpath = ArticlePath.Substring(0, ArticlePath.Length - extension.Length) + ".pdf";
                    string swfpath = ArticlePath.Substring(0, ArticlePath.Length - extension.Length) + ".swf";
                    if (extension == ".doc" || extension == ".docx")
                    {
                        Office2Pdf.DOCConvertToPDF(ArticlePath, pdfpath);
                        Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                    }
                    else if (extension == ".ppt" || extension == ".pptx")
                    {
                        Office2Pdf.PPTConvertToPDF(ArticlePath, pdfpath);
                        Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                        //pdf2swf.PDFConvertToSWF("G:/doc.pdf", " G:/1.swf");
                    }
                    else if (extension == ".xls" || extension == ".xlsx")
                    {
                        Office2Pdf.XLSConvertToPDF(ArticlePath, pdfpath);
                        Pdf2Swf.PDFToSWF(pdfpath, swfpath);
                    }
                    else if (extension == ".pdf")
                    {
                        Pdf2Swf.PDFToSWF(ArticlePath, swfpath);
                    }
                    //savePath = path.Substring(1, path.Length - 1) + fileName.Substring(0, fileName.Length - extension.Length) + ".swf";
                    //Session["upPath"] = path.Substring(1, path.Length - 1) + fileName;
                }
            }

            return View();
        }

        public ActionResult testoffice()
        {
            return View();
        }


    }
}
