using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ISchedule
    {
        int InsertSchedule(ScheduleInfo scheduleInfo);
        int DeleteSchedule(int scheduleId);
        int UpdateSchedule(ScheduleInfo scheduleInfo);

        IList<ScheduleInfo> GetSchedulesDescending();
        IList<ScheduleInfo> GetSchedulesByUserIdDescending(int userId);
        IList<ScheduleInfo> GetSchedulesByDate(string date);
        ScheduleInfo GetScheduleById(int id);

    }
}
