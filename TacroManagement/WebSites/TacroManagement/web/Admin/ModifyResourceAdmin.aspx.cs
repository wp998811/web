using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class web_Admin_ModifyResourceAdmin : System.Web.UI.Page
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

            if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                int id = Int32.Parse(Request.QueryString["id"]);
                BindResourceAdmin(id);
            }
        }
    }


    private void BindResourceAdmin(int id)
    {
        ResourceAdminInfo resourceAdminInfo = raBLL.GetResourceAdminByID(id);
        BindAdmin();
        this.ddlResourceType.SelectedValue = resourceAdminInfo.ResourceType;
        int userID = resourceAdminInfo.UserID;
        UserInfo userInfo = userBLL.GetUserById(userID);
        this.ddlAdmin.SelectedValue = userInfo.UserName;
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

    protected void btComfirm_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
        {
            int id = Int32.Parse(Request.QueryString["id"]);

            string resourceType = this.ddlResourceType.SelectedValue;

            string adminName = this.ddlAdmin.SelectedValue;

            UserInfo user = userBLL.GetUserByName(adminName);

            int userID = user.UserID;

            if (raBLL.ModifyResourceAdmin(id, userID, resourceType))
            {
                SetPrompt("修改成功", true);
            }
            else
            {
                SetPrompt("修改失败", true);
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
}

