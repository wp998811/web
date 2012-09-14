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

public partial class web_ClinicalResourceDetail : System.Web.UI.Page
{
    ClinicalResource clinicalResource = new ClinicalResource();
    User user = new User();
    public static string clinicalResourceID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!isUserLogin())
            {
                Response.Redirect("login.aspx");
            }
            if (Request.Params["clinicalResourceID"] != null && Request.Params["clinicalResourceID"] != "")
            {
                ClinicalResourceDataBind();
            }
        }
    }

    private void ClinicalResourceDataBind()
    {
        int clinicalResourceID = Convert.ToInt32(Request["clinicalResourceID"]);

        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(clinicalResourceID);
        if (clinicalResourceInfo != null)
        {
            UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);
            lblManager.Text = userInfo.UserName;
            lblCity.Text = clinicalResourceInfo.City;
            lblHospital.Text = clinicalResourceInfo.Hospital;
            lblDepartmentName.Text = clinicalResourceInfo.Department;
            lblDepartmentIntro.Text = clinicalResourceInfo.DepartIntro;
        }

        DataTable clinicalResourcedt = clinicalResource.SearchAllContactsByClinicalResourceID(clinicalResourceID);

        this.ClinicalContactPager.RecordCount = clinicalResourcedt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = clinicalResourcedt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ClinicalContactPager.CurrentPageIndex - 1;
        pds.PageSize = ClinicalContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }

    protected void ClinicalContact_PageChanged(object sender, EventArgs e)
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
}
