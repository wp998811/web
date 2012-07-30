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
    public class ClinicalContact : IClinicalContact
    {
        private const string PARM_ID = "@ID";
        private const string PARM_CLINICALID = "@ClinicalID";
        private const string PARM_CONTACTID = "@ContactID";

        private const string SQL_INSERT_CLINICALCONTACT = "insert into clinicalcontact(ClinicalID,ContactID) values(@ClinicalID,@ContactID)";
        private const string SQL_DELETE_CLINICALCONTACT = "delete from clinicalcontact where ID=@ID";
        private const string SQL_UPDATE_CLINICALCONTACT = "update clinicalcontact set ClinicalID=@ClinicalID,ContactID=@ContactID where ID=@ID";
        private const string SQL_SELECT_CLINICALCONTACTS = "select * from clinicalcontact";
        private const string SQL_SELECT_CLINICALCONTACT_BY_ID = "select * from clinicalcontact where ID=@ID";

        #region IClinicalContact 成员

        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="clinicalContactInfo"></param>
        /// <returns></returns>
        public int InsertClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CLINICALID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50)
                };
                parms[0].Value = clinicalContactInfo.ClinicalID;
                parms[1].Value = clinicalContactInfo.ContactID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CLINICALCONTACT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除临床资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteClinicalContact(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CLINICALCONTACT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新临床资源
        /// </summary>
        /// <param name="clinicalContactInfo"></param>
        /// <returns></returns>
        public int UpdateClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CLINICALID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,50)
                };
                parms[0].Value = clinicalContactInfo.ClinicalID;
                parms[1].Value = clinicalContactInfo.ContactID;
                parms[2].Value = clinicalContactInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CLINICALCONTACT, parms);
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
        public IList<ClinicalContactInfo> GetClinicalContacts()
        {
            IList<ClinicalContactInfo> clinicalContactInfos = new List<ClinicalContactInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLINICALCONTACTS, null))
                {
                    while (rdr.Read())
                    {
                        ClinicalContactInfo clinicalContactInfo = new ClinicalContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                        clinicalContactInfos.Add(clinicalContactInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalContactInfos;

        }

        /// <summary>
        /// 根据ID查找临床资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalContactInfo GetClinicalContactById(int id)
        {
            ClinicalContactInfo clinicalContactInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 50);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLINICALCONTACT_BY_ID, parm))
                {
                    if (rdr.Read())
                        clinicalContactInfo = new ClinicalContactInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2));
                    else
                        clinicalContactInfo = new ClinicalContactInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalContactInfo;
        }

        #endregion
    }
}
