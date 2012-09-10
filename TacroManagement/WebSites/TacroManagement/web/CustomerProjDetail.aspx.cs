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


public partial class web_CustomerProjDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CustomerProjDataBind();
        }
    }

    private void CustomerProjDataBind()
    {
        int customerProjID = Convert.ToInt32(Request["customerProjID"]);
        CustomerProject customerProject = new CustomerProject();
        CustomerContact customerContact = new CustomerContact();
        Customer customer = new Customer();
        CustomerProjectInfo customerProjInfo = customerProject.GetCustomerProjByPorjId(customerProjID);
        CustomerInfo customerInfo = customer.GetCustomerById(customerProjInfo.CustomerID);
        if (customerProjInfo != null)
        {
            label_customerName2.Text = customerInfo.CustomerName;
            label_productName2.Text = customerProjInfo.ProductName;
            label_service2.Text = customerProjInfo.Service;
            label_progress2.Text = customerProjInfo.Progress;
            label_projectType2.Text = customerProjInfo.ProjectType;
            label_contractAmount2.Text = customerProjInfo.ContractAmount.ToString();
            label_payment2.Text = customerProjInfo.Payment;
            label_payState2.Text = customerProjInfo.PayState;
        }

        CustomerGridView.DataSource = customerProject.SearchCustomerByProjID(customerProjID);
        CustomerGridView.DataBind();

        ContactGridView.DataSource = customerContact.SearchAllContactsByCustomerID(customerProjInfo.CustomerID);
        ContactGridView.DataBind();

        //ddlCurrentPage.Items.Clear();
        //for (int i = 1; i <= ContactGridView.PageCount; i++)
        //{
        //    ddlCurrentPage.Items.Add(i.ToString());
        //}
        //ddlCurrentPage.SelectedIndex = ContactGridView.PageIndex;
    }

    ///// <summary>
    ///// 重新绑定
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    this.ContactGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
    //    CustomerProjDataBind();
    //}
    //protected void lnkbtnFrist_Click(object sender, EventArgs e)
    //{
    //    this.ContactGridView.PageIndex = 0;
    //    CustomerProjDataBind();
    //}
    //protected void lnkbtnPre_Click(object sender, EventArgs e)
    //{
    //    if (this.ContactGridView.PageIndex > 0)
    //    {
    //        this.ContactGridView.PageIndex = this.ContactGridView.PageIndex - 1;
    //        CustomerProjDataBind();
    //    }
    //}
    //protected void lnkbtnNext_Click(object sender, EventArgs e)
    //{
    //    if (this.ContactGridView.PageIndex < this.ContactGridView.PageCount)
    //    {
    //        this.ContactGridView.PageIndex = this.ContactGridView.PageIndex + 1;
    //        CustomerProjDataBind();
    //    }
    //}
    //protected void lnkbtnLast_Click(object sender, EventArgs e)
    //{
    //    this.ContactGridView.PageIndex = this.ContactGridView.PageCount;
    //    CustomerProjDataBind();
    //}

    //protected void ContactGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.ContactGridView.PageIndex + 1, this.ContactGridView.PageCount);

    //    //遍历所有行设置边框样式
    //    foreach (TableCell tc in e.Row.Cells)
    //    {
    //        tc.Attributes["style"] = "border-color:Black";
    //    }
    //    //用索引来取得编号
    //    if (e.Row.RowIndex != -1)
    //    {
    //        int id = ContactGridView.PageIndex * ContactGridView.PageSize + e.Row.RowIndex + 1;
    //        e.Row.Cells[0].Text = id.ToString();
    //    }
    //}
}
