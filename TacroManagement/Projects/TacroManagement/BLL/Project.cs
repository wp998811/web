using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Project
    {
        private static readonly IProject dal = DALFactory.DataAccess.CreateProject();

        #region
        public int InsertProject(ProjectInfo projectInfo)
        {
            return dal.InsertProject(projectInfo);
        }

        public int DeleteProject(string projectNum)
        {
            return dal.DeleteProject(projectNum);
        }

        public int UpdateProject(ProjectInfo projectInfo)
        {
            return dal.UpdateProject(projectInfo);
        }

        public IList<ProjectInfo> GetProjects()
        {
            return dal.GetProjects();
        }

        public ProjectInfo GetProjectByNum(string projectNum)
        {
            return dal.GetProjectByProjectNum(projectNum);
        }

        public IList<ProjectInfo> GetProjectByAdminID(int adminID)
        {
            return dal.GetProjectByAdminId(adminID);
        }

        public int GetProjectSpareTime(string projectNum)
        {
            return dal.GetProjectSpareTime(projectNum);
        }

        public int GetProjectTimeLength(string projectNum)
        {
            return dal.GetProjectTimeLength(projectNum);
        }
        #endregion

        //项目负责人修改项目信息
        public bool ModifyProject(string projectNum, string clientName, string projectType, string projectDescription, string startTime, string endTime)
        {
            if(string.IsNullOrEmpty(projectNum))
                return false;
            ProjectInfo projectInfo = dal.GetProjectByProjectNum(projectNum);
            if(projectInfo == null)
                return false;
            projectInfo.ProjectClientName = clientName;
            projectInfo.ProjectType = projectType;
            projectInfo.ProjectDescription = projectDescription;
            projectInfo.BeginTime = startTime;
            projectInfo.EndTime = endTime;
            if (dal.UpdateProject(projectInfo) == 1)
                return true;
            return false;
        }

        //判断项目是否为空
        public bool IsNullOrEmpty(ProjectInfo projectInfo)
        {
            if (null == projectInfo)
                return true;
            if ("0" == projectInfo.ProjectNum)
                return true;
            return false;
        }
    }
}
