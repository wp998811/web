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

public partial class web_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }

    }

    //用户登录
    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        User user = new User();
        string userName = this.txtUserName.Text.Trim();
        string userPassword = this.txtPassword.Text.Trim();
        bool loginResult = user.UserLogin(userName,userPassword);
        
        if (loginResult)
        {
            Session["UserName"] = userName;

            //系统管理员
            if (user.IsSysAdmin(userName))
            {
                Response.Redirect("Admin/AdminManagement.aspx");
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
        else
        {
            Response.Write(" <script language=javascript> window.alert( '用户名或密码错误! '); </script> ");
        }
    }
    protected void Login(object sender, ImageClickEventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;

        User user = new User();

        if (user.IsUserNameExists(userName))
        {
            UserInfo userInfo = user.GetUserByName(userName);
            if (userInfo.Password == password)
            {
                Session["userID"] = userInfo.UserID.ToString();
                Response.Redirect("AddVisitRecord.aspx");
            }
        }
    }
}
