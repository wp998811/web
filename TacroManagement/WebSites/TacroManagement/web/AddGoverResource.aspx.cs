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

public partial class web_AddGoverResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
        }
    }

    protected void Add_GoverResource(object sender, EventArgs e)
    {
        GoverResource goverResource = new GoverResource();
        GoverResourceInfo goverResourceInfo = new GoverResourceInfo();
        goverResourceInfo.UserID = 1;
        goverResourceInfo.GoverCity = textBox_city.Text;
        goverResourceInfo.OrganName = textBox_organName.Text;
        goverResourceInfo.OrganIntro = textBox_organIntro.Text;

        if (goverResource.InsertGoverResource(goverResourceInfo) == 1)
        {
            Response.Redirect("GoverResourceList.aspx");
        }
    }
}
