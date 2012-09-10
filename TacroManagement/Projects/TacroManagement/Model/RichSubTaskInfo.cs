using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RichSubTaskInfo
    {
        private string adminName;
        private string adminEmail;
        private string adminPhone;

        private string projectNum;

        public string ProjectNum
        {
            get { return projectNum; }
            set { projectNum = value; }
        }

        private int taskId;

        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }


        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }
        private int period;

        public int Period
        {
            get { return period; }
            set { period = value; }
        }
        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string endTime;

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string product;

        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        private string foreTask;

        public string ForeTask
        {
            get { return foreTask; }
            set { foreTask = value; }
        }
        private string resource;

        public string Resource
        {
            get { return resource; }
            set { resource = value; }
        }
        private int isRemind;

        public int IsRemind
        {
            get { return isRemind; }
            set { isRemind = value; }
        }
        private string taskState;

        public string TaskState
        {
            get { return taskState; }
            set { taskState = value; }
        }

        public RichSubTaskInfo()
        {

        }

        public RichSubTaskInfo(string projectNum, int taskId, string taskName, int period, string startTime, 
            string endTime, string product, string foreTask, string resource, 
            int isRemind, string taskState, string adminName, string adminEmail, string adminPhone)
        {
            this.projectNum = projectNum;
            this.taskId = taskId;
            this.taskName = taskName;
            this.period = period;
            this.startTime = startTime;
            this.endTime = endTime;
            this.product = product;
            this.foreTask = foreTask;
            this.resource = resource;
            this.isRemind = isRemind;
            this.taskState = taskState;
            this.adminName = adminName;
            this.adminEmail = adminEmail;
            this.adminPhone = adminPhone;
        }

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
        

        public string AdminEmail
        {
            get { return adminEmail; }
            set { adminEmail = value; }
        }
        

        public string AdminPhone
        {
            get { return adminPhone; }
            set { adminPhone = value; }
        }


    }
}
