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

public partial class web_PartnerResourceDetail : System.Web.UI.Page
{
    PartnerResource partnerResource = new PartnerResource();
    User user = new User();
    public static string partnerResourceID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["partnerResourceID"] != null && Request.Params["partnerResourceID"] != "")
            {
                partnerResourceID = Request.Params["partnerResourceID"];
                PartnerResourceDataBind();
            }
        }
    }

    private void PartnerResourceDataBind()
    {
        PartnerResourceInfo partnerResourceInfo = partnerResource.GetPartnerResourceById(Convert.ToInt32(partnerResourceID));
        if (partnerResourceInfo != null)
        {
            UserInfo userInfo = user.GetUserById(partnerResourceInfo.UserID);
            lblManager.Text = userInfo.UserName;
            lblCity.Text = partnerResourceInfo.PartnerCity;
            lblOrganName.Text = partnerResourceInfo.OrganName;
            lblOrganIntro.Text = partnerResourceInfo.OrganIntro;
        }

        DataTable partnerResourcedt = partnerResource.SearchAllContactsByPartnerResourceID(Convert.ToInt32(partnerResourceID));

        this.PartnerContactPager.RecordCount = partnerResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = partnerResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = PartnerContactPager.CurrentPageIndex - 1;
        pds.PageSize = PartnerContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }

    protected void PartnerContact_PageChanged(object sender, EventArgs e)
    {
        PartnerResourceDataBind();
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
