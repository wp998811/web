using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ProjectDocUser
    {
        private static readonly IProjectDocUser dal = DALFactory.DataAccess.CreateProjectDocUser();

        #region
        public int InsertProjDocUser(ProjDocUserInfo projDocUserInfo)
        {
            return dal.InsertProjectDocUser(projDocUserInfo);
        }

        public int DeleteProjDocUser(int id)
        {
            return dal.DeleteProjectDocUser(id);
        }

        public int DeleteProjectDocUserByDocId(int ProjDocId)
        {
            return dal.DeleteProjectDocUserByDocId(ProjDocId);

        }
        public int UpdateProjDocUser(ProjDocUserInfo projDocUserInfo)
        {
            return dal.UpdateProjectDocUser(projDocUserInfo);
        }

        public IList<ProjDocUserInfo> GetProjDocUsers()
        {
            return dal.GetProjectDocUsers();
        }

        public IList<ProjDocUserInfo> GetProjDocUserByDocId(int docId)
        {
            return dal.GetProjectDocUserByDocId(docId);
        }

        public IList<ProjDocUserInfo> GetProjDocUserByUserId(int userId)
        {
            return dal.GetProjectDocUserByUserId(userId);
        }

        public ProjDocUserInfo GetProjDocUserById(int id)
        {
            return dal.GetProjectDocUserById(id);
        }

         public ProjDocUserInfo GetProjectDocUserByProjectDocUser(int docID,int userID)
        {
            return dal.GetProjectDocUserByProjectDocUser(docID, userID);
        }
        #endregion
    }
}
