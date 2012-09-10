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

public partial class web_ClinicalResourceDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ClinicalResourceDataBind();
        }
    }

    private void ClinicalResourceDataBind()
    {
        int clinicalResourceID = Convert.ToInt32(Request["clinicalResourceID"]);
        ClinicalResource clinicalResource = new ClinicalResource();
        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(clinicalResourceID);
        User user = new User();
        if (clinicalResourceInfo != null)
        {
            UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);
            label_manager2.Text = userInfo.UserName;
            label_city2.Text = clinicalResourceInfo.City;
            label_hospital2.Text = clinicalResourceInfo.Hospital;
            label_departmentName2.Text = clinicalResourceInfo.Department;
            label_departIntro2.Text = clinicalResourceInfo.DepartIntro;
        }

        ContactGridView.DataSource = clinicalResource.SearchAllContactsByClinicalResourceID(clinicalResourceID);
        ContactGridView.DataBind();

        ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= ContactGridView.PageCount; i++)
        {
            ddlCurrentPage.Items.Add(i.ToString());
        }
        ddlCurrentPage.SelectedIndex = ContactGridView.PageIndex;
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ddlCurrentPage.SelectedIndex;
        ClinicalResourceDataBind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = 0;
        ClinicalResourceDataBind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex > 0)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex - 1;
            ClinicalResourceDataBind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex < this.ContactGridView.PageCount)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex + 1;
            ClinicalResourceDataBind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ContactGridView.PageCount;
        ClinicalResourceDataBind();
    }

    protected void ContactGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.ContactGridView.PageIndex + 1, this.ContactGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = ContactGridView.PageIndex * ContactGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
}
