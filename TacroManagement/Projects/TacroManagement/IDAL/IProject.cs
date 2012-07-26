using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IProject
    {
        //新增项目
        int InsertProject(ProjectInfo projectInfo);
        //删除项目
        int DeleteProject(int projectId);
        //更新项目信息
        int UpdateProject(ProjectInfo projectInfo);

        //获得所有的项目
        IList<ProjectInfo> GetProjects();
        //通过名字获得project
        ProjectInfo GetProjectByName(string name);
        //通过id获得project
        ProjectInfo GetProjectById(int id);
    }
}
