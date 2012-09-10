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

public partial class web_ModifyProjectDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string docID = Request.QueryString["DocID"];
            if (string.IsNullOrEmpty(docID))
            {
                return;
            }
            ProjectDoc projectDoc = new ProjectDoc();
            ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
            DocID.Text = docID;

            InitProject(projectDocInfo);
            InitSubTask(projectDocInfo);
            InitProjectDoc(projectDocInfo);
            InitUsers(Convert.ToInt32(docID));
        }
    }

    private void InitProjectDoc(ProjectDocInfo projectDocInfo)
    {
        DocNameText.Text = projectDocInfo.DocName;
        DocDescription.Text = projectDocInfo.DocDescription;
        DocKeyText.Text = projectDocInfo.DocKey;
        ProjectDocCate.SelectedItem.Text = projectDocInfo.ProjDocCate;
        DownLoadPremission.SelectedValue = Convert.ToString(projectDocInfo.DocPermission);
        uploadTime.Text = projectDocInfo.UploadTime;

        BLL.User user = new BLL.User();
        UserInfo userInfo = user.GetUserById(projectDocInfo.UploadUserId);
        UploadUserName.Text = userInfo.UserName;
    }

    private void InitSubTask(ProjectDocInfo projectDocInfo)
    {
        SubTask subTask = new SubTask();
        SubTaskInfo subTaskInfo = subTask.GetSubTaskById(projectDocInfo.TaskId);
        IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(subTaskInfo.ProjectNum);
        SubTaskName.Items.Clear();
        SubTaskName.Items.Add(new ListItem("选择子任务", "0"));

        for (int i = 0; i < subTaskInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(subTaskInfos[i].TaskId);
            listItem.Text = subTaskInfos[i].TaskName;
            SubTaskName.Items.Add(listItem);
        }
        SubTaskName.SelectedValue = Convert.ToString(projectDocInfo.TaskId);
    }

    private void InitProject(ProjectDocInfo projectDocInfo)
    {
        SubTask subTask = new SubTask();
        SubTaskInfo subTaskInfo = subTask.GetSubTaskById(projectDocInfo.TaskId);

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
        ProjectName.SelectedValue = Convert.ToString(subTaskInfo.ProjectNum);
    }

    private void InitUsers(int projDocID)
    {
        BLL.User user = new BLL.User();
        IList<UserInfo> userInfos = user.GetUsers();
        UserNameListView.DataSource = user.GetTableByUserList(userInfos);
        UserNameListView.DataBind();

        ProjectDocUser projectDocUser = new ProjectDocUser();
        for (int i = 0; i < UserNameListView.Rows.Count; ++i)
        {
            GridViewRow gvr = UserNameListView.Rows[i];
            Control ctl = gvr.FindControl("ckb");
            CheckBox ckb = (CheckBox)ctl;

            string userId = UserNameListView.DataKeys[i][0].ToString();
            ProjDocUserInfo projDocUserInfo = projectDocUser.GetProjectDocUserByProjectDocUser(projDocID, Convert.ToInt32(userId));
            if (projDocUserInfo.ProjDocId == projDocID)
            {
                ckb.Checked = true;
            }
        }

    }
    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        ProjectDoc projectDoc = new ProjectDoc();
        ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(DocID.Text.Trim()));

        projectDocInfo.DocName = DocNameText.Text.Trim();
        projectDocInfo.DocDescription = DocDescription.Text.Trim();
        projectDocInfo.DocKey = DocKeyText.Text.Trim();
        projectDocInfo.TaskId = Convert.ToInt32(SubTaskName.Text.Trim());
        projectDocInfo.ProjDocCate = ProjectDocCate.Text.Trim();
        projectDocInfo.DocPermission = Convert.ToInt32(DownLoadPremission.SelectedValue);
        projectDocInfo.UploadTime = uploadTime.Text.Trim();

        BLL.User user = new BLL.User();
        UserInfo userInfo = user.GetUserByName(UploadUserName.Text.Trim());
        if (string.IsNullOrEmpty(userInfo.UserName))
        {
            Response.Write("<script   language=javascript> window.alert( '  用户名不存在  '); </script>");
            return;
        }
        projectDocInfo.UploadUserId = userInfo.UserID;

        int oldDocPermission = projectDocInfo.DocPermission;
        int newDocPermission = Convert.ToInt32(DownLoadPremission.SelectedValue);
        projectDocInfo.DocPermission = newDocPermission;

        int isUpdate = projectDoc.UpdateProjectDoc(projectDocInfo);
        if (isUpdate == 1)
        {
            projectDoc.ChangePermission(projectDocInfo.ProjDocId,oldDocPermission,newDocPermission,GetCheckedUserId());
            Response.Write("<script   language=javascript> window.alert( ' 保存成功  '); </script>");
        }
        else
        {
            Response.Write("<script   language=javascript> window.alert( '保存失败  '); </script>");
        }
    }

    private IList<int> GetCheckedUserId()
    {
        IList<int> userIds = new List<int>();
        for (int i = 0; i < UserNameListView.Rows.Count; ++i)
        {
            GridViewRow gvr = UserNameListView.Rows[i];
            Control ctl = gvr.FindControl("ckb");
            CheckBox ckb = (CheckBox)ctl;

            if (ckb.Checked)
            {
                string userId = UserNameListView.DataKeys[i][0].ToString();
                userIds.Add(Convert.ToInt32(userId));
            }
        }
        return userIds;
    }
}
