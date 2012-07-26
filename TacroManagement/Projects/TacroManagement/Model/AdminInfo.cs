using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AdminInfo
    {
        private int id;
        private string adminName;
        private string adminPassword;

        public AdminInfo()
        {
        }

        public AdminInfo(string adminName,string adminPassword)
        {
            this.adminName = adminName;
            this.adminPassword = adminPassword;
        }

        public int ID
        {
            get 
            {
                return id;
            }
        }

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
    }

}
