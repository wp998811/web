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
        if (!IsPostBack)
        {
            DocRadioButtonList.SelectedValue = "Document";
            InitDocCate();
            InitProjectDoc();
        }
       

        //ProjectName.Visible = false;
        //ProjectDocCate.Visible = false;
        //SubTaskName.Visible = false;    
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
        //DepartName.Items.Clear();
        //DepartName.Items.Add(new ListItem("选择部门", "0"));
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
        string docKey = DocKeyText.Text.Trim();
        string uploadUserName = UploadUserName.Text.Trim();
        string uploadTimeBegin = UploadTimeBeginText.Text.Trim();
        string uploadTimeEnd = UploadTimeEndText.Text.Trim();

        if (DocRadioButtonList.SelectedValue == "Document")
        {//资料文档查询
            string docVersion = DocVersionText.Text.Trim();       
            string departID = DepartName.SelectedValue;
            string docCateID = DocCate.SelectedValue;

            Document document = new Document();
            string searchCondition = document.GetSearchCondition(docName, docVersion, docKey, departID, docCateID, uploadUserName, uploadTimeBegin, uploadTimeEnd);       
            DataTable documents =  document.SearchDocument(searchCondition);
            DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
            documents.Columns.Add(subTaskColumn);
            DocGridView.DataSource = documents;
            DocGridView.DataBind();
            DocGridView.Columns[4].Visible = false;
        }
        else
        {// 项目文档
            string projectDocCateName = ProjectDocCate.Text.Trim();
            string projectNum = ProjectName.SelectedValue;
            string subTaskID = SubTaskName.SelectedValue;

        }


       
        




    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void DepartName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DepartDocCate departDocCate = new DepartDocCate();
        //IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(int.Parse(DepartName.SelectedValue));

        //for (int i = 0; i < departDocCateInfos.Count;++i )
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
    protected void ProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Project project = new Project();
        //ProjectInfo projectInfo = project.GetProjectByNum(ProjectName.SelectedValue);
        //SubTask subTask = new SubTask();
        //IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(ProjectName.SelectedValue);

        //for (int i = 0; i < subTaskInfos.Count; ++i)
        //{
        //    ListItem listItem = new ListItem();
        //    listItem.Value = Convert.ToString(subTaskInfos[i].TaskId);
        //    listItem.Text = subTaskInfos[i].TaskName;
        //    SubTaskName.Items.Add(listItem);
        //}

        //if (SubTaskName.Items.Count >=0)
        //{
        //    SubTaskName.SelectedIndex = 0;
        //}

        
       
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
