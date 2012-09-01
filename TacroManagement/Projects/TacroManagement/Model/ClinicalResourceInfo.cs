using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ClinicalResourceInfo
    {
        private int clinicalID;
        private int userID;
        private string city;
        private string hospital;
        private string department;
        private string departIntro;

        public ClinicalResourceInfo()
        {
        }

        public ClinicalResourceInfo(int userID, string city, string hospital, string department, string departIntro)
        {
            this.userID = userID;
            this.city = city;
            this.hospital = hospital;
            this.department = department;
            this.departIntro = departIntro;
        }

        public ClinicalResourceInfo(int clinicalID, int userID, string city, string hospital, string department, string departIntro)
        {
            this.clinicalID = clinicalID;
            this.userID = userID;
            this.city = city;
            this.hospital = hospital;
            this.department = department;
            this.departIntro = departIntro;
        }

        public int ClinicalID
        {
            get { return clinicalID; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Hospital
        {
            get { return hospital; }
            set { hospital = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string DepartIntro
        {
            get { return departIntro; }
            set { departIntro = value; }
        }
    }
}
