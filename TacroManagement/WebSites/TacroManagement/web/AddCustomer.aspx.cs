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

public partial class web_AddCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CustomerDataBind();
        }
    }

    private void CustomerDataBind()
    {
            User user = new User();
            IList<UserInfo> userInfos = user.GetUsers();
            for (int i = 0; i < userInfos.Count; i++)
            {
                dropDown_customerManager.Items.Add(new ListItem(userInfos[i].UserName, Convert.ToString(userInfos[i].UserID)));
            }
            ArrayList customerTypeList = new ArrayList();
            customerTypeList.Add("外包");
            customerTypeList.Add("转包");
            for (int i = 0; i < customerTypeList.Count; i++)
            {
                ddl_clientType.Items.Add(new ListItem(customerTypeList[i].ToString(), i.ToString()));
            }
            ArrayList productRangeList = new ArrayList();
            productRangeList.Add("激光");
            productRangeList.Add("超声");
            productRangeList.Add("体外诊断试剂");
            productRangeList.Add("监护");
            productRangeList.Add("影像");
            for (int i = 0; i < productRangeList.Count; i++)
            {
                ddl_productRange.Items.Add(new ListItem(productRangeList[i].ToString(), i.ToString()));
            }
    }

    protected void Add_Customer(object sender, EventArgs e)
    {
        Customer customer = new Customer();
        CustomerInfo customerInfo = new CustomerInfo();
        customerInfo.CustomerName = textBox_customerName.Text;
        customerInfo.UserID = Convert.ToInt32(dropDown_customerManager.SelectedValue);
        customerInfo.CustomerCity = textBox_city.Text;
        customerInfo.CustomerType = ddl_clientType.SelectedItem.Text;
        customerInfo.CustomerRank = textBox_level.Text;
        customerInfo.ProductRange = ddl_productRange.SelectedItem.Text;
        customerInfo.TaxID = textBox_taxID.Text;
        customerInfo.OrganCode = textBox_organCode.Text;

        if (customer.InsertCustomer(customerInfo) == 1)
        {
            Response.Redirect("CustomerList.aspx");
        }
    }
}

