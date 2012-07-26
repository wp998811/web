using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IShedule
    {
        int InsertSchedule(ScheduleInfo scheduleInfo);
        int DeleteSchedule(int scheduleId);
        int UpdateSchedule(ScheduleInfo scheduleInfo);

        IList<ScheduleInfo> GetSchedulesDescending();
        IList<ScheduleInfo> GetSchedulesByUserIdDescending(int userId);
        IList<ScheduleInfo> GetSchedulesByDate(string date);
        ScheduleInfo GetScheduleByIdDescending(int id);

    }
}
