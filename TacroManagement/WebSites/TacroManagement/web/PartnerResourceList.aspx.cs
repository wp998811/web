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

public partial class web_PartnerResource : System.Web.UI.Page
{
    PartnerResource partnerResource = new PartnerResource();
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
            if (!isPartnerResourceManager())
            {
                HideItems();
            }
            PartnerResourceDataBind();
        }
    }

    private void PartnerResourceDataBind()
    {
        DataTable partnerResourcedt = new DataTable();
        if (!isPartnerResourceManager())
        {
            partnerResourcedt = partnerResource.SearchAllPartnerResources();
        }
        else
            partnerResourcedt = partnerResource.SearchPartnerResourcesByUserId(Convert.ToInt32(Session["userID"].ToString()));

        this.PartnerResourcePager.RecordCount = partnerResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = partnerResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = PartnerResourcePager.CurrentPageIndex - 1;
        pds.PageSize = PartnerResourcePager.PageSize;

        rpPartnerResourceList.DataSource = pds;
        rpPartnerResourceList.DataBind();
    }

    protected void Add_PartnerResource(object sender, EventArgs e)
    {
        Response.Redirect("AddPartnerResource.aspx");
    }

    protected void Query_PartnerResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string organName = txtOrganName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        UserInfo userInfo = user.GetUserById(Convert.ToInt32(Session["UserID"]));

        DataTable partnerResourcedt = new DataTable();
        if (!isPartnerResourceManager())
            partnerResourcedt = partnerResource.GetDataTableByPartnerList(partnerResource.GetPartnerResearchBySearch(manager, city, organName, contactName));
        else
        {
            if (userInfo.UserID != 0)
                partnerResourcedt = partnerResource.GetDataTableByPartnerList(partnerResource.GetPartnerResearchBySearch(userInfo.UserName, city, organName, contactName));
        }

        this.PartnerResourcePager.RecordCount = partnerResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = partnerResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = PartnerResourcePager.CurrentPageIndex - 1;
        pds.PageSize = PartnerResourcePager.PageSize;

        rpPartnerResourceList.DataSource = pds;
        rpPartnerResourceList.DataBind();
    }

    protected void rpPartnerResourceList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int partnerResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyPartnerResource.aspx?partnerResourceID=" + partnerResourceID.ToString());
                    break;
                }
            case "delete":
                {
                    int partnerResourceID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (partnerResource.DeletePartnerResource(partnerResourceID) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    PartnerResourceDataBind();
                    break;
                }
            case "detail":
                {
                    int partnerResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("PartnerResourceDetail.aspx?partnerResourceID=" + partnerResourceID);
                    break;
                }
        }
    }

    protected void PartnerResource_PageChanged(object sender, EventArgs e)
    {
        PartnerResourceDataBind();
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

    protected bool isPartnerResourceManager()
    {
        int userID = Convert.ToInt32(Session["userID"].ToString());
        ResourceAdminInfo resourceAdminInfo = resourceAdmin.GetResourceAdminByResourceTypeAndUserID(userID, "合作伙伴资源");
        if (resourceAdminInfo == null)
            return false;

        return true;
    }

    protected void PartnerResourceRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (!isPartnerResourceManager())
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

    protected void HideItems()
    {
        icon.Visible = false;
        hrefAdd.Visible = false;
        lblManager.Visible = false;
        txtManager.Visible = false;
    }
}
