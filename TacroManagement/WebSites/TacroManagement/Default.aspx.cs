using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    #region 测试

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin();
        string adminName = this.txtUserName.Text.Trim();
        string adminPassword = this.txtPassword.Text.Trim();

        bool loginResult = admin.Login(adminName,adminPassword);

        if (loginResult)
        {
            Response.Write(" <script   language=javascript> window.alert( '登录成功 '); </script> ");
        }
        else
        {
            Response.Write(" <script   language=javascript> window.alert( '登录失败 '); </script> ");
        }
    }


    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userName = this.txtName.Text.Trim();
        string password = this.password.Text.Trim();
        string userType = this.type.Text.Trim();
        string userEmail = this.email.Text.Trim();
        string userPhone = this.phone.Text.Trim();
        int departID =Convert.ToInt32(this.departID.Text.Trim());

        if (user.IsUserNameExists(userName))
        {
            Response.Write("<script   language=javascript> window.alert( '  用户名存在 '); </script>");
        }
        else
        {
            bool addResult = user.AddUser(userName, password, userType, userEmail, userPhone, departID);
            if(addResult)
                Response.Write("<script   language=javascript> window.alert( '  添加成功 '); </script>");
            else
                Response.Write("<script   language=javascript> window.alert( '  添加失败 '); </script>");
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }

    protected void btnUserLogin_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userName = this.txtName.Text.Trim();
        string password = this.password.Text.Trim();

        bool loginResult = user.UserLogin(userName,password); 

        if (loginResult)
        {
            Response.Write(" <script   language=javascript> window.alert( '登录成功 '); </script> ");
        }
        else
        {
            Response.Write(" <script   language=javascript> window.alert( '登录失败 '); </script> ");
        }
    }
    #endregion


}
