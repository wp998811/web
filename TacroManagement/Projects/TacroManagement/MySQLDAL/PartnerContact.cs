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
    public class PartnerContact:IPartnerContact
    {
        #region PartnerContact Constant String

        private const string PARM_ID = "@ID";
        private const string PARM_PARTNERID = "@PartnerID";
        private const string PARM_CONTACTID = "@ContactID";

        private const string SQL_INSERT_PARTNERCONTACT = "INSERT INTO partnercontact(PartnerID, ContactID) VALUES (@PartnerID, @ContactID) ";
        private const string SQL_DELETE_PARTNERCONTACT = "DELETE FROM partnercontact WHERE ID=@ID";
        private const string SQL_UPDATE_PARTNERCONTACT = "UPDATE partnercontact SET PartnerID = @PartnerID, ContactID = @ContactID WHERE ID = @ID";
        private const string SQL_SELECT_PARTNERCONTACT = "SELECT * FORM partnercontact";
        private const string SQL_SELECT_PARTNERCONTACT_BY_ID = "SELECT * FROM partnercontact WHERE ID = @ID";
        private const string SQL_SELECT_PARTNERCONTACT_BY_PARTNER_CONTACT = "SELECT * FROM partnercontact WHERE PartnerID = @PartnerID AND ContactID = @ContactID";

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
                parms[0].Value = partnerContactInfo.PartnerID;
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
                parms[0].Value = partnerContactInfo.PartnerID;
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
                        PartnerContactInfo partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
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
        /// 根据文档合作伙伴联系人编号查找合作伙伴联系人
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
                        partnerContactInfo = new PartnerContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
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

        #endregion

    }
}
