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

public partial class ExploreDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String docName = Request.QueryString["docName"];
            Document document = new Document();
            DocumentInfo  documentInfo = document.GetDocumentByName(docName);
            DocNameLabel.Text = documentInfo.DocName;
            DocVersionLabel.Text = documentInfo.DocVersion;
        }
        
    }
}
