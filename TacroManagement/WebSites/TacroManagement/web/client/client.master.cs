using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BLL;
using Model;

public partial class web_client_client : System.Web.UI.MasterPage
{
    User userManage = new User();
    Project projectManage = new Project();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Session["UserName"].ToString();
            this.lblUserName.Text = userName;
        }
    }
}
