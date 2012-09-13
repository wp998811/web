using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_NewProject : System.Web.UI.Page
{
    User userBLL = new User();
    Client clientBLL = new Client();
    Project projectBLL = new Project();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }

            BindDDLAdmin();
            BindClient();
        }
    }

    //绑定项目管理人员
    private void BindDDLAdmin()
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

    //绑定客户
    private void BindClient()
    {
        IList<UserInfo> users = userBLL.GetUsers();
        foreach (UserInfo item in users)
        {
            if (item.UserType == "客户")
            {
                this.ddlClient.Items.Add(new ListItem(item.UserName));
            }
        }
    }

    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }

    //添加
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string projectNum = this.txtProjectNum.Text.Trim();
        string projectName = this.txtProjectName.Text.Trim();

        string projectAdminName = this.ddlAdmin.SelectedValue;
        UserInfo userInfo = userBLL.GetUserByName(projectAdminName);
        int projectAdminID = userInfo.UserID;

        string projectClientName = this.ddlClient.SelectedValue;
        string projectType = this.ddlProjectType.SelectedValue;
        string projectDes = this.txtProjectDes.Text.Trim();
        string beginTime = this.iBeginDate.Value;
        string endTime = this.iEndDate.Value;

        if (iBeginDate.Value.CompareTo(iEndDate.Value) > 0)
        {
            SetPrompt("项目开始日期不能晚于结束日期！", true);
            return;
        }

        if (projectBLL.IsProjectExists(projectNum))
        {
            this.lblProjectNum.Visible = true;
            SetPrompt("新建项目失败", true);
        }
        else
        {
            this.lblProjectNum.Visible = false;
            if (projectBLL.AddProject(projectNum, projectName, projectAdminID, projectDes, projectType, projectClientName, beginTime, endTime))
            {
                SetPrompt("新建项目成功", true);
            }
            else
                SetPrompt("新建项目失败", true);
        }


    }

    //返回
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        SetPrompt("", false);
        this.lblProjectNum.Visible = false;
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }

}
