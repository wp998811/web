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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
        }
    }

    protected void Add_GoverContact(object sender, EventArgs e)
    {
        Contact contact = new Contact();
        ContactInfo contactInfo = new ContactInfo();
        GoverContact goverContact = new GoverContact();
        GoverContactInfo goverContactInfo = new GoverContactInfo();
        contactInfo.ContactName = textBox_contactName.Text;
        contactInfo.Position = textBox_position.Text;
        contactInfo.Mobilephone = textBox_mobilephone.Text;
        contactInfo.Telephone = textBox_telephone.Text;
        contactInfo.Email = textBox_email.Text;
        contactInfo.Address = textBox_address.Text;
        contactInfo.PostCode = textBox_postCode.Text;
        contactInfo.FaxNumber = textBox_faxNumber.Text;

        int goverResourceID = Convert.ToInt32(Request.QueryString["goverResourceID"]);

        goverContactInfo.GoverID = goverResourceID;

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
}
