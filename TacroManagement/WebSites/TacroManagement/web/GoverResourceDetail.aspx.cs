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

public partial class web_GoverResourceDetail : System.Web.UI.Page
{
    GoverResource goverResource = new GoverResource();
    User user = new User();
    public static string goverResourceID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["goverResourceID"] != null && Request.Params["goverResourceID"] != "")
            {
                goverResourceID = Request.Params["goverResourceID"];
                GoverResourceDataBind();
            }
        }
    }

    private void GoverResourceDataBind()
    {
        GoverResourceInfo goverResourceInfo = goverResource.GetGoverResourceById(Convert.ToInt32(goverResourceID));
        if (goverResourceInfo != null)
        {
            UserInfo userInfo = user.GetUserById(goverResourceInfo.UserID);
            lblManager.Text = userInfo.UserName;
            lblCity.Text = goverResourceInfo.GoverCity;
            lblOrganName.Text = goverResourceInfo.OrganName;
            lblOrganIntro.Text = goverResourceInfo.OrganIntro;
        }

        DataTable goverResourcedt = goverResource.SearchAllContactsByGoverResourceID(Convert.ToInt32(goverResourceID));

        this.GoverContactPager.RecordCount = goverResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = goverResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = GoverContactPager.CurrentPageIndex - 1;
        pds.PageSize = GoverContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }

    protected void GoverContact_PageChanged(object sender, EventArgs e)
    {
        GoverResourceDataBind();
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
