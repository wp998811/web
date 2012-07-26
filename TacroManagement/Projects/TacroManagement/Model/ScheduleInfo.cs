using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class ScheduleInfo
    {
        private int id;
        private int userId;
        private string scheduleContent;
        private string time;

        public ScheduleInfo()
        {

        }

        public ScheduleInfo(int userId, string scheduleContent, string time)
        {
            this.userId = userId;
            this.scheduleContent = scheduleContent;
            this.time = time;
        }

        public ScheduleInfo(int id, int userId, string scheduleContent, string time)
        {
            this.id = id;
            this.userId = userId;
            this.scheduleContent = scheduleContent;
            this.time = time;
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string ScheduleContent
        {
            get { return scheduleContent; }
            set { scheduleContent = value; }
        }


        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
  

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
