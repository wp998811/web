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

using System.Collections.Generic;
using BLL;
using Model;

public partial class web_AdvancedSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //初始化部门
        if (!IsPostBack)
        {
          //  DocRadioButtonList.SelectedValue = "Document";
            InitDocCate();
            InitProjectDoc();
        }
 
    }

    private void InitProjectDoc()
    {
        Project project = new Project();
        IList<ProjectInfo> projectInfos = project.GetProjects();

        ProjectName.Items.Clear();
        ProjectName.Items.Add(new ListItem("选择项目","0"));

        for (int i = 0; i < projectInfos.Count;++i )
        {
            ListItem listItem = new ListItem();
            listItem.Value = projectInfos[i].ProjectNum;
            listItem.Text = projectInfos[i].ProjectName;
            ProjectName.Items.Add(listItem);
        }

        if (ProjectName.Items.Count <=0)
        {
            return;
        } 
        ProjectName.SelectedIndex = 0;

        SubTask subTask = new SubTask();
        IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(ProjectName.SelectedValue);
        SubTaskName.Items.Clear();
        SubTaskName.Items.Add(new ListItem("选择子任务", "0"));

        for (int i = 0; i < subTaskInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(subTaskInfos[i].TaskId);
            listItem.Text = subTaskInfos[i].TaskName;
            SubTaskName.Items.Add(listItem);
        }

        if (SubTaskName.Items.Count >= 0)
        {
            SubTaskName.SelectedIndex = 0;
        }
    }

    private void InitDocCate()
    {
        Department department = new Department();
        IList<DepartmentInfo> departmentInfos = department.GetDepartments();
        DepartName.Items.Clear();
        DepartName.Items.Add(new ListItem("选择部门", "0"));
        for (int i = 0; i < departmentInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Text = departmentInfos[i].DepartName;
            listItem.Value = Convert.ToString(departmentInfos[i].DepartID);
            DepartName.Items.Add(listItem);
        }
        if (DepartName.Items.Count <= 0)
        {
            return;
        }
        DepartName.SelectedIndex = 0;

        DepartDocCate departDocCate = new DepartDocCate();
        IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(Convert.ToInt32(DepartName.SelectedItem.Value));
        for (int i = 0; i < departDocCateInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(departDocCateInfos[i].Id);
            listItem.Text = departDocCateInfos[i].CategoryName;
            DocCate.Items.Add(listItem);
        }
        if (DocCate.Items.Count >= 1)
        {
            DocCate.SelectedIndex = 0;
        }
    }
    protected void AdvancedSearchButton_Click(object sender, EventArgs e)
    {
        string docName = DocNameText.Text.Trim();
        string docKey = DocKeyText.Text.Trim();
        string uploadUserName = UploadUserName.Text.Trim();
        string uploadTimeBegin = UploadTimeBeginText.Text.Trim();
        string uploadTimeEnd = UploadTimeEndText.Text.Trim();

        if (DocRadioButtonList.SelectedValue == "Document")
        {//资料文档查询
            string docVersion = DocVersionText.Text.Trim();       
            string departID = DepartName.SelectedValue;
            string docCateID = DocCateIDText.Value;

            Document document = new Document();
            string searchCondition = document.GetSearchCondition(docName, docVersion, docKey, departID, docCateID, uploadUserName, uploadTimeBegin, uploadTimeEnd);
            IList<DocumentInfo> documentInfos = document.GetDocumentBySearchCondition(searchCondition);
            DataTable documents = document.GetDataTableByDocumentList(documentInfos);

            DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
            documents.Columns.Add(subTaskColumn);
            DocGridView.DataSource = documents;
            DocGridView.DataBind();
            DocGridView.Columns[4].Visible = false;
        }
        else
        {// 项目文档
            string projectDocCateName = null;
            if (ProjectDocCate.SelectedIndex != 0)
            {
                projectDocCateName = ProjectDocCate.Text.Trim();
            }
          
           
            string projectNum = ProjectName.SelectedValue;
            string subTaskID = SubTaskIDText.Value;

            ProjectDoc projectDoc = new ProjectDoc();
            string searchCondition = projectDoc.GetSearchCondition(docName, docKey, subTaskID, projectDocCateName, uploadUserName, uploadTimeBegin, uploadTimeEnd);
            DataTable projecctDocs = projectDoc.SearchProjectDoc(searchCondition);

            DataColumn docVersionColumn = new DataColumn("版本");//与页面的GirdView一致
            projecctDocs.Columns.Add(docVersionColumn);
            DataColumn departNameColumn = new DataColumn("所属部门");//与页面的GirdView一致
            projecctDocs.Columns.Add(departNameColumn);

            DocGridView.DataSource = projecctDocs;
            DocGridView.DataBind();
            DocGridView.Columns[1].Visible = false;
            DocGridView.Columns[3].Visible = false;

        }

    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string docID = DocGridView.DataKeys[index][0].ToString();

        bool isDocument = false;
        if ( DocRadioButtonList.SelectedValue == "Document")
        {
            isDocument= true;
        }

        if (e.CommandName == "ExploreDocument")
        {
            if (isDocument)
            {
                Document document = new Document();
                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                Response.Write("<script  language='javascript'> window.open('ExploreDocument.aspx?emotion=../" + documentInfo.SavePath + "&DocID=" + docID + "&DocumentCate=Document','_blank'); </script>");
            }
            else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                //Response.Write("<script  language='javascript'> window.open('ExploreProjectDoc.aspx?DocID=" + docID + "','_blank'); </script>");
                Response.Redirect("ExploreDocument.aspx?emotion=../" + projectDocInfo.SavePath + "&DocID=" + docID + "&DocumentCate=ProjectDoc");
            }
            //Response.Redirect("Search.aspx");
            //Server.Transfer("Default.aspx");
        }
        else if (e.CommandName == "DownloadDocument")
        {
            //查看下载权限是否允许
            string docName = null;
            string docUrl=null;
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
                docUrl = documentInfo.UploadPath;
            }else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                if (!projectDoc.isPremissionToDownload(projectDocInfo.DocPermission, projectDocInfo.ProjDocId, 1))
                {
                    Response.Write("<script   language=javascript> window.alert( '   下载权限不够，无法下载  '); </script>");
                    return;
                }
                docName= projectDocInfo.DocName;
                docUrl = projectDocInfo.UploadPath;
            }

            //获取后缀名
            string fileName = docName;
             fileName = fileName + "." + docUrl.Substring(docUrl.LastIndexOf(".") + 1);

            Response.Clear();
            Response.Buffer = true;
            // Response.ContentType = "text/xml/rmvb";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string path = Server.MapPath("~/");
            Response.WriteFile(path + docUrl);
            Response.End();

        }
        else if (e.CommandName == "ModifyDocument")
        {
            string address=null;
            if (DocRadioButtonList.SelectedValue == "Document")
            {
                 address = "ModifyDocument.aspx?DocID=" + docID;
                
            }else
            {
                 address = "ModifyProjectDoc.aspx?DocID=" + docID;
            }
            Response.Redirect(address);
        }
        else if (e.CommandName == "DeleteDocument")
        {
            int isDelete = 0;
            string uploadPath = null;
            string savePath = null;
            if (isDocument)
            {
                Document document = new Document();
                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                uploadPath = documentInfo.UploadPath;
                savePath = documentInfo.SavePath;
                isDelete = document.DeleteDocument(Convert.ToInt32(docID));
            }
            else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));

                uploadPath = projectDocInfo.UploadPath;
                savePath = projectDocInfo.SavePath;
                isDelete = projectDoc.DeleteProjectDoc(Convert.ToInt32(docID));

            }
           
             if (isDelete == 1)
            {
                string path = Server.MapPath(@"~/");
                File.Delete(path + uploadPath);
                File.Delete(path + savePath);
                AdvancedSearchButton_Click(null, null);
                Response.Write("<script   language=javascript> window.alert( '  删除成功  '); </script>");
               
            }
             else
             {
                 Response.Write("<script   language=javascript> window.alert( '  删除失败  '); </script>");
             }

        }
    }
}
