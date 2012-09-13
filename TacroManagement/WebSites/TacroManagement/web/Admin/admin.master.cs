using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                this.lblUserName.Text = Session["UserName"].ToString();
            }
            DateTime dt = DateTime.Now;
            this.lblDate.Text=dt.GetDateTimeFormats('D')[3].ToString();

           
        }
    }
}
