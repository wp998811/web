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

public partial class web_AddClinicalResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ClinicalResourceDataBind();
        }
    }

    private void ClinicalResourceDataBind()
    {

    }

    protected void Add_ClinicalResource(object sender, EventArgs e)
    {
        ClinicalResource clinicalResource = new ClinicalResource();
        ClinicalResourceInfo clinicalResourceInfo = new ClinicalResourceInfo();
        clinicalResourceInfo.UserID = 1;
        clinicalResourceInfo.City = textBox_city.Text;
        clinicalResourceInfo.Hospital = textBox_hospital.Text;
        clinicalResourceInfo.Department = textBox_departmentName.Text;
        clinicalResourceInfo.DepartIntro = textBox_departIntro.Text;

        if (clinicalResource.InsertClinicalResource(clinicalResourceInfo) == 1)
        {
            Response.Redirect("ClinicalResourceList.aspx");
        }
    }
}
