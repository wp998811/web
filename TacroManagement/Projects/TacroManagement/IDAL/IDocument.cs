using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IDocument
    {

        int InsertDocument(DocumentInfo documentInfo);               //新增文档
        int DeleteDocument(int documentId);                                   //删除文档
        int UpdateDocument(DocumentInfo documentInfo);            //更新文档

        IList<DocumentInfo> GetDocument();                                         //查找所以文档
        DocumentInfo GetDocumentByName(string docName);              //通过文档名称删除文档
        DocumentInfo GetDocumentById(int docId);                               //通过文档ID查找文档

        int DeleteDocumentByName(string docName);                            //通过文档名称删除文档
        IList<DocumentInfo> GetDocumentBySearchCondition(string docName, 
                                                                                            string docVersion, 
                                                                                            string docKey,
                                                                                            int DepertId, 
                                                                                            int docCategoryID,
                                                                                            int uploadUserID,
                                                                                            string updateTimeBegin, 
                                                                                            string updateTimeEnd);//通过查询条件查找文档

       
     

    }
}
