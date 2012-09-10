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
using System.IO;
using System.Text;


using System.Collections.Generic;
using BLL;
using Model;

public partial class web_ExplorePicAndTxt : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
       if (!IsPostBack)
       {
           string url = Request.QueryString["emotion"];
           string extension = Path.GetExtension(url);
           if (extension ==".txt")
           {
               ShowImage.Visible = false;
               ShowText.Text = File.ReadAllText(Server.MapPath(@"./") +"" +url, UnicodeEncoding.GetEncoding("GB2312"));
           }
           else
           {
               ShowText.Visible = false;
               ShowImage.ImageUrl = url;
           }


           int docID = Convert.ToInt32(Request.QueryString["DocID"]);
           string documentCate = Request.QueryString["DocumentCate"];
           DocID.Value = Convert.ToString(docID);

           if (documentCate == "Document")
           {

               InitDocument(docID);
           }
           else
           {
               InitProjectDoc(docID);
           }
       }
    }


    private void InitProjectDoc(int docID)
    {
        DocumentCate.Text = "项目文档";
        ProjectDoc projectDoc = new ProjectDoc();
        ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(docID);

        DocName.Text = projectDocInfo.DocName;
        DocKey.Text = projectDocInfo.DocKey;
        DocDescription.Text = projectDocInfo.DocDescription;
        DocCate.Text = projectDocInfo.ProjDocCate;
        UploadTime.Text = projectDocInfo.UploadTime;

        SubTask subTask = new SubTask();
        SubTaskInfo subTaskInfo = subTask.GetSubTaskById(projectDocInfo.TaskId);
        SubTaskName.Text = subTaskInfo.TaskName;

        User user = new User();
        UserInfo userInfo = user.GetUserById(projectDocInfo.UploadUserId);
        UploadUser.Text = userInfo.UserName;

        int download = projectDocInfo.DocPermission;
        if (download == 1)
        {
            DownloadPremission.Text = "所有用户";
        }
        else if (download == 2)
        {
            DownloadPremission.Text = "本部门用户";
        }
        else if (download == 3)
        {
            string str = "自定义用户：";
            ProjectDocUser projectDocUser = new ProjectDocUser();
            IList<ProjDocUserInfo> projDocUserInfo = projectDocUser.GetProjDocUserByDocId(docID);
            for (int i = 0; i < projDocUserInfo.Count; ++i)
            {
                str = str + " " + user.GetUserById(Convert.ToInt32(projDocUserInfo[i].UserId)).UserName;
            }
            DownloadPremission.Text = str;
        }
        文档版本.Visible = false;
        所属部门.Visible = false;
        文档状态.Visible = false;

    }

    private void InitDocument(int docID)
    {
        DocumentCate.Text = "资料库";
        Document document = new Document();
        DocumentInfo documentInfo = document.GetDocumentById(docID);

        DocName.Text = documentInfo.DocName;
        DocVersion.Text = documentInfo.DocVersion;
        DocKey.Text = documentInfo.DocKey;
        DocDescription.Text = documentInfo.DocDescription;
        DocState.Text = documentInfo.DocState;
        UploadTime.Text = documentInfo.UploadTime;

        Department department = new Department();
        DepartmentInfo departmentInfo = department.GetDepartmentByID(documentInfo.DepartID);
        DepartName.Text = departmentInfo.DepartName;

        DepartDocCate departDocCate = new DepartDocCate();
        DepartDocCateInfo departDocCateInfo = departDocCate.GetDepartDocCateById(documentInfo.DocCategoryID);
        DocCate.Text = departDocCateInfo.CategoryName;

        User user = new User();
        UserInfo userInfo = user.GetUserById(documentInfo.UploadUserID);
        UploadUser.Text = userInfo.UserName;

        int download = documentInfo.DocPermission;
        if (download == 1)
        {
            DownloadPremission.Text = "所有用户";
        }
        else if (download == 2)
        {
            DownloadPremission.Text = "本部门用户";
        }
        else if (download == 3)
        {
            string str = "自定义用户：";
            DocUser docUser = new DocUser();
            IList<DocUserInfo> docUserInfos = docUser.GetDocUserByDocId(docID);
            for (int i = 0; i < docUserInfos.Count; ++i)
            {
                str = str + " " + user.GetUserById(docUserInfos[i].UserID).UserName;
            }
            DownloadPremission.Text = str;
        }
        项目子任务.Visible = false;

    }
    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        bool isDocument = false;
        if (DocumentCate.Text == "资料库")
        {
            isDocument = true;
        }
        string docID = DocID.Value;
        //查看下载权限是否允许
        string docName = null;
        string uploadPath = null;
        if (isDocument)
        {
            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
            if (!document.isPremissionToDownload(documentInfo.DocPermission, documentInfo.DocID, 1))
            {
                Response.Write("<script   language=javascript> window.alert( '   下载权限不够，无法下载  '); </script>");
                return;
            }
            docName = documentInfo.DocName;
            uploadPath = documentInfo.UploadPath;
        }
        else
        {
            ProjectDoc projectDoc = new ProjectDoc();
            ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
            if (!projectDoc.isPremissionToDownload(projectDocInfo.DocPermission, projectDocInfo.ProjDocId, 1))
            {
                Response.Write("<script   language=javascript> window.alert( '   下载权限不够，无法下载  '); </script>");
                return;
            }
            docName = projectDocInfo.DocName;
            uploadPath = projectDocInfo.UploadPath;
        }

        //获取后缀名
        string fileName = docName;
        fileName = fileName + "." + uploadPath.Substring(uploadPath.LastIndexOf(".") + 1);

        Response.Clear();
        Response.Buffer = true;
        // Response.ContentType = "text/xml/rmvb";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.WriteFile(Server.MapPath("~/") + uploadPath);
        Response.End();

    }
   
}
