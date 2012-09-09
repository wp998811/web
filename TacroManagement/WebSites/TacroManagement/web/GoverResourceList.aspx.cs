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

public partial class web_GoverResourceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GoverResourceDataBind();
        }
    }

    private void GoverResourceDataBind()
    {
        GoverResource goverResource = new GoverResource();

        GoverResourceGridView.DataSource = goverResource.SearchAllGoverResources();
        GoverResourceGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= GoverResourceGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        if (ddlCurrentPage.SelectedIndex != -1)
            ddlCurrentPage.SelectedIndex = GoverResourceGridView.PageIndex;
    }

    protected void GoverResourceGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string goverResourceID = GoverResourceGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyGoverResource.aspx?goverResourceID=" + goverResourceID);
    }


    protected void Add_GoverResource(object sender, EventArgs e)
    {
        Response.Redirect("AddGoverResource.aspx");
    }

    protected void GoverResourceGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GoverResource goverResource = new GoverResource();

        int goverResourceId = Convert.ToInt32(GoverResourceGridView.DataKeys[e.RowIndex][0].ToString());

        if (goverResource.DeleteGoverResource(goverResourceId) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        GoverResourceDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GoverResourceGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        GoverResourceDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.GoverResourceGridView.PageIndex = 0;
        GoverResourceDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.GoverResourceGridView.PageIndex > 0)
        {
            this.GoverResourceGridView.PageIndex = this.GoverResourceGridView.PageIndex - 1;
            GoverResourceDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.GoverResourceGridView.PageIndex < this.GoverResourceGridView.PageCount)
        {
            this.GoverResourceGridView.PageIndex = this.GoverResourceGridView.PageIndex + 1;
            GoverResourceDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.GoverResourceGridView.PageIndex = this.GoverResourceGridView.PageCount;
        GoverResourceDataBind();
    }

    protected void GoverResourceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.GoverResourceGridView.PageIndex + 1, this.GoverResourceGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = GoverResourceGridView.PageIndex * GoverResourceGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void GoverResourceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string goverResourceId = GoverResourceGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("GoverResourceDetail.aspx?goverResourceId=" + goverResourceId);
                break;
        }
    }

    protected void Query_GoverResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string organName = txtOrganName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        GoverResource goverResource = new GoverResource();
        DataTable goverResources = goverResource.GetDataTableByGoverList(goverResource.GetGoverResourceBySearch(manager, city, organName, contactName));
        //DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
        //documents.Columns.Add(subTaskColumn);
        GoverResourceGridView.DataSource = goverResources;
        GoverResourceGridView.DataBind();
    }
}

