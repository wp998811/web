using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Library_TestLibrary : System.Web.UI.Page
{
    string saveName = "";
    string uploadPath = "";
    string savePath = "";

    Pdf2Swf pdf2swf = new Pdf2Swf();
    Office2Pdf office2pdf = new Office2Pdf();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //上传文件到服务器
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fullFileName = File1.PostedFile.FileName;
        //string fileType = File1.PostedFile.ContentType;//文件类型
        int fileLength = File1.PostedFile.ContentLength;//文件大小
        fullFileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);// 取出文件名的路径（不包括文件的名称） 
        /*
               //上传文件到服务器 
                string upload_file = Server.MapPath("./file/") + FileName;//取出服务器虚拟路径,存储上传文件 
         */
        //以日期建立文件夹
        string path = "\\Library\\file\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
        string ArticlePath = Server.MapPath("~") + path;

        if (fileLength > 0 || !string.IsNullOrEmpty(fullFileName))
        {
            //建立主文件夹
            if (!Directory.Exists(ArticlePath))
            {
                Directory.CreateDirectory(ArticlePath);
            }

            saveName = Path.GetFileName(fullFileName);
            //以时间重新命名上传文件
            string extension = Path.GetExtension(fullFileName).ToLower();

            string fileName = DateTime.Now.ToString("HH-mm-ss") + extension;
            ArticlePath += fileName;
            //保存文件
            this.File1.PostedFile.SaveAs(ArticlePath);

            //pdf、office文件处理
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

            uploadPath = path.Substring(1, path.Length - 1) + fileName;


            //更新数据库



        }
    }


}
