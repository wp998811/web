using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DepartmentInfo
    {
        private int departID;
        private string departName;
        private string departAdmin;

        public DepartmentInfo() { }

        public DepartmentInfo(string departName, string departAdmin)
        {
            this.departName = departName;
            this.departAdmin = departAdmin;
        }

        public DepartmentInfo(int departID, string departName, string departAdmin)
        {
            this.departID = departID;
            this.departName = departName;
            this.departAdmin = departAdmin;
        }

        public int DepartID
        {
            get { return departID; }
        }

        public string DepartName
        {
            get { return departName; }
            set { departName = value; }
        }

        public string DepartAdmin
        {
            get { return departAdmin; }
            set { departAdmin = value; }
        }
    }
}