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
    public class ClinicalResource : IClinicalResource
    {
        private const string PARM_CLINICALID = "@ClinicalID";
        private const string PARM_USERID = "@UserID";
        private const string PARM_CITY = "@City";
        private const string PARM_HOSPITAL = "@Hospital";
        private const string PARM_DEPARTMENT = "@Department";
        private const string PARM_DEPARTMENTINTRO = "@DepartIntro";

        private const string SQL_INSERT_CLINICALRESOURCE = "insert into clinicalresource(UserID,City,Hospital,Department,DepartIntro) values(@UserID,@City,@Hospital,@Department,@DepartIntro)";
        private const string SQL_DELETE_CLINICALRESOURCE = "delete from clinicalresource where ClinicalID=@ClinicalID";
        private const string SQL_UPDATE_CLINICALRESOURCE = "update clinicalresource set UserID=@UserID,City=@City,Hospital=@Hospital,Department=@Department,DepartIntro=@DepartIntro where ClinicalID=@ClinicalID";
        private const string SQL_SELECT_CLINICALRESOURCES = "select * from clinicalresource";
        private const string SQL_SELECT_CLINICALRESOURCE_BY_CLINICALID = "select * from clinicalresource where ClinicalID=@ClinicalID";
        private const string SQL_SELECT_CLINICALRESOURCE_BY_USERID = "select * from clinicalresource where UserID=@UserID";
        private const string SQL_SELECT_CONTACT_BY_CLINICALID = "select * from contact where ContactID  in (select ContactID from clinicalcontact where ClinicalID=@ClinicalID)";

        #region IClinicalResource 成员

        /// <summary>
        /// 新增临床资源
        /// </summary>
        /// <param name="clinicalResourceInfo"></param>
        /// <returns></returns>
        public int InsertClinicalResource(ClinicalResourceInfo clinicalResourceInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_HOSPITAL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTMENTINTRO,MySqlDbType.VarChar,200)
                };

                if (clinicalResourceInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = clinicalResourceInfo.UserID;

                parms[1].Value = clinicalResourceInfo.City;
                parms[2].Value = clinicalResourceInfo.Hospital;
                parms[3].Value = clinicalResourceInfo.Department;
                parms[4].Value = clinicalResourceInfo.DepartIntro;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CLINICALRESOURCE, parms);

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
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public int DeleteClinicalResource(int clinicalId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLINICALID, MySqlDbType.Int32);
                parm.Value = clinicalId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CLINICALRESOURCE, parm);
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
        /// <param name="clinicalResourceInfo"></param>
        /// <returns></returns>
        public int UpdateClinicalResource(ClinicalResourceInfo clinicalResourceInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_HOSPITAL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTMENTINTRO,MySqlDbType.VarChar,200),
                    new MySqlParameter(PARM_CLINICALID,MySqlDbType.Int32,50)
                };

                if (clinicalResourceInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = clinicalResourceInfo.UserID;
                parms[1].Value = clinicalResourceInfo.City;
                parms[2].Value = clinicalResourceInfo.Hospital;
                parms[3].Value = clinicalResourceInfo.Department;
                parms[4].Value = clinicalResourceInfo.DepartIntro;
                parms[5].Value = clinicalResourceInfo.ClinicalID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CLINICALRESOURCE, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据查询条件查找合作伙伴资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResourceByCondition(string selectCondition)
        {

            string sqlString;
            if (selectCondition == "")
            {
                sqlString = "SELECT * FROM clinicalresource ";
            }
            else
            {
                sqlString = "SELECT * FROM clinicalresource WHERE " + selectCondition;
            }
            IList<ClinicalResourceInfo> clinicalResources = new List<ClinicalResourceInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, sqlString, null))
                {
                    while (rdr.Read())
                    {
                        ClinicalResourceInfo clinicalResourceInfo = new ClinicalResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                        clinicalResources.Add(clinicalResourceInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalResources;

        }


        /// <summary>
        /// 查找所有临床资源
        /// </summary>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResources()
        {
            IList<ClinicalResourceInfo> clinicalResourceInfos = new List<ClinicalResourceInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLINICALRESOURCES, null))
                {
                    while (rdr.Read())
                    {
                        ClinicalResourceInfo clinicalResourceInfo = new ClinicalResourceInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0: rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                        clinicalResourceInfos.Add(clinicalResourceInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalResourceInfos;

        }

        /// <summary>
        /// 根据ID查找临床资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalResourceInfo GetClinicalResourceById(int id)
        {
            ClinicalResourceInfo clinicalResourceInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLINICALID, MySqlDbType.VarChar, 50);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLINICALRESOURCE_BY_CLINICALID, parm))
                {
                    if (rdr.Read())
                        clinicalResourceInfo = new ClinicalResourceInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                    else
                        clinicalResourceInfo = new ClinicalResourceInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalResourceInfo;
        }

        /// <summary>
        /// 根据用户ID查找临床资源
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResourceByUserId(int userId)
        {
            IList<ClinicalResourceInfo> clinicalResourceInfos = new List<ClinicalResourceInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32, 50);
                parm.Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLINICALRESOURCE_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ClinicalResourceInfo clinicalResource = new ClinicalResourceInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                        clinicalResourceInfos.Add(clinicalResource);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clinicalResourceInfos;
        }

        /// <summary>
        /// 根据用户ID查找临床资源
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ContactInfo> GetContactByClinicalResourceId(int clinicalResourceId)
        {
            IList<ContactInfo> contactInfos = new List<ContactInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLINICALID, MySqlDbType.Int32, 50);
                parm.Value = clinicalResourceId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_CLINICALID, parm))
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

