using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProjectUserInfo
    {
        private int id;
        private string projectNum;
        private int userId;

        public ProjectUserInfo()
        {

        }

        public ProjectUserInfo(string projectNum, int userId)
        {
            this.projectNum = projectNum;
            this.userId = userId;
        }

        public ProjectUserInfo(int id, string projectNum, int userId)
        {
            this.id = id;
            this.projectNum = projectNum;
            this.userId = userId;
        }

        public int ID
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public string ProjectNum
        {
            set { this.projectNum = value; }
            get { return this.projectNum; }
        }

        public int UserId
        {
            set { this.userId = value; }
            get { return this.userId; }
        }
    }
}
