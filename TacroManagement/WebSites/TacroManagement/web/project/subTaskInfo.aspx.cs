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

public partial class web_project_subTaskInfo : System.Web.UI.Page
{
    User userManage = new User();
    SubTask subTaskManage = new SubTask();
    Project projectManage = new Project();
    FormatString formatString = new FormatString();
    public static string projectNum = "";
    public static string taskId = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["projectNum"] != null && Request.Params["projectNum"] != "")
            {
                if(Request.Params["subTaskId"] != null && Request.Params["subTaskId"] != "")
                {
                    projectNum = Request.Params["projectNum"].ToString();
                    taskId = Request.Params["subTaskId"].ToString();
                    BindData();
                }
            }
        }
    }

    private void BindData()
    {
        int id = Convert.ToInt32(taskId);
        SubTaskInfo subTaskInfo = subTaskManage.GetSubTaskById(id);
        ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
        if(subTaskInfo != null && subTaskInfo.TaskId != 0)
        {
            if(projectInfo != null)
            {
                lblNavProjectName.Text = projectInfo.ProjectName;
                lblNavSubTaskName.Text = subTaskInfo.TaskName;
                lblTaskName.Text = subTaskInfo.TaskName;
                lblPeriod.Text = Convert.ToString(subTaskInfo.Period);
                lblBeginDate.Text = formatString.FormatDate(subTaskInfo.StartTime);
                lblEndDate.Text = formatString.FormatDate(subTaskInfo.EndTime);
                lblProduct.Text = subTaskInfo.Product;
                lblForeTask.Text = subTaskInfo.ForeTask;
                lblResource.Text = subTaskInfo.Resource;
                lblTaskState.Text = subTaskInfo.TaskState;
                if (subTaskInfo.IsRemind == 1)
                    lblIsRemind.Text = "是";
                else
                    lblIsRemind.Text = "否";
                UserInfo userInfo = userManage.GetUserById(subTaskInfo.UserId);
                if(userInfo != null && userInfo.UserID != 0)
                {
                    lblManager.Text = userInfo.UserName;
                }
            }
        }
    }
}
