using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class ProjectInfo
    {
        private string ProjectNum;
        private string ProjectName;
        private int ProjectAdminID;
        private string ProjectDescription;
        private string ProjectType;
        private string BeginTime;
        private string EndTime;

        public ProjectInfo()
        {

        }

        public ProjectInfo(string ProjectNum, string ProjectName, int ProjectAdminID, string ProjectDescription
            , string ProjectType, string BeginTime, string EndTime)
        {
            this.ProjectNum = ProjectNum;
            this.ProjectName = ProjectName;
            this.ProjectAdminID = ProjectAdminID;
            this.ProjectDescription = ProjectDescription;
            this.ProjectType = ProjectType;
            this.BeginTime = BeginTime;
            this.EndTime = EndTime;
        }


    }
}
