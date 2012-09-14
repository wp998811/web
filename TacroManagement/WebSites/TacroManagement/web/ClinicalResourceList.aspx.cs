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

public partial class web_ClinicalResourceList : System.Web.UI.Page
{
    ClinicalResource clinicalResource = new ClinicalResource();
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
            if (!isClinicalResourceManager())
            {
                HideItems();
            }
            ClinicalResourceDataBind();
        }
    }

    private void ClinicalResourceDataBind()
    {
        DataTable clinicalResourcedt = new DataTable();
        if (!isClinicalResourceManager())
        {
            clinicalResourcedt = clinicalResource.SearchAllClinicalResources();
        }
        else
            clinicalResourcedt = clinicalResource.SearchClinicalResourcesByUserId(Convert.ToInt32(Session["userID"].ToString()));

        this.ClinicalResourcePager.RecordCount = clinicalResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = clinicalResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ClinicalResourcePager.CurrentPageIndex - 1;
        pds.PageSize = ClinicalResourcePager.PageSize;

        rpClinicalResourceList.DataSource = pds;
        rpClinicalResourceList.DataBind();
    }

    protected void Add_ClinicalResource(object sender, EventArgs e)
    {
        Response.Redirect("AddClinicalResource.aspx");
    }

    protected void Query_ClinicalResource(object sender, EventArgs e)
    {
        string manager = txtManager.Text.Trim();
        string city = txtCity.Text.Trim();
        string hospital = txtHospital.Text.Trim();
        string deptName = txtDepartmentName.Text.Trim();
        string contactName = txtContactName.Text.Trim();

        UserInfo userInfo = user.GetUserById(Convert.ToInt32(Session["UserID"]));

        DataTable clinicalResourcedt = new DataTable();
        if (!isClinicalResourceManager())
            clinicalResourcedt = clinicalResource.GetDataTableByClinicalList(clinicalResource.GetClinicalResearchBySearch(manager, city, hospital, deptName, contactName));
        else
        {
            if (userInfo.UserID != 0)
                clinicalResourcedt = clinicalResource.GetDataTableByClinicalList(clinicalResource.GetClinicalResearchBySearch(userInfo.UserName, city, hospital, deptName, contactName));
        }

        this.ClinicalResourcePager.RecordCount = clinicalResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = clinicalResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ClinicalResourcePager.CurrentPageIndex - 1;
        pds.PageSize = ClinicalResourcePager.PageSize;

        rpClinicalResourceList.DataSource = pds;
        rpClinicalResourceList.DataBind();
    }

    protected void rpClinicalResourceList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int clinicalResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyClinicalResource.aspx?clinicalResourceID=" + clinicalResourceID.ToString());
                    break;
                }
            case "delete":
                {
                    int clinicalResourceID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (clinicalResource.DeleteClinicalResource(clinicalResourceID) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    ClinicalResourceDataBind();
                    break;
                }
            case "detail":
                {
                    int clinicalResourceID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ClinicalResourceDetail.aspx?clinicalResourceID=" + clinicalResourceID);
                    break;
                }
        }
    }

    protected void ClinicalResource_PageChanged(object sender, EventArgs e)
    {
        ClinicalResourceDataBind();
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

    protected bool isClinicalResourceManager()
    {
        int userID = Convert.ToInt32(Session["userID"].ToString());
        ResourceAdminInfo resourceAdminInfo = resourceAdmin.GetResourceAdminByResourceTypeAndUserID(userID, "临床资源");
        if (resourceAdminInfo.ResourceAdminID == 0)
            return false;

        return true;
    }

    protected void ClinicalResourceRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (!isClinicalResourceManager())
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
