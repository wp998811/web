using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class web_Admin_ModifyUser : System.Web.UI.Page
{
    User userBLL = new User();
    Department departBLL = new Department();
    Client client = new Client();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
            {
                int userID = Int32.Parse(Request.QueryString["userId"]);
                BindUserInfo(userID);
            }
        }
    }

    private void BindUserInfo(int userID)
    {
        UserInfo userInfo = userBLL.GetUserById(userID);
        this.txtUserName.Text = userInfo.UserName;
        this.txtPassword.Text = userInfo.Password;
        this.ddlUserType.SelectedValue = userInfo.UserType;
        this.txtEmail.Text = userInfo.UserEmail;
        this.txtPhone.Text = userInfo.UserPhone;
        BindDDLDepartment();
        this.ddlDepart.SelectedIndex = userInfo.DepartID;
    }

    protected void btComfirm_Click(object sender, EventArgs e)
    {
        string userName = this.txtUserName.Text.Trim();
        string password = this.txtPassword.Text.Trim();
        string userType = this.ddlUserType.SelectedValue;
        string userEmail = this.txtEmail.Text.Trim();
        string userPhone = this.txtPhone.Text.Trim();
        int departID = this.ddlDepart.SelectedIndex;

        if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
        {
            int userID = Int32.Parse(Request.QueryString["userId"]);

            if (userBLL.ModifyUser(userID, userName, password, userType, userEmail, userPhone, departID))
                SetPrompt("修改成功", true);
            else
                SetPrompt("修改失败", true);
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }

    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }

    private void BindDDLDepartment()
    {
        this.ddlDepart.Items.Add(new ListItem("请选择部门"));
        IList<DepartmentInfo> departments = departBLL.GetDepartments();
        foreach (DepartmentInfo item in departments)
        {
            string departName = item.DepartName;
            this.ddlDepart.Items.Add(new ListItem(departName));
        }
    }
}
