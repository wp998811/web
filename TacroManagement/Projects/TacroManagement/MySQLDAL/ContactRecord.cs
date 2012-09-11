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
    public class ContactRecord : IContactRecord
    {
        private const string PARM_ID = "@ID";
        private const string PARM_CONTACTID = "@ContactID";
        private const string PARM_RECORDDETAIL = "@RecordDetail";
        private const string PARM_RECORDTIME = "@RecordTime";
        private const string PARM_USERID= "@UserID";

        private const string SQL_INSERT_CONTACTRECORD = "insert into contactrecord(ContactID,RecordDetail,RecordTime,UserID) values(@ContactID,@RecordDetail,@RecordTime,@UserID)";
        private const string SQL_DELETE_CONTACTRECORD = "delete from contactrecord where ID=@ID";
        private const string SQL_UPDATE_CONTACTRECORD = "update contactrecord set ContactID=@ContactID,RecordDetail=@RecordDetail,RecordTime=@RecordTime,UserID=@UserID where ID=@ID";
        private const string SQL_SELECT_CONTACTRECORDS = "select * from contactrecord";
        private const string SQL_SELECT_CONTACTRECORD_BY_ID = "select * from contactrecord where ID=@ID";
        private const string SQL_SELECT_CONTACTRECORDS_BY_CONTACTID = "select * from contactrecord where ContactID=@ContactID";
        private const string SQL_SELECT_CONTACTRECORDS_BY_USERID = "select * from contactrecord where UserID=@UserID";

        #region IContactRecord 成员

        /// <summary>
        /// 新增联系人记录
        /// </summary>
        /// <param name="contactRecordInfo"></param>
        /// <returns></returns>
        public int InsertContactRecord(ContactRecordInfo contactRecordInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_RECORDDETAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_RECORDTIME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50)
                };
                if (contactRecordInfo.ContactID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = contactRecordInfo.ContactID;

                parms[1].Value = contactRecordInfo.RecordDetail;
                parms[2].Value = contactRecordInfo.RecordTime;
                if (contactRecordInfo.UserID == 0)
                    parms[3].Value = DBNull.Value;
                else
                    parms[3].Value = contactRecordInfo.UserID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CONTACTRECORD, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除联系人记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteContactRecord(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CONTACTRECORD, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新联系人记录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateContactRecord(ContactRecordInfo contactRecordInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_RECORDDETAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_RECORDTIME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,50)
                };
                if (contactRecordInfo.ContactID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = contactRecordInfo.ContactID;

                parms[1].Value = contactRecordInfo.RecordDetail;
                parms[2].Value = contactRecordInfo.RecordTime;
                if (contactRecordInfo.UserID == 0)
                    parms[3].Value = DBNull.Value;
                else
                    parms[3].Value = contactRecordInfo.UserID;
                parms[4].Value = contactRecordInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CONTACTRECORD, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有联系人记录
        /// </summary>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecords()
        {
            IList<ContactRecordInfo> contactRecords = new List<ContactRecordInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACTRECORDS, null))
                {
                    while (rdr.Read())
                    {
                        ContactRecordInfo contactRecord = new ContactRecordInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4));
                        contactRecords.Add(contactRecord);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactRecords;

        }

        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ContactRecordInfo GetContactRecordById(int id)
        {
            ContactRecordInfo contactRecordInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 50);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACTRECORD_BY_ID, parm))
                {
                    if (rdr.Read())
                        contactRecordInfo = new ContactRecordInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4));
                    else
                        contactRecordInfo = new ContactRecordInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactRecordInfo;
        }

        /// <summary>
        /// 根据用户ID查找联系人记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecordsByUserId(int userId)
        {
            IList<ContactRecordInfo> contactRecordInfos = new List<ContactRecordInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32, 50);
                parm.Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACTRECORDS_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ContactRecordInfo contactRecordInfo = new ContactRecordInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4));
                        contactRecordInfos.Add(contactRecordInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactRecordInfos;
        }

        /// <summary>
        /// 根据联系人ID查找联系人记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecordsByContactId(int contactId)
        {
            IList<ContactRecordInfo> contactRecordInfos = new List<ContactRecordInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32, 50);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACTRECORDS_BY_CONTACTID, parm))
                {
                    while (rdr.Read())
                    {
                        ContactRecordInfo contactRecordInfo = new ContactRecordInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4));
                        contactRecordInfos.Add(contactRecordInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactRecordInfos;
        }

        #endregion
    }
}

