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

public partial class web_CustomerProjList : System.Web.UI.Page
{
    Customer customer = new Customer();
    CustomerProject customerProject = new CustomerProject();
    User user = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        IList<CustomerProjectInfo> customerProjectInfos = customerProject.GetCustomerProjects();

        rpCustomerProjList.DataSource = customerProject.SearchAllCustomerProjs().DefaultView;
        rpCustomerProjList.DataBind();

        DataTable customerProjdt = customerProject.SearchAllCustomerProjs();

        this.CustomerProjPager.RecordCount = customerProjdt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = customerProjdt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = CustomerProjPager.CurrentPageIndex - 1;
        pds.PageSize = CustomerProjPager.PageSize;

        rpCustomerProjList.DataSource = pds;
        rpCustomerProjList.DataBind();
    }

    protected void CustomerProj_PageChanged(object sender, EventArgs e)
    {
        CustomerProjDataBind();
    }

    protected void Add_CustomerProj(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomerProj.aspx");
    }

    protected void Query_CustomerProject(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string customerType = txtCustomerType.Text.Trim();
        string projectType = txtProjectType.Text.Trim();
        string progress = txtProgress.Text.Trim();
        string customerName = txtCustomerName.Text.Trim();
        string service = txtService.Text.Trim();
        string productName = txtProductType.Text.Trim();
        string contactName = "";

        DataTable customerProjects = customerProject.GetDataTableByCustomerProjList(customerProject.GetCustomerProjectResearchBySearch(manager, city, customerType, projectType, progress, customerName, service, productName, contactName));
        rpCustomerProjList.DataSource = customerProjects.DefaultView;
        rpCustomerProjList.DataBind();
    }


    protected void rpCustomerProjList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int customerProjID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyCustomerProject.aspx?customerProjID=" + customerProjID);
                    break;
                }
            case "delete":
                {
                    int customerProjID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (customerProject.DeleteCustomerProject(customerProjID) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    CustomerProjDataBind();
                    break;
                }
            case "detail":
                {
                    int customerProjID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("CustomerProjDetail.aspx?customerProjID=" + customerProjID);
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
