using System;
using System.Collections;
using System.Collections.Generic;
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

using BLL;
using Model;

public partial class web_AddCustomer : System.Web.UI.Page
{
    User user = new User();
    Customer customer = new Customer();

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

    private void CustomerDataBind()
    {
        IList<UserInfo> userInfos = user.GetUsers();
        for (int i = 0; i < userInfos.Count; i++)
        {
            ddlManager.Items.Add(new ListItem(userInfos[i].UserName, Convert.ToString(userInfos[i].UserID)));
        }
        ArrayList customerTypeList = new ArrayList();
        customerTypeList.Add("外包");
        customerTypeList.Add("转包");
        for (int i = 0; i < customerTypeList.Count; i++)
        {
            ddlCustomerType.Items.Add(new ListItem(customerTypeList[i].ToString(), i.ToString()));
        }
        ArrayList productRangeList = new ArrayList();
        productRangeList.Add("激光");
        productRangeList.Add("超声");
        productRangeList.Add("体外诊断试剂");
        productRangeList.Add("监护");
        productRangeList.Add("影像");
        for (int i = 0; i < productRangeList.Count; i++)
        {
            ddlProductRange.Items.Add(new ListItem(productRangeList[i].ToString(), i.ToString()));
        }
    }

    protected void Add_Customer(object sender, EventArgs e)
    {
        CustomerInfo customerInfo = new CustomerInfo();
        customerInfo.CustomerName = txtCustomerName.Text;
        customerInfo.UserID = Convert.ToInt32(ddlManager.SelectedValue);
        customerInfo.CustomerCity = txtCity.Text;
        customerInfo.CustomerType = ddlCustomerType.SelectedItem.Text;
        customerInfo.CustomerRank = txtLevel.Text;
        customerInfo.ProductRange = ddlProductRange.SelectedItem.Text;
        customerInfo.TaxID = txtTaxID.Text;
        customerInfo.OrganCode = txtOrganCode.Text;

        if (customer.InsertCustomer(customerInfo) == 1)
        {
            Response.Redirect("CustomerList.aspx");
        }
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
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

