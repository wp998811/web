using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    #region 测试

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin();
        string adminName = this.txtUserName.Text.Trim();
        string adminPassword = this.txtPassword.Text.Trim();

        bool loginResult = admin.Login(adminName,adminPassword);

        if (loginResult)
        {
            Response.Write(" <script   language=javascript> window.alert( '登录成功 '); </script> ");
        }
        else
        {
            Response.Write(" <script   language=javascript> window.alert( '登录失败 '); </script> ");
        }
    }


    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userName = this.txtName.Text.Trim();
        string password = this.password.Text.Trim();
        string userType = this.type.Text.Trim();
        string userEmail = this.email.Text.Trim();
        string userPhone = this.phone.Text.Trim();
        int departID =Convert.ToInt32(this.departID.Text.Trim());

        if (user.IsUserNameExists(userName))
        {
            Response.Write("<script   language=javascript> window.alert( '  用户名存在 '); </script>");
        }
        else
        {
            bool addResult = user.AddUser(userName, password, userType, userEmail, userPhone, departID);
            if(addResult)
                Response.Write("<script   language=javascript> window.alert( '  添加成功 '); </script>");
            else
                Response.Write("<script   language=javascript> window.alert( '  添加失败 '); </script>");
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int userID = 1;//测试ID

        User user = new User();

        string userName = this.txtName.Text.Trim();
        string password = this.password.Text.Trim();
        string userType = this.type.Text.Trim();
        string userEmail = this.email.Text.Trim();
        string userPhone = this.phone.Text.Trim();
        int departID = Convert.ToInt32(this.departID.Text.Trim());

        if (user.IsUserNameExists(userName))
        {
            Response.Write("<script   language=javascript> window.alert( '  用户名存在 '); </script>");
        }
        else
        {
            bool editResult = user.ModifyUser(userID,userName, password, userType, userEmail, userPhone, departID);
            if (editResult)
                Response.Write("<script   language=javascript> window.alert( '  编辑成功 '); </script>");
            else
                Response.Write("<script   language=javascript> window.alert( '  编辑失败 '); </script>");
        }


    }

    protected void btnUserLogin_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userName = this.txtName.Text.Trim();
        string password = this.password.Text.Trim();

        bool loginResult = user.UserLogin(userName,password); 

        if (loginResult)
        {
            Response.Write(" <script   language=javascript> window.alert( '登录成功 '); </script> ");
        }
        else
        {
            Response.Write(" <script   language=javascript> window.alert( '登录失败 '); </script> ");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int userID=5;

        User user=new User();

        UserInfo userInfo = user.GetUserById(userID);

        if (userInfo == null || string.IsNullOrEmpty(userInfo.UserName))
        {
            Response.Write(" <script   language=javascript> window.alert( '用户不存在 '); </script> ");
            return;
        }
        int delResult = user.DeleteUser(userID);
        
        if(delResult==1)
            Response.Write(" <script   language=javascript> window.alert( '删除成功 '); </script> ");
        else
            Response.Write(" <script   language=javascript> window.alert( '删除失败 '); </script> ");

    }

    #endregion


<<<<<<< HEAD
<<<<<<< HEAD

=======
=======
>>>>>>> origin/MacGrady
    #region test by wangjie
    protected void testButton_Click(object sender, EventArgs e)
    {

        string filePath = FileUpload1.PostedFile.FileName;
        if (filePath.Trim().Length > 0)
        {
            string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            //string serverfimename = Server.MapPath(@"../") + filename;
            string serverfilename = @"c:\upload\" + filename;

            if (System.IO.File.Exists(serverfilename))
            {
                //this.Page.RegisterStartupScript("", "<script>alert('此文件已经存在！');</script>");
            }
            else
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(serverfilename);
                      //  this.Page.RegisterStartupScript("", "<script>alert('文件上传成功！');</script>");
                    }
                    catch (Exception exc)
                    {
                    //    this.Page.RegisterStartupScript("", "<script>alert('文件上传失败！');</script>");
                    }
                }
            }
        }
        //PartnerResource partnerResource = new PartnerResource();
        //PartnerResourceInfo partnerResourceInfo = new PartnerResourceInfo();
        //IList<PartnerResourceInfo> partnerResourceInfos;
        //partnerResourceInfo = partnerResource.GetPartnerResourceById(1);
        //int isInsert = partnerResource.InsertPartnerResource(partnerResourceInfo);
        //partnerResourceInfo.OrganName = "更新组织名称";
        //int isUpdate = partnerResource.UpdetePartnerResource(partnerResourceInfo);
        //int isDelete = partnerResource.DeletePartnerResource(2);
        //partnerResourceInfos = partnerResource.GetPartnerResource();

        //PartnerContactInfo partnerContactInfo = new PartnerContactInfo();
        //PartnerContact partnerContact = new PartnerContact();
        //IList<PartnerContactInfo> partnerContactInfos;
        //partnerContactInfo = partnerContact.GetPartnerContactById(1);
        //int isInsert = partnerContact.InsertPartnerContact(partnerContactInfo);
        //partnerContactInfo.PartnerID = 3;
        //int isUpdate = partnerContact.UpdatePartnerContact(partnerContactInfo);
        //int isDelete = partnerContact.DeletePartnerContact(6);
        //partnerContactInfos = partnerContact.GetPartnerContact();

        //GoverResource goverResource = new GoverResource();
        //GoverResourceInfo goverResourcetInfo = new GoverResourceInfo();
        //IList<GoverResourceInfo> goverResourceInfos;
        //goverResourcetInfo = goverResource.GetGoverResourceById(1);
        //int isInsert = goverResource.InsertGoverResource(goverResourcetInfo);
        //goverResourcetInfo.OrganName = "更新组织名称";
        //int isUpdate = goverResource.UpdeteGoverResource(goverResourcetInfo);
        //int isDelete = goverResource.DeleteGoverResource(2);
        //goverResourceInfos = goverResource.GetGoverResource();
          
       // GoverContact goverContact = new GoverContact();
       // GoverContactInfo goverContactInfo = new GoverContactInfo();
       // IList<GoverContactInfo> goverContactInfos ;
       // goverContactInfo = goverContact.GetGoverContactById(1);
       // int isInsert = goverContact.InsertGoverContact(goverContactInfo);
       // goverContactInfo.ContactID = 3;
       // int isUpdate = goverContact.UpdateGoverContact(goverContactInfo);
       //int isDelete = goverContact.DeleteGoverContact(1);
       // goverContactInfos = goverContact.GetGoverContact();

        //DocUserInfo docUserInfo = new DocUserInfo();
        //DocUser docUser = new DocUser();
        //docUserInfo = docUser.GetDocUserById(1);
        //int isDelete = docUser.DeleteDocUser(2);
        //docUserInfo.UserID = 2;
        //int isInsert = docUser.InsertDocUser(docUserInfo);
        //docUserInfo.DocID = 1;
        //int isUpdate = docUser.UpdateDocUser(docUserInfo);
        //IList<DocUserInfo> docUserInfos = docUser.GetDocUser();
        //docUserInfo = docUser.GetDocUserByDocUser(4, 1);

        //DepartDocCate departDocCate = new DepartDocCate();
        //DepartDocCateInfo departDocCateInfo = new DepartDocCateInfo();
        //departDocCateInfo = departDocCate.GetDepartDocCateById(2);
        //int isInsert = departDocCate.InsertDepartDocCate(departDocCateInfo);
        //departDocCate.InsertDepartDocCate(departDocCateInfo);
        //departDocCate.InsertDepartDocCate(departDocCateInfo);
        //IList<DepartDocCateInfo> departDocCateInfos =departDocCate.GetDepartDocCate();
        //departDocCateInfo.Visibility =2;
        //departDocCateInfo.CategoryName = "文档目录update";
        //int isUpdate = departDocCate.UpdateDepartDocCate(departDocCateInfo);
        //int isDelete = departDocCate.DeleteDepartDocCate(3);
        //departDocCateInfo = departDocCate.GetDepartDocCateByDepartCategory(2, "文档目录update");
     
        //Document document = new Document();
        //DocumentInfo documentInfo= document.GetDocumentById(1); 
        //int IsInsert = document.InsertDocument(documentInfo);
        //documentInfo.DocName = "文档update";
        //int isUpdate = document.UpdateDocument(documentInfo);
        // int IsDelete =  document.DeleteDocument(2);
        // int IsDelete =  document.DeleteDocumentByName("文档名称B");
        //DocumentInfo documentInfo = document.GetDocumentByName("文档名称B");
        //IList<DocumentInfo> documentInfos = document.GetDocument();   
        //Console.WriteLine(documentInfo.DocState);
        //Console.ReadLine();
    }
    #endregion
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "text/xml/rmvb";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.AppendHeader("Content-Disposition", "attachment;filename=exam.rmvb");
        string path = Server.MapPath("./");
        Response.WriteFile(path + "upload/b.rmvb");
        Response.End();
     
    }
<<<<<<< HEAD
>>>>>>> origin/MacGrady
=======
>>>>>>> origin/MacGrady
}
