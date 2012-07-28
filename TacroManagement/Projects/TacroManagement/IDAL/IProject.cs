using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IProject
    {
        //新增项目
        int InsertProject(ProjectInfo projectInfo);
        //删除项目
        int DeleteProject(string projectNum);
        //更新项目信息
        int UpdateProject(ProjectInfo projectInfo);

        //获得所有的项目
        IList<ProjectInfo> GetProjects();
        //通过名字获得project
        ProjectInfo GetProjectByProjectNum(string projectNums);
        //通过id获得project
        IList<ProjectInfo> GetProjectByAdminId(int adminId);
    }
}
