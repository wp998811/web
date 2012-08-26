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

public partial class web_AdvancedSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //初始化部门
        DocRadioButtonList.SelectedValue = "Document";
        InitDocCate();
        InitProjectDoc();

        //ProjectName.Visible = false;
        //ProjectDocCate.Visible = false;
        //SubTaskName.Visible = false;    
    }

    private void InitProjectDoc()
    {
        Project project = new Project();
        IList<ProjectInfo> projectInfos = project.GetProjects();

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
        //Department department = new Department();
        //IList<DepartmentInfo> departmentInfos = department.GetDepartment();
        //for (int i = 0; i < departmentInfos.Count; ++i)
        //{
        //    ListItem listItem = new ListItem();
        //    listItem.Text = departmentInfos[i].DepartName;
        //    listItem.Value = Convert.ToString(departmentInfos[i].DepartID);
        //    DepartName.Items.Add(listItem);
        //}
        //if (DepartName.Items.Count <= 0)
        //{
        //    return;
        //}
        //DepartName.SelectedIndex = 0;

        //DepartDocCate departDocCate = new DepartDocCate();
        //IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(DepartName.SelectedItem.Value);
        //for (int i = 0; i < departDocCateInfos.Count; ++i)
        //{
        //    ListItem listItem = new ListItem();
        //    listItem.Value = Convert.ToString(departDocCateInfos[i].Id);
        //    listItem.Text = departDocCateInfos[i].CategoryName;
        //    DocCate.Items.Add(listItem);
        //}
        //if (DocCate.Items.Count >= 1)
        //{
        //    DocCate.SelectedIndex = 0;
        //}
    }
    protected void AdvancedSearchButton_Click(object sender, EventArgs e)
    {
        string docName = DocNameText.Text.Trim();
        string docVersion = DocVersionText.Text.Trim();
        string docKey = DocKeyText.Text.Trim();
        string departName = DepartName.Text.Trim();
        string docCate = DocCate.Text.Trim();
        string uploadUserName = UploadUserName.Text.Trim();
        string uploadTimeBegin = UploadTimeBeginText.Text.Trim();
        string uploadTimeEnd = UploadTimeEndText.Text.Trim();

        Document document = new Document();
        string searchCondition = document.GetSearchCondition(departName, docVersion, docKey, departName, docCate, uploadUserName, uploadTimeBegin, uploadTimeEnd);
        DocGridView.DataSource = document.SearchDocument(searchCondition);
        DocGridView.DataBind();
    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void DepartName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DepartDocCate departDocCate = new DepartDocCate();
        IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(int.Parse(DepartName.SelectedValue));

        for (int i = 0; i < departDocCateInfos.Count;++i )
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
    protected void ProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Project project = new Project();
        //ProjectInfo projectInfo = project.GetProjectByNum(ProjectName.SelectedValue);
        SubTask subTask = new SubTask();
        IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(ProjectName.SelectedValue);

        for (int i = 0; i < subTaskInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(subTaskInfos[i].TaskId);
            listItem.Text = subTaskInfos[i].TaskName;
            SubTaskName.Items.Add(listItem);
        }

        if (SubTaskName.Items.Count >=0)
        {
            SubTaskName.SelectedIndex = 0;
        }

        
       
    }
    protected void DocRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DocRadioButtonList.SelectedValue == "Document")
        //{
        //    DepartName.Visible = true;
        //    DocCate.Visible = true;
        //    DocVersionText.Visible = true;
        //    Label2.Visible = true;

        //    ProjectName.Visible = false;
        //    ProjectDocCate.Visible = false;
        //    SubTaskName.Visible = false;          
        //} 
        //else
        //{
        //    DepartName.Visible = false;
        //    DocCate.Visible = false;
        //    DocVersionText.Visible = false;
        //    Label2.Visible = false;

        //    ProjectName.Visible = true;
        //    ProjectDocCate.Visible = true;
        //    SubTaskName.Visible = true;
        //}
    }
}
