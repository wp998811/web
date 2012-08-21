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

public partial class AdvancedSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AdvancedSearchButton_Click(object sender, EventArgs e)
    {
        string docName = DocNameText.Text.Trim();
        string docVersion = DocVersionText.Text.Trim();
        string docKey = DocKeyText.Text.Trim();
        string departName = DepartName.Text.Trim();
        string docCate = DocCate.Text.Trim();
        string uploadUserName = UploadUserName.Text.Trim();
        string uploadTimeBegin = UploadTimeBeginText.Text.Trim();
        string uploadTimeEnd = UploadTimeEndText.Text.Trim();

        Document document = new Document();
        string searchCondition = document.GetSearchCondition(departName, docVersion, docKey, departName, docCate, uploadUserName, uploadTimeBegin, uploadTimeEnd);
        DocGridView.DataSource = document.SearchDocument(searchCondition);
        DocGridView.DataBind(); 
    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
}
