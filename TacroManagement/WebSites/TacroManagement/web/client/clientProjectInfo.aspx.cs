using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class web_client_clientProjectInfo : System.Web.UI.Page
{
    Project projectManage = new Project();
    ProjectUser projectUserManage = new ProjectUser();
    User userManage = new User();
    SubTask subTaskManage = new SubTask();
    Department departmentManage = new Department();
    Affair affairManage = new Affair();
    FormatString formatString = new FormatString();
    public static string projectNum = "";
    public string strProgress = "";
    public static int userID;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["projectNum"] != null && Request.Params["projectNum"].Trim() != "")
            {
                string userName = Session["UserName"].ToString();
                userID = (userManage.GetUserByName(userName)).UserID;
                projectNum = Request.Params["projectNum"];
                //////////////////////////////////////////////////              
                BindProjectInfo(projectNum);
                BindSubTasks(projectNum);
                BindProjectUser(projectNum);

                //////////////////////////////////////////////////
                //进行权限控制
                ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
                if (projectInfo.ProjectAdminID != userID)
                {
                    a1.Visible = false;
                    a2.Visible = false;
                    a3.Visible = false;

                    icon1.Visible = false;
                    icon2.Visible = false;
                    icon3.Visible = false;

                    for (int i = 0; i < rpUserList.Items.Count; i++)
                    {
                        LinkButton linkButton = rpUserList.Items[i].FindControl("lbtnRpDelete") as LinkButton;
                        linkButton.Visible = false;
                    }
                    for (int i = 0; i < rpSubTask.Items.Count; i++)
                    {
                        LinkButton LinkButtonModify = rpSubTask.Items[i].FindControl("rpLbtnModify") as LinkButton;
                        LinkButton LinkButtonDel = rpSubTask.Items[i].FindControl("rpLbtnDel") as LinkButton;
                        LinkButtonModify.Visible = false;
                        LinkButtonDel.Visible = false;
                    }
                }
                else
                {
                    a1.HRef = "projectModify.aspx?projectNum=" + projectNum;
                }
            }
        }
        SetProgress(projectNum);
    }

    private void BindProjectInfo(string projectNum)
    {
        ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
        if (!projectManage.IsNullOrEmpty(projectInfo))
        {
            lblProjectName2.Text = projectInfo.ProjectName;
            lblProjectName.Text = projectInfo.ProjectName;
            lblClientName.Text = projectInfo.ProjectClientName;
            //lblProjectAdmin = projectInfo.ProjectAdminID;
            UserInfo userInfo = userManage.GetUserById(projectInfo.ProjectAdminID);
            if (userInfo != null && userInfo.UserID != 0)
                lblProjectAdmin.Text = userInfo.UserName;
            lblProjectType.Text = projectInfo.ProjectType;
            //lblBeginDate.Text = projectInfo.BeginTime;
            //lblEndDate.Text = projectInfo.EndTime;
            lblBeginDate.Text = formatString.FormatDate(projectInfo.BeginTime);
            lblEndDate.Text = formatString.FormatDate(projectInfo.EndTime);
            lblProjectDescription.Text = projectInfo.ProjectDescription;
        }
    }

    private void BindSubTasks(string projectNum)
    {
        IList<RichSubTaskInfo> tasks = new List<RichSubTaskInfo>();
        IList<SubTaskInfo> subTasks = subTaskManage.GetSubTasksByProjectNum(projectNum);
        foreach (SubTaskInfo subTaskInfo in subTasks)
        {
            UserInfo userInfo = userManage.GetUserById(subTaskInfo.UserId);
            if (userInfo != null && userInfo.UserID != 0)
                tasks.Add(new RichSubTaskInfo(projectNum, subTaskInfo.TaskId, subTaskInfo.TaskName, subTaskInfo.Period, formatString.FormatDate(subTaskInfo.StartTime), formatString.FormatDate(subTaskInfo.EndTime),
                     subTaskInfo.Product, subTaskInfo.ForeTask, subTaskInfo.Resource, subTaskInfo.IsRemind, subTaskInfo.TaskState,
                     userInfo.UserName, userInfo.UserEmail, userInfo.UserPhone));
            else
            {
                tasks.Add(new RichSubTaskInfo(projectNum, subTaskInfo.TaskId, subTaskInfo.TaskName, subTaskInfo.Period, formatString.FormatDate(subTaskInfo.StartTime), formatString.FormatDate(subTaskInfo.EndTime),
                     subTaskInfo.Product, subTaskInfo.ForeTask, subTaskInfo.Resource, subTaskInfo.IsRemind, subTaskInfo.TaskState));
            }
        }
        //dlSubTask.DataSource = tasks;
        //dlSubTask.DataBind();
        //gvSubTask.DataSource = tasks;
        //gvSubTask.DataBind();
        this.AspNetPager1.RecordCount = tasks.Count;
        PagedDataSource pg = new PagedDataSource();
        pg.DataSource = tasks;
        pg.AllowPaging = true;
        pg.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pg.PageSize = AspNetPager1.PageSize;
        rpSubTask.DataSource = pg;
        rpSubTask.DataBind();

        //绑定子任务进度
        foreach (RichSubTaskInfo info in tasks)
        {
            info.TaskName = info.TaskName + ":" + info.TaskState;
            switch (info.TaskState)
            {
                case "待执行":
                    info.TaskState = "btn disabled";
                    break;
                case "执行中":
                    info.TaskState = "btn btn-info disabled";
                    break;
                case "已完成":
                    info.TaskState = "btn btn-success disabled";
                    break;
                case "已取消":
                    info.TaskState = "btn btn-inverse disabled";
                    break;
                default:
                    info.TaskState = "btn disabled";
                    break;
            }
        }
        rpSubTaskState.DataSource = tasks;
        rpSubTaskState.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindSubTasks(projectNum);
    }

    private void BindProjectUser(string projectNum)
    {
        IList<UserInfo> userInfoList = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);


        //gvUser.DataSource = userInfoList;
        //gvUser.DataBind();

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
        rateI = rateI > 100 ? 100 : rateI;
        StringBuilder sbList = new StringBuilder();
        string str = "<div class=\"bar\" style=\"width: {0}%;\"></div>";
        sbList.Append(string.Format(str, rateI.ToString()));
        strProgress = sbList.ToString();
        string lblShow = rateI + "%";
        lblRate.Text = lblShow;
    }
    protected void gvSubTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            SubTaskInfo subTaskInfo = subTaskManage.GetSubTaskById(taskId);
            if (subTaskManage.DeleteSubTask(taskId) > 0)
            {
                //添加项目动态
                if (subTaskInfo != null && subTaskInfo.TaskId != 0)
                {
                    string des = "删除子任务：" + subTaskInfo.TaskName;
                    string name = Session["UserName"].ToString();
                    int id = (userManage.GetUserByName("name")).UserID;
                    AffairInfo affair = new AffairInfo(des, id, DateTime.Now.ToString(), projectNum);
                    affairManage.InsertAffair(affair);
                }


                Response.Write("<script language='javascript'>alert('删除成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
        }
        if (e.CommandName == "modify")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            string url = "subTaskModify.aspx?projectNum=" + projectNum + "&taskID=" + taskId + "&type=1";
            Response.Redirect(url);
        }

    }
    protected void addSubTask_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "addSubTask")
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
            if (id == projectInfo.ProjectAdminID)
            {
                Response.Write("<script language='javascript'>alert('不能删除项目负责人！')</script>");
                return;
            }
            IList<SubTaskInfo> subTaskInfos = subTaskManage.GetSubTasksByProjectNum(projectNum);
            foreach (SubTaskInfo subTaskInfo in subTaskInfos)
            {
                if (subTaskInfo.UserId == id)
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

    protected void rpLbtnModify_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "modify")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            string url = "subTaskModify.aspx?projectNum=" + projectNum + "&taskID=" + taskId + "&type=1";
            Response.Redirect(url);
        }
    }

    protected void lbtnRpDelete_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
            if (id == projectInfo.ProjectAdminID)
            {
                Response.Write("<script language='javascript'>alert('不能删除项目负责人！')</script>");
                return;
            }
            IList<SubTaskInfo> subTaskInfos = subTaskManage.GetSubTasksByProjectNum(projectNum);
            foreach (SubTaskInfo subTaskInfo in subTaskInfos)
            {
                if (subTaskInfo.UserId == id)
                {
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




    protected void rpLbtnDel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int taskId = Convert.ToInt32(e.CommandArgument.ToString());
            SubTaskInfo subTaskInfo = subTaskManage.GetSubTaskById(taskId);
            if (subTaskManage.DeleteSubTask(taskId) > 0)
            {
                //添加项目动态
                string uName = Session["UserName"].ToString();
                int uId = (userManage.GetUserByName(uName)).UserID;
                if (subTaskInfo != null && subTaskInfo.TaskId != 0)
                {
                    string des = "删除子任务：" + subTaskInfo.TaskName;
                    AffairInfo affair = new AffairInfo(des, uId, DateTime.Now.ToString(), projectNum);
                    affairManage.InsertAffair(affair);
                }


                Response.Write("<script language='javascript'>alert('删除成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
        }
    }

    protected void lbtnAddUser_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            if (ddlUser.Items.Count == 0)
                return;
            int id = Convert.ToInt32(ddlUser.SelectedValue);
            IList<UserInfo> userInfos = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);
            foreach (UserInfo userInfo in userInfos)
            {
                if (userInfo.UserID == id)
                {
                    Response.Write("<script language='javascript'>alert('该员工已经存在于该项目！')</script>");
                    return;
                }
            }
            ProjectUserInfo projectUser = new ProjectUserInfo(projectNum, id);
            if (projectUserManage.InsertProjectUser(projectUser) > 0)
            {
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
            else
                Response.Write("<script language='javascript'>alert('添加出错！')</script>");
        }
    }
}
