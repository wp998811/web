<%@ WebHandler Language="c#" Class="File_WebHandler" Debug="true" %>

using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

public class File_WebHandler : IHttpHandler, IRequiresSessionState
{
    private const int UploadFileLimit = 3;//上传文件数量限制

    private string _msg = "上传成功！";//返回信息

    string saveName = "";
    string savePath = "";
    Office2Pdf office2pdf = new Office2Pdf();
    Pdf2Swf pdf2swf = new Pdf2Swf();

    public void ProcessRequest(HttpContext context)
    {
        int iTotal = context.Request.Files.Count;

        if (iTotal == 0)
        {
            _msg = "没有数据";
        }
        else
        {

            for (int i = 0; i < iTotal; i++)
            {
                context.Session.Clear();
                HttpPostedFile file = context.Request.Files[i];
                
                string path = "\\Library\\file\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                string ArticlePath = System.Web.HttpContext.Current.Server.MapPath("~") + path;
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

                    string[] extensions = { ".doc", ".docx", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf" };
                    foreach (string item in extensions)
                    {
                        if (extension.Equals(item))
                        {
                            string pdfpath = ArticlePath.Substring(0, ArticlePath.Length - extension.Length) + ".pdf";
                            string swfpath = ArticlePath.Substring(0, ArticlePath.Length - extension.Length) + ".swf";

                            if (extension == ".doc" || extension == ".docx")
                            {
                                office2pdf.DOCConvertToPDF(ArticlePath, pdfpath);
                                pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
                            }
                            else if (extension == ".ppt" || extension == ".pptx")
                            {
                                office2pdf.PPTConvertToPDF(ArticlePath, pdfpath);
                                pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
                            }
                            else if (extension == ".xls" || extension == ".xlsx")
                            {
                                office2pdf.XLSConvertToPDF(ArticlePath, pdfpath);
                                pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
                            }
                            else if (extension == ".pdf")
                            {
                                pdf2swf.PDFConvertToSWF(ArticlePath, swfpath);
                            }

                            savePath = path.Substring(1, path.Length - 1) + fileName.Substring(0, fileName.Length - extension.Length) + ".swf";
                            context.Session["upPath"] = path.Substring(1, path.Length - 1) + fileName;
                        }
                    }
                    
             
                }
            }
            context.Session["savePath"] = savePath;
            context.Session["name"] = saveName;
        }
        
        context.Response.Write("<script>window.parent.Finish('" + _msg + "');</script>");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}