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

public partial class web_AddGoverContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    GoverContact goverContact = new GoverContact();
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
            if (Request.Params["goverResourceID"] != null && Request.Params["goverResourceID"].Trim() != "")
            {
                goverResourceID = Request.Params["goverResourceID"];
            }
        }
    }

    protected void Add_GoverContact(object sender, EventArgs e)
    {
        GoverContactInfo goverContactInfo = new GoverContactInfo();
        ContactInfo contactInfo = new ContactInfo();
        contactInfo.ContactName = txtContactName.Text;
        contactInfo.Position = txtPosition.Text;
        contactInfo.Mobilephone = txtMobilephone.Text;
        contactInfo.Telephone = txtTelephone.Text;
        contactInfo.Email = txtEmail.Text;
        contactInfo.Address = txtAddress.Text;
        contactInfo.PostCode = txtPostCode.Text;
        contactInfo.FaxNumber = txtFaxNumber.Text;

        goverContactInfo.GoverID = Convert.ToInt32(goverResourceID);

        if (contact.InsertContact(contactInfo) == 1)
        {
            goverContactInfo.ContactID = contact.GetContactByContactNameAndTelephone(contactInfo.ContactName, contactInfo.Telephone).ContactID;
            if (goverContact.InsertGoverContact(goverContactInfo) == 1)
                Response.Write("<script  language='javascript'> window.alert('添加成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('添加失败'); </script>");
        }

        Response.Redirect("ModifyGoverResource.aspx?goverResourceID=" + goverResourceID.ToString());
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ModifyGoverResource.aspx?goverResourceID=" + goverResourceID.ToString());
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
