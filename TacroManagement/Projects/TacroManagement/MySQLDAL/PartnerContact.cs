﻿using System;
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
    public class PartnerContact : IPartnerContact
    {
        #region PartnerContact Constant String

        private const string PARM_ID = "@ID";
        private const string PARM_PARTNERID = "@PartnerID";
        private const string PARM_CONTACTID = "@ContactID";

        private const string SQL_INSERT_PARTNERCONTACT = "INSERT INTO partnercontact(PartnerID, ContactID) VALUES (@PartnerID, @ContactID) ";
        private const string SQL_DELETE_PARTNERCONTACT = "DELETE FROM partnercontact WHERE ID=@ID";
        private const string SQL_DELETE_PARTNERCONTACT_BY_PARTNERID = "delete from partnercontact where PartnerID=@PartnerID";
        private const string SQL_DELETE_PARTNERCONTACT_BY_CONTACTID = "delete from partnercontact where ContactID=@ContactID";
        private const string SQL_UPDATE_PARTNERCONTACT = "UPDATE partnercontact SET PartnerID = @PartnerID, ContactID = @ContactID WHERE ID = @ID";
        private const string SQL_SELECT_PARTNERCONTACT = "SELECT * FROM partnercontact";
        private const string SQL_SELECT_PARTNERCONTACT_BY_ID = "SELECT * FROM partnercontact WHERE ID = @ID";
        private const string SQL_SELECT_PARTNERCONTACT_BY_PARTNERID = "SELECT * FROM partnercontact WHERE PartnerID = @PartnerID";
        private const string SQL_SELECT_PARTNERCONTACT_BY_CONTACTID = "SELECT * FROM partnercontact WHERE ContactID = @ContactID";
        private const string SQL_SELECT_PARTNERCONTACT_BY_PARTNER_CONTACT = "SELECT * FROM partnercontact WHERE PartnerID = @PartnerID AND ContactID = @ContactID";
        private const string SQL_SELECT_CONTACTS_BY_PARTNER_ID = "select * from contact where ContactID in (select ContactID from partnercontact where PartnerID = @PartnerID)";

        #endregion

        #region IPartnerContact Members

        /// <summary>
        /// 新增合作伙伴联系人
        /// </summary>
        /// <param name="partnerContactInfo"></param>
        /// <returns></returns>
        int IPartnerContact.InsertPartnerContact(PartnerContactInfo partnerContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_PARTNERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,11) 
                };
                if (partnerContactInfo.PartnerID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = partnerContactInfo.PartnerID;
                if (partnerContactInfo.ContactID == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = partnerContactInfo.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PARTNERCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IPartnerContact.DeletePartnerContact(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PARTNERCONTACT, parm);
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
        public int DeletePartnerContactByPartnerId(int partnerId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32);
                parm.Value = partnerId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PARTNERCONTACT_BY_PARTNERID, parm);
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
        public int DeletePartnerContactByContactId(int contactId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32);
                parm.Value = contactId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PARTNERCONTACT_BY_CONTACTID, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新合作伙伴联系人
        /// </summary>
        /// <param name="partnerContactInfo"></param>
        /// <returns></returns>
        int IPartnerContact.UpdatePartnerContact(PartnerContactInfo partnerContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_PARTNERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,11) ,
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,11)
                };
                if (partnerContactInfo.PartnerID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = partnerContactInfo.PartnerID;
                if (partnerContactInfo.ContactID == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = partnerContactInfo.ContactID;
                parms[2].Value = partnerContactInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PARTNERCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有合作伙伴联系人
        /// </summary>
        /// <returns></returns>
        IList<PartnerContactInfo> IPartnerContact.GetPartnerContact()
        {
            IList<PartnerContactInfo> partnerContactInfos = new List<PartnerContactInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERCONTACT, null))
                {
                    while (rdr.Read())
                    {
                        PartnerContactInfo partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        partnerContactInfos.Add(partnerContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerContactInfos;
        }

        /// <summary>
        /// 根据合作伙伴联系人编号查找合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PartnerContactInfo IPartnerContact.GetPartnerContactById(int id)
        {
            PartnerContactInfo partnerContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERCONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                        partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        partnerContactInfo = new PartnerContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerContactInfo;
        }


        /// <summary>
        /// 根据合作伙伴ID查找合作伙伴联系人
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        IList<PartnerContactInfo> IPartnerContact.GetPartnerContactByPartner(int PartnerId)
        {
             IList<PartnerContactInfo> partnerContactInfos = new List<PartnerContactInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32, 11);
                parm.Value = PartnerId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERCONTACT_BY_PARTNERID, parm))
                {
                    while (rdr.Read())
                    {
                        PartnerContactInfo partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        partnerContactInfos.Add(partnerContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerContactInfos;
        }

        // <summary>
        /// 根据联系人编号查找合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PartnerContactInfo IPartnerContact.GetPartnerContactByContactId(int contactId)
        {
            PartnerContactInfo partnerContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32, 11);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERCONTACT_BY_CONTACTID, parm))
                {
                    if (rdr.Read())
                        partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        partnerContactInfo = new PartnerContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerContactInfo;
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<ContactInfo> GetContactsByPartnerId(int partnerID)
        {
            IList<ContactInfo> contactInfos = new List<ContactInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32, 50);
                parm.Value = partnerID;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACTS_BY_PARTNER_ID, parm))
                {
                    while (rdr.Read())
                    {
                        ContactInfo contactInfo = new ContactInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        contactInfos.Add(contactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return contactInfos;
        }

        #endregion

    }
}