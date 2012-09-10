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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            VisitRecordDataBind();

            //if (Session["userID"].ToString() == "")
            //{
            //    Response.Redirect("login.aspx");
            //}
            ContactGridView.Visible = false;
            CustomerGridView.Visible = false;
        }
    }

    private void VisitRecordDataBind()
    {
        Customer customer = new Customer();
        CustomerContact customerContact = new CustomerContact();
        VisitRecord visitRecord = new VisitRecord();
        Contact contact = new Contact();

        int visitRecordID = Convert.ToInt32(Request["visitRecordID"]);
        VisitRecordInfo visitRecordInfo = visitRecord.GetVisitRecordById(visitRecordID);
        ContactInfo contactInfo = contact.GetContactById(visitRecordInfo.ContactID);
        CustomerInfo customerInfo = customerContact.GetCustomerByContactId(visitRecordInfo.ContactID);
        textBox_recordDetail.Text = visitRecordInfo.VisitDetail;

        iEndDate.Value = FormatDateTime(visitRecordInfo.RecordTime);

        textBox_customerName.Text = customerInfo.CustomerName;
        CustomerID_TextBox.Text = customerInfo.CustomerID.ToString();
        textBox_contactName.Text = contactInfo.ContactName;
        ContactID_TextBox.Text = contactInfo.ContactID.ToString();

        CustomerGridView.DataSource = customer.SearchAllCustomers();
        CustomerGridView.DataBind();

        if (CustomerID_TextBox.Text != "")
        {
            int customerID = Convert.ToInt32(CustomerID_TextBox.Text);
            ContactGridView.DataSource = customerContact.SearchAllContactsByCustomerID(customerID);
        }
        else
        {
            ContactGridView.DataSource = contact.SearchAllContacts();
        }
        ContactGridView.DataBind();
    }

    protected void Modify_VisitRecord(object sender, EventArgs e)
    {
        VisitRecord visitRecord = new VisitRecord();
        VisitRecordInfo visitRecordInfo = visitRecord.GetVisitRecordById(Convert.ToInt32(Request["visitRecordID"]));
        visitRecordInfo.ContactID = Convert.ToInt32(ContactID_TextBox.Text);
        visitRecordInfo.RecordTime = iEndDate.Value;
        visitRecordInfo.VisitDetail = textBox_recordDetail.Text;
        //visitRecordInfo.UserID = Convert.ToInt32(Request["userID"]);
        visitRecordInfo.UserID = 1;

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

    protected void Select_Customer(object sender, EventArgs e)
    {
        CustomerGridView.Visible = true;
        Customer_Hidden.Visible = true;
    }

    protected void Select_Contact(object sender, EventArgs e)
    {
        ContactGridView.Visible = true;
        Contact_Hidden.Visible = true;
        VisitRecordDataBind();
    }

    //protected void CustomerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        CheckBox mycb = new CheckBox();
    //        mycb = (CheckBox)e.Row.FindControl("CheckBox1");
    //        if (mycb != null)
    //        {
    //            //if (e.Row.RowType == DataControlRowType.DataRow)
    //            //{
    //            //    mycb.Attributes.Add("onclick", "select_customer(this.name)");
    //            //}
    //        }
    //    }
    //}

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

    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerCheckBoxChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= CustomerGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(CustomerGridView.Rows[i].FindControl("Customer_CheckBox"));
            if (cbox != (CheckBox)sender)
                cbox.Checked = false;
        }
        int customerID = Convert.ToInt32(GetCustomerID());
        Customer customer = new Customer();
        CustomerInfo customerInfo = customer.GetCustomerById(customerID);
        textBox_customerName.Text = customerInfo.CustomerName;
        CustomerID_TextBox.Text = customerID.ToString();
    }

    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ContactCheckBoxChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= ContactGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(ContactGridView.Rows[i].FindControl("Contact_CheckBox"));
            if (cbox != (CheckBox)sender)
                cbox.Checked = false;
        }
        int contactID = Convert.ToInt32(GetContactID());
        Contact contact = new Contact();
        ContactInfo contactInfo = contact.GetContactById(contactID);
        textBox_contactName.Text = contactInfo.ContactName;
    }

    public string GetCustomerID()
    {
        //取选中的事件编号
        string streid = "";
        if (CustomerGridView != null)
        {
            int i, row;
            i = 0;
            row = CustomerGridView.Rows.Count;
            CheckBox mycb = new CheckBox();
            for (i = 0; i < row; i++)
            {
                mycb = (CheckBox)CustomerGridView.Rows[i].FindControl("Customer_CheckBox");
                if (mycb != null)
                {
                    if (mycb.Checked)
                    {
                        TextBox mytb = new TextBox();
                        mytb = (TextBox)CustomerGridView.Rows[i].FindControl("Customer_TextBox");
                        if (mytb != null)
                        {
                            streid = streid + mytb.Text.Trim() + ",";
                        }
                    }
                }
            }
        }
        if (streid.Length > 0)
        {
            streid = streid.Remove(streid.Length - 1);
        }
        return streid;
    }

    public string GetContactID()
    {
        //取选中的事件编号
        string streid = "";
        if (ContactGridView != null)
        {
            int i, row;
            i = 0;
            row = ContactGridView.Rows.Count;
            CheckBox mycb = new CheckBox();
            for (i = 0; i < row; i++)
            {
                mycb = (CheckBox)ContactGridView.Rows[i].FindControl("Contact_CheckBox");
                if (mycb != null)
                {
                    if (mycb.Checked)
                    {
                        TextBox mytb = new TextBox();
                        mytb = (TextBox)ContactGridView.Rows[i].FindControl("Contact_TextBox");
                        if (mytb != null)
                        {
                            streid = streid + mytb.Text.Trim() + ",";
                        }
                    }
                }
            }
        }
        if (streid.Length > 0)
        {
            streid = streid.Remove(streid.Length - 1);
        }
        return streid;
    }

    protected void CustomerList_Hidden(object sender, EventArgs e)
    {
        CustomerGridView.Visible = false;
        Customer_Hidden.Visible = false;
    }

    protected void ContactList_Hidden(object sender, EventArgs e)
    {
        ContactGridView.Visible = false;
        Contact_Hidden.Visible = false;
    }
}
