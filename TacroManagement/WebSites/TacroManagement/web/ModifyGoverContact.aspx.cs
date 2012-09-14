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

public partial class web_ModifyGoverContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    User user = new User();
    public static string contactID = "";
    public static string goverResourceID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["contactID"] != null && Request.Params["contactID"] != "" &&
                Request.Params["goverResourceID"] != null && Request.Params["goverResourceID"] != "")
            {
                contactID = Request.Params["contactID"];
                goverResourceID = Request.Params["goverResourceID"];
                ContactDataBind();
            }
        }
    }

    private void ContactDataBind()
    {
        ContactInfo contactInfo = contact.GetContactById(Convert.ToInt32(contactID));
        if (contactInfo != null)
        {
            txtContactName.Text = contactInfo.ContactName;
            txtPosition.Text = contactInfo.Position;
            txtMobilephone.Text = contactInfo.Mobilephone;
            txtTelephone.Text = contactInfo.Telephone;
            txtEmail.Text = contactInfo.Email;
            txtAddress.Text = contactInfo.Address;
            txtPostCode.Text = contactInfo.PostCode;
            txtFaxNumber.Text = contactInfo.FaxNumber;
        }
    }

    protected void Modify_GoverContact(object sender, EventArgs e)
    {
        ContactInfo contactInfo = contact.GetContactById(Convert.ToInt32(contactID));
        contactInfo.ContactName = txtContactName.Text;
        contactInfo.Position = txtPosition.Text;
        contactInfo.Mobilephone = txtMobilephone.Text;
        contactInfo.Telephone = txtTelephone.Text;
        contactInfo.Email = txtEmail.Text;
        contactInfo.Address = txtAddress.Text;
        contactInfo.PostCode = txtPostCode.Text;
        contactInfo.FaxNumber = txtFaxNumber.Text;

        if (contact.UpdateContact(contactInfo) != -1)
        {
            Response.Write("<script  language='javascript'> alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
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
