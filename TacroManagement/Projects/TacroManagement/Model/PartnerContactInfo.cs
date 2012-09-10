using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PartnerContactInfo
    {
        private int id;
        private int partnerID;
        private int contactID;

        public PartnerContactInfo()
        {
        }

        public PartnerContactInfo(int id, int partnerID, int contactID)
        {
            this.id = id;
            this.partnerID = partnerID;
            this.contactID = partnerID;
        }
        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public int PartnerID
        {
            get { return partnerID; }
            set { partnerID = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
