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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Session["UserName"].ToString();
            UserInfo userInfo = userManage.GetUserByName(userName);
            int userId = 0;
            if (userInfo != null && userInfo.UserID != 0)
            {
                userId = userInfo.UserID;
                BindData(userId);
            }

        }
    }
    protected void BindData(int userId)
    {
        //绑定项目管理rp
        IList<ProjectUserInfo> projectUserInfoList = projectUserManage.GetProjectUsersByUserId(userId);
        IList<ProjectInfo> projectInfoList = new List<ProjectInfo>();

        foreach (ProjectUserInfo projectUserInfo in projectUserInfoList)
        {
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectUserInfo.ProjectNum);
            if (projectInfo != null)
            {
                projectInfoList.Add(projectInfo);
            }
        }
        rpProject.DataSource = projectInfoList;
        rpProject.DataBind();
    }
}
