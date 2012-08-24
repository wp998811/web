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
#endregion  

        /// <summary>
        /// 根据查询条件查询文档
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        public DataTable SearchDocument(string searchCondition)
        {
            DataTable dataTable = new DataTable();
            DataColumn docNameColumn = new DataColumn("文档名称");
            DataColumn docVersionColumn = new DataColumn("文档版本");
            DataColumn docCateColumn = new DataColumn("文档类别");
            DataColumn departColumn = new DataColumn("文档所属部门");
            DataColumn uploadColumn = new DataColumn("上传人");
            DataColumn uploadTimeColumn = new DataColumn("上传时间");

            dataTable.Columns.Add(docNameColumn);
            dataTable.Columns.Add(docVersionColumn);
            dataTable.Columns.Add(docCateColumn);
            dataTable.Columns.Add(departColumn);
            dataTable.Columns.Add(uploadColumn);
            dataTable.Columns.Add(uploadTimeColumn);

            IList<DocumentInfo> documentInfos = GetDocumentBySearchCondition(searchCondition); //查询语句

            for (int i = 0; i < documentInfos.Count; ++i)
            {
                DocumentInfo documentInfo = documentInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["文档名称"] = documentInfo.DocName;
                dataRow["文档版本"] = documentInfo.DocVersion;
                DepartDocCate departDocCate = new DepartDocCate();
                DepartDocCateInfo departDocCateInfo =departDocCate.GetDepartDocCateById(documentInfo.DocCategoryID);
                dataRow["文档类别"] = departDocCateInfo.CategoryName;
                dataRow["文档所属部门"] = departDocCateInfo.DepartID;
                User user = new User();
                UserInfo userInfo = user.GetUserById(documentInfo.UploadUserID);
                dataRow["上传人"] = userInfo.UserName;
                dataRow["上传时间"] = documentInfo.UploadTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public string GetSearchCondition(string docName, string docVersion, string docKey, string DepertName, string docCategoryName, string uploadUserName, string updateTimeBegin, string updateTimeEnd)
        {
            string condition ="";
            if (!string.IsNullOrEmpty(docName))
            {
                if (condition != "")
                {
                    condition  +=" AND ";
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

            if (!string.IsNullOrEmpty(DepertName))
            {
                //Department department = new Department();
                //DepartmentInfo departmentInfo = department.GetDepartmentByName(DepertName);
                //if (string.IsNullOrEmpty(departmentInfo.DepartmentID))
                //{
                //    return "";
                //}
                //if (condition != "")
                //{
                //    condition += " AND ";
                //}
                //condition += " DepartID = '" + departmentInfo.DepartmentID + "' ";
            }

            if (!string.IsNullOrEmpty(docCategoryName) && string.IsNullOrEmpty(DepertName))
            {
                //DepartDocCate departDocCate = new DepartDocCate();
               // DepartDocCateInfo departDocCateInfo = departDocCate.GetDepartDocCateByDepartCategory();              
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

        public bool AddDocument(string docName, string docVersion, string docKey, string docDescription,string DepertName,string docCategoryName, string docState, int docPermission,int userId)
        {
            DocumentInfo documentInfo = new DocumentInfo();
            documentInfo.DocName = docName;
            documentInfo.DocVersion = docVersion;
            documentInfo.DocKey = docKey;
            documentInfo.DocDescription = docDescription;          
            documentInfo.DocState = docState;
            documentInfo.DocUrl = "Documents/" + docName;
            documentInfo.DocPermimission = docPermission;
            documentInfo.UploadUserID = userId;

            DateTime dateTime = DateTime.Now;
            documentInfo.UploadTime = dateTime.ToString();
           
            //if (!string.IsNullOrEmpty(DepertName))
            //{
            //    Department department = new Department();
            //    DepartmentInfo departmentInfo= department.GetDepartmentByDepartName(DepertName);
            //    if (string.IsNullOrEmpty(departmentInfo.DepartName))
            //    {//部门不存在
            //        return false;
            //    }
            //    documentInfo.DepartID = departmentInfo.DepartID;
            //    if (!string.IsNullOrEmpty(docCategoryName))
            //    {
            //        DepartDocCate departDocCate = new DepartDocCate();
            //        DepartDocCateInfo departDocCateInfo= departDocCate.GetDepartDocCateByDepartCategory(departmentInfo.DepartID,docCategoryName);
            //        if (!string.IsNullOrEmpty(departDocCateInfo.CategoryName))
            //        {
            //            //部门文档类型存在
            //            documentInfo.DocCategoryID = departDocCateInfo.Id;
            //        }
            //    }

            //}

            int reslut =InsertDocument(documentInfo);
            if (reslut ==1)
            {
                return true;
            }
            return false;
        }
    }
}
