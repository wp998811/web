using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using BLL;
using Model;

public partial class web_UploadDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string filePath = FileUpload1.PostedFile.FileName;
        if (filePath.Length <=0)
        {
            Response.Write("<script   language=javascript> window.alert( ' 请选择需要上传的文件 '); </script>");
        }
        string docName = DocNameText.Text.Trim();
        string docDescription = DocDescription.Text.Trim();
        string docKey = DocKeyText.Text.Trim();

        if (DocRadioButtonList.SelectedValue == "Document")
        {
            string docVersion = DocVersionText.Text.Trim();
            string departID =DepartName.SelectedValue;
            string docCateID = DocCate.SelectedValue;
            string downloadPremission = DownLoadPremission.SelectedValue;
            string docState = DocState.SelectedValue;


            Document document = new Document();
            bool isAdd = document.AddDocument(docName, docVersion, docKey, docDescription, "2", "12", docState, downloadPremission, "1");

            if (isAdd)
            {//数据库插入成功
                string fileName = docName;

                if (docName.IndexOf('.') == -1)
                {
                    //Response.Write("<script   language=javascript> window.alert( ' 请文件名后缀 '); </script>");
                    fileName = fileName + "." + filePath.Substring(filePath.LastIndexOf(".") + 1);
                }
               bool isUpload = UploadDocument(fileName);
               if (!isUpload)
                { //上传失败
                    document.DeleteDocumentByName(docName);
                }
            }
        
        }
        else
        {
            string projectID = ProjectName.SelectedValue;
            string subTaskID = SubTaskName.SelectedValue;
            string projectDocCate = ProjectDocCate.SelectedValue;

        }
    }

    private bool UploadDocument(string fileName)
    {
        string filePath = FileUpload1.PostedFile.FileName;
        if (filePath.Trim().Length > 0)
        {
            //string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            string serverFileName = Server.MapPath(@"~/") +"Documents\\"+ fileName;
            if (System.IO.File.Exists(serverFileName))
            {
                Response.Write("<script   language=javascript> window.alert( ' 上传失败，文件已存在  '); </script>");
                return false;
            }
            else
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(serverFileName);
                        Response.Write("<script   language=javascript> window.alert( ' 上传成功  '); </script>");
                        return true;
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<script   language=javascript> window.alert( ' 上传失败" + exc + "  '); </script>");
                       return false;
                    }
                }
                return false;
            }
        }
        Response.Write("<script   language=javascript> window.alert( ' 请选择需要上传的文件 '); </script>");
        return false;
    }
}
