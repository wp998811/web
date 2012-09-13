using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class web_Admin_ModifyProject : System.Web.UI.Page
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

            if (!string.IsNullOrEmpty(Request.QueryString["projectNum"].ToString()))
            {
                string projectNum = Request.QueryString["projectNum"].ToString();
                BindProject(projectNum);
            }
        }
    }

    //格式化日期格式
    protected string FormatDate(string strDate)
    {
        DateTime dtDate = Convert.ToDateTime(strDate);
        return dtDate.ToString("yyyy-MM-dd");
    }

    private void BindProject(string projectNum)
    {
        BindDDLAdmin();
        BindClient();
        ProjectInfo projectInfo = projectBLL.GetProjectByNum(projectNum);
        this.lblProjectNum.Text = projectInfo.ProjectNum;
        this.lblProjectName.Text = projectInfo.ProjectName;

        UserInfo userInfo = userBLL.GetUserById(projectInfo.ProjectAdminID);
        this.ddlAdmin.SelectedValue = userInfo.UserName;

        this.ddlClient.SelectedValue = projectInfo.ProjectClientName;
        this.ddlProjectType.SelectedValue = projectInfo.ProjectType;
        this.txtProjectDes.Text = projectInfo.ProjectDescription;

        this.iBeginDate.Value = FormatDate(projectInfo.BeginTime);
        this.iEndDate.Value = FormatDate(projectInfo.EndTime);

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

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string projectNum = this.lblProjectNum.Text.Trim();
        string projectAdmin = this.ddlAdmin.SelectedValue;
        UserInfo userInfo = userBLL.GetUserByName(projectAdmin);
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

        if (projectBLL.ModifyProject(projectNum, projectAdminID, projectDes, projectType, projectClientName, beginTime, endTime))
        {
            SetPrompt("修改项目成功", true);
        }
        else
        {
            SetPrompt("修改项目失败", true);
        }
    }


    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }
}
