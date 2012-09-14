using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class web_Admin_UserList : System.Web.UI.Page
{
    User userBLL = new User();
    Department departmentBLL = new Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUsers();
        }
    }

    private void BindUsers()
    {
        IList<UserInfo> userInfos = userBLL.GetUsers();
        this.AspNetPager1.RecordCount = userInfos.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = userInfos;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        dlUser.DataSource = pds;
        dlUser.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindUsers();
    }

    protected void lbDeleteUser_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int userID = Convert.ToInt32(e.CommandArgument.ToString());
            if (userBLL.DeleteUser(userID) == 1)
            {
                BindUsers();
            }
        }
    }
    
    protected string GetDepartName(string departID)
    {
        if (departID == "0")
        {
            return "暂无部门";
        }
        DepartmentInfo departmentInfo = departmentBLL.GetDepartmentByID(Int32.Parse(departID));
        return departmentInfo.DepartName;
    }

}
