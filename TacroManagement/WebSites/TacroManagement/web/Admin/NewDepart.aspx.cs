using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_AddDepart : System.Web.UI.Page
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
        }
    }


    protected void btComfirm_Click(object sender, EventArgs e)
    {
        this.lblDepartName.Visible = false;

        string departName = this.txtDepartName.Text.Trim();
        string departAdmin = this.txtDepartAdmin.Text.Trim();

        if (departBLL.IsDepartmentExists(departName))
        {
            this.lblDepartName.Visible = true;
        }
        else
        {
            if (departBLL.AddDepartment(departName, departAdmin))
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
