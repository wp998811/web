using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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

        public ProjectDocInfo GetProjectDocByName(string docName)
        {
            return dal.GetProjectDocByName(docName);
        }

        public IList<ProjectDocInfo> GetProjectDocsByUpLoadUserId(int userId)
        {
            return dal.GetProjectDocsByUpLoadUserId(userId);
        }

        public IList<ProjectDocInfo> GetProjectDocs(string projectDocCate, string projectDocName, string projectDocKey
            , int projectDocTaskId, int uploadUserId, string uploadTime)
        {
            return dal.GetProjectDocs(projectDocCate, projectDocName, projectDocKey, projectDocTaskId, uploadUserId, uploadTime);
        }

        public ProjectDocInfo GetProjectDocById(int id)
        {
            return dal.GetProjectDocById(id);
        }
        #endregion

        public bool AddProjectDoc(string taskId, string projDocCate, string docName, string docKey, string docDescription, string uploadPath,string savePath, string docPermission, string uploadUserId)
        {
            ProjectDocInfo projectDocInfo = new ProjectDocInfo();
            projectDocInfo.ProjDocCate = projDocCate;
            projectDocInfo.DocName = docName;
            projectDocInfo.DocKey = docKey;
            projectDocInfo.DocDescription = docDescription;
            projectDocInfo.UploadPath = uploadPath;
            projectDocInfo.SavePath = savePath;
            projectDocInfo.UploadUserId = Convert.ToInt32(uploadUserId);

            if (!string.IsNullOrEmpty(docPermission))
            {
                int iDocPermission = Convert.ToInt32(docPermission);

                projectDocInfo.DocPermission = iDocPermission;

            }
            if (!string.IsNullOrEmpty(taskId))
            {
                int iTaskId = Convert.ToInt32(taskId);
                if (iTaskId != 0)
                {
                    projectDocInfo.TaskId = iTaskId;
                }
            }
            DateTime dateTime = DateTime.Now;
            projectDocInfo.UploadTime = dateTime.ToString();

            ProjectDoc projectDoc = new ProjectDoc();
            int isInsert = projectDoc.InsertProjectDoc(projectDocInfo);

            if (isInsert == 1)
            {
                return true;
            }

            return false;

        }


        public DataTable SearchProjectDoc(string searchCondition)
        {
            DataTable dataTable = new DataTable();
            DataColumn docIDColumn = new DataColumn("docID");
            DataColumn docNameColumn = new DataColumn("名称");
            DataColumn docCateColumn = new DataColumn("类别");
            DataColumn subTaskColumn = new DataColumn("项目子任务");
            DataColumn uploadColumn = new DataColumn("上传人");
            DataColumn uploadTimeColumn = new DataColumn("上传时间");

            dataTable.Columns.Add(docIDColumn);
            dataTable.Columns.Add(docNameColumn);
            dataTable.Columns.Add(docCateColumn);
            dataTable.Columns.Add(subTaskColumn);
            dataTable.Columns.Add(uploadColumn);
            dataTable.Columns.Add(uploadTimeColumn);

            IList<ProjectDocInfo> projectDocInfos = GetProjectDocBySearchCondition(searchCondition); //查询语句

            for (int i = 0; i < projectDocInfos.Count; ++i)
            {

                ProjectDocInfo projectDocInfo = projectDocInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["docID"] = projectDocInfo.ProjDocId;
                dataRow["名称"] = projectDocInfo.DocName;
                dataRow["类别"] = projectDocInfo.ProjDocCate;

                SubTask subTask = new SubTask();
                SubTaskInfo subTaskInfo = subTask.GetSubTaskById(projectDocInfo.TaskId);
                dataRow["项目子任务"] = subTaskInfo.TaskName;
                User user = new User();
                UserInfo userInfo = user.GetUserById(projectDocInfo.UploadUserId);
                dataRow["上传人"] = userInfo.UserName;
                dataRow["上传时间"] = projectDocInfo.UploadTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        public IList<ProjectDocInfo> GetProjectDocBySearchCondition(string selectCondition)
        {
           return dal.GetProjectDocBySearchCondition(selectCondition);
        }

        public string GetSearchCondition(string docName, string docKey, string subTaskID, string projDocCate, string uploadUserName, string updateTimeBegin, string updateTimeEnd)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(docName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " DocName LIKE '%" + docName + "%' ";
            }

            if (!string.IsNullOrEmpty(docKey))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " DocKey LIKE '%" + docKey + "%' ";
            }
            if (!string.IsNullOrEmpty(subTaskID))
            {
                int iSubTask = Convert.ToInt32(subTaskID);
                if (iSubTask != 0)
                {
                    if (condition != "")
                    {
                        condition += " AND ";
                    }
                    condition += " TaskID = '" + iSubTask + "' ";
                }
            }
            if (!string.IsNullOrEmpty(projDocCate))
            {
            
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " ProjDocCate = '" + projDocCate + "' ";

            }

            if (!string.IsNullOrEmpty(uploadUserName))
            {
                User user = new User();
                UserInfo userInfo = user.GetUserByName(uploadUserName);
                if (string.IsNullOrEmpty(userInfo.UserName))
                {
                    return "";
                }
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadUserID = '" + userInfo.UserID + "' ";
            }

            if (!string.IsNullOrEmpty(updateTimeBegin))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadTime >= '" + updateTimeBegin + "' ";
            }

            if (!string.IsNullOrEmpty(updateTimeEnd))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UploadTime <= '" + updateTimeEnd + "' ";
            }
            return condition;
        }

        public bool isPremissionToDownload(int downloadPremission, int docID, int userID)
        {
            if (downloadPremission == 1)
            {
                return true;
            }
            User user = new User();
            UserInfo userInfo = user.GetUserById(userID);
            ProjectDocInfo projectDocInfo = GetProjectDocById(docID);
           

            if (downloadPremission == 2)
            {
                SubTask subTask = new SubTask();
                SubTaskInfo subTaskInfo = subTask.GetSubTaskById(projectDocInfo.TaskId);
                ProjectUser projectUser = new ProjectUser();
                ProjectUserInfo projectUserInfo = projectUser.GetProjectUserByProjectUser(subTaskInfo.ProjectNum, userInfo.UserID);
                if (projectUserInfo.UserId == userInfo.UserID)
                {
                    return true;
                }
                return false;
            }
            else
            {
                ProjectDocUser projectDocUser = new ProjectDocUser();
                ProjDocUserInfo projDocUserInfo = projectDocUser.GetProjectDocUserByProjectDocUser(docID ,userInfo.UserID);
                if (projDocUserInfo.ProjDocId == docID)
                {
                    return true;
                }
                return false;
            }

        }

        public void ChangePermission(int projDocID, int oldPermission, int newPremission, IList<int> userIdList)
        {
            if (oldPermission != 3 && newPremission != 3)
            {
                return;
            }
            ProjectDocUser projectDocUer = new ProjectDocUser();
            if (oldPermission == 3)
            {
                projectDocUer.DeleteProjectDocUserByDocId(projDocID);
            }

            if (newPremission == 3)
            {
                for (int i = 0; i < userIdList.Count; ++i)
                {
                    ProjDocUserInfo projDocUserInfo = new ProjDocUserInfo(projDocID, Convert.ToString(userIdList[i]));
                    projectDocUer.InsertProjDocUser(projDocUserInfo);
                }
            }
        }

    }
}