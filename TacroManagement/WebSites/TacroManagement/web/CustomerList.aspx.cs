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
    Customer customer = new Customer();
    User user = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        IList<CustomerInfo> customerInfos = customer.GetCustomers();

        this.CustomerPager.RecordCount = customerInfos.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = customer.SearchAllCustomers().DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = CustomerPager.CurrentPageIndex - 1;
        pds.PageSize = CustomerPager.PageSize;

        rpCustomerList.DataSource = pds;
        rpCustomerList.DataBind();
    }

    protected void Customer_PageChanged(object sender, EventArgs e)
    {
        CustomerDataBind();
    }

    protected void rpCustomerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (!Authoritycontrol())
        //{
        //    Control deleteCon = e.Item.FindControl("DeleteBtn");
        //    if (deleteCon != null)
        //    {
        //        LinkButton deleteBtn = (LinkButton)deleteCon;
        //        deleteBtn.Visible = false;
        //    }
        //    Control modifyCon = e.Item.FindControl("ModifyBtn");
        //    if (modifyCon != null)
        //    {
        //        LinkButton modifyBtn = (LinkButton)modifyCon;
        //        modifyBtn.Visible = false;
        //    }
        //}
    }

    protected void rpCustomerList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int customerId = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyCustomer.aspx?customerID=" + customerId);
                    break;
                }
            case "delete":
                {
                    int customerId = Convert.ToInt32(e.CommandArgument.ToString());

                    if (customer.DeleteCustomer(customerId) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    CustomerDataBind();
                    break;
                }
            case "detail":
                {
                    int customerId = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("CustomerDetail.aspx?customerID=" + customerId);
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
