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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            VisitRecordDataBind();
        }
    }

    private void VisitRecordDataBind()
    {
        int visitRecordID = Convert.ToInt32(Request["visitRecordID"]);
        VisitRecord visitRecord = new VisitRecord();
        Customer customer = new Customer();
        Contact contact = new Contact();
        VisitRecordInfo visitRecordInfo = visitRecord.GetVisitRecordById(visitRecordID);
        ContactInfo contactInfo = contact.GetContactById(visitRecordInfo.ContactID);
        User user = new User();
        if (visitRecordInfo != null && contactInfo != null)
        {
            label_contactName2.Text = contactInfo.ContactName;
            label_address2.Text = contactInfo.Address;
            label_telephone2.Text = contactInfo.Telephone;
            label_recordTime2.Text = visitRecordInfo.RecordTime;
            label_recordDetail2.Text = visitRecordInfo.VisitDetail;
        }
    }
}
