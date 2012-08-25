using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class SubTask
    {
        private static readonly ISubTask dal = DALFactory.DataAccess.CreateSubTask();

        #region
        public int InsertSubTask(SubTaskInfo subTaskInfo)
        {
            return dal.InsertSubTask(subTaskInfo);
        }

        public int DeleteSubTask(int taskId)
        {
            return dal.DeleteSubTask(taskId);
        }

        public int UpdateSubTask(SubTaskInfo subTaskInfo)
        {
            return dal.UpdateSubTask(subTaskInfo);
        }

        public IList<SubTaskInfo> GetSubTasks()
        {
            return dal.GetSubTasks();
        }

        public IList<SubTaskInfo> GetSubTasksByProjectNum(string projectNum)
        {
            return dal.GetSubTasksByProjectNum(projectNum);
        }

        public IList<SubTaskInfo> GetSubTasksByUserId(int userId)
        {
            return dal.GetSubTasksByUserId(userId);
        }

        public SubTaskInfo GetSubTaskById(int id)
        {
            return dal.GetSubTaskById(id);
        }
        #endregion
    }
}
