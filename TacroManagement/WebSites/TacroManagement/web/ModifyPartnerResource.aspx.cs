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

public partial class web_ModifyPartnerResource : System.Web.UI.Page
{
    PartnerResource partnerResource = new PartnerResource();
    PartnerContact partnerContact = new PartnerContact();
    Contact contact = new Contact();
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

            if (Request.Params["partnerResourceID"] != null && Request.Params["partnerResourceID"].Trim() != "")
            {
                partnerResourceID = Request.Params["partnerResourceID"];
                PartnerResourceDataBind();
            }
        }
    }

    private void PartnerResourceDataBind()
    {
        PartnerResourceInfo partnerResourceInfo = partnerResource.GetPartnerResourceById(Convert.ToInt32(partnerResourceID));
        UserInfo userInfo = user.GetUserById(partnerResourceInfo.UserID);

        txtManager.Text = userInfo.UserName;
        txtCity.Text = partnerResourceInfo.PartnerCity;
        txtHiddenUserID.Text = userInfo.UserID.ToString();
        txtOrganName.Text = partnerResourceInfo.OrganName;
        txtOrganIntro.Text = partnerResourceInfo.OrganIntro;

        IList<UserInfo> userInfos = user.GetUsers();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";

        ddlUser.DataSource = userInfos;
        ddlUser.DataBind();

        ContactRpDataBind();
    }

    private void ContactRpDataBind()
    {
        DataTable contactdt = partnerResource.SearchAllContactsByPartnerResourceID(Convert.ToInt32(partnerResourceID));

        this.ContactPager.RecordCount = contactdt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = contactdt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ContactPager.CurrentPageIndex - 1;
        pds.PageSize = ContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }


    protected void Modify_PartnerResource(object sender, EventArgs e)
    {
        PartnerResourceInfo partnerResourceInfo = partnerResource.GetPartnerResourceById(Convert.ToInt32(partnerResourceID));
        partnerResourceInfo.UserID = Convert.ToInt32(txtHiddenUserID.Text);
        partnerResourceInfo.PartnerCity = txtCity.Text;
        partnerResourceInfo.OrganName = txtOrganName.Text;
        partnerResourceInfo.OrganIntro = txtOrganIntro.Text;

        if (partnerResource.UpdetePartnerResource(partnerResourceInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("GoverResourceList.aspx");
    }

    protected void Contact_PageChanged(object sender, EventArgs e)
    {
        ContactRpDataBind();
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("PartnerResourceList.aspx");
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

    protected void rpContactList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyPartnerContact.aspx?goverResourceID=" + partnerResourceID.ToString() + "&contactID=" + contactID.ToString());
                    break;
                }
            case "delete":
                {
                    int contactId = Convert.ToInt32(e.CommandArgument.ToString());

                    if (contact.DeleteContact(contactId) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    ContactRpDataBind();
                    break;
                }
            case "addVisitRecord":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("AddVisitRecord.aspx?contactID=" + contactID.ToString() + "&ID=" + partnerResourceID + "&resourceType=合作伙伴");
                    ContactRpDataBind();
                    break;
                }
        }
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
