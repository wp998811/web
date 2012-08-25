using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ProjectDoc
    {
        private static readonly IProjectDoc dal = DALFactory.DataAccess.CreateProjectDoc();

        #region
        public int InsertProjectDoc(ProjectDocInfo projectDocInfo)
        {
            return dal.InsertProjectDoc(projectDocInfo);
        }

        public int DeleteProjectDoc(int projectDocId)
        {
            return dal.DeleteProjectDoc(projectDocId);
        }

        public int UpdateProjectDoc(ProjectDocInfo projectDocInfo)
        {
            return dal.UpdateProjectDoc(projectDocInfo);
        }

        public IList<ProjectDocInfo> GetProjectDocs()
        {
            return dal.GetProjectDocs();
        }

        public IList<ProjectDocInfo> GetProjectDocsByTaskId(int taskId)
        {
            return dal.GetProjectDocsByTaskId(taskId);
        }

        public IList<ProjectDocInfo> GetProjectDocsByUpLoadUserId(int userId)
        {
            return dal.GetProjectDocsByUpLoadUserId(userId);
        }

        public IList<ProjectDocInfo> GetProjectDocs(int projectDocCate, string projectDocName, string projectDocKey
            , int projectDocTaskId, int uploadUserId, string uploadTime)
        {
            return dal.GetProjectDocs(projectDocCate, projectDocName, projectDocKey, projectDocTaskId, uploadUserId, uploadTime);
        }

        public ProjectDocInfo GetProjectDocById(int id)
        {
            return dal.GetProjectDocById(id);
        }
        #endregion
    }
}
