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
using BLL;
using Model;

public partial class web_projectModify : System.Web.UI.Page
{
    Project projectManage = new Project();
    User userManage = new User();
    
    public static string projectNum = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(Request.Params["projectNum"] != null && Request.Params["projectNum"] != "")
            {
                projectNum = Request.Params["projectNum"];
                BindData(projectNum);
            }
        }
    }

    protected void BindData(string projectNum)
    {
        ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
        if(!projectManage.IsNullOrEmpty(projectInfo))
        {
            lblProjectName.Text = projectInfo.ProjectName;
            //lblProjectManager.Text = projectInfo.ProjectAdminID;
            UserInfo userInfo = userManage.GetUserById(projectInfo.ProjectAdminID);
            if (userInfo != null && userInfo.UserID != -1)
                lblProjectManager.Text = userInfo.UserName;
            ddlProjectType.Items.Insert(0, new ListItem("临床试验"));
            ddlProjectType.Items.Insert(1, new ListItem("注册"));
            ddlProjectType.Items.Insert(2, new ListItem("咨询"));
            ddlProjectType.Items.Insert(3, new ListItem("其他"));
            switch(projectInfo.ProjectType)
            {
                case "临床试验":
                    ddlProjectType.SelectedIndex = 0;
                    break;
                case "注册":
                    ddlProjectType.SelectedIndex = 1;
                    break;
                case "咨询":
                    ddlProjectType.SelectedIndex = 2;
                    break;
                case "其他":
                    ddlProjectType.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
            txtClientName.Text = projectInfo.ProjectClientName;
            txtProjectDes.Text = projectInfo.ProjectDescription;
            iBeginDate.Value = projectInfo.BeginTime;
            iEndDate.Value = projectInfo.EndTime;
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if(txtClientName.Text.Trim().Length == 0)
        {
            Response.Write("<script language='javascript'>alert('客户名不能为空')</script>");
            return;
        }
        if (iBeginDate.Value.Trim().Length == 0)
        {
            Response.Write("<script language='javascript'>alert('开始日期不能为空')</script>");
            return;
        }
        if (iEndDate.Value.Trim().Length == 0)
        {
            Response.Write("<script language='javascript'>alert('结束日期不能为空')</script>");
            return;
        }
        if(iBeginDate.Value.CompareTo(iEndDate.Value) > 0)
        {
            Response.Write("<script language='javascript'>alert('开始日期不能晚于结束日期')</script>");
            return;
        }

        string projectType = ddlProjectType.SelectedValue;
        string projectName = lblProjectName.Text;
        string projectManager = lblProjectManager.Text;
        string projectClientName = txtClientName.Text;
        string projectDes = txtProjectDes.Text;
        string projectBeginDate = iBeginDate.Value;
        string projectEndDate = iEndDate.Value;

        ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
        if (projectInfo != null)
        {
            projectInfo.ProjectName = projectName;

            UserInfo userInfo = userManage.GetUserByName(projectManager);
            if(userInfo != null && userInfo.UserID != -1)
            {
                projectInfo.ProjectAdminID = userInfo.UserID;
            }
            projectInfo.ProjectClientName = projectClientName;
            projectInfo.ProjectType = projectType;
            projectInfo.ProjectDescription = projectDes;
            projectInfo.BeginTime = projectBeginDate;
            projectInfo.EndTime = projectEndDate;

            if(projectManage.UpdateProject(projectInfo) != -1)
            {
                Response.Write("<script language='javascript'>alert('提交成功')</script>");
                string url = "projectInfo.aspx?projectNum=" + projectNum;
                Response.Redirect(url);
            }
            else
                Response.Write("<script language='javascript'>alert('提交失败')</script>");
        }
        else
            return;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string url = "projectInfo.aspx?projectNum=" + projectNum;
        Response.Redirect(url);
    }
}
