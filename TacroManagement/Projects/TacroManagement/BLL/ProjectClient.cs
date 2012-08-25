using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ProjectClient
    {
        private static readonly IProjectClient dal = DALFactory.DataAccess.CreateProjectClient();

        #region
        public int InsertProjectClient(ProjectClientInfo projectClientInfo)
        {
            return dal.InsertProjectClient(projectClientInfo);
        }

        public int DeleteProjectClient(int id)
        {
            return dal.DeleteProjectClient(id);
        }

        public int UpdateProjectClient(ProjectClientInfo projectClientInfo)
        {
            return dal.UpdateProjectClient(projectClientInfo);
        }

        public IList<ProjectClientInfo> GetProjectClients()
        {
            return dal.GetProjectClients();
        }

        public IList<ProjectClientInfo> GetProjectClientsByProjectNum(string projectNum)
        {
            return dal.GetProjectClientsByProjectNum(projectNum);
        }

        public IList<ProjectClientInfo> GetProjectClientsByClientId(int clientId)
        {
            return dal.GetProjectClientsByClientId(clientId);
        }

        public ProjectClientInfo GetProjectClientById(int id)
        {
            return dal.GetProjectClientById(id);
        }
        #endregion
    }
}
