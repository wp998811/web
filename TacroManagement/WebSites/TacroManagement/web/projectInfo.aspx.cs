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
using BLL;
using Model;

public partial class web_projectInfo : System.Web.UI.Page
{
    Project projectManage = new Project();
    ProjectUser projectUserManage = new ProjectUser();
    User userManage = new User();
    SubTask subTaskManage = new SubTask();
    public static string projectNum = "";


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
            if (projectUserManage.DeleteProjectUserByProjectNumAndUserID(projectNum, id) > 0)
            {
                Response.Write("<script language='javascript'>alert('删除成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
        }
    }
}
