using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using DBUtility;
using System.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace MySQLDAL
{
    public class SubTask : ISubTask
    {
        private const string PARM_TASKID = "@TaskID";
        private const string PARM_PROJECT_NUM = "@ProjectNum";
        private const string PARM_TASK_NAME = "@TaskName";
        private const string PARM_PERIOD = "@Period";
        private const string PARM_START_TIME = "@StartTime";
        private const string PARM_END_TIME = "@EndTime";
        private const string PARM_PRODUCT = "@Product";
        private const string PARM_FORE_TASK = "@ForeTask";
        private const string PARM_RESOURCE = "@Resource";
        private const string PARM_USERID = "@UserID";
        private const string PARM_TASK_STATE = "@TaskState";
        private const string PARM_IS_REMIND = "@IsRemind";
        private const string PARM_REMIND_TIME = "@RemindTime";

        private const string SQL_INSERT_SUBTASK = "insert into subtask(ProjectNum, TaskName, Period, StartTime, EndTime, Product, ForeTask, Resource, UserID, TaskState, IsRemind, RemindTime) values(@ProjectNum, @TaskName, @Period, @StartTime, @EndTime, @Product, @ForeTask, @Resource, @UserID, @TaskState, @IsRemind, @RemindTime)";
        private const string SQL_DELETE_SUBTASK = "delete from subtask where TaskID=@TaskID";
        private const string SQL_UPDATE_SUBTASK = "update subtask set ProjectNum=@ProjectNum, TaskName=@TaskName, Period=@Period, StartTime=@StartTime, EndTime=@EndTime, Product=@Product, ForeTask=@ForeTask, Resource=@Resource, UserID=@UserID, TaskState=@TaskState, IsRemind=@IsRemind, RemindTime=@RemindTime where TaskID=@TaskID";
        private const string SQL_GET_SUBTASKS = "select * from subtask";
        private const string SQL_GET_SUBTASK_BY_ID = "select * from subtask where TaskID=@TaskID";
        private const string SQL_GET_SUBTASKS_BY_PROJECT_NUM = "select * from subtask where ProjectNum=@ProjectNum";
        private const string SQL_GET_SUBTASKS_BY_USERID = "select * from subtask where UserID=@UserID";

        #region ISubTask 成员

        public int InsertSubTask(SubTaskInfo subTaskInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_TASK_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PERIOD, MySqlDbType.Int32),
                    new MySqlParameter(PARM_START_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_END_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PRODUCT, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_FORE_TASK, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_RESOURCE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_TASK_STATE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_IS_REMIND, MySqlDbType.Int32),
                    new MySqlParameter(PARM_REMIND_TIME, MySqlDbType.VarChar, 50)
                };

                if (subTaskInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = subTaskInfo.ProjectNum;

                parms[1].Value = subTaskInfo.TaskName;
                parms[2].Value = subTaskInfo.Period;
                parms[3].Value = subTaskInfo.StartTime;
                parms[4].Value = subTaskInfo.EndTime;
                parms[5].Value = subTaskInfo.Product;
                parms[6].Value = subTaskInfo.ForeTask;
                parms[7].Value = subTaskInfo.Resource;
                if (subTaskInfo.UserId == 0)
                    parms[8].Value = DBNull.Value;
                else
                    parms[8].Value = subTaskInfo.UserId;
                parms[9].Value = subTaskInfo.TaskState;
                parms[10].Value = subTaskInfo.IsRemind;
                parms[11].Value = subTaskInfo.RemindTime;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_SUBTASK, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteSubTask(int taskId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_TASKID, MySqlDbType.Int32);
                parm.Value = taskId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_SUBTASK, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateSubTask(SubTaskInfo subTaskInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_TASK_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PERIOD, MySqlDbType.Int32),
                    new MySqlParameter(PARM_START_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_END_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PRODUCT, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_FORE_TASK, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_RESOURCE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_TASK_STATE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_IS_REMIND, MySqlDbType.Int32),
                    new MySqlParameter(PARM_REMIND_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_TASKID, MySqlDbType.Int32)
                };

                if (subTaskInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = subTaskInfo.ProjectNum;
                parms[1].Value = subTaskInfo.TaskName;
                parms[2].Value = subTaskInfo.Period;
                parms[3].Value = subTaskInfo.StartTime;
                parms[4].Value = subTaskInfo.EndTime;
                parms[5].Value = subTaskInfo.Product;
                parms[6].Value = subTaskInfo.ForeTask;
                parms[7].Value = subTaskInfo.Resource;
                if (subTaskInfo.UserId == 0)
                    parms[8].Value = DBNull.Value;
                else
                    parms[8].Value = subTaskInfo.UserId;
                parms[9].Value = subTaskInfo.TaskState;
                parms[10].Value = subTaskInfo.IsRemind;
                parms[11].Value = subTaskInfo.RemindTime;
                parms[12].Value = subTaskInfo.TaskId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_SUBTASK, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<SubTaskInfo> GetSubTasks()
        {
            throw new NotImplementedException();
        }

        public SubTaskInfo GetSubTaskById(int taskId)
        {
            SubTaskInfo subTask = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_TASKID, MySqlDbType.Int32);
                parm.Value = taskId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_GET_SUBTASK_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        subTask = new SubTaskInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9), rdr.GetString(10), rdr.GetInt32(11), rdr.GetString(12));
                    }
                    else
                        subTask = new SubTaskInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return subTask;
        }

        public IList<SubTaskInfo> GetSubTasksByProjectNum(string projectNum)
        {
            IList<SubTaskInfo> subTasks = new List<SubTaskInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_GET_SUBTASKS_BY_PROJECT_NUM, parm))
                {
                    while (rdr.Read())
                    {
                        SubTaskInfo subTask = new SubTaskInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9), rdr.GetString(10), rdr.GetInt32(11), rdr.GetString(12));
                        subTasks.Add(subTask);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return subTasks;
        }

        public IList<SubTaskInfo> GetSubTasksByUserId(int userId)
        {
            IList<SubTaskInfo> subTasks = new List<SubTaskInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32);
                parm.Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_GET_SUBTASKS_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        SubTaskInfo subTask = new SubTaskInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9), rdr.GetString(10), rdr.GetInt32(11), rdr.GetString(12));
                        subTasks.Add(subTask);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return subTasks;
        }

        #endregion
    }
}