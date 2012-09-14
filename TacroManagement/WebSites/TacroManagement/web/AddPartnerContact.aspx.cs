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

public partial class web_AddPartnerContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    PartnerContact partnerContact = new PartnerContact();
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
            }
        }
    }

    protected void Add_PartnerContact(object sender, EventArgs e)
    {
        PartnerContactInfo partnerContactInfo = new PartnerContactInfo();
        ContactInfo contactInfo = new ContactInfo();
        contactInfo.ContactName = txtContactName.Text;
        contactInfo.Position = txtPosition.Text;
        contactInfo.Mobilephone = txtMobilephone.Text;
        contactInfo.Telephone = txtTelephone.Text;
        contactInfo.Email = txtEmail.Text;
        contactInfo.Address = txtAddress.Text;
        contactInfo.PostCode = txtPostCode.Text;
        contactInfo.FaxNumber = txtFaxNumber.Text;

        partnerContactInfo.PartnerID = Convert.ToInt32(partnerResourceID);

        if (contact.InsertContact(contactInfo) == 1)
        {
            partnerContactInfo.ContactID = contact.GetContactByContactNameAndTelephone(contactInfo.ContactName, contactInfo.Telephone).ContactID;
            if (partnerContact.InsertPartnerContact(partnerContactInfo) == 1)
                Response.Write("<script  language='javascript'> window.alert('添加成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('添加失败'); </script>");
        }

        Response.Redirect("ModifyPartnerResource.aspx?partnerResourceID=" + partnerResourceID.ToString());
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ModifyPartnerResource.aspx?partnerResourceID=" + partnerResourceID.ToString());
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
