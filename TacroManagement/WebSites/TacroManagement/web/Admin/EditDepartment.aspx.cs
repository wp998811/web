using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_EditDepartment : System.Web.UI.Page
{

    Department departBLL = new Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["departId"]))
            {
                int departID = Int32.Parse(Request.QueryString["departId"]);
                BindDepartInfo(departID);
            }
        }
    }

    private void BindDepartInfo(int departID)
    {
        DepartmentInfo departmentInfo = departBLL.GetDepartmentByID(departID);
        this.txtDepartName.Text = departmentInfo.DepartName;
        this.txtDepartAdmin.Text = departmentInfo.DepartAdmin;
    }

    protected void btComfirm_Click(object sender, EventArgs e)
    {
        string departName = this.txtDepartName.Text.Trim();
        string departAdmin = this.txtDepartAdmin.Text.Trim();

        if (!string.IsNullOrEmpty(Request.QueryString["departId"]))
        {
            int departID = Int32.Parse(Request.QueryString["departId"]);

            if (departBLL.EditDepartment(departID,departName,departAdmin))
                SetPrompt("修改成功", true);
            else
                SetPrompt("修改失败", true);
        }
    }

    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }     
    }
}
