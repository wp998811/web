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

public partial class web_ModifyUser : System.Web.UI.Page
{

    User userBLL = new User();
    private static int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            Session["UserID"] = "1";
            if (Session["UserID"] != null)
            {

            }
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

    private void InitUser()
    {
        UserInfo userInfo = userBLL.GetUserById(userID);
        txtUserName.Text = userInfo.UserName;
            txtEmail.Text=userInfo.UserEmail;
            txtPhone.Text = userInfo.UserPhone;
    }
    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        this.lblUserName.Visible = false;

        string userName=txtUserName.Text.Trim();
        string userEmail = txtEmail.Text.Trim();
        string userPhone = txtPhone.Text.Trim();
        if (userBLL.IsUserNameExists(userName))
        {
            this.lblUserName.Visible = true;
        }
        {
            UserInfo userInfo = userBLL.GetUserById(userID);
            userInfo.UserName = userName;
            userInfo.UserEmail = userEmail;
            userInfo.UserPhone = userPhone;
            if (userBLL.UpdateUser(userInfo) == 1)
            {
                SetPrompt("添加成功", true);
            }
            else
            {
                SetPrompt("添加失败", true);
            }
        }
    }

    private void SetPrompt(string Prompt, bool IsVisible)
    {
        lblPrompt.Text = Prompt;
        lblPrompt.Visible = IsVisible;
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }
}
