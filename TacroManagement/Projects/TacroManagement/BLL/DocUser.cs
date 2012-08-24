using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;


namespace BLL
{
    public class DocUser:IDocUser
    {
        private static readonly IDocUser dal = DALFactory.DataAccess.CreateDocUser();

        /// <summary>
        /// 新增文档用户
        /// </summary>
        /// <param name="docUserInfo"></param>
        /// <returns></returns>
        public int InsertDocUser(DocUserInfo docUserInfo)
        {
            return dal.InsertDocUser(docUserInfo);
        }

        /// <summary>
        /// 删除文档用户
        /// </summary>
        /// <param name="docUserId"></param>
        /// <returns></returns>
        public int DeleteDocUser(int docUserId)
        {

            return dal.DeleteDocUser(docUserId);
        }

        /// <summary>
        /// 更新文档用户
        /// </summary>
        /// <param name="docUserInfo"></param>
        /// <returns></returns>

        public int UpdateDocUser(DocUserInfo docUserInfo)
        {
            return dal.UpdateDocUser(docUserInfo);
        }
    
    
        /// <summary>
        /// 查找所有文档用户
        /// </summary>
        /// <returns></returns>
       public  IList<DocUserInfo> GetDocUser()
        {
            return dal.GetDocUser();
        }

        /// <summary>
        /// 根据文档用户编号查找文档用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocUserInfo GetDocUserById(int id)
       {
           return dal.GetDocUserById(id);
       }

        /// <summary>
        /// 根据文档和用户查找文档用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="DocumentID"></param>
        /// <returns></returns>
      public DocUserInfo GetDocUserByDocUser(int userID, int DocumentID)
        {
            return dal.GetDocUserByDocUser(userID, DocumentID);
        }
    
    
    }
}
