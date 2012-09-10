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

public partial class web_UploadDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDocCate();
            InitProjectDoc();
            InitUsers();
        }
    }

    /// <summary>
    /// 初始化文档所属的所有项目
    /// </summary>
    private void InitProjectDoc()
    {
        Project project = new Project();
        IList<ProjectInfo> projectInfos = project.GetProjects();


        ProjectName.Items.Clear();
        ProjectName.Items.Add(new ListItem("选择项目", "0"));

        for (int i = 0; i < projectInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = projectInfos[i].ProjectNum;
            listItem.Text = projectInfos[i].ProjectName;
            ProjectName.Items.Add(listItem);
        }

        //if (ProjectName.Items.Count <= 0)
        //{
        //    return;
        //}
        //ProjectName.SelectedIndex = 0;

        SubTask subTask = new SubTask();
        IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(ProjectName.SelectedValue);

        for (int i = 0; i < subTaskInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(subTaskInfos[i].TaskId);
            listItem.Text = subTaskInfos[i].TaskName;
            SubTaskName.Items.Add(listItem);
        }

        //if (SubTaskName.Items.Count >= 0)
        //{
        //    SubTaskName.SelectedIndex = 0;
        //}
    }

    /// <summary>
    /// 初始化文档所属的所有部门
    /// </summary>
    private void InitDocCate()
    {
        Department department = new Department();
        IList<DepartmentInfo> departmentInfos = department.GetDepartments();
        DepartName.Items.Clear();
        DepartName.Items.Add(new ListItem("选择部门", "0"));
        for (int i = 0; i < departmentInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Text = departmentInfos[i].DepartName;
            listItem.Value = Convert.ToString(departmentInfos[i].DepartID);
            DepartName.Items.Add(listItem);
        }
        //if (DepartName.Items.Count <= 0)
        //{
        //    return;
        //}
        //DepartName.SelectedIndex = 0;

        DepartDocCate departDocCate = new DepartDocCate();
        IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(Convert.ToInt32(DepartName.SelectedItem.Value));
        for (int i = 0; i < departDocCateInfos.Count; ++i)
        {
            ListItem listItem = new ListItem();
            listItem.Value = Convert.ToString(departDocCateInfos[i].Id);
            listItem.Text = departDocCateInfos[i].CategoryName;
            DocCate.Items.Add(listItem);
        }
        //if (DocCate.Items.Count >= 1)
        //{
        //    DocCate.SelectedIndex = 0;
        //}
    }

    /// <summary>
    /// 查询所有用户绑定到UserNameListView
    /// </summary>
    private void InitUsers()
    {
        BLL.User user = new BLL.User();
        IList<UserInfo> userInfos = user.GetUsers();
        UserNameListView.DataSource = user.GetTableByUserList(userInfos);
        UserNameListView.DataBind();
    }

    /// <summary>
    /// 点击上传文档按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        
         string docName = DocNameText.Text.Trim();
        string projectName = ProjectName.Text.Trim();
        string filePath = FileUpload1.PostedFile.FileName;
        int fileLength = FileUpload1.PostedFile.ContentLength;
        if (filePath.Length <=0 || fileLength <=0)
        {
            Response.Write("<script   language=javascript> window.alert( ' 请选择需要上传的文件 '); </script>");
            return;
        }
        string fileName = docName;
        if (docName.IndexOf('.') == -1)
        {
            //Response.Write("<script   language=javascript> window.alert( ' 请文件名后缀 '); </script>");
            fileName = fileName + "." + filePath.Substring(filePath.LastIndexOf(".") + 1);
        }
        string extension = Path.GetExtension(fileName).ToLower();
        string directory = null;
        if (DocRadioButtonList.SelectedValue == "Document")
        {
            directory = "Documents/";
        }
        else
        {
            directory ="ProjectDocs/" + projectName + "/";
        }
        string savePath = null;
       //只有属于office文件和pdf时才需要转的swf文件
        if (extension == ".doc" || extension == ".docx" || extension == ".ppt" || extension == ".pptx" || extension == ".xls" || extension == ".xlsx" || extension == ".pdf")
        {
            savePath = directory + fileName.Substring(0, fileName.Length - extension.Length) + ".swf";
        }
        else
        {
            savePath = directory + fileName;
        }
        string uploadPath = directory+ fileName;
        string docDescription = DocDescription.Text.Trim();
        string docKey = DocKeyText.Text.Trim();
        if (DocRadioButtonList.SelectedValue == "Document")
        {
            //资料文档上传
            string docVersion = DocVersionText.Text.Trim();
            string departID =DepartName.SelectedValue;
            string docCateID = DocCateIDText.Value;
            string downloadPremission = DownLoadPremission.SelectedValue;
            string docState = DocState.SelectedValue;

            Document document = new Document();
            bool isAdd = document.AddDocument(docName, docVersion, docKey, docDescription, departID, docCateID, docState, uploadPath,savePath, downloadPremission, "1");
            DocumentInfo documentInfo = document.GetDocumentByName(docName);
            if (isAdd)
            {//数据库插入成功
                DocUser docUser = new DocUser();
                if (downloadPremission == "3")
               {
                    IList<int> userIds =GetCheckedUserId();
                    for (int i = 0; i<userIds.Count; ++i)
                    {
                        DocUserInfo docUserInfo = new DocUserInfo(documentInfo.DocID, userIds[i]);
                        docUser.InsertDocUser(docUserInfo);
                    }
               }

               bool isUpload = UploadDocument(directory,fileName);
               if (!isUpload)
                { //上传失败
                    document.DeleteDocumentByName(docName);
                    docUser.DeleteDocUserByDocId(documentInfo.DocID);
                }
            }
        
        }
        else
        {
            //项目文档上传
            string subTaskID = SubTaskIDText.Value;
            string projectDocCate = ProjectDocCate.Text;
            string downloadPremission = DownLoadPremission.SelectedValue;

            ProjectDoc projectDoc = new ProjectDoc();
            bool isAdd = projectDoc.AddProjectDoc(subTaskID, projectDocCate, docName, docKey, docDescription, uploadPath,savePath, downloadPremission, "1");
           ProjectDocInfo projectDocInfo = projectDoc.GetProjectDocByName(docName); 

            if(isAdd)
            {//数据库插入成功     
                // 自定义用户
                ProjectDocUser projectDocUser = new ProjectDocUser();
                if (downloadPremission == "3")
                {
                    IList<int> userIds = GetCheckedUserId();
                    for (int i = 0; i<userIds.Count; ++i)
                    {
                        ProjDocUserInfo projDocUserInfo = new ProjDocUserInfo(projectDocInfo.ProjDocId, Convert.ToString(userIds[i]));
                        projectDocUser.InsertProjDocUser(projDocUserInfo);
                    }
                }
                bool isUpload = UploadDocument(directory, fileName);
                if (!isUpload)
                { //上传失败
                    projectDocUser.DeleteProjectDocUserByDocId(projectDocInfo.ProjDocId);
                    projectDoc.DeleteProjectDoc(projectDocInfo.ProjDocId);
                }
            }
        }
    }

    /// <summary>
    /// 上传文档
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private bool UploadDocument(string directory, string fileName)
    {
            string serverFileName;
            string serverPath = Server.MapPath(@"~/") + directory;
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }

            serverFileName = serverPath + fileName;
            if (File.Exists(serverFileName))
            {
                Response.Write("<script   language=javascript> window.alert( ' 上传失败，文件已存在  '); </script>");
                return false;
            }
            else
            {
                try
                {
                    FileUpload1.PostedFile.SaveAs(serverFileName);
                    SaveAsSwf(serverFileName, fileName);
                    Response.Write("<script   language=javascript> window.alert( ' 上传成功  '); </script>");
                    return true;
                }
                catch (Exception exc)
                {
                    Response.Write("<script   language=javascript> window.alert( ' 上传失败" + exc + "  '); </script>");
                   return false;
                }
            }
    }

    /// <summary>
    /// 把word,excel,ppt,ptf保存为swf文件并删除pdf临时文档
    /// </summary>
    /// <param name="organName"></param>
    /// <returns></returns>
    private bool SaveAsSwf(string articlePath, string fileName)
    {
        Pdf2Swf pdf2swf = new Pdf2Swf();
        Office2Pdf office2pdf = new Office2Pdf();
        string extension = Path.GetExtension(fileName).ToLower();
        string pdfpath = articlePath.Substring(0, articlePath.Length - extension.Length) + ".pdf";
        string swfpath = articlePath.Substring(0, articlePath.Length - extension.Length) + ".swf";


        if (extension == ".doc" || extension == ".docx")
        {
            office2pdf.DOCConvertToPDF(articlePath, pdfpath);
            pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
            File.Delete(pdfpath);
            return true;
        }

        else if (extension == ".ppt" || extension == ".pptx")
        {
            office2pdf.PPTConvertToPDF(articlePath, pdfpath);
            pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
            File.Delete(pdfpath);
            return true;
        }
        else if (extension == ".xls" || extension == ".xlsx")
        {
            office2pdf.XLSConvertToPDF(articlePath, pdfpath);
            pdf2swf.PDFConvertToSWF(pdfpath, swfpath);
            File.Delete(pdfpath);
            return true;
        }
        else if (extension == ".pdf")
        {
            pdf2swf.PDFConvertToSWF(articlePath, swfpath);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获取UserNameListView中选择的UserID的List
    /// </summary>
    /// <returns></returns>
    private IList<int> GetCheckedUserId()
    {
        IList<int> userIds=new List<int>();
        for (int i = 0; i < UserNameListView.Rows.Count; ++i)
        {
            GridViewRow gvr = UserNameListView.Rows[i];
            Control ctl = gvr.FindControl("ckb");
            CheckBox ckb= (CheckBox)ctl;

            if (ckb.Checked)
            {
                string userId = UserNameListView.DataKeys[i][0].ToString();
                userIds.Add(Convert.ToInt32(userId));
            }
        }
        return userIds;
    }
}
