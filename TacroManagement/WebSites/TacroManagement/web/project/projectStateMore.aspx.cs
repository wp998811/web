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

public partial class web_project_projectStateMore : System.Web.UI.Page
{
    Affair affairManage = new Affair();
    User userManage = new User();
    Project projectManage = new Project();
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

    protected void BindData(int userId)
    {
        IList<AffairInfo> affairInfoList = affairManage.GetAffairsByUserID(userId);
        IList<RichAffairInfo> richAffairInfoList = new List<RichAffairInfo>();
        foreach (AffairInfo affairInfo in affairInfoList)
        {
            if (affairInfo != null && affairInfo.AffairId != 0)
            {
                ProjectInfo projectInfo = projectManage.GetProjectByNum(affairInfo.ProjectNum);
                UserInfo userInfo = userManage.GetUserById(affairInfo.AffairOperatorId);
                RichAffairInfo rAffairInfo = new RichAffairInfo(affairInfo.AffairId, affairInfo.AffairDescription, affairInfo.AffairTime, userInfo.UserName, projectInfo.ProjectName);
                richAffairInfoList.Add(rAffairInfo);
            }
        }


        //rpProjectState.DataSource = richAffairInfoList;
        //rpProjectState.DataBind();

        this.AspNetPager1.RecordCount = richAffairInfoList.Count;
        PagedDataSource pg = new PagedDataSource();
        pg.DataSource = richAffairInfoList;
        pg.AllowPaging = true;
        pg.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pg.PageSize = AspNetPager1.PageSize;
        rpProjectState.DataSource = pg;
        rpProjectState.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData(userId);
    }
}
