using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ResourceAdminInfo
    {
        private int id;
        private int userID;
        private string resourceType;

        public ResourceAdminInfo()
        {
        }

        public ResourceAdminInfo(int userID,string resourceType)
        {
            this.userID = userID;
            this.resourceType = resourceType;
        }

        public ResourceAdminInfo(int id,int userID,string resourceType)
        {
            this.id = id;
            this.userID = userID;
            this.resourceType = resourceType;
        }

        public int Id
        {
            get { return id; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        public string ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; }
        }

    }
}
