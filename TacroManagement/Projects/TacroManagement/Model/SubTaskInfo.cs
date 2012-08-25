using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SubTaskInfo
    {
        private int taskId;
        private string projectNum;
        private string taskName;
        private int period;
        private string startTime;
        private string endTime;
        private string product;
        private string foreTask;
        private string resource;
        private int userId;
        private string taskState;
        private int isRemind;
        private string remindTime;

        public SubTaskInfo()
        {
        
        }

        public SubTaskInfo(int taskId, string projectNum, string taskName, int period, string startTime, string endTime
            , string product, string foreTask, string resource, int userId, string taskState, int isRemind, string remindTime)
        {
            this.taskId = taskId;
            this.projectNum = projectNum;
            this.taskName = taskName;
            this.period = period;
            this.startTime = startTime;
            this.endTime = endTime;
            this.product = product;
            this.foreTask = foreTask;
            this.resource = resource;
            this.userId = userId;
            this.taskState = taskState;
            this.isRemind = isRemind;
            this.remindTime = remindTime;
        }

        public SubTaskInfo(string projectNum, string taskName, int period, string startTime, string endTime
            , string product, string foreTask, string resource, int userId, string taskState, int isRemind, string remindTime)
        {
            this.projectNum = projectNum;
            this.taskName = taskName;
            this.period = period;
            this.startTime = startTime;
            this.endTime = endTime;
            this.product = product;
            this.foreTask = foreTask;
            this.resource = resource;
            this.userId = userId;
            this.taskState = taskState;
            this.isRemind = isRemind;
            this.remindTime = remindTime;
        }

        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        

        public string ProjectNum
        {
            get { return projectNum; }
            set { projectNum = value; }
        }
        

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }
        

        public int Period
        {
            get { return period; }
            set { period = value; }
        }
        

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        

        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        

        public string ForeTask
        {
            get { return foreTask; }
            set { foreTask = value; }
        }
        

        public string Resource
        {
            get { return resource; }
            set { resource = value; }
        }
        

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        

        public string TaskState
        {
            get { return taskState; }
            set { taskState = value; }
        }
        

        public int IsRemind
        {
            get { return isRemind; }
            set { isRemind = value; }
        }
        

        public string RemindTime
        {
            get { return remindTime; }
            set { remindTime = value; }
        }
    }
}
