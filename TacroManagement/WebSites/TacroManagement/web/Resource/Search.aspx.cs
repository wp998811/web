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
            Session["UserID"] = "1";
            DocRadioButtonList.SelectedValue = "Document";
            AspNetPager1.Visible = false;
        }
        else
        {
            LogoImage.Visible = false;
            AspNetPager1.Visible = true;
        }
        
        if ( DocRadioButtonList.SelectedValue == "Document")
        {
           ProjDocRepeater.Visible =false;
           DocRepeater.Visible = true;
        }
        else
        {
             ProjDocRepeater.Visible =true;
             DocRepeater.Visible = false;
        }
    }

    private void BindDocuments()
    {
        DataTable dataTable = ViewState["DataTable"] as DataTable;
        this.AspNetPager1.RecordCount = dataTable.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dataTable.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        DocRepeater.DataSource = pds;
        DocRepeater.DataBind();
    }
    private void BindProjDocs()
    {
        DataTable dataTable = ViewState["DataTable"] as DataTable;
        this.AspNetPager1.RecordCount = dataTable.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dataTable.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        ProjDocRepeater.DataSource = pds;
        ProjDocRepeater.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        if (DocRadioButtonList.SelectedValue == "Document")
        {
            BindDocuments();
        }
        else
        {
            BindProjDocs();
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
            this.ViewState["DataTable"] = documents;
            BindDocuments();
        }
        else
        {
            string condition = "docName Like '%" + searchText + "%' OR DocKey LIKE '%" + searchText + "%'";
            ProjectDoc projectDoc = new ProjectDoc();
            DataTable projecctDocs = projectDoc.SearchProjectDoc(condition);
            this.ViewState["DataTable"] = projecctDocs;
            BindProjDocs();
        }
       
    }
    public void RepeaterToExcel(System.Web.UI.Control ctl)
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
        DataTable dataTable = ViewState["DataTable"] as DataTable;
        if (dataTable == null || dataTable.Rows.Count <= 0)
        {
            return;
        }
        if (DocRadioButtonList.SelectedValue == "Document")
        {
            DocRepeater.DataSource = dataTable;
            DocRepeater.DataBind();
            RepeaterToExcel(DocRepeater);
        }
        else
        {
            ProjDocRepeater.DataSource = dataTable;
            ProjDocRepeater.DataBind();
            RepeaterToExcel(ProjDocRepeater);
        }
       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    public bool Authoritycontrol()
    {

        User user = new User();
        string userId = Session["UserID"].ToString();
        if (userId == "0")
        {
            return false;
        }
        UserInfo userInfo = user.GetUserById(Convert.ToInt32(userId));
        if (!user.IsUserNameExists(userInfo.UserName))
        {
            return false;
        }
        return true;
    }
    protected void DocRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int  docID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "ExploreDocument")
        {
            ExploreDoc(docID, true);
        }
        else if (e.CommandName == "DownloadDocument")
        {

            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentById(docID);
            string userId=Session["UserID"].ToString();
            //User user = new User();
            //UserInfo userInfo = user.GetUserByName(userName);
            if (document.isPremissionToDownload(documentInfo.DocPermission, docID, Convert.ToInt32(userId)))
            {
                DownloadDoc(docID, true);
            }
        }
        else if (e.CommandName == "ModifyDocument")
        {
            ModifyDoc(docID, true);
        }
        else if (e.CommandName == "DeleteDocument")
        {
            DeleteDoc(docID,true);
        }
    }

    protected void ProjDocRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int docID = Convert.ToInt32(e.CommandArgument);
        //string userName=Session["UserName"].ToString();

        //User user=new User();
        //UserInfo userInfo=user.GetUserByName(userName);
        string userId = Session["UserID"].ToString();
        if (e.CommandName == "ExploreDocument")
        {
            ExploreDoc(docID, false);
        }
        else if (e.CommandName == "DownloadDocument")
        {
            DownloadDoc(docID, false);
        }
        else if (e.CommandName == "ModifyDocument")
        {
            ProjectDoc projectDoc = new ProjectDoc();
            if (projectDoc.isDeleteOrModify(docID,Convert.ToInt32(userId)))
            {
                ModifyDoc(docID, false);
            }
        }
        else if (e.CommandName == "DeleteDocument")
        {
            ProjectDoc projectDoc = new ProjectDoc();
            if (projectDoc.isDeleteOrModify(docID, Convert.ToInt32(userId)))
            {
               DeleteDoc(docID, false);
            }
        }
    }

    private void ExploreDoc(int docID,bool isDocument)
    {

        string documentCate = null;
        string docUrl = null;
        if (isDocument)
        {
            documentCate = "Document";
            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
            docUrl = documentInfo.SavePath;
        }
        else
        {
            documentCate = "ProjectDoc";
            ProjectDoc projectDoc = new ProjectDoc();
            ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
            docUrl = projectDocInfo.SavePath;
        }

        string extension = Path.GetExtension(docUrl).ToLower();
        string address = null;
        if (extension == ".swf")
        {
            address = "ExploreDocument.aspx";
        }
        else
        {
            address = "ExplorePicAndTxt.aspx";
        }
        string url = "../../" + docUrl;
        Response.Redirect(address + "?emotion=" + Server.UrlEncode(url) + "&DocID=" + docID + "&DocumentCate=" + documentCate);
       
    }
    private void DownloadDoc(int docID,bool isDocument)
    {
        string docName = null;
        string uploadPath = null;
        if (isDocument)
        {
            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
            docName = documentInfo.DocName;
            uploadPath = documentInfo.UploadPath;
        }
        else
        {
            ProjectDoc projectDoc = new ProjectDoc();
            ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocById(Convert.ToInt32(docID));
            docName = projectDocInfo.DocName;
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
        Response.WriteFile(Server.MapPath("~/") + uploadPath);
        Response.End();
    }
    private void ModifyDoc(int docID, bool isDocument)
    {
        string address = null;
        if (isDocument)
        {
            address = "ModifyDocument.aspx?DocID=" + docID;
        }
        else
        {
            address = "ModifyProjectDoc.aspx?DocID=" + docID;
        }
        Response.Redirect(address);
    }

    private void DeleteDoc(int docID, bool isDocument)
    {

        int isDelete = 0;
        string uploadPath = null;
        string savePath = null;
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
            File.Delete(path + uploadPath);
            File.Delete(path + savePath);
            SearchSubmit_Click(null, null);
            Response.Write("<script   language=javascript> window.alert( '  删除成功  '); </script>");
        }
        else
        {
            Response.Write("<script   language=javascript> window.alert( '  删除失败  '); </script>");
        }

    }
    protected void DocRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (!Authoritycontrol())
        {
            Control deleteCon = e.Item.FindControl("DeleteBtn");
            if (deleteCon != null)
            {
                LinkButton deleteBtn = (LinkButton)deleteCon;
                deleteBtn.Visible = false;
            }
            Control modifyCon = e.Item.FindControl("ModifyBtn");
            if (modifyCon != null)
            {
                LinkButton modifyBtn = (LinkButton)modifyCon;
                modifyBtn.Visible = false;
            }
        }
        
    }
    protected void ProjDocRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}
