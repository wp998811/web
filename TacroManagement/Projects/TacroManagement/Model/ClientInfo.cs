using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ClientInfo
    {
        private int clientID;
        private string clientName;
        private string clientCompany;

        public ClientInfo() { }

        public ClientInfo(string clientName, string clientCompany)
        {
            this.clientName = clientName;
            this.clientCompany = clientCompany;
        }

        public ClientInfo(int clientID,string clientName,string clientCompany) 
        {
            this.clientID = clientID;
            this.clientName = clientName;
            this.clientCompany = clientCompany;
        }


        public int ClientID
        {
            get { return clientID; }
        }


        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public string ClientCompany
        {
            get { return clientCompany; }
            set { clientCompany = value; }
        }

    }
}
