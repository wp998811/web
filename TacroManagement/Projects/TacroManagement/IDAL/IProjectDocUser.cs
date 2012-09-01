using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IProjectDocUser
    {
        int InsertProjectDocUser(ProjDocUserInfo projectDocInfo);
        int DeleteProjectDocUser(int id);
        int UpdateProjectDocUser(ProjDocUserInfo projectDocInfo);

        ProjDocUserInfo GetProjectDocUserById(int id);
        IList<ProjDocUserInfo> GetProjectDocUsers();
        IList<ProjDocUserInfo> GetProjectDocUserByDocId(int docId);
        IList<ProjDocUserInfo> GetProjectDocUserByUserId(int userId);
    }
}
