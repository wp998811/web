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

public partial class web_DocumentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string searchCondition = Request.QueryString["SearchCondition"];
        Document document = new Document();
        IList<DocumentInfo> documentInfos = document.GetDocumentBySearchCondition(searchCondition);
        DataTable documents = document.GetDataTableByDocumentList(documentInfos);
        DocGridView.DataSource = documents;
        DocGridView.DataBind();
    }
}
