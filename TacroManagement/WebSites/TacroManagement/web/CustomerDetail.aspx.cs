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
    User user = new User();
    Customer customer = new Customer();
    Contact contact = new Contact();
    CustomerContact customerContact = new CustomerContact();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            CustomerDataBind();
        }
    }

    private void UserRpDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);

        rpUserList.DataSource = user.SearchUserByUserID(customer.GetCustomerById(customerID).UserID);
        rpUserList.DataBind();
    }

    private void CustomerDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        CustomerInfo customerInfo = customer.GetCustomerById(customerID);
        User user = new User();
        if (customerInfo != null)
        {
            lblCustomerName.Text = customerInfo.CustomerName;
            lblCity.Text = customerInfo.CustomerCity;
            lblCustomerType.Text = customerInfo.CustomerType;
            lblCustomerRank.Text = customerInfo.CustomerRank;
            lblProductRange.Text = customerInfo.ProductRange;
            lblTaxID.Text = customerInfo.TaxID;
            lblOrganCode.Text = customerInfo.OrganCode;
        }
        ContactRpDataBind();
        UserRpDataBind();
    }

    private void ContactRpDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        IList<ContactInfo> contactInfos = customerContact.GetCustomerContactsByCustomerId(customerID);

        this.ContactPager.RecordCount = contactInfos.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = customerContact.SearchAllContactsByCustomerID(customerID).DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ContactPager.CurrentPageIndex - 1;
        pds.PageSize = ContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }

    protected void Contact_PageChanged(object sender, EventArgs e)
    {
        ContactRpDataBind();
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
