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

public partial class web_ModifyContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ContactDataBind();
        }
    }

    private void ContactDataBind()
    {
        int contactID = Convert.ToInt32(Request["contactID"]);
        Contact contact = new Contact();
        ContactInfo contactInfo = contact.GetContactById(contactID);
        if (contactInfo != null)
        {
            textBox_contactName.Text = contactInfo.ContactName;
            textBox_position.Text = contactInfo.Position;
            textBox_mobilephone.Text = contactInfo.Mobilephone;
            textBox_telephone.Text = contactInfo.Telephone;
            textBox_email.Text = contactInfo.Email;
            textBox_address.Text = contactInfo.Address;
            textBox_postCode.Text = contactInfo.PostCode;
            textBox_faxNumber.Text = contactInfo.FaxNumber;
        }
    }
    
    protected void Modify_Contact(object sender, EventArgs e)
    {
        Contact contact = new Contact();
        ContactInfo contactInfo = contact.GetContactById(Convert.ToInt32(Request.QueryString["contacID"]));
        contactInfo.ContactName = textBox_contactName.Text;
        contactInfo.Position = textBox_position.Text;
        contactInfo.Mobilephone = textBox_mobilephone.Text;
        contactInfo.Telephone = textBox_telephone.Text;
        contactInfo.Email = textBox_email.Text;
        contactInfo.Address = textBox_address.Text;
        contactInfo.PostCode = textBox_postCode.Text;
        contactInfo.FaxNumber = textBox_faxNumber.Text;

        if (contact.UpdateContact(contactInfo) != -1)
        {
            Response.Write("<script  language='javascript'> alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("ModifyCustomer.aspx?=" + contactInfo.ContactID.ToString());
    }

    protected void Add_Contact(object sender, EventArgs e)
    {
        string customerID = Request.QueryString["customerID"];
        Response.Redirect("AddContact.aspx?customerID=" + customerID);
    }
}
