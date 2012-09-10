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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerProjDataBind();
        }
    }

    private void CustomerProjDataBind()
    {
        CustomerProject customerProject = new CustomerProject();
        IList<CustomerProjectInfo> customerProjectInfos = customerProject.GetCustomerProjects();

        CustomerProjGridView.DataSource = customerProject.SearchAllCustomerProjs();
        CustomerProjGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= CustomerProjGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        if (ddlCurrentPage.SelectedIndex != -1)
            ddlCurrentPage.SelectedIndex = CustomerProjGridView.PageIndex;
    }

    protected void CustomerProjGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string customerProjId = CustomerProjGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyCustomerProject.aspx?customerProjID=" + customerProjId);
    }


    protected void Add_CustomerProj(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomerProj.aspx");
    }

    protected void CustomerProjGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CustomerProject customerProj = new CustomerProject();

        int customerProjId = Convert.ToInt32(CustomerProjGridView.DataKeys[e.RowIndex][0].ToString());

        if (customerProj.DeleteCustomerProject(customerProjId) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        CustomerProjDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CustomerProjGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        CustomerProjDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.CustomerProjGridView.PageIndex = 0;
        CustomerProjDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.CustomerProjGridView.PageIndex > 0)
        {
            this.CustomerProjGridView.PageIndex = this.CustomerProjGridView.PageIndex - 1;
            CustomerProjDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.CustomerProjGridView.PageIndex < this.CustomerProjGridView.PageCount)
        {
            this.CustomerProjGridView.PageIndex = this.CustomerProjGridView.PageIndex + 1;
            CustomerProjDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.CustomerProjGridView.PageIndex = this.CustomerProjGridView.PageCount;
        CustomerProjDataBind();
    }

    protected void CustomerProjGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.CustomerProjGridView.PageIndex + 1, this.CustomerProjGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = CustomerProjGridView.PageIndex * CustomerProjGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void CustomerProjGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string customerProjId = CustomerProjGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("CustomerProjDetail.aspx?customerProjID=" + customerProjId);
                break;
        }
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
        string productName = txtProductName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        CustomerProject customerProject = new CustomerProject();
        DataTable customerProjects = customerProject.GetDataTableByCustomerProjList(customerProject.GetCustomerProjectResearchBySearch(manager, city, customerType, projectType, progress, customerName, service, productName, contactName));
        CustomerProjGridView.DataSource = customerProjects;
        CustomerProjGridView.DataBind();
    }
}
