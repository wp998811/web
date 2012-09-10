using System;
using System.Collections.Generic;
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
using System.Text;
using BLL;
using Model;

public partial class web_projectInfo : System.Web.UI.Page
{
    Project projectManage = new Project();
    ProjectUser projectUserManage = new ProjectUser();
    User userManage = new User();
    SubTask subTaskManage = new SubTask();
    Department departmentManage = new Department();
    public static string projectNum = "";
    public string strProgress = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.Params["projectNum"] != null && Request.Params["projectNum"].Trim() != "")
            {
                projectNum = Request.Params["projectNum"];
                BindProjectInfo(projectNum);
                BindSubTasks(projectNum);
                BindProjectUser(projectNum);
                SetProgress(projectNum);
            }
        }
    }

    private void BindProjectInfo(string projectNum)
    {
        ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
        if(!projectManage.IsNullOrEmpty(projectInfo))
        {
            lblProjectName2.Text = projectInfo.ProjectName;
            lblProjectName.Text = projectInfo.ProjectName;
            lblClientName.Text = projectInfo.ProjectClientName;
            //lblProjectAdmin = projectInfo.ProjectAdminID;
            UserInfo userInfo = userManage.GetUserById(projectInfo.ProjectAdminID);
            if (userInfo != null && userInfo.UserID != 0)
                lblProjectAdmin.Text = userInfo.UserName;
            lblProjectType.Text = projectInfo.ProjectType;
            lblBeginDate.Text = projectInfo.BeginTime;
            lblEndDate.Text = projectInfo.EndTime;
            lblProjectDescription.Text = projectInfo.ProjectDescription;
        }
    }

    private void BindSubTasks(string projectNum)
    {
        IList<RichSubTaskInfo> tasks = new List<RichSubTaskInfo>();
        IList<SubTaskInfo> subTasks = subTaskManage.GetSubTasksByProjectNum(projectNum);
        foreach(SubTaskInfo subTaskInfo in subTasks)
        {
            UserInfo userInfo = userManage.GetUserById(subTaskInfo.UserId);
            if(userInfo != null && userInfo.UserID != 0)
                tasks.Add(new RichSubTaskInfo(projectNum, subTaskInfo.TaskId, subTaskInfo.TaskName, subTaskInfo.Period, subTaskInfo.StartTime, subTaskInfo.EndTime,
                     subTaskInfo.Product, subTaskInfo.ForeTask, subTaskInfo.Resource, subTaskInfo.IsRemind, subTaskInfo.TaskState, 
                     userInfo.UserName, userInfo.UserEmail, userInfo.UserPhone));
            else
            {
                tasks.Add(new RichSubTaskInfo(projectNum, subTaskInfo.TaskId, subTaskInfo.TaskName, subTaskInfo.Period, subTaskInfo.StartTime, subTaskInfo.EndTime,
                     subTaskInfo.Product, subTaskInfo.ForeTask, subTaskInfo.Resource, subTaskInfo.IsRemind, subTaskInfo.TaskState));
            }
        }
        //dlSubTask.DataSource = tasks;
        //dlSubTask.DataBind();
        gvSubTask.DataSource = tasks;
        gvSubTask.DataBind();
    }

    private void BindProjectUser(string projectNum)
    {
        IList<UserInfo> userInfoList = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);
        

        gvUser.DataSource = userInfoList;
        gvUser.DataBind();

        rpUserList.DataSource = userInfoList;
        rpUserList.DataBind();

        //绑定用户ddlUser
        IList<UserInfo> userInfos = userManage.GetUsers();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";

        ddlUser.DataSource = userInfos;
        ddlUser.DataBind();
    }

    private void SetProgress(string num)
    {
        int timeLength = projectManage.GetProjectTimeLength(num);
        int timeSpare = projectManage.GetProjectSpareTime(num);
        float rateF = (float)timeSpare / (float)timeLength;
        rateF *= 100;
        int rateI = (int)rateF;
        StringBuilder sbList = new StringBuilder();
        string str = "<div class=\"bar\" style=\"width: {0}%;\"></div>";
        sbList.Append(string.Format(str, rateI.ToString()));
        strProgress = sbList.ToString();
        string lblShow = rateI + "%";
        lblRate.Text = lblShow;
    }
    protected void gvSubTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "del")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            if(subTaskManage.DeleteSubTask(taskId) > 0)
            {
                Response.Write("<script language='javascript'>alert('删除成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
        }
        if(e.CommandName == "modify")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            string url = "subTaskModify.aspx?projectNum=" + projectNum +"&taskID=" + taskId + "&type=1";
            Response.Redirect(url);
        }

    }
    protected void addSubTask_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "addSubTask")
        {
            string url = "subTaskModify.aspx?projectNum=" + projectNum + "&type=2";
            Response.Redirect(url);
        }
    }
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
            if(id == projectInfo.ProjectAdminID)
            {
                Response.Write("<script language='javascript'>alert('不能删除项目负责人！')</script>");
                return;
            }
            IList<SubTaskInfo> subTaskInfos = subTaskManage.GetSubTasksByProjectNum(projectNum);
            foreach(SubTaskInfo subTaskInfo in subTaskInfos)
            {
                if(subTaskInfo.UserId == id)
                {
                    //TODO 如果该子任务的负责人是要删除的用户，则将该项设为null
                    subTaskInfo.UserId = -1;
                    subTaskManage.UpdateSubTask(subTaskInfo);
                }
            }
            if (projectUserManage.DeleteProjectUserByProjectNumAndUserID(projectNum, id) > 0)
            {
                Response.Write("<script language='javascript'>alert('删除成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
        }
    }
    protected void lbtnAddUser_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "add")
        {
            if (ddlUser.Items.Count == 0)
                return;
            int id = Convert.ToInt32(ddlUser.SelectedValue);
            IList<UserInfo> userInfos = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);
            foreach(UserInfo userInfo in userInfos)
            {
                if(userInfo.UserID == id)
                {
                    Response.Write("<script language='javascript'>alert('该员工已经存在于该项目！')</script>");
                    return;
                }
            }
            ProjectUserInfo projectUser = new ProjectUserInfo(projectNum, id);
            if(projectUserManage.InsertProjectUser(projectUser) > 0)
            {
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
            else
                Response.Write("<script language='javascript'>alert('添加出错！')</script>");
        }
    }
}
