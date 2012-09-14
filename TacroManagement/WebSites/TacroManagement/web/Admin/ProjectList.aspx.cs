using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class web_Admin_ProjectList : System.Web.UI.Page
{
    Project projectBLL = new Project();
    User userBLL = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProjects();
        }
    }

    private void BindProjects()
    {
        IList<ProjectInfo> projectInfos = projectBLL.GetProjects();
        this.AspNetPager1.RecordCount = projectInfos.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = projectInfos;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        dlProject.DataSource = pds;
        dlProject.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindProjects();
    }

    //删除
    protected void lbDeleteProject_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string projectNum = e.CommandArgument.ToString();
            if (projectBLL.DeleteProject(projectNum) == 1)
            {
                BindProjects();
            }
        }
    }

    //获取项目管理人员名
    protected string GetAdminName(string projectAdminID)
    {
        UserInfo userInfo = userBLL.GetUserById(int.Parse(projectAdminID));
        return userInfo.UserName;
    }

    //格式化日期格式
    protected string FormatDate(string strDate)
    {
        DateTime dtDate = Convert.ToDateTime(strDate);
        return dtDate.ToString("yyyy-MM-dd");
    }


}
