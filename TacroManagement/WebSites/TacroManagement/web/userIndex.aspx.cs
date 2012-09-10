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

public partial class web_userIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            string userName = Session["UserName"].ToString();

            this.lblUser.Text = userName;
            
        }
    }

    //个人资料修改
    protected void imgBtnModifyInfo_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}
