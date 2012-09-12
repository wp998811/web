using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_ResourceAdminLists : System.Web.UI.Page
{
    User userBLL = new User();
    ResourceAdmin raBLL = new ResourceAdmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindResourceAdmin();
        }
    }

    private void BindResourceAdmin()
    {
        IList<ResourceAdminInfo> resourceAdmins = raBLL.GetResourceAdmins();
        this.AspNetPager1.RecordCount = resourceAdmins.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = resourceAdmins;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        this.dlResourceAdmin.DataSource = pds;
        this.dlResourceAdmin.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindResourceAdmin();
    }

    protected void dlResourceAdmin_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string strID = "";
        strID = ((Label)e.Item.FindControl("lblID")).Text;
        int id = Int32.Parse(strID);
        raBLL.DeleteResourceAdmin(id);
        dlResourceAdmin.EditItemIndex = -1;
        BindResourceAdmin();
    }

    protected string GetUserName(string userID)
    {
        UserInfo user = userBLL.GetUserById(Int32.Parse(userID));
        return user.UserName;
    }
}
