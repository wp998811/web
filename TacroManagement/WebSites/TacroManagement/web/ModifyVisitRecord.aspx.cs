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

public partial class web_ModifyVisitRecord : System.Web.UI.Page
{
    Customer customer = new Customer();
    CustomerContact customerContact = new CustomerContact();
    VisitRecord visitRecord = new VisitRecord();
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
        txtVisitDetail.Text = visitRecordInfo.VisitDetail;
        txtVisitTime.Value = FormatDateTime(visitRecordInfo.RecordTime);
    }

    protected void Modify_VisitRecord(object sender, EventArgs e)
    {
        VisitRecordInfo visitRecordInfo = visitRecord.GetVisitRecordById(Convert.ToInt32(visitRecordID));
        visitRecordInfo.RecordTime = txtVisitTime.Value;
        visitRecordInfo.VisitDetail = txtVisitDetail.Text;

        if (visitRecord.UpdateVisitRecord(visitRecordInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("VisitRecordList.aspx");
    }

    private string FormatDateTime(string dateTime)
    {
        string result = "";
        if (dateTime != "" && dateTime != null)
        {
            string[] time = dateTime.Split(' ');
            result = time[0].Replace('/', '-');
        }
        return result;
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("VisitRecordList.aspx");
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
