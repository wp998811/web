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

public partial class web_ModifyCustomerProjContact : System.Web.UI.Page
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
        Customer customer = new Customer();
        CustomerContact customerContact = new CustomerContact();

        CustomerGridView.DataSource = customer.SearchAllCustomers();
        CustomerGridView.DataBind();

        if (CustomerID_TextBox.Text != "")
        {
            int customerID = Convert.ToInt32(CustomerID_TextBox.Text);
            ContactGridView.DataSource = customerContact.SearchAllContactsByCustomerID(customerID);
            ContactGridView.DataBind();
        }

        CustomerProjectInfo customerProjectInfo = customerProject.GetCustomerProjByPorjId(customerProjID);
        CustomerInfo customerInfo = customer.GetCustomerById(customerProjectInfo.CustomerID);
        textBox_service.Text = customerProjectInfo.Service;
        textBox_productName.Text = customerProjectInfo.ProductName;
        textBox_projectType.Text = customerProjectInfo.ProjectType;
        textBox_contractAmount.Text = customerProjectInfo.ContractAmount.ToString();
        textBox_payment.Text = customerProjectInfo.Payment;
        textBox_customerName.Text = customerInfo.CustomerName;
        CustomerID_TextBox.Text = customerInfo.CustomerID.ToString();

        ArrayList progressList = new ArrayList();
        progressList.Add("洽谈");
        progressList.Add("评估");
        progressList.Add("签约");
        progressList.Add("启动");
        progressList.Add("跟踪");
        progressList.Add("关闭");
        for (int i = 0; i < progressList.Count; i++)
        {
            ddl_progress.Items.Add(new ListItem(progressList[i].ToString(), i.ToString()));
            if (customerProjectInfo.Progress == progressList[i].ToString())
                ddl_progress.SelectedIndex = i;
        }
        ArrayList payStateList = new ArrayList();
        payStateList.Add("未付款");
        payStateList.Add("已付款");
        payStateList.Add("已开票");
        for (int i = 0; i < payStateList.Count; i++)
        {
            ddl_payState.Items.Add(new ListItem(payStateList[i].ToString(), i.ToString()));
            if (customerProjectInfo.PayState == payStateList[i].ToString())
                ddl_payState.SelectedIndex = i;
        }
    }

    protected void Modify_CustomerProj(object sender, EventArgs e)
    {
        CustomerProject customerProject = new CustomerProject();
        CustomerProjectInfo customerProjectInfo = customerProject.GetCustomerProjByPorjId(Convert.ToInt32(Request["customerProjID"]));

        customerProjectInfo.CustomerID = Convert.ToInt32(CustomerID_TextBox.Text);
        customerProjectInfo.Service = textBox_service.Text;
        customerProjectInfo.Progress = ddl_progress.SelectedItem.Text;
        customerProjectInfo.ProductName = textBox_productName.Text;
        customerProjectInfo.ProjectType = textBox_projectType.Text;
        customerProjectInfo.ContractAmount = (float)Convert.ToDouble(textBox_contractAmount.Text);
        customerProjectInfo.Payment = textBox_payment.Text;
        customerProjectInfo.PayState = ddl_payState.SelectedItem.Text;

        if (customerProject.UpdateCustomerProject(customerProjectInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("CustomerProjList.aspx");
    }

    protected void Select_Customer(object sender, EventArgs e)
    {
        CustomerGridView.Visible = true;
        Customer_Hidden.Visible = true;
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

    protected void CustomerList_Hidden(object sender, EventArgs e)
    {
        CustomerGridView.Visible = false;
        Customer_Hidden.Visible = false;
    }

    protected void Select_Contact(object sender, EventArgs e)
    {
        ContactGridView.Visible = true;
        Contact_Hidden.Visible = true;
        CustomerProjDataBind();
    }

    protected void ContactList_Hidden(object sender, EventArgs e)
    {
        ContactGridView.Visible = false;
        Contact_Hidden.Visible = false;
    }
}
