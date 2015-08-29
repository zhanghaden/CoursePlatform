using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;

/// <summary>
/// Pdf2Swf 将pdf转化为swf
/// </summary>
public class Pdf2Swf
{
    private static string toolPah = System.Web.HttpContext.Current.Server.MapPath("~/FlexPaper/pdf2swf.exe");
    public Pdf2Swf()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 把PDF文件转化为SWF文件
    /// </summary>
    /// <param name="toolPah">pdf2swf工具路径</param>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="targetPath">目标文件路径</param>
    /// <returns>true=转化成功</returns>
    public static bool PDFToSWF( string sourcePath, string targetPath)
    {
        Process pc = new Process();
        bool returnValue = true;

        string cmd = toolPah;
        string args = " -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
        try
        {
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            pc.StartInfo = psi;
            pc.Start();
            pc.WaitForExit();
        }
        catch (Exception ex)
        {
            returnValue = false;
            throw new Exception(ex.Message);
        }
        finally
        {
            pc.Close();
            pc.Dispose();
        }
        return returnValue;
    }

}
