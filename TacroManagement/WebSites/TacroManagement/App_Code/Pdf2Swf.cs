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
    public Pdf2Swf()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void PDFConvertToSWF(string sourcePath, string targetPath)
    {
        //切记，使用pdf2swf.exe 打开的文件名之间不能有空格，否则会失败
        string cmdStr = HttpContext.Current.Server.MapPath("~/SWFTools/pdf2swf.exe");
        string source = @"""" + sourcePath + @"""";
        string target = @"""" + targetPath + @"""";
        //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
        string argsStr = "  -t " + source + " -s flashversion=9 -o " + target;
        ExcutedCmd(cmdStr, argsStr);
    }

    private static void ExcutedCmd(string cmd, string args)
    {
        using (Process p = new Process())
        {
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            p.StartInfo = psi;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }
    }
}
