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

public partial class web_ClinicalResourceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClinicalResourceDataBind();
        }
    }

    private void ClinicalResourceDataBind()
    {
        ClinicalResource clinicalResource = new ClinicalResource();

        ClinicalResourceGridView.DataSource = clinicalResource.SearchAllClinicalResources();
        ClinicalResourceGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= ClinicalResourceGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        if (ddlCurrentPage.SelectedIndex != -1)
            ddlCurrentPage.SelectedIndex = ClinicalResourceGridView.PageIndex;
    }

    protected void ClinicalResourceGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string clinicalResourceId = ClinicalResourceGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyClinicalResource.aspx?clinicalResourceID=" + clinicalResourceId);
    }


    protected void Add_ClinicalResource(object sender, EventArgs e)
    {
        Response.Redirect("AddClinicalResource.aspx");
    }

    protected void ClinicalResourceGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClinicalResource clinicalResource = new ClinicalResource();

        int clinicalResourceId = Convert.ToInt32(ClinicalResourceGridView.DataKeys[e.RowIndex][0].ToString());

        if (clinicalResource.DeleteClinicalResource(clinicalResourceId) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        ClinicalResourceDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClinicalResourceGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        ClinicalResourceDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.ClinicalResourceGridView.PageIndex = 0;
        ClinicalResourceDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.ClinicalResourceGridView.PageIndex > 0)
        {
            this.ClinicalResourceGridView.PageIndex = this.ClinicalResourceGridView.PageIndex - 1;
            ClinicalResourceDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.ClinicalResourceGridView.PageIndex < this.ClinicalResourceGridView.PageCount)
        {
            this.ClinicalResourceGridView.PageIndex = this.ClinicalResourceGridView.PageIndex + 1;
            ClinicalResourceDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.ClinicalResourceGridView.PageIndex = this.ClinicalResourceGridView.PageCount;
        ClinicalResourceDataBind();
    }

    protected void ClinicalResourceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.ClinicalResourceGridView.PageIndex + 1, this.ClinicalResourceGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = ClinicalResourceGridView.PageIndex * ClinicalResourceGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void ClinicalResourceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string clinicalResourceId = ClinicalResourceGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("ClinicalResourceDetail.aspx?clinicalResourceID=" + clinicalResourceId);
                break;
        }
    }

    protected void Query_ClinicalResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string hospital = txtHospital.Text.Trim();
        string deptName = txtDepartment.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        ClinicalResource clinicalResource = new ClinicalResource();
        DataTable clinicalResources = clinicalResource.GetDataTableByClinicalList(clinicalResource.GetClinicalResearchBySearch(manager, city, hospital, deptName, contactName));
        ClinicalResourceGridView.DataSource = clinicalResources;
        ClinicalResourceGridView.DataBind();
    }
}
