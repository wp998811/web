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

public partial class web_AddPartnerResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
        }
    }

    protected void Add_PartnerResource(object sender, EventArgs e)
    {
        PartnerResource partnerResource = new PartnerResource();
        PartnerResourceInfo partnerResourceInfo = new PartnerResourceInfo();
        partnerResourceInfo.UserID = 1;
        partnerResourceInfo.PartnerCity = textBox_city.Text;
        partnerResourceInfo.OrganName = textBox_organName.Text;
        partnerResourceInfo.OrganIntro = textBox_organIntro.Text;

        if (partnerResource.InsertPartnerResource(partnerResourceInfo) == 1)
        {
            Response.Redirect("PartnerResourceList.aspx");
        }
    }
}
