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

    }
    protected void Login(object sender, ImageClickEventArgs e)
    {
        string userName = UserName.Text;
        string password = Password.Text;

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
