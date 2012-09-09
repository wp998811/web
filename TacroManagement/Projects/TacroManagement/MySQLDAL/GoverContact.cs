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
    public class GoverContact : IGoverContact
    {
        #region GoverContact Constant String

        private const string PARM_ID = "@ID";
        private const string PARM_GOVERID = "@GoverID";
        private const string PARM_CONTACTID = "@ContactID";

        private const string SQL_INSERT_GOVERCONTACT = "INSERT INTO govercontact(GoverID, ContactID) VALUES (@GoverID, @ContactID) ";
        private const string SQL_DELETE_GOVERCONTACT = "DELETE FROM govercontact WHERE ID=@ID";
        private const string SQL_UPDATE_GOVERCONTACT = "UPDATE govercontact SET GoverID = @GoverID, ContactID = @ContactID WHERE ID = @ID";
        private const string SQL_SELECT_GOVERCONTACT = "SELECT * FROM govercontact";
        private const string SQL_SELECT_GOVERCONTACT_BY_ID = "SELECT * FROM govercontact WHERE ID = @ID";
        private const string SQL_SELECT_GOVERCONTACT_BY_GOVER = "SELECT * FROM govercontact WHERE GoverID = @GoverID";
        private const string SQL_SELECT_GOVERCONTACT_BY_CONTACTID = "SELECT * FROM govercontact WHERE ContactID = @ContactID";
        private const string SQL_SELECT_GOVERCONTACT_BY_GOVER_CONTACT = "SELECT * FROM govercontact WHERE GoverID = @GoverID AND ContactID = @ContactID";

        #endregion


        #region IGoverContact Members

        /// <summary>
        /// 新增政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        int IGoverContact.InsertGoverContact(GoverContactInfo goverContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_GOVERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,11) 
                };
                if (goverContactInfo.GoverID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = goverContactInfo.GoverID;
                if(goverContactInfo.ContactID == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = goverContactInfo.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_GOVERCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IGoverContact.DeleteGoverContact(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_GOVERCONTACT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        int IGoverContact.UpdateGoverContact(GoverContactInfo goverContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_GOVERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,11) ,
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,11)
                };
                if (goverContactInfo.GoverID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = goverContactInfo.GoverID;
                if (goverContactInfo.ContactID == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = goverContactInfo.ContactID;
                parms[2].Value = goverContactInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_GOVERCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有政府联系人
        /// </summary>
        /// <returns></returns>
        IList<GoverContactInfo> IGoverContact.GetGoverContact()
        {
            IList<GoverContactInfo> goverContactInfos = new List<GoverContactInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_GOVERCONTACT, null))
                {
                    while (rdr.Read())
                    {
                        GoverContactInfo goverContactInfo = new GoverContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        goverContactInfos.Add(goverContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverContactInfos;
        }

        /// <summary>
        /// 根据文档政府联系人编号查找政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GoverContactInfo IGoverContact.GetGoverContactById(int id)
        {
            GoverContactInfo goverContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_GOVERCONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                        goverContactInfo = new GoverContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        goverContactInfo = new GoverContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverContactInfo;
        }

        /// <summary>
        /// 通过政府资料ID查找政府联系人
        /// </summary>
        /// <param name="goverId"></param>
        /// <returns></returns>
        public IList<GoverContactInfo> GetGoverContactByGover(int goverId)
        {
            IList<GoverContactInfo> goverContactInfos = new List<GoverContactInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_GOVERID, MySqlDbType.Int32, 11);
                parm.Value = goverId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_GOVERCONTACT_BY_GOVER, parm))
                {
                    while (rdr.Read())
                    {
                        GoverContactInfo goverContactInfo = new GoverContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        goverContactInfos.Add(goverContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverContactInfos;
        }

        /// <summary>
        /// 通过联系人ID查找政府联系人
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public GoverContactInfo GetGoverContactByContactId(int contactId)
        {
            GoverContactInfo goverContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32, 11);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_GOVERCONTACT_BY_CONTACTID, parm))
                {
                    if (rdr.Read())
                        goverContactInfo = new GoverContactInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        goverContactInfo = new GoverContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverContactInfo;
        }

        #endregion
    }
}