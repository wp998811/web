using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class AffairInfo
    {
        private int affairId;
        private string affairDescription;
        private int affairOperatorId;
        private string affairTime;
        private string projectNum;

        public AffairInfo()
        {

        }

        public AffairInfo(string affairDescription, int affairOperatorId, string affairTime, string projectNum)
        {
            this.affairDescription = affairDescription;
            this.affairOperatorId = affairOperatorId;
            this.affairTime = affairTime;
            this.projectNum = projectNum;
        }

        public AffairInfo(int affairId, string affairDescription, int affairOperatorId, string affairTime, string projectNum)
        {
            this.affairId = affairId;
            this.affairDescription = affairDescription;
            this.affairOperatorId = affairOperatorId;
            this.affairTime = affairTime;
            this.projectNum = projectNum;
        }

        public string ProjectNum
        {
            get { return projectNum; }
            set { projectNum = value; }
        }

        public string AffairTime
        {
            get { return affairTime; }
            set { affairTime = value; }
        }

        public int AffairOperatorId
        {
            get { return affairOperatorId; }
            set { affairOperatorId = value; }
        }

        public string AffairDescription
        {
            get { return affairDescription; }
            set { affairDescription = value; }
        }

        public int AffairId
        {
            get { return affairId; }
            set { affairId = value; }
        }
    }
}
