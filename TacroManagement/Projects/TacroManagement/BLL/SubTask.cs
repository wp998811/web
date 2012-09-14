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

        //获得该用户所负责的子任务中设置了自动提醒功能的未完成的子任务
        //count为前几项，为0表示所有
        public IList<SubTaskInfo> GetSubTasksDescIsRemind(int userID, int count)
        {
            IList<SubTaskInfo> tasks = GetSubTasksByUserId(userID);
            IList<SubTaskInfo> taskUser = new List<SubTaskInfo>();
            FormatString formatString = new FormatString();
            foreach(SubTaskInfo subTaskInfo in tasks)
            {
                int t = formatString.FormatDate(subTaskInfo.RemindTime).CompareTo(formatString.FormatDate(DateTime.Now.Date.ToString()));

                if (subTaskInfo.IsRemind == 1 && t >= 0)
                {
                    if (subTaskInfo.TaskState != "已完成" && subTaskInfo.TaskState != "已取消")
                    {
                        taskUser.Add(subTaskInfo);
                    }
                    if (count != 0)
                    {
                        if (taskUser.Count == count)
                            break;
                    }
                }
                
            }
            return taskUser;          
        }

        //获得该用户待办事宜今天到期的所以子任务
        public IList<SubTaskInfo> GetSubTasksIsRemindNow(int userID)
        {
            IList<SubTaskInfo> lists = GetSubTasksDescIsRemind(userID, 0);
            IList<SubTaskInfo> result = new List<SubTaskInfo>();
            FormatString formatString = new FormatString();
            foreach(SubTaskInfo subTaskInfo in lists)
            {
                int t = formatString.FormatDate(subTaskInfo.RemindTime).CompareTo(formatString.FormatDate(DateTime.Now.Date.ToString()));
                if(t > 0)
                    break;
                result.Add(subTaskInfo);
            }
            return result;
        }
    }
}
