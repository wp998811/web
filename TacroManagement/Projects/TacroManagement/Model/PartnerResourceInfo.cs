using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PartnerResourceInfo
    {
        private int partnerID;
        private int userID;
        private string partnerCity;
        private string organName;
        private string organIntro;

        public PartnerResourceInfo()
        {
        }
        public PartnerResourceInfo(int partnerID, int userID, string partnerCity, string organName, string organIntro)
        {
            this.partnerID = partnerID;
            this.userID = userID;
            this.partnerCity = partnerCity;
            this.organName = organName;
            this.organIntro = organIntro;
        }

        public string OrganIntro
        {
            get { return organIntro; }
            set { organIntro = value; }
        }

        public string OrganName
        {
            get { return organName; }
            set { organName = value; }
        }


        public string PartnerCity
        {
            get { return partnerCity; }
            set { partnerCity = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int PartnerID
        {
            get { return partnerID; }
            set { partnerID = value; }
        }
    }
}
