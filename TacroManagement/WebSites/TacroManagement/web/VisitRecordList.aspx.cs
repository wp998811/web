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

public partial class web_VisitRecordList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VisitRecordDataBind();
        }
    }

    private void VisitRecordDataBind()
    {
        VisitRecord visitRecord = new VisitRecord();
        IList<VisitRecordInfo> visitRecordInfos = visitRecord.GetVisitRecords();

        VisitRecordGridView.DataSource = visitRecord.SearchAllVisitRecords();
        VisitRecordGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= VisitRecordGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        if (ddlCurrentPage.SelectedIndex != -1)
            ddlCurrentPage.SelectedIndex = VisitRecordGridView.PageIndex;
    }

    protected void VisitRecordGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string visitRecordId = VisitRecordGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyVisitRecord.aspx?visitRecordID=" + visitRecordId);
    }


    protected void Add_VisitRecord(object sender, EventArgs e)
    {
        Response.Redirect("AddVisitRecord.aspx");
    }

    protected void VisitRecordGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        VisitRecord visitRecord = new VisitRecord();

        int visitRecordId = Convert.ToInt32(VisitRecordGridView.DataKeys[e.RowIndex][0].ToString());

        if (visitRecord.DeleteVisitRecord(visitRecordId) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        VisitRecordDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.VisitRecordGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        VisitRecordDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.VisitRecordGridView.PageIndex = 0;
        VisitRecordDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.VisitRecordGridView.PageIndex > 0)
        {
            this.VisitRecordGridView.PageIndex = this.VisitRecordGridView.PageIndex - 1;
            VisitRecordDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.VisitRecordGridView.PageIndex < this.VisitRecordGridView.PageCount)
        {
            this.VisitRecordGridView.PageIndex = this.VisitRecordGridView.PageIndex + 1;
            VisitRecordDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.VisitRecordGridView.PageIndex = this.VisitRecordGridView.PageCount;
        VisitRecordDataBind();
    }

    protected void VisitRecordGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.VisitRecordGridView.PageIndex + 1, this.VisitRecordGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = VisitRecordGridView.PageIndex * VisitRecordGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void VisitRecordGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Detail":
                string visitRecordId = VisitRecordGridView.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                Response.Redirect("VisitRecordDetail.aspx?visitRecordID=" + visitRecordId);
                break;
        }
    }
}
