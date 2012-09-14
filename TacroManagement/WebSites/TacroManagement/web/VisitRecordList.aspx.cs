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

using System.Collections.Generic;
using BLL;
using Model;

public partial class web_VisitRecordList : System.Web.UI.Page
{
    VisitRecord visitRecord = new VisitRecord();
    User user = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            VisitRecordDataBind();
        }
    }

    private void VisitRecordDataBind()
    {
        DataTable visitRecorddt = visitRecord.SearchAllVisitRecordsByUserID(Convert.ToInt32(Session["UserID"]));

        this.VisitRecordPager.RecordCount = visitRecorddt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = visitRecorddt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = VisitRecordPager.CurrentPageIndex - 1;
        pds.PageSize = VisitRecordPager.PageSize;

        rpVisitRecordList.DataSource = pds;
        rpVisitRecordList.DataBind();
    }

    protected void rpVisitRecordList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int visitRecordID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyVisitRecord.aspx?visitRecordID=" + visitRecordID.ToString());
                    break;
                }
            case "delete":
                {
                    int visitRecordID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (visitRecord.DeleteVisitRecord(visitRecordID) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    VisitRecordDataBind();
                    break;
                }
            case "detail":
                {
                    int visitRecordID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("VisitRecordDetail.aspx?visitRecordID=" + visitRecordID);
                    break;
                }
        }
    }

    protected void VisitRecord_PageChanged(object sender, EventArgs e)
    {
        VisitRecordDataBind();
    }

    protected bool isUserLogin()
    {
        if (Session["userID"].ToString() == "")
            return false;

        int userID = Convert.ToInt32(Session["userID"].ToString());
        if (user.GetUserById(userID) == null)
            return false;

        return true;
    }
}
