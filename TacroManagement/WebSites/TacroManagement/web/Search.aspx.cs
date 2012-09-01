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
using System.IO;

using System.Collections.Generic;
using BLL;
using Model;

public partial class web_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            DocRadioButtonList.SelectedValue = "Document";
        }
       
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
            DataTable documents= document.SearchDocument(condition);
            DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
            documents.Columns.Add(subTaskColumn);
            DocGridView.DataSource = documents;
            DocGridView.DataBind();
            DocGridView.Columns[4].Visible = false;

            Response.Write("<script  language='javascript'> window.parent.frames['mainFrame'].location.replace('../projectList.aspx'); </script>");

        }
        else
        {
            string condition = "docName Like '%" + searchText + "%' OR DocKey LIKE '%" + searchText + "%'";
            ProjectDoc projectDoc = new ProjectDoc();
            DataTable projecctDocs = projectDoc.SearchProjectDoc(condition);

            DataColumn docVersionColumn = new DataColumn("版本");//与页面的GirdView一致
            projecctDocs.Columns.Add(docVersionColumn);
            DataColumn departNameColumn = new DataColumn("所属部门");//与页面的GirdView一致
            projecctDocs.Columns.Add(departNameColumn);

            DocGridView.DataSource = projecctDocs;
            DocGridView.DataBind();
            DocGridView.Columns[1].Visible = false;
            DocGridView.Columns[3].Visible = false;

        }
       
    }

    protected void DocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);
        string docID = DocGridView.DataKeys[index][0].ToString();

        bool isDocument = false;
        if ( DocRadioButtonList.SelectedValue == "Document")
        {
            isDocument= true;
        }

        if (e.CommandName == "ExploreDocument")
        {
            string path = Server.MapPath("./");
            if (isDocument)
            { 
                Response.Write("<script  language='javascript'> window.open('ExploreDoc.aspx?DocID=" + docID + "','_blank'); </script>");
            }else
            {
                Response.Write("<script  language='javascript'> window.open('ExploreProjectDoc.aspx?DocID=" + docID + "','_blank'); </script>");
            }   
            //Response.Redirect("Search.aspx");
            //Server.Transfer("Default.aspx");
        }
        else if (e.CommandName == "DownloadDocument")
        {
            //查看下载权限是否允许
            string docName = null;
            string docUrl=null;
            if (isDocument)
            {
                Document document = new Document();
                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                docName = documentInfo.DocName;
                docUrl = documentInfo.DocUrl;
            }else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                docName= projectDocInfo.DocName;
                docUrl = projectDocInfo.DocUrl;
            }

            //获取后缀名
            string fileName = docName;
             fileName = fileName + "." + docUrl.Substring(docUrl.LastIndexOf(".") + 1);

            Response.Clear();
            Response.Buffer = true;
            // Response.ContentType = "text/xml/rmvb";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string path = Server.MapPath("~/");
            Response.WriteFile(path + docUrl);
            Response.End();

        }
        else if (e.CommandName == "ModifyDocument")
        {
            string address=null;
            if (DocRadioButtonList.SelectedValue == "Document")
            {
                 address = "ModifyDocument.aspx?DocID=" + docID;
                
            }else
            {
                 address = "ModifyProjectDoc.aspx?DocID=" + docID;
            }
            Response.Redirect(address);
        }
        else if (e.CommandName == "DeleteDocument")
        {
            int isDelete = 0;
            string docUrl =null;
            if (isDocument)
            {
                Document document = new Document();
                docUrl = document.GetDocumentById(Convert.ToInt32(docID)).DocUrl;
                isDelete = document.DeleteDocument(Convert.ToInt32(docID));
                
            }
            else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                docUrl = projectDoc.GetProjectDocById(Convert.ToInt32(docID)).DocUrl;
                isDelete = projectDoc.DeleteProjectDoc(Convert.ToInt32(docID));

            }
           
             if (isDelete == 1)
            {
                string fileName = Server.MapPath(@"~/") + docUrl;
                File.Delete(fileName);
                SearchSubmit_Click(null, null);
                Response.Write("<script   language=javascript> window.alert( '  删除成功  '); </script>");
               
            }
             else
             {
                 Response.Write("<script   language=javascript> window.alert( '  删除失败  '); </script>");
             }

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
    protected void DocGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
