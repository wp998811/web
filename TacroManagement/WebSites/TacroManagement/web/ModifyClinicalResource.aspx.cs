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

public partial class web_ModifyClinicalResource : System.Web.UI.Page
{
    ClinicalResource clinicalResource = new ClinicalResource();
    ClinicalContact clinicalContact = new ClinicalContact();
    Contact contact = new Contact();
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

            if (Request.Params["clinicalResourceID"] != null && Request.Params["clinicalResourceID"].Trim() != "")
            {
                clinicalResourceID = Request.Params["clinicalResourceID"];
                ClinicalResourceDataBind();
            }
        }
    }

    private void ClinicalResourceDataBind()
    {
        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(Convert.ToInt32(clinicalResourceID));
        UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);

        txtManager.Text = userInfo.UserName;
        txtCity.Text = clinicalResourceInfo.City;
        txtHiddenUserID.Text = userInfo.UserID.ToString();
        txtHospital.Text = clinicalResourceInfo.Hospital;
        txtDepartmentName.Text = clinicalResourceInfo.Department;
        txtDepartmentIntro.Text = clinicalResourceInfo.DepartIntro;

        IList<UserInfo> userInfos = user.GetUsers();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";

        ddlUser.DataSource = userInfos;
        ddlUser.DataBind();

        ContactRpDataBind();
    }

    private void ContactRpDataBind()
    {
        DataTable contactdt = clinicalContact.SearchAllContactsByClinicalID(Convert.ToInt32(clinicalResourceID));

        this.ContactPager.RecordCount = contactdt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = contactdt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ContactPager.CurrentPageIndex - 1;
        pds.PageSize = ContactPager.PageSize;

        rpContactList.DataSource = pds;
        rpContactList.DataBind();
    }


    protected void Modify_ClinicalResource(object sender, EventArgs e)
    {
        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(Convert.ToInt32(Request["clinicalResourceID"]));
        clinicalResourceInfo.UserID = Convert.ToInt32(txtHiddenUserID.Text);
        clinicalResourceInfo.City = txtCity.Text;
        clinicalResourceInfo.Department = txtDepartmentName.Text;
        clinicalResourceInfo.DepartIntro = txtDepartmentIntro.Text;
        clinicalResourceInfo.Hospital = txtHospital.Text;

        if (clinicalResource.UpdateClinicalResource(clinicalResourceInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("ClinicalResourceList.aspx");
    }

    protected void Add_ClinicalContact(object sender, EventArgs e)
    {
        string clinicalResourceID = Request.QueryString["clinicalResourceID"];
        Response.Redirect("AddClinicalContact.aspx?clinicalResourceID=" + clinicalResourceID);
    }

    protected void Contact_PageChanged(object sender, EventArgs e)
    {
        ContactRpDataBind();
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Redirect("ClinicalResourceList.aspx");
    }

    protected void lbtnSelectUser_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            if (ddlUser.Items.Count == 0)
                return;
            int userID = Convert.ToInt32(ddlUser.SelectedValue);
            UserInfo userInfo = user.GetUserById(userID);

            if (userInfo != null)
            {
                txtManager.Text = userInfo.UserName;
                txtHiddenUserID.Text = userID.ToString();
            }
        }
    }

    protected void rpContactList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "edit":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("ModifyClinicalContact.aspx?clinicalResourceID=" + clinicalResourceID.ToString() + "&contactID=" + contactID.ToString());
                    break;
                }
            case "delete":
                {
                    int contactId = Convert.ToInt32(e.CommandArgument.ToString());

                    if (contact.DeleteContact(contactId) == 1)
                    {
                        Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
                    }
                    else
                    {
                        Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
                    }
                    ContactRpDataBind();
                    break;
                }
            case "addVisitRecord":
                {
                    int contactID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("AddVisitRecord.aspx?contactID=" + contactID.ToString() + "&ID=" + clinicalResourceID + "&resourceType=临床");
                    ContactRpDataBind();
                    break;
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
}
