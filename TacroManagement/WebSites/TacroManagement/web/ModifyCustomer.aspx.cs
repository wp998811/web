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

public partial class web_ModifyCustomer : System.Web.UI.Page
{
    Customer customer = new Customer();
    User user = new User();
    Contact contact = new Contact();
    CustomerContact customerContact = new CustomerContact();
    public static string customerID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }

            if (Request.Params["customerID"] != null && Request.Params["customerID"].Trim() != "")
            {
                CustomerDataBind();
                customerID = Request.Params["customerID"];
            }
        }
    }

    private void ContactRpDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);

        DataTable contactdt = customerContact.SearchAllContactsByCustomerID(customerID);

        this.ContactPager.RecordCount = contactdt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = contactdt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ContactPager.CurrentPageIndex - 1;
        pds.PageSize = ContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();

        //绑定用户ddlUser
        IList<UserInfo> userInfos = user.GetUsers();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";

        ddlUser.DataSource = userInfos;
        ddlUser.DataBind();
    }

    protected void Contact_PageChanged(object sender, EventArgs e)
    {
        ContactRpDataBind();
    }

    private void CustomerDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        CustomerInfo customerInfo = customer.GetCustomerById(customerID);
        if (customerInfo != null)
        {
            txtCustomerName.Text = customerInfo.CustomerName;
            UserInfo userInfo = user.GetUserById(customerInfo.UserID);
            txtManager.Text = userInfo.UserName;
            ArrayList customerTypeList = new ArrayList();
            customerTypeList.Add("外包");
            customerTypeList.Add("转包");
            ddlCustomerType.Items.Clear();
            for (int i = 0; i < customerTypeList.Count; i++)
            {
                ddlCustomerType.Items.Add(new ListItem(customerTypeList[i].ToString(), i.ToString()));
                if (customerInfo.CustomerType == customerTypeList[i].ToString())
                    ddlCustomerType.SelectedIndex = i;
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
                if (customerInfo.ProductRange == productRangeList[i].ToString())
                    ddlProductRange.SelectedIndex = i;
            }
            txtCity.Text = customerInfo.CustomerCity;
            txtCustomerRank.Text = customerInfo.CustomerRank;
            txtTaxID.Text = customerInfo.TaxID;
            txtOrganCode.Text = customerInfo.OrganCode;

            txtHiddenUserID.Text = customerInfo.UserID.ToString();

            ContactRpDataBind();
        }
    }

    protected void ModifyContact(object sender, EventArgs e)
    {
        CustomerInfo customerInfo = customer.GetCustomerById(Convert.ToInt32(Request.QueryString["customerID"]));
        customerInfo.CustomerName = txtCustomerName.Text;
        customerInfo.UserID = Convert.ToInt32(txtHiddenUserID.Text);
        customerInfo.CustomerCity = txtCity.Text;
        customerInfo.CustomerType = ddlCustomerType.SelectedItem.Text;
        customerInfo.CustomerRank = txtCustomerRank.Text;
        customerInfo.ProductRange = ddlProductRange.SelectedItem.Text;
        customerInfo.TaxID = txtTaxID.Text;
        customerInfo.OrganCode = txtOrganCode.Text;

        if (customer.UpdateCustomer(customerInfo) != -1)
        {
            Response.Redirect("CustomerList.aspx");
        }
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }

    protected void lbtnSelectUser_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            if (ddlUser.Items.Count == 0)
                return;
            int userID = Convert.ToInt32(ddlUser.SelectedValue);
            UserInfo userInfo = user.GetUserById(userID);

            if (userInfo != null)
            {
                txtManager.Text = userInfo.UserName;
                txtHiddenUserID.Text = userID.ToString();
            }
        }
    }

    protected void rpContactList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyCustomerContact.aspx?contactID=" + contactID.ToString() + "&customerID=" + customerID);
                    break;
                }
            case "delete":
                {
                    int contactId = Convert.ToInt32(e.CommandArgument.ToString());

                    if (contact.DeleteContact(contactId) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    ContactRpDataBind();
                    break;
                }
            case "addVisitRecord":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("AddVisitRecord.aspx?contactID=" + contactID.ToString() + "&ID=" + customerID + "&resourceType=客户");
                    ContactRpDataBind();
                    break;
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
