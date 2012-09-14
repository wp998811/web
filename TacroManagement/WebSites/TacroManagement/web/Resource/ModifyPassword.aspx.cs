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

public partial class web_ModifyPassword : System.Web.UI.Page
{
    private static int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
               
            }
            {
            }
            if (Request.UrlReferrer != null)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
            }
           
        } 
        userID = Convert.ToInt32(Session["UserID"].ToString());
    }
    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        User user = new User();
        UserInfo userInfo = user.GetUserById(userID);
        string oldPass = OldPassword.Text.Trim();
        string newPass = NewPassword.Text.Trim();
        if (oldPass == userInfo.Password)
        {
            userInfo.Password = newPass;
            user.UpdateUser(userInfo);
            ClientScript.RegisterStartupScript(this.GetType(), "returnMsg", "<script type=text/javascript> $(\"#SuccessModal\").modal();</script>");
            return;
        }

        ClientScript.RegisterStartupScript(this.GetType(), "returnMsg", "<script type=text/javascript> $(\"#FailedModal\").modal();</script>");
    }
    protected void ReturnHome_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Return")
        {
            Response.Redirect("Home.aspx");
        }

    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (ViewState["retu"] != null)
        {
            Response.Redirect(ViewState["retu"].ToString());
        }
    }
}
