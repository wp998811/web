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
    public class Contact : IContact
    {
        private const string PARM_CONTACTID = "@ContactID";
        private const string PARM_CONTACTNAME = "@ContactName";
        private const string PARM_POSITION = "@Position";
        private const string PARM_MOBILEPHONE = "@Mobilephone";
        private const string PARM_TELEPHONE = "@Telephone";
        private const string PARM_EMAIL = "@Email";
        private const string PARM_ADDRESS = "@Address";
        private const string PARM_POSTCODE = "@PostCode";
        private const string PARM_FAXNUMBER = "@FaxNumber";

        private const string SQL_INSERT_CONTACT = "insert into contact(ContactName,Position,Mobilephone,Telephone,Email,Address,PostCode,FaxNumber) values(@ContactName,@Position,@Mobilephone,@Telephone,@Email,@Address,@PostCode,@FaxNumber)";
        private const string SQL_DELETE_CONTACT = "delete from contact where ContactID=@ContactID";
        private const string SQL_UPDATE_CONTACT = "update contact set ContactName=@ContactName,Position=@Position,Mobilephone=@Mobilephone,Telephone=@Telephone,Email=@Email,Address=@Address,PostCode=@PostCode,FaxNumber=@FaxNumber where ContactID=@ContactID";
        private const string SQL_SELECT_CONTACT = "select * from contact";
        private const string SQL_SELECT_CONTACT_BY_NAME = "select * from contact where ContactName=@ContactName";
        private const string SQL_SELECT_CONTACT_BY_NAME_AND_TELEPHONE = "select * from contact where ContactName=@ContactName and Telephone=@Telephone";
        private const string SQL_SELECT_CONTACT_BY_ID = "select * from contact where ContactID=@ContactID";
        private const string SQL_SELECT_IDENTITY = "select LAST_INSERT_ID()";

        #region IContact 成员

        /// <summary>
        /// 新增联系人
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public int InsertContact(ContactInfo contactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_POSITION,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_MOBILEPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TELEPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_EMAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ADDRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_POSTCODE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_FAXNUMBER,MySqlDbType.VarChar,50)
                };
                parms[0].Value = contactInfo.ContactName;
                parms[1].Value = contactInfo.Position;
                parms[2].Value = contactInfo.Mobilephone;
                parms[3].Value = contactInfo.Telephone;
                parms[4].Value = contactInfo.Email;
                parms[5].Value = contactInfo.Address;
                parms[6].Value = contactInfo.PostCode;
                parms[7].Value = contactInfo.FaxNumber;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CONTACT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public int DeleteContact(int contactId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32);
                parm.Value = contactId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CONTACT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新联系人
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public int UpdateContact(ContactInfo contactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_POSITION,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_MOBILEPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TELEPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_EMAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ADDRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_POSTCODE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_FAXNUMBER,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50)
                };
                parms[0].Value = contactInfo.ContactName;
                parms[1].Value = contactInfo.Position;
                parms[2].Value = contactInfo.Mobilephone;
                parms[3].Value = contactInfo.Telephone;
                parms[4].Value = contactInfo.Email;
                parms[5].Value = contactInfo.Address;
                parms[6].Value = contactInfo.PostCode;
                parms[7].Value = contactInfo.FaxNumber;
                parms[8].Value = contactInfo.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CONTACT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有联系人
        /// </summary>
        /// <returns></returns>
        public IList<ContactInfo> GetContacts()
        {
            IList<ContactInfo> contacts = new List<ContactInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT, null))
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
        /// 根据联系人姓名查找联系人
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ContactInfo GetContactByName(string contactName)
        {
            ContactInfo contactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTNAME, MySqlDbType.VarChar, 50);
                parm.Value = contactName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_NAME, parm))
                {
                    if (rdr.Read())
                        contactInfo = new ContactInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    else
                        contactInfo = new ContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactInfo;
        }

        /// <summary>
        /// 根据联系人姓名和手机号查找联系人
        /// </summary>
        /// <param name="contactName"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        public ContactInfo GetContactByNameAndTelephone(string contactName, string telephone)
        {
            ContactInfo contactInfo = null;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TELEPHONE,MySqlDbType.VarChar,50)
                };
                parms[0].Value = contactName;
                parms[1].Value = telephone;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_NAME_AND_TELEPHONE, parms))
                {
                    if (rdr.Read())
                        contactInfo = new ContactInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    else
                        contactInfo = new ContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactInfo;
        }


        /// <summary>
        /// 根据联系人ID查找联系人
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactInfo GetContactById(int contactId)
        {
            ContactInfo contactInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        contactInfo = new ContactInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    }
                    else
                        contactInfo = new ContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return contactInfo;
        }

        #endregion
    }
}
