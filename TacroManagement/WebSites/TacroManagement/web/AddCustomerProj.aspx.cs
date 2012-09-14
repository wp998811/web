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

public partial class web_AddCustomerProj : System.Web.UI.Page
{
    Customer customer = new Customer();
    CustomerContact customerContact = new CustomerContact();
    User user = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            CustomerProjDataBind();
            InitDropDownList();
        }
    }

    private void InitDropDownList()
    {
        ArrayList progressList = new ArrayList();
        progressList.Add("洽谈");
        progressList.Add("评估");
        progressList.Add("签约");
        progressList.Add("启动");
        progressList.Add("跟踪");
        progressList.Add("关闭");
        for (int i = 0; i < progressList.Count; i++)
        {
            ddlProgress.Items.Add(new ListItem(progressList[i].ToString(), i.ToString()));
        }
        ArrayList payStateList = new ArrayList();
        payStateList.Add("未付款");
        payStateList.Add("已付款");
        payStateList.Add("已开票");
        for (int i = 0; i < payStateList.Count; i++)
        {
            ddlPayState.Items.Add(new ListItem(payStateList[i].ToString(), i.ToString()));
        }
    }

    private void CustomerProjDataBind()
    {
        //CustomerGridView.DataSource = customer.SearchAllCustomers();
        //CustomerGridView.DataBind();

        //绑定用户ddlUser
        IList<CustomerInfo> customerInfos = customer.GetCustomers();
        ddlCustomer.DataTextField = "CustomerName";
        ddlCustomer.DataValueField = "CustomerID";

        ddlCustomer.DataSource = customerInfos;
        ddlCustomer.DataBind();
    }

    protected void Add_CustomerProj(object sender, EventArgs e)
    {
        CustomerProject customerProject = new CustomerProject();
        CustomerProjectInfo customerProjectInfo = new CustomerProjectInfo();

        customerProjectInfo.CustomerID = Convert.ToInt32(txtHiddenCustomerID.Text);
        customerProjectInfo.Service = txtService.Text;
        customerProjectInfo.Progress = ddlProgress.SelectedItem.Text;
        customerProjectInfo.ProductName = txtProductName.Text;
        customerProjectInfo.ProjectType = txtProjectType.Text;
        customerProjectInfo.ContractAmount = (float)Convert.ToDouble(txtContractAmount.Text);
        customerProjectInfo.Payment = txtPayment.Text;
        customerProjectInfo.PayState = ddlPayState.SelectedItem.Text;

        if (customerProject.InsertCustomerProject(customerProjectInfo) == 1)
        {
            Response.Redirect("CustomerProjList.aspx");
        }
    }

    protected void lbtnSelectCustomer_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            if (ddlCustomer.Items.Count == 0)
                return;
            int customerID = Convert.ToInt32(ddlCustomer.SelectedValue);
            CustomerInfo customerInfo = customer.GetCustomerById(customerID);

            if (customerInfo != null)
            {
                txtCustomerName.Text = customerInfo.CustomerName;
                txtHiddenCustomerID.Text = customerID.ToString();
            }
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
