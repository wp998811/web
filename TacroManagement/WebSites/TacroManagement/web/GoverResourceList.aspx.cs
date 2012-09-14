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

public partial class web_GoverResourceList : System.Web.UI.Page
{
    GoverResource goverResource = new GoverResource();
    User user = new User();
    ResourceAdmin resourceAdmin = new ResourceAdmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (!isGoverResourceManager())
            {
                HideItems();
            }
            GoverResourceDataBind();
        }
    }

    private void GoverResourceDataBind()
    {
        DataTable goverResourcedt = new DataTable();
        if (!isGoverResourceManager())
        {
            goverResourcedt = goverResource.SearchAllGoverResources();
        }
        else
            goverResourcedt = goverResource.SearchGoverResourcesByUserId(Convert.ToInt32(Session["userID"].ToString()));

        this.GoverResourcePager.RecordCount = goverResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = goverResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = GoverResourcePager.CurrentPageIndex - 1;
        pds.PageSize = GoverResourcePager.PageSize;

        rpGoverResourceList.DataSource = pds;
        rpGoverResourceList.DataBind();
    }

    protected void Add_GoverResource(object sender, EventArgs e)
    {
        Response.Redirect("AddGoverResource.aspx");
    }

    protected void Query_GoverResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string organName = txtOrganName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        UserInfo userInfo = user.GetUserById(Convert.ToInt32(Session["UserID"]));

        DataTable goverResourcedt = new DataTable();
        if (!isGoverResourceManager())
            goverResourcedt = goverResource.GetDataTableByGoverList(goverResource.GetGoverResourceBySearch(manager, city, organName, contactName));
        else
        {
            if (userInfo.UserID != 0)
                goverResourcedt = goverResource.GetDataTableByGoverList(goverResource.GetGoverResourceBySearch(userInfo.UserName, city, organName, contactName));
        }

        this.GoverResourcePager.RecordCount = goverResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = goverResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = GoverResourcePager.CurrentPageIndex - 1;
        pds.PageSize = GoverResourcePager.PageSize;

        rpGoverResourceList.DataSource = pds;
        rpGoverResourceList.DataBind();
    }

    protected void rpGoverResourceList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int goverResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyGoverResource.aspx?goverResourceID=" + goverResourceID.ToString());
                    break;
                }
            case "delete":
                {
                    int goverResourceID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (goverResource.DeleteGoverResource(goverResourceID) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    GoverResourceDataBind();
                    break;
                }
            case "detail":
                {
                    int goverResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("GoverResourceDetail.aspx?goverResourceID=" + goverResourceID);
                    break;
                }
        }
    }

    protected void GoverResource_PageChanged(object sender, EventArgs e)
    {
        GoverResourceDataBind();
    }

    protected bool isGoverResourceManager()
    {
        int userID = Convert.ToInt32(Session["userID"].ToString());
        ResourceAdminInfo resourceAdminInfo = resourceAdmin.GetResourceAdminByResourceTypeAndUserID(userID, "政府资源");
        if (resourceAdminInfo == null)
            return false;

        return true;
    }

    protected void GoverResourceRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (!isGoverResourceManager())
        {
            Control deleteCon = e.Item.FindControl("lbtnRpEdit");
            if (deleteCon != null)
            {
                LinkButton deleteBtn = (LinkButton)deleteCon;
                deleteBtn.Visible = false;
            }
            Control modifyCon = e.Item.FindControl("lbtnRpDelete");
            if (modifyCon != null)
            {
                LinkButton modifyBtn = (LinkButton)modifyCon;
                modifyBtn.Visible = false;
            }
        }
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

    protected void HideItems()
    {
        icon.Visible = false;
        hrefAdd.Visible = false;
        lblManager.Visible = false;
        txtManager.Visible = false;
    }
}

