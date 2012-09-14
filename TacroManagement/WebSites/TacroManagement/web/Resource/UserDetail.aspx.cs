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

public partial class web_UserDetail : System.Web.UI.Page
{
    User userBLL = new User();
    private static int userID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UserID"] = "1";
            if (Session["UserID"] == null)
            {
                //Response.Redirect("login.aspx");
            }
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }
            InitUser();
        }
        userID = Convert.ToInt32(Session["UserID"].ToString());
    }

    protected void InitUser()
    {
        UserInfo userInfo = userBLL.GetUserById(userID);
        lblUserName.Text = userInfo.UserName;
        lblEmail.Text = userInfo.UserEmail;
        lblPhone.Text = userInfo.UserPhone;
        lblUserType.Text = userInfo.UserType;

        Department department=new Department();
        DepartmentInfo departmentInfo=department.GetDepartmentByID(userInfo.DepartID);
        lblDepart.Text = departmentInfo.DepartName;
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }
}
