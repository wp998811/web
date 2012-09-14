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

public partial class web_project_projectMore : System.Web.UI.Page
{
    ProjectUser projectUserManage = new ProjectUser();
    Project projectManage = new Project();
    User userManage = new User();
    FormatString formatString = new FormatString();
    public static int userId;
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
        IList<ProjectUserInfo> projectUserInfoList = projectUserManage.GetProjectUsersByUserId(userId);
        IList<ProjectInfo> projectInfoList = new List<ProjectInfo>();

        foreach (ProjectUserInfo projectUserInfo in projectUserInfoList)
        {
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectUserInfo.ProjectNum);
            if (projectInfo != null)
            {
                projectInfo.BeginTime = formatString.FormatDate(projectInfo.BeginTime);
                projectInfoList.Add(projectInfo);
            }
        }
        //rpProject.DataSource = projectInfoList;
        //rpProject.DataBind();

        this.AspNetPager1.RecordCount = projectInfoList.Count;
        PagedDataSource pg = new PagedDataSource();
        pg.DataSource = projectInfoList;
        pg.AllowPaging = true;
        pg.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pg.PageSize = AspNetPager1.PageSize;
        rpProject.DataSource = pg;
        rpProject.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData(userId);
    }
}
