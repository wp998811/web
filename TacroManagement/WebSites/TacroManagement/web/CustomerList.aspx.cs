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

public partial class web_CustomerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerDataBind();
        }
    }

    private void CustomerDataBind()
    {
        Customer customer = new Customer();
        IList<CustomerInfo> projectInfos = customer.GetCustomers();

        CustomerGridView.DataSource = customer.SearchAllCustomers();
        CustomerGridView.DataBind();

        ddl_CustomerPage.Items.Clear();
        for (int i = 1; i <= CustomerGridView.PageCount; i++)
        {
            ddl_CustomerPage.Items.Add(i.ToString());
        }
        if (ddl_CustomerPage.SelectedIndex != -1)
            ddl_CustomerPage.SelectedIndex = CustomerGridView.PageIndex;
    }

    protected void CustomerGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string customerId = CustomerGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyCustomer.aspx?customerID=" + customerId);
    }


    protected void Add_Customer(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomer.aspx");
    }

    protected void CustomerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Customer customer = new Customer();

        int customerId = Convert.ToInt32(CustomerGridView.DataKeys[e.RowIndex][0].ToString());

        if (customer.DeleteCustomer(customerId)==1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        CustomerDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Customer_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CustomerGridView.PageIndex = this.ddl_CustomerPage.SelectedIndex;
        CustomerDataBind();
    }
    protected void Customer_FirstPage_Click(object sender, EventArgs e)
    {
        this.CustomerGridView.PageIndex = 0;
        CustomerDataBind();
    }
    protected void Customer_PrePage_Click(object sender, EventArgs e)
    {
        if (this.CustomerGridView.PageIndex > 0)
        {
            this.CustomerGridView.PageIndex = this.CustomerGridView.PageIndex - 1;
            CustomerDataBind();
        }
    }
    protected void Customer_NextPage_Click(object sender, EventArgs e)
    {
        if (this.CustomerGridView.PageIndex < this.CustomerGridView.PageCount)
        {
            this.CustomerGridView.PageIndex = this.CustomerGridView.PageIndex + 1;
            CustomerDataBind();
        }
    }
    protected void Customer_LastPage_Click(object sender, EventArgs e)
    {
        this.CustomerGridView.PageIndex = this.CustomerGridView.PageCount;
        CustomerDataBind();
    }

    protected void CustomerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.label_Customer_CurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.CustomerGridView.PageIndex + 1, this.CustomerGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = CustomerGridView.PageIndex * CustomerGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void CustomerGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string customerId = CustomerGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("CustomerDetail.aspx?customerID=" + customerId);
                break;
        }
    }
}
