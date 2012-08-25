using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProjectClientInfo
    {
        private int id;
        private string projectNum;
        private int clientId;

        public ProjectClientInfo()
        {

        }

        public ProjectClientInfo(int id, string projectNum, int clientId)
        {
            this.id = id;
            this.projectNum = projectNum;
            this.clientId = clientId;
        }

        public ProjectClientInfo(string projectNum, int clientId)
        {
            this.projectNum = projectNum;
            this.clientId = clientId;
        }

        public string ProjectNum
        {
            get { return projectNum; }
            set { projectNum = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

    }
}
