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
            IList<DocumentInfo> documentInfos = document.GetDocumentBySearchCondition(condition);
            DataTable documents = document.GetDataTableByDocumentList(documentInfos);
            DataColumn subTaskColumn = new DataColumn("项目子任务");//与页面的GirdView一致
            documents.Columns.Add(subTaskColumn);
            DocGridView.DataSource = documents;
            DocGridView.DataBind();
            DocGridView.Columns[4].Visible = false;
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
                
            string documentCate=null;
            string docUrl=null;
            if (isDocument)
            {
                documentCate ="Document";
                Document document = new Document();
                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                docUrl = documentInfo.SavePath;
                //Response.Write("<script  language='javascript'> window.open('ExploreDocument.aspx?emotion=../" + documentInfo.SavePath + "&DocID=" + docID + "&DocumentCate=Document','_blank'); </script>");
            }else
            {
                documentCate="ProjectDoc";
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                docUrl=projectDocInfo.SavePath;
                //Response.Write("<script  language='javascript'> window.open('ExploreProjectDoc.aspx?DocID=" + docID + "','_blank'); </script>");
                
            }

            string extension = Path.GetExtension(docUrl).ToLower();
            string address=null;
            if (extension == ".swf")
            {
                address = "ExploreDocument.aspx";
            }
            else
            {
                address = "ExplorePicAndTxt.aspx";
            }

            string url = "../"+docUrl;
            Response.Redirect(address + "?emotion=" + Server.UrlEncode(url) + "&DocID=" + docID + "&DocumentCate=" + documentCate);
        }
        else if (e.CommandName == "DownloadDocument")
        {
            //查看下载权限是否允许
            string docName = null;
            string uploadPath=null;
            if (isDocument)
            {
                Document document = new Document();

                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                if (!document.isPremissionToDownload(documentInfo.DocPermission,documentInfo.DocID,1))
                {
                    Response.Write("<script   language=javascript> window.alert( '   下载权限不够，无法下载  '); </script>");
                    return ;
                }
                docName = documentInfo.DocName;
                uploadPath = documentInfo.UploadPath;
            }else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                if (!projectDoc.isPremissionToDownload(projectDocInfo.DocPermission, projectDocInfo.ProjDocId, 1))
                {
                    Response.Write("<script   language=javascript> window.alert( '   下载权限不够，无法下载  '); </script>");
                    return ;
                }
                docName= projectDocInfo.DocName;
                uploadPath = projectDocInfo.UploadPath;
            }

            //获取后缀名
            string fileName = docName;
            fileName = fileName + "." + uploadPath.Substring(uploadPath.LastIndexOf(".") + 1);

            Response.Clear();
            Response.Buffer = true;
            // Response.ContentType = "text/xml/rmvb";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.WriteFile(Server.MapPath("~/")+ uploadPath);
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
            string uploadPath = null; 
            string savePath =null;
            if (isDocument)
            {
                Document document = new Document();
                DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
                uploadPath = documentInfo.UploadPath;
                savePath = documentInfo.SavePath;
                isDelete = document.DeleteDocument(Convert.ToInt32(docID));
                
            }
            else
            {
                ProjectDoc projectDoc = new ProjectDoc();
                ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
                uploadPath = projectDocInfo.UploadPath;
                savePath = projectDocInfo.SavePath;
                isDelete = projectDoc.DeleteProjectDoc(Convert.ToInt32(docID));

            }
           
             if (isDelete == 1)
            {
                string path = Server.MapPath(@"~/");
                File.Delete(path+uploadPath);
                File.Delete(path+savePath);
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

    public void GVToExcel(System.Web.UI.Control ctl)
    {
        DateTime dateTime = DateTime.Now;
        string timeString = dateTime.ToString();
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename="+timeString+".xls");
        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        ctl.Page.EnableViewState = false;
        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        ctl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        GVToExcel(DocGridView);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
}
