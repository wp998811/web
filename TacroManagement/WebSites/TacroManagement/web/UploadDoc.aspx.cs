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
        if (!IsPostBack)
        {
            InitDocCate();
            InitProjectDoc();
            InitUsers();
        }
    }

    private void InitProjectDoc()
    {
        Project project = new Project();
        IList<ProjectInfo> projectInfos = project.GetProjects();


        ProjectName.Items.Clear();
        ProjectName.Items.Add(new ListItem("选择项目", "0"));

        for (int i = 0; i < projectInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = projectInfos[i].ProjectNum;
            listItem.Text = projectInfos[i].ProjectName;
            ProjectName.Items.Add(listItem);
        }

        if (ProjectName.Items.Count <= 0)
        {
            return;
        }
        ProjectName.SelectedIndex = 0;

        SubTask subTask = new SubTask();
        IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(ProjectName.SelectedValue);

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

    private void InitUsers()
    {
        BLL.User user = new BLL.User();
        IList<UserInfo> userInfos = user.GetUsers();
        for (int i = 0; i < userInfos.Count;++i )
        {
            ListItem listItem = new ListItem();
            listItem.Value =  Convert.ToString(userInfos[i].UserID);
            listItem.Text = userInfos[i].UserName;
            UserNameList.Items.Add(listItem);
        }

    }




    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string filePath = FileUpload1.PostedFile.FileName;
        if (filePath.Length <=0)
        {
            Response.Write("<script   language=javascript> window.alert( ' 请选择需要上传的文件 '); </script>");
            return;
        }
        string docName = DocNameText.Text.Trim();
        string docDescription = DocDescription.Text.Trim();
        string docKey = DocKeyText.Text.Trim();
        
        string fileName = docName;
            if (docName.IndexOf('.') == -1)
            {
                //Response.Write("<script   language=javascript> window.alert( ' 请文件名后缀 '); </script>");
                fileName = fileName + "." + filePath.Substring(filePath.LastIndexOf(".") + 1);
            }

        if (DocRadioButtonList.SelectedValue == "Document")
        {
            string docVersion = DocVersionText.Text.Trim();
            string departID =DepartName.SelectedValue;
            string docCateID = DocCateIDText.Value;
            string downloadPremission = DownLoadPremission.SelectedValue;
            string docState = DocState.SelectedValue;

            
            Document document = new Document();
            bool isAdd = document.AddDocument(docName, docVersion, docKey, docDescription, departID, docCateID, docState, fileName, downloadPremission, "1");

            if (isAdd)
            {//数据库插入成功                
               bool isUpload = UploadDocument(fileName,true);
               if (!isUpload)
                { //上传失败
                    document.DeleteDocumentByName(docName);
                }
            }
        
        }
        else
        {
            string projectID = ProjectName.SelectedValue;
            string subTaskID = SubTaskIDText.Value;
            string projectDocCate = ProjectDocCate.Text;
            string downloadPremission = DownLoadPremission.SelectedValue;
            ProjectDoc projectDoc = new ProjectDoc();

            bool isAdd = projectDoc.AddProjectDoc(subTaskID, projectDocCate, docName, docKey, docDescription, fileName, downloadPremission, "1");

            if (isAdd)
            {//数据库插入成功                
                bool isUpload = UploadDocument(fileName, false);
                if (!isUpload)
                { //上传失败
                    string docUrl = "ProjectDocs/" + fileName;
                    string condition = " DocUrl = '" + docUrl + "'";
                    IList<ProjectDocInfo> projectDocInfos = projectDoc.GetProjectDocBySearchCondition(docUrl);
                    if (projectDocInfos.Count>0)
                    {
                        projectDoc.DeleteProjectDoc(projectDocInfos[0].ProjDocId);
                    }
                }
            }
        }
    }

    private bool UploadDocument(string fileName,bool isDocument)
    {
        string filePath = FileUpload1.PostedFile.FileName;
        if (filePath.Trim().Length > 0)
        {
            //string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            string serverFileName;
            if (isDocument)
            {
                serverFileName = Server.MapPath(@"~/") +"Documents\\"+ fileName;
            }
            else
            {
                serverFileName = Server.MapPath(@"~/") + "ProjectDocs\\" + fileName;
            }
            
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
