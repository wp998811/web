using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IDocUser
    {
        int InsertDocUser( DocUserInfo docUserInfo);      //新增文档用户
        int DeleteDocUser(int docUserId);                         //删除文档用户
        int DeleteDocUserByDocId(int docId);                   //通过文档ID删除文档用户
        int UpdateDocUser(DocUserInfo docUserInfo);     //更新文档用户

        IList<DocUserInfo> GetDocUser();                      //查找所以文档用户
        DocUserInfo GetDocUserById(int id);                   //通过Id查找文档用户
        IList<DocUserInfo> GetDocUserByDocId(int docId);        //通过文档ID查找文档用户
        DocUserInfo GetDocUserByDocUser(int userID, int DocumentID);  //通过用户ID和文档ID查找文档用户
    }
}
