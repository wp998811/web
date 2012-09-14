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

public partial class web_AddContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    ContactInfo contactInfo = new ContactInfo();
    CustomerContact customerContact = new CustomerContact();
    User user = new User();
    public static string customerID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }

            if (Request.Params["customerID"].Trim() != "")
            {
                customerID = Request.Params["customerID"];
            }
        }
    }

    protected void Add_Contact(object sender, EventArgs e)
    {
        CustomerContactInfo customerContactInfo = new CustomerContactInfo();
        contactInfo.ContactName = txtContactName.Text;
        contactInfo.Position = txtPosition.Text;
        contactInfo.Mobilephone = txtMobilephone.Text;
        contactInfo.Telephone = txtTelephone.Text;
        contactInfo.Email = txtEmail.Text;
        contactInfo.Address = txtAddress.Text;
        contactInfo.PostCode = txtPostCode.Text;
        contactInfo.FaxNumber = txtFaxNumber.Text;

        customerContactInfo.CustomerID = Convert.ToInt32(customerID);

        if (contact.InsertContact(contactInfo) == 1)
        {
            customerContactInfo.ContactID = contact.GetContactByContactNameAndTelephone(contactInfo.ContactName, contactInfo.Telephone).ContactID;
            if(customerContact.InsertCustomerContact(customerContactInfo) == 1)
                Response.Write("<script  language='javascript'> window.alert('添加成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('添加失败'); </script>");
        }

        if (Request.Params["customerID"] == null || Request.Params["customerID"] == "")
            Response.Redirect("ModifyCustomer.aspx?customerID=" + customerID.ToString());
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ModifyCustomer.aspx?customerID=" + customerID.ToString());
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
