using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class web_subTaskModify : System.Web.UI.Page
{
    SubTask subTaskManage = new SubTask();
    User userManage = new User();
    Project projectManage = new Project();
    ProjectUser projectUserManage = new ProjectUser();
    Affair affairManage = new Affair();
    string projectNum;
    int subTaskId;
    public static int type; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Request.Params["projectNum"] != null && Request.Params["projectNum"] != "")
            {
                projectNum = Request.Params["projectNum"];
            }
            if (Request.Params["taskID"] != null && Request.Params["taskID"] != "")
            {
                subTaskId = Convert.ToInt32(Request.Params["taskID"]);
            }
            if (Request.Params["type"] != null && Request.Params["type"] != "")
            {
                type = Convert.ToInt32(Request.Params["type"]);
                BindData(projectNum, subTaskId);
            } 
        }
    }
    protected void BindData(string projectNum, int subTaskId)
    {
        //编辑子任务
        if(type == 1)
        {
            #region 编辑子任务
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
            SubTaskInfo subTaskInfo = subTaskManage.GetSubTaskById(subTaskId);
            if (!projectManage.IsNullOrEmpty(projectInfo))
            {
                lblProjectName.Text = projectInfo.ProjectName;
            }
            if (subTaskInfo != null)
            {
                lblProjectNum.Text = projectNum;
                lblTaskID.Text = Convert.ToString(subTaskId);
                lblSubTaskName.Text = subTaskInfo.TaskName;
                txtSubTaskName.Text = subTaskInfo.TaskName;
                txtSubTaskPeriod.Text = Convert.ToString(subTaskInfo.Period);
                iBeginDate.Value = subTaskInfo.StartTime;
                iEndDate.Value = subTaskInfo.EndTime;
                txtProduct.Text = subTaskInfo.Product;
                txtForeTask.Text = subTaskInfo.ForeTask;
                txtResource.Text = subTaskInfo.Resource;

                //负责人，负责邮箱，负责人电话绑定
                IList<UserInfo> userInfos = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);
                ddlTaskManager.DataSource = userInfos;
                ddlTaskManager.DataTextField = "UserName";
                ddlTaskManager.DataValueField = "UserID";
                ddlTaskManager.DataBind();

                ddlTaskManager.SelectedIndex = ddlTaskManager.Items.IndexOf(ddlTaskManager.Items.FindByValue(Convert.ToString(subTaskInfo.UserId)));
                //ddlTaskManager.SelectedIndex = subTaskInfo.UserId;
                //ddlTaskManager.SelectedIndex = subTaskInfo.UserId;
                UserInfo userInfo = userManage.GetUserById(subTaskInfo.UserId);
                //ddlTaskManager.SelectedValue = userInfo.UserName;

                if (subTaskInfo.IsRemind > 0)
                    cbIsRemind.Checked = true;
                ddlTaskState.Items.Insert(0, new ListItem("待执行"));
                ddlTaskState.Items.Insert(1, new ListItem("执行中"));
                ddlTaskState.Items.Insert(2, new ListItem("已完成"));
                ddlTaskState.Items.Insert(3, new ListItem("已取消"));
                switch (subTaskInfo.TaskState)
                {
                    case "待执行":
                        ddlTaskState.SelectedIndex = 0;
                        break;
                    case "执行中":
                        ddlTaskState.SelectedIndex = 1;
                        break;
                    case "已完成":
                        ddlTaskState.SelectedIndex = 2;
                        break;
                    case "已取消":
                        ddlTaskState.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }

            }
            #endregion
        }
        //添加子任务
        else if (type == 2)
        {
            #region 添加子任务
            ProjectInfo projectInfo = projectManage.GetProjectByNum(projectNum);
            lblProjectName.Text = projectInfo.ProjectName;
            lblSubTaskName.Text = "添加子任务";

            lblProjectNum.Text = projectNum;
            IList<UserInfo> userInfos = projectUserManage.GetProjectUserInfosByProjectNum(projectNum);
            ddlTaskManager.DataSource = userInfos;
            ddlTaskManager.DataTextField = "UserName";
            ddlTaskManager.DataValueField = "UserID";
            ddlTaskManager.DataBind();

            ddlTaskState.Items.Insert(0, new ListItem("待执行"));
            ddlTaskState.Items.Insert(1, new ListItem("执行中"));
            ddlTaskState.Items.Insert(2, new ListItem("已完成"));
            ddlTaskState.Items.Insert(3, new ListItem("已取消"));
            #endregion
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if(txtSubTaskName.Text.Trim().Length == 0)
        {
            Response.Write("<script language='javascript'>alert('子任务名不能为空')</script>");
            return;
        }

        if(txtSubTaskPeriod.Text.Trim().Length == 0)
        {
            Response.Write("<script language='javascript'>alert('工期不能为空')</script>");
            return;
        }
        string taskName = txtSubTaskName.Text;
        int taskPeriod = Convert.ToInt32(txtSubTaskPeriod.Text);
        string taskBeginDate = iBeginDate.Value;
        string taskEndDate = iEndDate.Value;
        string taskProduct = txtProduct.Text;
        string taskForeTask = txtForeTask.Text;
        string taskResource = txtResource.Text;

        int taskManager;
        //TODO
         taskManager = Convert.ToInt32(ddlTaskManager.SelectedValue);
        //string taskManagerEmail = txtTaskManagerEmail.Text;
        //string taskManagerPhone = txtTaskManegerPhone.Text;
        int taskIsRemind = 0;
        if (cbIsRemind.Checked == true)
            taskIsRemind = 1;
        string taskState = ddlTaskState.SelectedItem.Text;

        if(type == 1)
        {
            //更新子任务
            int id = Convert.ToInt32(lblTaskID.Text);

            SubTaskInfo taskInfo = subTaskManage.GetSubTaskById(id);
            if (taskInfo != null && taskInfo.TaskId != 0)
            {
                taskInfo.TaskName = taskName;
                taskInfo.Period = taskPeriod;
                taskInfo.StartTime = taskBeginDate;
                taskInfo.EndTime = taskEndDate;
                taskInfo.Product = taskProduct;
                taskInfo.ForeTask = taskForeTask;
                taskInfo.Resource = taskResource;
                taskInfo.UserId = taskManager;
                taskInfo.IsRemind = taskIsRemind;
                taskInfo.TaskState = taskState;
                if (subTaskManage.UpdateSubTask(taskInfo) > 0)
                {

                    string num = lblProjectNum.Text;
                    string url = "projectInfo.aspx?projectNum=" + num;
                    Response.Redirect(url);
                    Response.Write("<script language='javascript'>alert('提交成功')</script>");
                    return;
                }
            }
        }
        else if (type == 2)
        {
            //添加子任务
            projectNum = lblProjectNum.Text;
            SubTaskInfo taskInfo = new SubTaskInfo(projectNum, taskName, taskPeriod, taskBeginDate, taskEndDate, taskProduct, taskForeTask, taskResource,
                taskManager, taskState, taskIsRemind, taskEndDate);
            if(subTaskManage.InsertSubTask(taskInfo) > 0)
            {
                //添加项目动态
                string des = "添加子任务：" + taskName;
                AffairInfo affair = new AffairInfo(des, taskManager, DateTime.Now.ToString(), projectNum);
                affairManage.InsertAffair(affair);
                string num = lblProjectNum.Text;
                string url = "projectInfo.aspx?projectNum=" + num;
                Response.Redirect(url);
                Response.Write("<script language='javascript'>alert('提交成功')</script>");
                return;
            }
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string num = lblProjectNum.Text;
        string url = "projectInfo.aspx?projectNum=" + num;
        Response.Redirect(url);
    }
    protected void ddlTaskManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}
