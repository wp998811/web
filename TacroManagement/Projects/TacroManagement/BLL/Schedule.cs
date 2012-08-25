using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Schedule
    {
        private static readonly ISchedule dal = DALFactory.DataAccess.CreateSchedule();

        #region
        public int InsertSchedule(ScheduleInfo scheduleInfo)
        {
            return dal.InsertSchedule(scheduleInfo);
        }

        public int DeleteSchedule(int scheduleId)
        {
            return dal.DeleteSchedule(scheduleId);
        }

        public int UpdateSchedule(ScheduleInfo scheduleInfo)
        {
            return dal.UpdateSchedule(scheduleInfo);
        }

        public IList<ScheduleInfo> GetSchedulesDes()
        {
            return dal.GetSchedulesDescending();
        }

        public IList<ScheduleInfo> GetSchedulesByUserIdDes(int userId)
        {
            return dal.GetSchedulesByUserIdDescending(userId);
        }

        public IList<ScheduleInfo> GetSchedulesByDate(string date)
        {
            return dal.GetSchedulesByDate(date);
        }

        public ScheduleInfo GetScheduleById(int id)
        {
            return dal.GetScheduleById(id);
        }
        #endregion
    }
}
