using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ClinicalContactInfo
    {
        private int id;
        private int clinicalID;
        private int contactID;

        public ClinicalContactInfo()
        {
        }

        public ClinicalContactInfo(int clinicalID, int contactID)
        {
            this.clinicalID = clinicalID;
            this.contactID = contactID;
        }

        public ClinicalContactInfo(int id, int clinicalID, int contactID)
        {
            this.id = id;
            this.clinicalID = clinicalID;
            this.contactID = contactID;
        }

        public int ID
        {
            get { return id; }
        }

        public int ClinicalID
        {
            get { return clinicalID; }
            set { clinicalID = value; }
        }

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }
    }
}
