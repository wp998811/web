﻿using System;
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

public partial class web_AddClinicalContact : System.Web.UI.Page
{
    Contact contact = new Contact();
    ClinicalContact clinicalContact = new ClinicalContact();
    User user = new User();
    public static string clinicalResourceID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["clinicalResourceID"] != null && Request.Params["clinicalResourceID"].Trim() != "")
            {
                clinicalResourceID = Request.Params["clinicalResourceID"];
            }
        }
    }

    protected void Add_ClinicalContact(object sender, EventArgs e)
    {
        ContactInfo contactInfo = new ContactInfo();
        ClinicalContactInfo clinicalContactInfo = new ClinicalContactInfo();
        contactInfo.ContactName = txtContactName.Text;
        contactInfo.Position = txtPosition.Text;
        contactInfo.Mobilephone = txtMobilephone.Text;
        contactInfo.Telephone = txtTelephone.Text;
        contactInfo.Email = txtEmail.Text;
        contactInfo.Address = txtEmail.Text;
        contactInfo.PostCode = txtPostCode.Text;
        contactInfo.FaxNumber = txtFaxNumber.Text;

        int clinicalResourceID = Convert.ToInt32(Request.QueryString["clinicalResourceID"]);

        clinicalContactInfo.ClinicalID = clinicalResourceID;

        if (contact.InsertContact(contactInfo) == 1)
        {
            clinicalContactInfo.ContactID = contact.GetContactByContactNameAndTelephone(contactInfo.ContactName, contactInfo.Telephone).ContactID;
            if (clinicalContact.InsertClinicalContact(clinicalContactInfo) == 1)
                Response.Write("<script  language='javascript'> window.alert('添加成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('添加失败'); </script>");
        }

        Response.Redirect("ModifyClinicalResource.aspx?clinicalResourceID=" + clinicalResourceID.ToString());
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ModifyClinicalResource.aspx?clinicalResourceID=" + clinicalResourceID.ToString());
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
