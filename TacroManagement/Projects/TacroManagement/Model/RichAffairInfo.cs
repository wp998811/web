using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RichAffairInfo
    {
        private int affairID;

        public int AffairID
        {
            get { return affairID; }
            set { affairID = value; }
        }
        private string affairDescription;

        public string AffairDescription
        {
            get { return affairDescription; }
            set { affairDescription = value; }
        }
        private string affairTime;

        public string AffairTime
        {
            get { return affairTime; }
            set { affairTime = value; }
        }
        private string affairOperator;

        public string AffairOperator
        {
            get { return affairOperator; }
            set { affairOperator = value; }
        }
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public RichAffairInfo(int affairID, string affairDescription, string affairTime, string affairOperator, string projectName)
        {
            this.affairID = affairID;
            this.affairDescription = affairDescription;
            this.affairTime = affairTime;
            this.affairOperator = affairOperator;
            this.projectName = projectName;
        }
    }
}
