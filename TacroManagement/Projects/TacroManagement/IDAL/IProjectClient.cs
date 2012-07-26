using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IProjectClient
    {
        int InsertProjectClient(ProjectClientInfo projectClientInfo);
        int DeleteProjectClient(int id);
        int UpdateProjectClient(ProjectClientInfo projectClientInfo);

        IList<ProjectClientInfo> GetProjectClients();
        ProjectClientInfo GetProjectClientById(int id);
        IList<ProjectClientInfo> GetProjectClientsByProjectNum(string projectNum);
        IList<ProjectClientInfo> GetProjectClientsByClientId(int clientId);
    }
}
