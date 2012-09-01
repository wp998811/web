using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerProjectInfo
    {
        private int projID;
        private int userID;
        private string customerCity;
        private string customerType;
        private string customerName;
        private string productName;
        private string service;
        private string progress;
        private string productCategory;
        private float contractAmount;
        private string payment;
        private string payState;
        private string taxID;
        private string organCode;

        public CustomerProjectInfo()
        {
        }

        public CustomerProjectInfo(int userID, string customerCity, string customerType, string customerName, string productName,
            string service, string progress, string productCategory, float contractAmount, string payment, string payState, string taxID, string organCode)
        {
            this.userID = userID;
            this.customerCity = customerCity;
            this.customerType = customerType;
            this.customerName = customerName;
            this.productName = productName;
            this.service = service;
            this.progress = progress;
            this.productCategory = productCategory;
            this.contractAmount = contractAmount;
            this.payment = payment;
            this.payState = payState;
            this.taxID = taxID;
            this.organCode = organCode;
        }

        public CustomerProjectInfo(int projID, int userID, string customerCity, string customerType, string customerName, string productName,
            string service, string progress, string productCategory, float contractAmount, string payment, string payState, string taxID, string organCode)
        {
            this.projID = projID;
            this.userID = userID;
            this.customerCity = customerCity;
            this.customerType = customerType;
            this.customerName = customerName;
            this.productName = productName;
            this.service = service;
            this.progress = progress;
            this.productCategory = productCategory;
            this.contractAmount = contractAmount;
            this.payment = payment;
            this.payState = payState;
            this.taxID = taxID;
            this.organCode = organCode;
        }

        public int ProjID
        {
            get { return projID; }
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

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Service
        {
            get { return service; }
            set { service = value; }
        }

        public string Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        public string ProductCategory
        {
            get { return productCategory; }
            set { productCategory = value; }
        }

        public float ContractAmount
        {
            get { return contractAmount; }
            set { contractAmount = value; }
        }

        public string Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public string PayState
        {
            get { return payState; }
            set { payState = value; }
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