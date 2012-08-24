using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Customer
    {
        private static readonly ICustomer dal = DALFactory.DataAccess.CreateCustomer();

        #region
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public int InsertCustomer(CustomerInfo customerInfo)
        {
            return dal.InsertCustomer(customerInfo);
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public int UpdateCustomer(CustomerInfo customerInfo)
        {
            return dal.UpdateCustomer(customerInfo);
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int DeleteCustomer(int customerID)
        {
            return dal.DeleteCustomer(customerID);
        }

        /// <summary>
        /// 查找所有客户
        /// </summary>
        /// <returns></returns>
        public IList<CustomerInfo> GetCustomers()
        {
            return dal.GetCustomers();
        }

        /// <summary>
        /// 通过客户编号查找用户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerInfo GetCustomerById(int customerId)
        {
            return dal.GetCustomerById(customerId);
        }
        #endregion

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="customerCity"></param>
        /// <param name="customerCity"></param>
        /// <param name="customerRank"></param>
        /// <param name="customerName"></param>
        /// <param name="productRange"></param>
        /// <param name="taxID"></param>
        /// <param name="organCode"></param>
        /// <returns></returns>
        public bool AddCustomer(int userID, string customerCity, string customerType, string customerRank, string customerName, string productRange, string taxID, string organCode)
        {
            if (userID < 0)
                return false;
            if (1 == dal.InsertCustomer(new CustomerInfo(userID, customerCity, customerType, customerRank, customerName, productRange, taxID,organCode)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="customerCity"></param>
        /// <param name="customerCity"></param>
        /// <param name="customerRank"></param>
        /// <param name="customerName"></param>
        /// <param name="productRange"></param>
        /// <param name="taxID"></param>
        /// <param name="organCode"></param>
        /// <returns></returns>
        public bool ModifyCustomer(int customerID, int userID, string customerCity, string customerType, string customerRank, string customerName, string productRange, string taxID, string organCode)
        {
            if (userID < 0)
                return false;
            CustomerInfo customerInfo = dal.GetCustomerById(customerID);
            if (customerInfo == null)
                return false;
            customerInfo.UserID = userID;
            customerInfo.CustomerCity = customerCity;
            customerInfo.CustomerType = customerType;
            customerInfo.CustomerRank = customerRank;
            customerInfo.CustomerName = customerName;
            customerInfo.ProductRange = productRange;
            customerInfo.TaxID = taxID;
            customerInfo.OrganCode = organCode;

            if (1 == dal.UpdateCustomer(customerInfo))
                return true;
            return false;
        }

    }
}
