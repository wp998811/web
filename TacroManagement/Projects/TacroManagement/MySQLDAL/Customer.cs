using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using DBUtility;
using System.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace MySQLDAL
{
    class Customer:ICustomer
    {
        private const string PARM_CUSTOMERID = "@CustomerID";
        private const string PARM_USERID = "@UserID";
        private const string PARM_CUSTOMERCITY = "@CustomerCity";
        private const string PARM_CUSTOMERTYPE = "@CustomerType";
        private const string PARM_CUSTOMERRANK = "@CustomerRank";
        private const string PARM_CUSTOMERNAME = "@CustomerName";
        private const string PARM_PRODUCTRANGE = "@ProductRange";
        private const string PARM_TAXID = "@TaxID";
        private const string PARM_ORGANCODE = "@OrganCode";

        private const string SQL_INSERT_CUSTOMER = "insert into customer(UserID, CustomerCity,CustomerType,CustomerRank,CustomerName,ProductRange, TaxID, OrganCode) values(@UserID, @CustomerCity, @CustomerType, @CustomerRank, @CustomerName, @ProductRange, @TaxID, @OrganCode)";
        private const string SQL_DELETE_CUSTOMER = "delete from customer where CustomerID=@CustomerID";
        private const string SQL_UPDATE_CUSTOMER = "update customer set UserID=@UserID,CustomerCity=@CustomerCity,CustomerType=@CustomerType,CustomerRank=@CustomerRank,CustomerName=@CustomerName,ProductRange=@ProductRange, TaxID=@TaxID, OrganCode=@OrganCode where CustomerID=@CustomerID";
        private const string SQL_SELECT_CUSTOMER = "select * from customer";
        private const string SQL_SELECT_CUSTOMER_BY_NAME = "select * from customer where CustomerName=@CustomerName";
        private const string SQL_SELECT_CUSTOMER_BY_ID = "select * from customer where CustomerID=@CustomerID";

        #region ICustomer 成员

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public int InsertCustomer(CustomerInfo customerInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CUSTOMERCITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERRANK,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTRANGE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TAXID,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ORGANCODE,MySqlDbType.VarChar,50)
                };
                if (customerInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = customerInfo.UserID;
                parms[1].Value = customerInfo.CustomerCity;
                parms[2].Value = customerInfo.CustomerType;
                parms[3].Value = customerInfo.CustomerRank;
                parms[4].Value = customerInfo.CustomerName;
                parms[5].Value = customerInfo.ProductRange;
                parms[6].Value = customerInfo.TaxID;
                parms[7].Value = customerInfo.OrganCode;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CUSTOMER, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int DeleteCustomer(int customerID)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERID, MySqlDbType.Int32);
                parm.Value = customerID;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMER, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public int UpdateCustomer(CustomerInfo customerInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CUSTOMERCITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERRANK,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTRANGE,MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_TAXID,MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_ORGANCODE,MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_CUSTOMERID,MySqlDbType.Int32,50)
                };
                if (customerInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = customerInfo.UserID;
                parms[1].Value = customerInfo.CustomerCity;
                parms[2].Value = customerInfo.CustomerType;
                parms[3].Value = customerInfo.CustomerRank;
                parms[4].Value = customerInfo.CustomerName;
                parms[5].Value = customerInfo.ProductRange;
                parms[6].Value = customerInfo.TaxID;
                parms[7].Value = customerInfo.OrganCode;
                parms[8].Value = customerInfo.CustomerID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CUSTOMER, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有客户
        /// </summary>
        /// <returns></returns>
        public IList<CustomerInfo> GetCustomers()
        {
            IList<CustomerInfo> customers = new List<CustomerInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMER, null))
                {
                    while (rdr.Read())
                    {
                        CustomerInfo customer = new CustomerInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        customers.Add(customer);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customers;

        }

        /// <summary>
        /// 根据客户名查找客户
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public CustomerInfo GetCustomerByCustomerName(string customerName)
        {
            CustomerInfo customerInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERNAME, MySqlDbType.VarChar, 50);
                parm.Value = customerName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMER_BY_NAME, parm))
                {
                    if (rdr.Read())
                        customerInfo = new CustomerInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    else
                        customerInfo = new CustomerInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerInfo;
        }

        /// <summary>
        /// 根据客户ID查找客户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerInfo GetCustomerById(int customerId)
        {
            CustomerInfo customerInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERID, MySqlDbType.Int32);
                parm.Value = customerId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMER_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        customerInfo = new CustomerInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    }
                    else
                        customerInfo = new CustomerInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return customerInfo;
        }

        #endregion
    }
}
