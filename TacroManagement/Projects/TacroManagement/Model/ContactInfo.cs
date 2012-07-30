using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContactInfo
    {
        private int contactID;
        private string contactName;
        private string position;
        private string mobilephone;
        private string telephone;
        private string email;
        private string address;
        private string postCode;
        private string faxNumber;


        public ContactInfo()
        {
        }

        public ContactInfo(string contactName, string position, string mobilephone, string telephone, string email, string address, string postCode, string faxNumber)
        {
            this.contactName = contactName;
            this.position = position;
            this.mobilephone = mobilephone;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
            this.postCode = postCode;
            this.faxNumber = faxNumber;
        }

        public ContactInfo(int contactID, string contactName, string position, string mobilephone, string telephone, string email, string address, string postCode, string faxNumber)
        {
            this.contactID = contactID;
            this.contactName = contactName;
            this.position = position;
            this.mobilephone = mobilephone;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
            this.postCode = postCode;
            this.faxNumber = faxNumber;
        }

        public int ContactID
        {
            get { return contactID; }
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Mobilephone
        {
            get { return mobilephone; }
            set { mobilephone = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }

    }
}
