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

public partial class web_ModifyDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string docID = Request.QueryString["DocID"];
            if (string.IsNullOrEmpty(docID))
            {
                return;
            }
            Document document = new Document();
            DocumentInfo documentInfo = document.GetDocumentById(Convert.ToInt32(docID));
            DocID.Text = docID;
            IntiDepartment();
            InitDocument(documentInfo);
            InitUsers(Convert.ToInt32(docID) ,1);
        }
    }

    private void IntiDepartment()
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
    }
    private void InitDocument(DocumentInfo documentInfo)
    {
        
        DocNameText.Text = documentInfo.DocName;
        DocVersionText.Text = documentInfo.DocVersion;
        DocDescription.Text = documentInfo.DocDescription;
        DocKeyText.Text = documentInfo.DocKey;
        DepartName.SelectedValue = Convert.ToString(documentInfo.DepartID);
        if (documentInfo.DepartID != 0)
        {
            BLL.DepartDocCate departDocCate = new BLL.DepartDocCate();
            IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(documentInfo.DepartID);
            for (int i = 0; i < departDocCateInfos.Count; ++i)
            {
                ListItem listItem = new ListItem();
                listItem.Value = Convert.ToString(departDocCateInfos[i].Id);
                listItem.Text = departDocCateInfos[i].CategoryName;
                DocCate.Items.Add(listItem);
            }
            DocCate.SelectedValue = Convert.ToString(documentInfo.DocCategoryID);
        }
        DocState.SelectedValue = documentInfo.DocState;
        DownLoadPremission.SelectedValue = Convert.ToString(documentInfo.DocPermission);
        uploadTime.Value = documentInfo.UploadTime;
    }

    private void InitUsers(int docID,int userID)
    {
        BLL.User user = new BLL.User();
        IList<UserInfo> userInfos = user.GetUsers();
        DocUser docUser = new DocUser();
        InitUploadUser(userInfos, userID);
        UserRepeater.DataSource = user.GetTableByUserList(userInfos);
        UserRepeater.DataBind();
        for (int i = 0; i < UserRepeater.Items.Count; ++i)
        {
            RepeaterItem RPItem = UserRepeater.Items[i];
            Label UID = RPItem.FindControl("UserIDLabel") as Label;
            DocUserInfo docUserInfo = docUser.GetDocUserByDocUser(Convert.ToInt32(UID.Text.Trim()), docID);
            if (docUserInfo.DocID == docID)
            {
                CheckBox CHB = RPItem.FindControl("ckb") as CheckBox;
                CHB.Checked = true;
            }
        }

    }
   private void  InitUploadUser(IList<UserInfo> userLists,int docID)
   {
       for (int i = 0; i < userLists.Count; ++i)
       {
           ListItem listItem = new ListItem();
           listItem.Value = Convert.ToString(userLists[i].UserID);
           listItem.Text = userLists[i].UserName;
           UploadUserList.Items.Add(listItem);
       }
       UploadUserList.SelectedValue = Convert.ToString(docID);
   }
    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        Document document = new Document();
        DocumentInfo documentInfo =document.GetDocumentById(Convert.ToInt32(DocID.Text));
        documentInfo.DocName = DocNameText.Text.Trim();
        documentInfo.DocDescription = DocDescription.Text.Trim();
        documentInfo.DocKey = DocKeyText.Text.Trim();
        documentInfo.DocVersion = DocVersionText.Text.Trim();
        documentInfo.DepartID = Convert.ToInt32(DepartName.SelectedValue);
        documentInfo.DocCategoryID = Convert.ToInt32(DocCate.SelectedValue);
        documentInfo.DocState = DocState.SelectedValue;
        documentInfo.UploadTime = uploadTime.Value;
        
        //BLL.User user =new BLL.User();
        //UserInfo userInfo = user.GetUserByName(UploadUserName.Text.Trim());
        //if (string.IsNullOrEmpty(userInfo.UserName))
        //{
        //    Response.Write("<script   language=javascript> window.alert( '  用户名不存在  '); </script>");
        //    return;
        //}
        documentInfo.UploadUserID = Convert.ToInt32(UploadUserList.SelectedValue);

        int oldDocPermission = documentInfo.DocPermission ;
        int newDocPermission =Convert.ToInt32(DownLoadPremission.SelectedValue);
        documentInfo.DocPermission = newDocPermission;
        
        int isUpdate = document.UpdateDocument(documentInfo);
        if (isUpdate ==1)
        {
            document.ChangePermission(documentInfo.DocID,oldDocPermission, newDocPermission, GetCheckedUserId());
            Response.Write("<script   language=javascript> window.alert( ' 保存成功  '); </script>");
        } 
        else
        {
            Response.Write("<script   language=javascript> window.alert( '保存失败  '); </script>");
        }

    }

    private IList<int> GetCheckedUserId()
    {
        IList<int> userIds = new List<int>();
        for (int i = 0; i < UserRepeater.Items.Count; ++i)
        {
            RepeaterItem RPItem = UserRepeater.Items[i];
            CheckBox CHB = RPItem.FindControl("ckb") as CheckBox;

            if (CHB.Checked)
            {
                Label UID = RPItem.FindControl("UserIDLabel") as Label;
                userIds.Add(Convert.ToInt32(UID.Text.Trim()));
            }
        }
        return userIds;
    }
}
