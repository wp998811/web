using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IProjectUser
    {
        int InsertProjectUser(ProjectUserInfo projectUserInfo);
        int DeleteProjectUser(int Id);
        int UpdateProjectUser(ProjectUserInfo projectUserInfo);

        IList<ProjectUserInfo> GetProjectUsers();
        IList<ProjectUserInfo> GetProjectUsersByProjectNum(string projectNum);
        IList<ProjectUserInfo> GetProjectUsersByUserId(int userId);
        ProjectUserInfo GetProjectUserById(int id);
        ProjectUserInfo GetProjectUserByProjectUser(string projectNum, int userId);
    }
}
