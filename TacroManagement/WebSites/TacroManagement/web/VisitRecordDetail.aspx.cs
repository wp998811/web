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

public partial class web_VisitRecordDetail : System.Web.UI.Page
{
    VisitRecord visitRecord = new VisitRecord();
    Customer customer = new Customer();
    Contact contact = new Contact();
    User user = new User();
    public static string visitRecordID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["visitRecordID"] != null && Request.Params["visitRecordID"] != "")
            {
                visitRecordID = Request.Params["visitRecordID"];
                VisitRecordDataBind();
            }
        }
    }

    private void VisitRecordDataBind()
    {
        VisitRecordInfo visitRecordInfo = visitRecord.GetVisitRecordById(Convert.ToInt32(visitRecordID));
        ContactInfo contactInfo = contact.GetContactById(visitRecordInfo.ContactID);

        if (visitRecordInfo != null && contactInfo != null)
        {
            lblContactName.Text = contactInfo.ContactName;
            lblAddress.Text = contactInfo.Address;
            lblTelephone.Text = contactInfo.Telephone;
            lblVisitTime.Text = visitRecordInfo.RecordTime;
            lblVisitDetail.Text = visitRecordInfo.VisitDetail;
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
