using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;
namespace BLL
{
    public class Document
    {
        private static readonly IDocument dal = DALFactory.DataAccess.CreateDocument();

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
    }
}
