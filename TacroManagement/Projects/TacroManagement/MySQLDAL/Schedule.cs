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
    public class Schedule : ISchedule
    {
        private const string PARM_ID = "@ID";
        private const string PARM_USERID = "@UserID";
        private const string PARM_SCHEDULE_CONTENT = "@ScheduleContent";
        private const string PARM_SCHEDULE_TIME = "@ScheduleTime";

        private const string SQL_INSERT_SCHEDULE = "insert into schedule(UserID, ScheduleContent, ScheduleTime) values(@UserID, @ScheduleContent, @ScheduleTime)";
        private const string SQL_DELETE_SCHEDULE = "delete from schedule where ID=@ID";
        private const string SQL_UPDATE_SCHEDULE = "update schedule set UserID=@UserID, ScheduleContent=@ScheduleContent, ScheduleTime=@ScheduleTime where ID=@ID";

        private const string SQL_SELECT_SCHEDULES = "select * from schedule ORDERED BY ScheduleTime DESC";
        private const string SQL_SELECT_SCHEDULES_BY_USERID = "select * from schedule where UserID=@UserID ORDERED BY ScheduleTime DESC";
        private const string SQL_SELECT_SCHEDULE_BY_ID = "select * from schedule where ID=@ID";
        private const string SQL_SELECT_SCHEDULE_BY_DATE = "select * from schedule where ScheduleTime=@ScheduleTime";
        #region ISchedule 成员

        public int InsertSchedule(ScheduleInfo scheduleInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_SCHEDULE_CONTENT, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_SCHEDULE_TIME, MySqlDbType.VarChar, 50)
                };
                if (scheduleInfo.UserId == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = scheduleInfo.UserId;   
                parms[1].Value = scheduleInfo.ScheduleContent;
                parms[2].Value = scheduleInfo.Time;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_SCHEDULE, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteSchedule(int scheduleId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = scheduleId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_SCHEDULE, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateSchedule(ScheduleInfo scheduleInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_SCHEDULE_CONTENT, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_SCHEDULE_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_ID, MySqlDbType.Int32)
                };
                if (scheduleInfo.UserId == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = scheduleInfo.UserId;  
                parms[1].Value = scheduleInfo.ScheduleContent;
                parms[2].Value = scheduleInfo.Time;
                parms[3].Value = scheduleInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_SCHEDULE, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ScheduleInfo> GetSchedulesDescending()
        {
            IList<ScheduleInfo> schedules = new List<ScheduleInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_SCHEDULES, null))
                {
                    while (rdr.Read())
                    {
                        ScheduleInfo schedule = new ScheduleInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                        schedules.Add(schedule);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return schedules;
        }

        public IList<ScheduleInfo> GetSchedulesByUserIdDescending(int userId)
        {
            IList<ScheduleInfo> schedules = new List<ScheduleInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32);
                parm.Value = userId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_SCHEDULES_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ScheduleInfo schedule = new ScheduleInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                        schedules.Add(schedule);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return schedules;
        }

        public IList<ScheduleInfo> GetSchedulesByDate(string date)
        {
            IList<ScheduleInfo> schedules = new List<ScheduleInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_SCHEDULE_TIME, MySqlDbType.VarChar, 50);
                parm.Value = date;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_SCHEDULE_BY_DATE, parm))
                {
                    while (rdr.Read())
                    {
                        ScheduleInfo schedule = new ScheduleInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                        schedules.Add(schedule);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return schedules;
        }

        public ScheduleInfo GetScheduleById(int id)
        {
            ScheduleInfo schedule = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_SCHEDULE_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        schedule = new ScheduleInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3));
                    }
                    else
                        schedule = new ScheduleInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return schedule;
        }

        #endregion
    }
}
