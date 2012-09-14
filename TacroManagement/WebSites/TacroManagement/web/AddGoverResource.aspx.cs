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

public partial class web_AddGoverResource : System.Web.UI.Page
{
    GoverResource goverResource = new GoverResource();
    User user = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            GoverResourceDataBind();
        }
    }

    private void GoverResourceDataBind()
    {
        IList<UserInfo> userInfos = user.GetUsers();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";

        ddlUser.DataSource = userInfos;
        ddlUser.DataBind();
    }

    protected void Add_GoverResource(object sender, EventArgs e)
    {
        GoverResourceInfo goverResourceInfo = new GoverResourceInfo();
        goverResourceInfo.UserID = Convert.ToInt32(txtHiddenUserID.Text);
        goverResourceInfo.GoverCity = txtCity.Text;
        goverResourceInfo.OrganName = txtDepartmentName.Text;
        goverResourceInfo.OrganIntro = txtDepartmentIntro.Text;

        if (goverResource.InsertGoverResource(goverResourceInfo) == 1)
        {
            Response.Redirect("GoverResourceList.aspx");
        }
    }

    protected void lbtnSelectUser_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            if (ddlUser.Items.Count == 0)
                return;
            int userID = Convert.ToInt32(ddlUser.SelectedValue);
            UserInfo userInfo = user.GetUserById(userID);

            if (userInfo != null)
            {
                txtManager.Text = userInfo.UserName;
                txtHiddenUserID.Text = userID.ToString();
            }
        }
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("GoverResourceList.aspx");
    }

    protected bool isUserLogin()
    {
        if (Session["userID"].ToString() == "")
            return false;

        int userID = Convert.ToInt32(Session["userID"].ToString());
        if (user.GetUserById(userID) == null)
            return false;

        return true;
    }
}
