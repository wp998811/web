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

public partial class web_project_taskMore : System.Web.UI.Page
{
    User userManage = new User();
    SubTask subTaskManage = new SubTask();
    FormatString formatString = new FormatString();
    public static int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Session["UserName"].ToString();
            UserInfo userInfo = userManage.GetUserByName(userName);
            if (userInfo != null && userInfo.UserID != 0)
            {
                userId = userInfo.UserID;
                BindData(userId);
            }
        }
    }

    private void BindData(int userId)
    {
        IList<SubTaskInfo> subTaskInfoList = subTaskManage.GetSubTasksDescIsRemind(userId, 0);
        //rpTask.DataSource = subTaskInfoList;
        //rpTask.DataBind();
        foreach(SubTaskInfo subTaskInfo in subTaskInfoList)
        {
            subTaskInfo.RemindTime = formatString.FormatDate(subTaskInfo.RemindTime);
        }

        this.AspNetPager1.RecordCount = subTaskInfoList.Count;
        PagedDataSource pg = new PagedDataSource();
        pg.DataSource = subTaskInfoList;
        pg.AllowPaging = true;
        pg.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pg.PageSize = AspNetPager1.PageSize;
        rpTask.DataSource = pg;
        rpTask.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData(userId);
    }
}
