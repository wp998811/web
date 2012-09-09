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


public partial class web_CustomerDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CustomerDataBind();
        }
    }



    private void ContactGridViewDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        CustomerContact customerContact = new CustomerContact();

        ContactGridView.DataSource = customerContact.SearchAllContactsByCustomerID(customerID);
        ContactGridView.DataBind();

        ddl_ContactPage.Items.Clear();
        for (int i = 1; i <= ContactGridView.PageCount; i++)
        {
            ddl_ContactPage.Items.Add(i.ToString());
        }
        ddl_ContactPage.SelectedIndex = ContactGridView.PageIndex;
    }

    private void CustomerDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        Customer customer = new Customer();
        CustomerInfo customerInfo = customer.GetCustomerById(customerID);
        User user = new User();
        if (customerInfo != null)
        {
            label_customerName2.Text = customerInfo.CustomerName;
            UserInfo userInfo = user.GetUserById(customerInfo.UserID);
            label_customerManager2.Text = userInfo.UserName;
            label_city2.Text = customerInfo.CustomerCity;
            label_clientType2.Text = customerInfo.CustomerType;
            label_level2.Text = customerInfo.CustomerRank;
            label_productRange2.Text = customerInfo.ProductRange;
            label_taxID2.Text = customerInfo.TaxID;
            label_organCode2.Text = customerInfo.OrganCode;
        }
        ContactGridViewDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Contact_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ddl_ContactPage.SelectedIndex;
        ContactGridViewDataBind();
    }
    protected void Contact_FirstPage_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = 0;
        ContactGridViewDataBind();
    }
    protected void Contact_PrePage_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex > 0)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex - 1;
            ContactGridViewDataBind();
        }
    }
    protected void Contact_NextPage_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex < this.ContactGridView.PageCount)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex + 1;
            ContactGridViewDataBind();
        }
    }
    protected void Contact_LastPage_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ContactGridView.PageCount;
        ContactGridViewDataBind();
    }

    protected void ContactGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.label_Contact_CurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.ContactGridView.PageIndex + 1, this.ContactGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = ContactGridView.PageIndex * ContactGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
}
