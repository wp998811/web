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
    CustomerProject customerProject = new CustomerProject();
    CustomerContact customerContact = new CustomerContact();
    Customer customer = new Customer();
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
        }
    }

    private void CustomerProjDataBind()
    {
        int customerProjID = Convert.ToInt32(Request["customerProjID"]);

        CustomerProjectInfo customerProjInfo = customerProject.GetCustomerProjByPorjId(customerProjID);
        CustomerInfo customerInfo = customer.GetCustomerById(customerProjInfo.CustomerID);
        if (customerProjInfo != null)
        {
            lblCustomerName.Text = customerInfo.CustomerName;
            lblProductName.Text = customerProjInfo.ProductName;
            lblService.Text = customerProjInfo.Service;
            lblProgress.Text = customerProjInfo.Progress;
            lblProjectType.Text = customerProjInfo.ProjectType;
            lblContractAmount.Text = customerProjInfo.ContractAmount.ToString();
            lblPayment.Text = customerProjInfo.Payment;
            lblPayState.Text = customerProjInfo.PayState;
        }

        rpCustomerList.DataSource = customerProject.SearchCustomerByProjID(customerProjID);
        rpCustomerList.DataBind();

        DataTable contactdt = customerContact.SearchAllContactsByCustomerID(customerProjInfo.CustomerID);

        this.ContactPager.RecordCount = contactdt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = contactdt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ContactPager.CurrentPageIndex - 1;
        pds.PageSize = ContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }

    protected void Contact_PageChanged(object sender, EventArgs e)
    {
        CustomerProjDataBind();
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
