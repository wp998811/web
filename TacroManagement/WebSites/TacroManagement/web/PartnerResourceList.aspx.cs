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

public partial class web_PartnerResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PartnerResourceDataBind();
        }
    }

    private void PartnerResourceDataBind()
    {
        PartnerResource partnerResource = new PartnerResource();

        PartnerResourceGridView.DataSource = partnerResource.SearchAllPartnerResources();
        PartnerResourceGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= PartnerResourceGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        if (ddlCurrentPage.SelectedIndex != -1)
            ddlCurrentPage.SelectedIndex = PartnerResourceGridView.PageIndex;
    }

    protected void PartnerResourceGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string partnerResourceID = PartnerResourceGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyPartnerResource.aspx?partnerResourceID=" + partnerResourceID);
    }


    protected void Add_PartnerResource(object sender, EventArgs e)
    {
        Response.Redirect("AddPartnerResource.aspx");
    }

    protected void PartnerResourceGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PartnerResource partnerResource = new PartnerResource();

        int partnerResourceId = Convert.ToInt32(PartnerResourceGridView.DataKeys[e.RowIndex][0].ToString());

        if (partnerResource.DeletePartnerResource(partnerResourceId) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        PartnerResourceDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.PartnerResourceGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        PartnerResourceDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.PartnerResourceGridView.PageIndex = 0;
        PartnerResourceDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.PartnerResourceGridView.PageIndex > 0)
        {
            this.PartnerResourceGridView.PageIndex = this.PartnerResourceGridView.PageIndex - 1;
            PartnerResourceDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.PartnerResourceGridView.PageIndex < this.PartnerResourceGridView.PageCount)
        {
            this.PartnerResourceGridView.PageIndex = this.PartnerResourceGridView.PageIndex + 1;
            PartnerResourceDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.PartnerResourceGridView.PageIndex = this.PartnerResourceGridView.PageCount;
        PartnerResourceDataBind();
    }

    protected void PartnerResourceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.PartnerResourceGridView.PageIndex + 1, this.PartnerResourceGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = PartnerResourceGridView.PageIndex * PartnerResourceGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void PartnerResourceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string partnerResourceId = PartnerResourceGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("PartnerResourceDetail.aspx?partnerResourceId=" + partnerResourceId);
                break;
        }
    }

    protected void Query_PartnerResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string organName = txtOrganName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        PartnerResource partnerResource = new PartnerResource();
        DataTable partnerResources = partnerResource.GetDataTableByPartnerList(partnerResource.GetPartnerResearchBySearch(manager, city, organName, contactName));
        //DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
        //documents.Columns.Add(subTaskColumn);
        PartnerResourceGridView.DataSource = partnerResources;
        PartnerResourceGridView.DataBind();
    }
}
