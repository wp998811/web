using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ResourceAdminInfo
    {
        private int resourceAdminID;
        private int userID;
        private string resourceType;

        public ResourceAdminInfo()
        {

        }

        public ResourceAdminInfo(int userID, string resourceType)
        {
            this.userID = userID;
            this.resourceType = resourceType;
        }

        public ResourceAdminInfo(int resourceAdminID, int userID, string resourceType)
        {
            this.resourceAdminID = resourceAdminID;
            this.userID = userID;
            this.resourceType = resourceType;
        }

        public int ResourceAdminID
        {
            get { return this.resourceAdminID; }
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public string ResourceType
        {
            get { return this.resourceType; }
            set { this.resourceType = value; }
        }
    }
}