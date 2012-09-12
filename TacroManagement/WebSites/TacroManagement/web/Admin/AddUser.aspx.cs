using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_AddUser : System.Web.UI.Page
{
    User userBLL = new User();
    Department departBLL = new Department();
    Client clientBLL = new Client();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }

            BindDDLDepartment();
        }
    }


    protected void btAdd_Click(object sender, EventArgs e)
    {
        string userName = this.txtUserName.Text.Trim();
        string password = this.txtPassword.Text.Trim();
        string userType = this.ddlUserType.SelectedValue;
        string email = this.txtEmail.Text.Trim();
        string phone = this.txtPhone.Text.Trim();
        int departID = this.ddlDepart.SelectedIndex;

        if (userBLL.IsUserNameExists(userName))
        {
            this.lblUserName.Visible = true;
        }
        else
        {
            this.lblUserName.Visible = false;
            if (userBLL.AddUser(userName, password, userType, email, phone, departID))
            {
                if (userType.Equals("客户"))
                {
                    if (clientBLL.AddClient(userName, " "))
                        SetPrompt("添加成功", true);
                    else
                        SetPrompt("添加失败", true);
                }
                else
                    SetPrompt("添加成功", true);
            }
            else
                SetPrompt("添加失败", true);
        }

    }

    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        this.lblUserName.Visible = false;
        SetPrompt("", false);
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
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
