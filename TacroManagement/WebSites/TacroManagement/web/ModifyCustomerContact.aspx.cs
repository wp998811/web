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

public partial class web_ModifyCustomerContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    CustomerContact customerContact = new CustomerContact();
    User user = new User();
    public static string contactID = "";
    public static string customerID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["contactID"] != null && Request.Params["contactID"].Trim() != "" &&
                Request.Params["customerID"] != null && Request.Params["customerID"].Trim() != "")
            {
                ContactDataBind();
                contactID = Request.Params["contactID"];
                customerID = Request.Params["customerID"];
            }
        }
    }

    private void ContactDataBind()
    {
        int contactID = Convert.ToInt32(Request["contactID"]);
        ContactInfo contactInfo = contact.GetContactById(contactID);
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

    protected void Modify_CustomerContact(object sender, EventArgs e)
    {
        if (contactID != null && contactID != "")
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

            CustomerInfo customerInfo = customerContact.GetCustomerByContactId(contactInfo.ContactID);

            if (customerInfo != null && contact.UpdateContact(contactInfo) == 1)
                Response.Redirect("ModifyCustomer.aspx?customerID=" + customerInfo.CustomerID.ToString());
        }
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ModifyCustomer.aspx?customerID=" + customerID);
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
