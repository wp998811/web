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
    public class PartnerResource : IPartnerResource
    {
        #region PartnerResource Constant String

        private const string PARM_PARTNERID = "@PartnerID";
        private const string PARM_USERID = "@UserID";
        private const string PARM_PARTNERCITY = "@PartnerCity";
        private const string PARM_ORGANNAME = "@OrganName";
        private const string PARM_ORGANINTRO = "@OrganIntro";

        private const string SQL_INSERT_PARTNERRESOURCE = "INSERT INTO partnerresource(UserID, PartnerCity, OrganName, OrganIntro) VALUES (@UserID, @PartnerCity, @OrganName, @OrganIntro) ";
        private const string SQL_DELETE_PARTNERRESOURCE = "DELETE FROM partnerresource WHERE PartnerID=@PartnerID";
        private const string SQL_UPDATE_PARTNERRESOURCE = "UPDATE partnerresource SET UserID = @UserID, PartnerCity =@PartnerCity, OrganName =@OrganName, OrganIntro =@OrganIntro WHERE PartnerID = @PartnerID";
        private const string SQL_SELECT_PARTNERRESOURCE = "SELECT * FROM partnerresource";
        private const string SQL_SELECT_PARTNERRESOURCE_BY_ID = "SELECT * FROM partnerresource WHERE PartnerID = @PartnerID";
        private const string SQL_SELECT_CONTACT_BY_PARTNERID = "select * from contact where ContactID  in (select ContactID from partnercontact where PartnerID=@PartnerID)";

        #endregion




        #region IPartnerResource Members

        /// <summary>
        /// 新增合作伙伴资料
        /// </summary>
        /// <param name="partnerResourceInfo"></param>
        /// <returns></returns>
        int IPartnerResource.InsertPartnerResource(PartnerResourceInfo partnerResourceInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_PARTNERCITY,MySqlDbType.VarChar,50) ,
                    new MySqlParameter(PARM_ORGANNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ORGANINTRO,MySqlDbType.VarChar,200)
                };
                parms[0].Value = partnerResourceInfo.UserID;
                parms[1].Value = partnerResourceInfo.PartnerCity;
                parms[2].Value = partnerResourceInfo.OrganName;
                parms[3].Value = partnerResourceInfo.OrganIntro;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PARTNERRESOURCE, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除合作伙伴资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IPartnerResource.DeletePartnerResource(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PARTNERRESOURCE, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新合作伙伴资料
        /// </summary>
        /// <param name="partnerResourceInfo"></param>
        /// <returns></returns>
        int IPartnerResource.UpdetePartnerResource(PartnerResourceInfo partnerResourceInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_PARTNERCITY,MySqlDbType.VarChar,50) ,
                    new MySqlParameter(PARM_ORGANNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ORGANINTRO,MySqlDbType.VarChar,200),
                    new MySqlParameter(PARM_PARTNERID,MySqlDbType.Int32,11)
                };
                parms[0].Value = partnerResourceInfo.UserID;
                parms[1].Value = partnerResourceInfo.PartnerCity;
                parms[2].Value = partnerResourceInfo.OrganName;
                parms[3].Value = partnerResourceInfo.OrganIntro;
                parms[4].Value = partnerResourceInfo.PartnerID;


                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PARTNERRESOURCE, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;

        }

        /// <summary>
        /// 查找所有合作伙伴资料
        /// </summary>
        /// <returns></returns>
        IList<PartnerResourceInfo> IPartnerResource.GetPartnerResource()
        {
            IList<PartnerResourceInfo> partnerResources = new List<PartnerResourceInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERRESOURCE, null))
                {
                    while (rdr.Read())
                    {
                        PartnerResourceInfo partnerResource = new PartnerResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                        partnerResources.Add(partnerResource);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerResources;
        }

        /// <summary>
        /// 根据文档合作伙伴资料编号查找合作伙伴资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PartnerResourceInfo IPartnerResource.GetPartnerResourceById(int id)
        {
            PartnerResourceInfo partnerResourceInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERRESOURCE_BY_ID, parm))
                {
                    if (rdr.Read())
                        partnerResourceInfo = new PartnerResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                    else
                        partnerResourceInfo = new PartnerResourceInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerResourceInfo;
        }

        /// <summary>
        /// 根据查询条件查找合作伙伴资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<PartnerResourceInfo> GetPartnerResourceByCondition(string selectCondition)
        {

            string sqlString;
            if (selectCondition == "")
            {
                sqlString = "SELECT * FROM partnerresource ";
            }
            else
            {
                sqlString = "SELECT * FROM partnerresource WHERE " + selectCondition;
            }
            IList<PartnerResourceInfo> partnerResources = new List<PartnerResourceInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, sqlString, null))
                {
                    while (rdr.Read())
                    {
                        PartnerResourceInfo partnerResourceInfo = new PartnerResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                        partnerResources.Add(partnerResourceInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return partnerResources;

        }

        /// <summary>
        /// 根据ID查找合作伙伴资源
        /// </summary>
        /// <param name="partnerResourceId"></param>
        /// <returns></returns>
        public IList<ContactInfo> GetContactsByPartnerResourceId(int partnerResourceId)
        {
            IList<ContactInfo> contactInfos = new List<ContactInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32, 50);
                parm.Value = partnerResourceId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CONTACT_BY_PARTNERID, parm))
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