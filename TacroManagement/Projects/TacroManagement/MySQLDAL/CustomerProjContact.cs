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
    public class CustomerProjContact : ICustomerProjContact
    {
        private const string PARM_ID = "@ID";
        private const string PARM_CUSTOMERPROJID = "@CustomerProjID";
        private const string PARM_CONTACTID = "@ContactID";

        private const string SQL_INSERT_CUSTOMERPROJCONTACT = "insert into customerprojcontact(CustomerProjID, ContactID) values(@CustomerProjID, @ContactID)";
        private const string SQL_DELETE_CUSTOMERPROJCONTACT = "delete from customerprojcontact where ID=@ID";
        private const string SQL_UPDATE_CUSTOMERPROJCONTACT = "update customerprojcontact set CustomerProjID=@CustomerProjID,ContactID=@ContactID where ID=@ID";
        private const string SQL_SELECT_CUSTOMERPROJCONTACTS = "select * from customerprojcontact";
        private const string SQL_SELECT_CUSTOMERPROJCONTACT_BY_ID = "select * from customerprojcontact where ID=@ID";

        #region ICustomerProjContact 成员

        /// <summary>
        /// 新增客户项目联系人关系
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertCustomerProjContact(CustomerProjContactInfo customerProjContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CUSTOMERPROJID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50)
                };
                parms[0].Value = customerProjContactInfo.CustomerProjID;
                parms[1].Value = customerProjContactInfo.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CUSTOMERPROJCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除客户项目联系人关系
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteCustomerProjContact(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMERPROJCONTACT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户项目联系人关系
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerProjContact(CustomerProjContactInfo customerProjContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_CUSTOMERPROJID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,50)
                };
                parms[0].Value = customerProjContactInfo.CustomerProjID;
                parms[1].Value = customerProjContactInfo.ContactID;
                parms[2].Value = customerProjContactInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CUSTOMERPROJCONTACT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有客户项目联系人关系
        /// </summary>
        /// <returns></returns>
        public IList<CustomerProjContactInfo> GetCustomerProjContacts()
        {
            IList<CustomerProjContactInfo> customerProjContactInfos = new List<CustomerProjContactInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJCONTACTS, null))
                {
                    while (rdr.Read())
                    {
                        CustomerProjContactInfo customerProjContactInfo = new CustomerProjContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                        customerProjContactInfos.Add(customerProjContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjContactInfos;

        }

        /// <summary>
        /// 根据ID查找客户项目联系人关系
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public CustomerProjContactInfo GetCustomerProjContactById(int id)
        {
            CustomerProjContactInfo customerProjContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 50);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJCONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                        customerProjContactInfo = new CustomerProjContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                    else
                        customerProjContactInfo = new CustomerProjContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjContactInfo;
        }

        #endregion
    }
}

