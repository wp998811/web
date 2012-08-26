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

public partial class web_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DocRadioButtonList.SelectedValue = "Document";
    }


    protected void SearchSubmit_Click(object sender, EventArgs e)
    {
        string searchText = SearchText.Text.Trim();
        if (string.IsNullOrEmpty(searchText))
        {
            return;
        }

        if (DocRadioButtonList.SelectedValue == "Document")
        {
            string condition = "docName LIKE '%" + searchText + "%' OR DocKey LIKE '%" + searchText + "%'";
            Document document = new Document();
            DocGridView.DataSource = document.SearchDocument(condition);
            DocGridView.DataBind();
        }
        else
        {

        }
       
    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ExploreDocument")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DocGridView.Rows[index];
            string docName = row.Cells[2].Text;

            //string docName = Convert.ToString(e.CommandArgument);
            string path = Server.MapPath("./");
            Response.Write("<script  language='javascript'> window.open('ExploreDoc.aspx?docName=" + docName + "','_blank'); </script>");
            //Response.Redirect("Search.aspx");
            //Server.Transfer("Default.aspx");
        }
        else if (e.CommandName == "DownloadDocument")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DocGridView.Rows[index];
            string docName = row.Cells[2].Text;

            //查看下载权限是否允许

            //         WebClient webClient = new WebClient();
            ////         webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            // //        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            //         string path = Server.MapPath("./");
            //         webClient.DownloadFileAsync(new Uri(path+"upload/a.txt"), @"d:\myfile.txt");

            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentByName(docName);
            Response.Clear();
            Response.Buffer = true;
            // Response.ContentType = "text/xml/rmvb";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + documentInfo.DocName);
            string path = Server.MapPath("./");
            Response.WriteFile(path + documentInfo.DocUrl);
            Response.End();
        }
    }

    public string GetDocumentName(int index)
    {
        if (index < 0 || index >= DocGridView.Rows.Count)
        {
            return "";
        }
        GridViewRow row = DocGridView.Rows[index];
        return row.Cells[2].Text;
    }

}
