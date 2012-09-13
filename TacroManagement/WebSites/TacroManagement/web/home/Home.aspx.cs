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
using BLL;
using Model;

public partial class web_Home : System.Web.UI.Page
{
    User userManage = new User();
    Project projectManage = new Project();
    ProjectUser projectUserManage = new ProjectUser();
    SubTask subTaskManage = new SubTask();
    Affair affairManage = new Affair();
    FormatString formatString = new FormatString();
    public static int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Session["UserName"].ToString();
            UserInfo userInfo = userManage.GetUserByName(userName);
            if (userInfo != null && userInfo.UserID != 0)
            {
                userId = userInfo.UserID;
                BindData(userId);
            }

        }
    }
    protected void BindData(int userId)
    {
        //绑定用户名
        (Page.Form.FindControl("form1").FindControl("lblUserName") as Label).Text = Session["UserName"].ToString();
        //绑定项目动态rp
        IList<AffairInfo> affairInfoList = affairManage.GetAffairsByUserID(userId);
        IList<RichAffairInfo> richAffairInfoList = new List<RichAffairInfo>();
        //只取前五项
        int count = 0;
        foreach(AffairInfo affairInfo in affairInfoList)
        {
            if(affairInfo != null && affairInfo.AffairId != 0)
            {
                ProjectInfo projectInfo = projectManage.GetProjectByNum(affairInfo.ProjectNum);
                UserInfo userInfo = userManage.GetUserById(affairInfo.AffairOperatorId);
                RichAffairInfo rAffairInfo = new RichAffairInfo(affairInfo.AffairId, affairInfo.AffairDescription, affairInfo.AffairTime, userInfo.UserName, projectInfo.ProjectName);
                if((++count) > 5)
                    break;
                richAffairInfoList.Add(rAffairInfo);
            }
        }
        rpProjectState.DataSource = richAffairInfoList;
        rpProjectState.DataBind();
        
        //绑定待办事宜rp
        IList<SubTaskInfo> subTaskInfoList = subTaskManage.GetSubTasksDescIsRemind(userId, 5);
        foreach(SubTaskInfo subTaskInfo in subTaskInfoList)
        {
            subTaskInfo.StartTime = formatString.FormatDate(subTaskInfo.StartTime);
            subTaskInfo.RemindTime = formatString.FormatDate(subTaskInfo.RemindTime);
        }
        rpTask.DataSource = subTaskInfoList;
        rpTask.DataBind();
        //绑定项目管理rp
        count = 0;
        IList<ProjectUserInfo> projectUserInfoList = projectUserManage.GetProjectUsersByUserId(userId);
        IList<ProjectInfo> projectInfoList = new List<ProjectInfo>();

        foreach (ProjectUserInfo projectUserInfo in projectUserInfoList)
        {
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectUserInfo.ProjectNum);
            projectInfo.BeginTime = formatString.FormatDate(projectInfo.BeginTime);
            projectInfo.EndTime = formatString.FormatDate(projectInfo.EndTime);
            if (projectInfo != null)
            {
                if((++count) > 5)
                    break;
                projectInfoList.Add(projectInfo);
            }
        }
        rpProject.DataSource = projectInfoList;
        rpProject.DataBind();
    }

    protected void lBtnTaskMore_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "more")
        {
            string url = "../project/taskMore.aspx";
            Response.Redirect(url);
        }
    }

    protected void lBtnProjectStateMore_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "more")
        {
            string url = "../project/projectStateMore.aspx";
            Response.Redirect(url);
        }
    }


    protected void lBtnProjectMore_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "more")
        {
            string url = "../project/projectMore.aspx";
            Response.Redirect(url);
        }
    }
}
