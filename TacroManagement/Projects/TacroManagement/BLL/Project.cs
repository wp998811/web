using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;
using System.Data;


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

        /// <summary>
        /// 查询所有项目信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllProjects()
        {
            DataTable dataTable = new DataTable();
            DataColumn projectNameColumn = new DataColumn("项目名称");
            DataColumn projectManagerColumn = new DataColumn("项目负责人");
 //        DataColumn projectdescColumn = new DataColumn("项目描述");
            DataColumn projectTypeColumn = new DataColumn("项目类别");
            DataColumn clientNameColumn = new DataColumn("客户名称");
            DataColumn beginTimeColumn = new DataColumn("开始时间");
            DataColumn endTimeColumn = new DataColumn("结束时间");

            dataTable.Columns.Add(projectNameColumn);
            dataTable.Columns.Add(projectManagerColumn);
            dataTable.Columns.Add(projectTypeColumn);
            dataTable.Columns.Add(clientNameColumn);
            dataTable.Columns.Add(beginTimeColumn);
            dataTable.Columns.Add(endTimeColumn);

            IList<ProjectInfo> projectInfos = GetProjects(); //查询语句
            User user = new User();

            for (int i = 0; i < projectInfos.Count; ++i)
            {
                ProjectInfo projectInfo = projectInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["项目名称"] = projectInfo.ProjectName;
                UserInfo userInfo = user.GetUserById(projectInfo.ProjectAdminID);
                dataRow["项目负责人"] = userInfo.UserName;
                dataRow["项目类别"] = projectInfo.ProjectType;
                dataRow["客户名称"] = projectInfo.ProjectClientName;
                dataRow["开始时间"] = projectInfo.BeginTime;
                dataRow["结束时间"] = projectInfo.EndTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        #region ZeroV
        /// <summary>
        /// 判断项目代号是否存在
        /// </summary>
        /// <param name="projectNum"></param>
        /// <returns></returns>
        public bool IsProjectExists(string projectNum)
        {
            ProjectInfo projectInfo = GetProjectByNum(projectNum);
            if (!string.IsNullOrEmpty(projectInfo.ProjectNum))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 新建项目
        /// </summary>
        /// <param name="projectNum"></param>
        /// <param name="projectName"></param>
        /// <param name="projectAdminID"></param>
        /// <param name="projectDes"></param>
        /// <param name="projectType"></param>
        /// <param name="projectClient"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool AddProject(string projectNum,string projectName,int projectAdminID,string projectDes,string projectType,string projectClient,string beginTime,string endTime)
        {
            if (string.IsNullOrEmpty(projectNum)||string.IsNullOrEmpty(projectName))
            {
                return false;
            }
            if (projectAdminID < 1)
            {
                return false;
            }
            if (dal.InsertProject(new ProjectInfo(projectNum, projectName, projectAdminID, projectDes, projectType, projectClient, beginTime, endTime)) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="projectNum"></param>
        /// <param name="projectName"></param>
        /// <param name="projectAdminID"></param>
        /// <param name="projectDes"></param>
        /// <param name="projectType"></param>
        /// <param name="projectClient"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool ModifyProject(string projectNum, int projectAdminID, string projectDes, string projectType, string projectClient, string beginTime, string endTime)
        {
            if (string.IsNullOrEmpty(projectNum))
            {
                return false;
            }
            if (projectAdminID < 1)
            {
                return false;
            }
            ProjectInfo projectInfo = dal.GetProjectByProjectNum(projectNum);
            projectInfo.ProjectAdminID = projectAdminID;
            projectInfo.ProjectDescription = projectDes;
            projectInfo.ProjectType = projectType;
            projectInfo.ProjectClientName = projectClient;
            projectInfo.BeginTime = beginTime;
            projectInfo.EndTime = endTime;

            if (1==dal.UpdateProject(projectInfo))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
