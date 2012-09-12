using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_AddResourceAdmin : System.Web.UI.Page
{
    User userBLL = new User();

    ResourceAdmin raBLL = new ResourceAdmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }
            BindAdmin();
        }
    }

    protected void BindAdmin()
    {
        IList<UserInfo> users = userBLL.GetUsers();
        foreach (UserInfo item in users)
        {
            if (item.UserType != "客户")
            {
                this.ddlAdmin.Items.Add(new ListItem(item.UserName));
            }
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

    protected void btComfirm_Click(object sender, EventArgs e)
    {
        string resourceType = this.ddlResourceType.SelectedValue;

        string adminName = this.ddlAdmin.SelectedValue;

        UserInfo user = userBLL.GetUserByName(adminName);

        int userID = user.UserID;

        if (raBLL.AddResourceAdmin(userID,resourceType))
        {
            SetPrompt("指定成功", true);
        }
        else
        {
            SetPrompt("指定失败", true);
        }
    }
}
