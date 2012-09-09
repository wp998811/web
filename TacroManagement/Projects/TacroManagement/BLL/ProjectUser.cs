using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ProjectUser
    {
        private static readonly IProjectUser dal = DALFactory.DataAccess.CreateProjectUser();

        #region 
        public int InsertProjectUser(ProjectUserInfo projectUserInfo)
        {
            return dal.InsertProjectUser(projectUserInfo);
        }

        public int DeleteProjectUser(int id)
        {
            return dal.DeleteProjectUser(id);
        }

        public int UpdateProjectUser(ProjectUserInfo projectUserInfo)
        {
            return dal.UpdateProjectUser(projectUserInfo);
        }

        public IList<ProjectUserInfo> GetProjectUsers()
        {
            return dal.GetProjectUsers();
        }

        public IList<ProjectUserInfo> GetProjectUsersByProjectNum(string projectNum)
        {
            return dal.GetProjectUsersByProjectNum(projectNum);
        }

        public IList<ProjectUserInfo> GetProjectUsersByUserId(int userId)
        {
            return dal.GetProjectUsersByUserId(userId);
        }

        public ProjectUserInfo GetProjectUserById(int id)
        {
            return dal.GetProjectUserById(id);
        }
         public ProjectUserInfo GetProjectUserByProjectUser(string projectNum,int userId)
        {
            return dal.GetProjectUserByProjectUser(projectNum, userId);
        }
        #endregion
    }
}
