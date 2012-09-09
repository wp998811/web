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
    public class CustomerContact : ICustomerContact
    {
        private const string PARM_ID = "@ID";
        private const string PARM_CUSTOMERID = "@CustomerID";
        private const string PARM_CONTACTID = "@ContactID";
        private const string PARM_CUSTOMER_CUSTOMERID = "@customer.CustomerID";
        private const string PARM_CONTACT_CONTACTID = "@contact.ContactID";

        private const string SQL_INSERT_CUSTOMERCONTACT = "insert into customercontact(CustomerID, ContactID) values(@CustomerID, @ContactID)";
        private const string SQL_DELETE_CUSTOMERCONTACT = "delete from customercontact where ID=@ID";
        private const string SQL_DELETE_CUSTOMERCONTACT_BY_CONTACTID = "delete from customercontact where ContactID=@ContactID";
        private const string SQL_DELETE_CUSTOMERCONTACT_BY_CUSTOMERID = "delete from customercontact where CustomerID=@CustomerID";
        private const string SQL_UPDATE_CUSTOMERCONTACT = "update customercontact set CustomerID=@CustomerID,ContactID=@ContactID where ID=@ID";
        private const string SQL_SELECT_CONTACT_BY_CUSTOMERID = "select contact.ContactID, contact.ContactName, contact.Position, contact.Mobilephone, contact.Telephone, contact.Email," +
            "contact.Address, contact.PostCode, contact.FaxNumber from contact where contact.ContactID in (select contact.ContactID from customercontact, contact where customercontact.CustomerID=@CustomerID and customercontact.ContactID=contact.ContactID)";
        private const string SQL_SELECT_CUSTOMERCONTACTCONTACTS = "select * from customercontact";
        private const string SQL_SELECT_CUSTOMERCONTACTCONTACT_BY_ID = "select * from customercontact where ID=@ID";
        private const string SQL_SELECT_CUSTOMER_BY_CONTACT_ID = "select * from customer where CustomerID in (select CustomerID from customercontact where ContactID=@ContactID)";

        #region ICustomerContact 成员

        /// <summary>
        /// 新增客户联系人关系
        /// </summary>
        /// <param name="customerContact"></param>
        /// <returns></returns>
        public int InsertCustomerContact(CustomerContactInfo customerContact)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CUSTOMERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50)
                };
                parms[0].Value = customerContact.CustomerID;
                parms[1].Value = customerContact.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CUSTOMERCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除客户联系人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCustomerContact(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMERCONTACT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据联系人ID删除客户联系人信息
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public int DeleteCustomerContactByContactId(int contactId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32);
                parm.Value = contactId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMERCONTACT_BY_CONTACTID, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据客户ID删除客户联系人信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int DeleteCustomerContactByCustomerId(int customerId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERID, MySqlDbType.Int32);
                parm.Value = customerId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMERCONTACT_BY_CUSTOMERID, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户联系人信息
        /// </summary>
        /// <param name="customerContactInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerContact(CustomerContactInfo customerContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_CUSTOMERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,50)
                };
                parms[0].Value = customerContactInfo.CustomerID;
                parms[1].Value = customerContactInfo.ContactID;
                parms[2].Value = customerContactInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CUSTOMERCONTACT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<CustomerContactInfo> GetCustomerContacts()
        {
            IList<CustomerContactInfo> customerContactInfos = new List<CustomerContactInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERCONTACTCONTACTS, null))
                {
                    while (rdr.Read())
                    {
                        CustomerContactInfo customerContactInfo = new CustomerContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                        customerContactInfos.Add(customerContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerContactInfos;

        }

        /// <summary>
        /// 根据客户ID查找所有联系人信息
        /// </summary>
        /// <returns></returns>
        public IList<ContactInfo> GetContactsByCustomerId(int customerId)
        {
            IList<ContactInfo> contacts = new List<ContactInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERID, MySqlDbType.Int32, 50);
                parm.Value = customerId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_CUSTOMERID, parm))
                {
                    while (rdr.Read())
                    {
                        ContactInfo contact = new ContactInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        contacts.Add(contact);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contacts;

        }

        /// <summary>
        /// 根据联系人ID查找客户信息
        /// </summary>
        /// <returns></returns>
        public CustomerInfo GetCustomerByContactId(int contactId)
        {
            CustomerInfo customerInfo= null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32, 50);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMER_BY_CONTACT_ID, parm))
                {
                    if (rdr.Read())
                    {
                        customerInfo = new CustomerInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
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

        /// <summary>
        /// 根据ID查找客户联系人
        /// </summary>
        /// <param name="customerContactId"></param>
        /// <returns></returns>
        public CustomerContactInfo GetCustomerContactById(int customerContactId)
        {
            CustomerContactInfo customerContactInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = customerContactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERCONTACTCONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        customerContactInfo = new CustomerContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                    }
                    else
                        customerContactInfo = new CustomerContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return customerContactInfo;
        }

        #endregion
    }
}

