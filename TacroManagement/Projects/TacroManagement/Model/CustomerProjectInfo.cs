using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerProjectInfo
    {
        private int projID;
        private int customerID;
        private string productName;
        private string service;
        private string progress;
        private float contractAmount;
        private string payment;
        private string payState;
        private string projectType;

        public CustomerProjectInfo()
        {
        }

        public CustomerProjectInfo(int customerID, string productName, string service, string progress, float contractAmount,
            string payment, string payState, string projectType)
        {
            this.customerID = customerID;
            this.productName = productName;
            this.service = service;
            this.progress = progress;
            this.contractAmount = contractAmount;
            this.payment = payment;
            this.payState = payState;
            this.projectType = projectType;
        }

        public CustomerProjectInfo(int projID, int customerID, string productName, string service, string progress, float contractAmount,
            string payment, string payState, string projectType)
        {
            this.projID = projID;
            this.customerID = customerID;
            this.productName = productName;
            this.service = service;
            this.progress = progress;
            this.contractAmount = contractAmount;
            this.payment = payment;
            this.payState = payState;
            this.projectType = projectType;
        }

        public int ProjID
        {
            get { return projID; }
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
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

        public string ProjectType
        {
            get { return projectType; }
            set { projectType = value; }
        }
    }
}