using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerInfo
    {
        private int customerID;
        private int userID;
        private string customerCity;
        private string customerType;
        private string customerRank;
        private string customerName;
        private string productRange;
        private string taxID;
        private string organCode;

        public CustomerInfo()
        {
        }

        public CustomerInfo(int userID, string customerCity, string customerType,string customerRank,string customerName, string productRange, string taxID, string organCode)
        {
            this.userID = userID;
            this.customerCity = customerCity;
            this.customerType = customerType;
            this.customerRank = customerRank;
            this.customerName = customerName;
            this.productRange = productRange;
            this.taxID = taxID;
            this.organCode = organCode;
        }

        public CustomerInfo(int customerID, int userID, string customerCity, string customerType, string customerRank,string customerName, string productRange, string taxID, string organCode)
        {
            this.customerID = customerID;
            this.userID = userID;
            this.customerCity = customerCity;
            this.customerType = customerType;
            this.customerRank = customerRank;
            this.customerName = customerName;
            this.productRange = productRange;
            this.taxID = taxID;
            this.organCode = organCode;
        }

        public int CustomerID
        {
            get { return customerID; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string CustomerCity
        {
            get { return customerCity; }
            set { customerCity = value; }
        }

        public string CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }

        public string CustomerRank
        {
            get { return customerRank; }
            set { customerRank = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string ProductRange
        {
            get { return productRange; }
            set { productRange = value; }
        }

        public string TaxID
        {
            get { return taxID; }
            set { taxID = value; }
        }

        public string OrganCode
        {
            get { return organCode; }
            set { organCode = value; }
        }

    }
}
