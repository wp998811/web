using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerProjContactInfo
    {
        private int id;
        private int customerProjID;
        private int contactID;

        public CustomerProjContactInfo()
        {
        }

        public CustomerProjContactInfo(int customerProjID, int contactID)
        {
            this.customerProjID = customerProjID;
            this.contactID = contactID;
        }

        public CustomerProjContactInfo(int id, int customerProjID, int contactID)
        {
            this.id = id;
            this.customerProjID = customerProjID;
            this.contactID = contactID;
        }

        public int ID
        {
            get { return id; }
        }

        public int CustomerProjID
        {
            get { return customerProjID; }
            set { customerProjID = value; }
        }

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

    }
}
