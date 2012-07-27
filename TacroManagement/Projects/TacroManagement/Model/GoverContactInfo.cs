using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GoverContactInfo
    {
        private int id;
        private int goverID;
        private int contactID;

        public GoverContactInfo()
        {

        }

        public GoverContactInfo(int Id, int goverID, int contactID)
        {
            this.id = Id;
            this.goverID = goverID;
            this.contactID = contactID;
            
        }
        public int GoverID
        {
            get { return goverID; }
            set { goverID = value; }
        }
       
        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public int Id
        {
          get { return id; }
          set { id = value; }
        }
    }
}
