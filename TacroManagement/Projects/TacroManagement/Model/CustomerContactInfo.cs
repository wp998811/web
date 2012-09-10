using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerContactInfo
    {
        private int id;
        private int contactID;
        private int customerID;

        public CustomerContactInfo()
        {
        }

        public CustomerContactInfo(int contactID, int customerID)
        {
            this.contactID = contactID;
            this.customerID = customerID;
        }

        public CustomerContactInfo(int id, int contactID, int customerID)
        {
            this.id = id;
            this.contactID = contactID;
            this.customerID = customerID;
        }

        public int ID
        {
            get { return id; }
        }

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

    }
}