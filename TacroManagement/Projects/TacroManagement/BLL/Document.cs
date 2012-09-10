using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Model;
using IDAL;
using DALFactory;
namespace BLL
{
    public class Document
    {
        private static readonly IDocument dal = DALFactory.DataAccess.CreateDocument();

        #region
        /// <summary>
        /// 新增文档
        /// </summary>
        /// <param name="documentInfo"></param>
        /// <returns></returns>
        public int InsertDocument(DocumentInfo documentInfo)
        {
            return dal.InsertDocument(documentInfo);
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public int DeleteDocument(int documentId)
        {
            return dal.DeleteDocument(documentId);
        }

        /// <summary>
        /// 根据文档名称删除用户
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        public int DeleteDocumentByName(string documentName)
        {
            return dal.DeleteDocumentByName(documentName);
        }

        /// <summary>
        /// 更新文档
        /// </summary>
        /// <param name="documentInfo"></param>
        /// <returns></returns>
        public int UpdateDocument(DocumentInfo documentInfo)
        {
            return dal.UpdateDocument(documentInfo);
        }

        public DocumentInfo GetDocumentById(int id)
        {
            return dal.GetDocumentById(id);
        }

        /// <summary>
        /// 查找所有文档
        /// </summary>
        /// <returns></returns>
        public IList<DocumentInfo> GetDocument()
        {
            return dal.GetDocument();
        }

        /// <summary>
        /// 根据文档名查找文档
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        public DocumentInfo GetDocumentByName(string docName)
        {
            return dal.GetDocumentByName(docName);
        }

        /// <summary>
        /// 根据查询条件查询文档
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        public IList<DocumentInfo> GetDocumentBySearchCondition(string selectCondition)
        {
            return dal.GetDocumentBySearchCondition(selectCondition);
        }

       public  IList<DocumentInfo> GetDocumentByLatelyTime(string latelyTime)
        {
            return dal.GetDocumentByLatelyTime(latelyTime);
        }
#endregion  

        /// <summary>
        /// 根据查询条件查询文档
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        public DataTable GetDataTableByDocumentList(IList<DocumentInfo> documentInfos)
        {

            DataTable dataTable = new DataTable();
            DataColumn docIDColumn = new DataColumn("docID");
            DataColumn docNameColumn = new DataColumn("名称");
            DataColumn docVersionColumn = new DataColumn("版本");
            DataColumn docCateColumn = new DataColumn("类别");
            DataColumn departColumn = new DataColumn("所属部门");
            DataColumn uploadColumn = new DataColumn("上传人");
            DataColumn uploadTimeColumn = new DataColumn("上传时间");

            dataTable.Columns.Add(docIDColumn);
            dataTable.Columns.Add(docNameColumn);
            dataTable.Columns.Add(docVersionColumn);
            dataTable.Columns.Add(docCateColumn);
            dataTable.Columns.Add(departColumn);
            dataTable.Columns.Add(uploadColumn);
            dataTable.Columns.Add(uploadTimeColumn);

            for (int i = 0; i < documentInfos.Count; ++i)
            {
                DocumentInfo documentInfo = documentInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["docID"] = documentInfo.DocID;
                dataRow["名称"] = documentInfo.DocName;
                dataRow["版本"] = documentInfo.DocVersion;
                DepartDocCate departDocCate = new DepartDocCate();
                DepartDocCateInfo departDocCateInfo = departDocCate.GetDepartDocCateById(documentInfo.DocCategoryID);
                dataRow["类别"] = departDocCateInfo.CategoryName;

                Department department = new Department();
                DepartmentInfo departmentInfo = department.GetDepartmentByID(departDocCateInfo.DepartID);
                dataRow["所属部门"] = departmentInfo.DepartName;

                User user = new User();
                UserInfo userInfo = user.GetUserById(documentInfo.UploadUserID);
                dataRow["上传人"] = userInfo.UserName;
                dataRow["上传时间"] = documentInfo.UploadTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public string GetSearchCondition(string docName, string docVersion, string docKey, string DepertID, string docCategoryID, string uploadUserName, string updateTimeBegin, string updateTimeEnd)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(docName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " DocName LIKE '%" + docName + "%' ";
            }

            if (!string.IsNullOrEmpty(docVersion))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " DocVersion LIKE '%" + docVersion + "%' ";
            }

            if (!string.IsNullOrEmpty(docKey))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " DocKey LIKE '%" + docKey + "%' ";
            }

             if (!string.IsNullOrEmpty(DepertID))
            {
                int iDepartID = Convert.ToInt32(DepertID);
                if (iDepartID != 0)
                {
                   
                    if (condition != "")
                    {
                        condition += " AND ";
                    }
                    condition += " DepartID = '" + iDepartID + "' ";

                    if (!string.IsNullOrEmpty(docCategoryID))
                    {
                        int iDocCate = Convert.ToInt32(docCategoryID);
                        if (iDocCate !=0)
                        {
                            if (condition != "")
                            {
                                condition += " AND ";
                            }
                            condition += " DocCategryID = '" + iDocCate + "' ";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(uploadUserName))
            {
                User user = new User();
                UserInfo userInfo = user.GetUserByName(uploadUserName);
                if (string.IsNullOrEmpty(userInfo.UserName))
                {
                    return "";
                }
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadUserID = '" + userInfo.UserID + "' ";
            }

            if (!string.IsNullOrEmpty(updateTimeBegin))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadTime >= '" + updateTimeBegin + "' ";
            }

            if (!string.IsNullOrEmpty(updateTimeEnd))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadTime <= '" + updateTimeEnd + "' ";
            }
            return condition;
        }

        public bool AddDocument(string docName, string docVersion, string docKey, string docDescription,string DepertID,string docCategoryID, string docState, string uploadPath,string savePath,string docPermission,string userId)
        {
            DocumentInfo documentInfo = new DocumentInfo();
            documentInfo.DocName = docName;
            documentInfo.DocVersion = docVersion;
            documentInfo.DocKey = docKey;
            documentInfo.DocDescription = docDescription;
            documentInfo.DocState = docState;
            documentInfo.UploadPath =  uploadPath;
            documentInfo.SavePath = savePath;
            documentInfo.UploadUserID = Convert.ToInt32(userId);

            //处理
            documentInfo.DocPermission = Convert.ToInt32(docPermission);

            DateTime dateTime = DateTime.Now;
            documentInfo.UploadTime = dateTime.ToString();
           

            if (!string.IsNullOrEmpty(DepertID))
            {
                int iDepartID = Convert.ToInt32(DepertID);
                if (iDepartID != 0)
                {
                    documentInfo.DepartID = iDepartID;

                    if (!string.IsNullOrEmpty(docCategoryID))
                    {
                        int iDocCate = Convert.ToInt32(docCategoryID);
                        if (iDocCate !=0)
                        {
                            documentInfo.DocCategoryID =iDocCate;
                        }
                    }
                }
            }


            int reslut = InsertDocument(documentInfo);
            if (reslut == 1)
            {
                return true;
            }
            return false;
        }

        public bool isPremissionToDownload(int downloadPremission, int docID, int userID)
        {
            if (downloadPremission ==1)
            {
                return true;
            }
            User user = new User(); 
            UserInfo userInfo = user.GetUserById(userID);
            DocumentInfo documentInfo = GetDocumentById(docID);
            if (downloadPremission ==2)
            {
                if (userInfo.DepartID == documentInfo.DepartID)
                {
                    return true;
                }
                return false;    
            }
            else
            {
                DocUser docUser = new DocUser();
                DocUserInfo docUserInfo=docUser.GetDocUserByDocUser(userInfo.UserID,documentInfo.DocID);
                if (docUserInfo.DocID == docID)
                {
                    return true;
                }
                return false;
            }

        }

        public void ChangePermission(int docID, int oldPermission , int newPremission, IList<int> userIdList)
        {
            if (oldPermission != 3 && newPremission !=3)
            {
                return;
            }
            DocUser docUer=new DocUser();
            if (oldPermission == 3)
            {
                docUer.DeleteDocUserByDocId(docID);
            }

            if (newPremission ==3)
            {
                for (int i=0;i<userIdList.Count;++i)
                {
                    DocUserInfo docUserInfo=new DocUserInfo(docID,userIdList[i]);
                    docUer.InsertDocUser(docUserInfo);
                }  
            }
        }

        public IList<DocumentInfo> GetDocumentLately()
        {
            string dateTime = DateTime.Today.AddDays(-7).ToString("yyyy-mm-dd");
            return GetDocumentByLatelyTime(dateTime);
        }
    }
}
