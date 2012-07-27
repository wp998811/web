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
    public class GoverResource:IGoverResource
    {

        #region GoverResource Constant String

        private const string PARM_PARTNERID = "@GoverID";
        private const string PARM_USERID ="@UserID";
        private const string PARM_PARTNERCITY ="@GoverCity";
        private const string PARM_ORGANNAME="@OrganName";
        private const string PARM_ORGANINTRO = "@OranIntro";

        private const string SQL_INSERT_PARTNERRESOURCE = "INSERT INTO goverresource(UserID, GoverCity, OrganName, OrganIntro) VALUES (@UserID, @GoverCity, @OrganName, @OrganIntro) ";
        private const string SQL_DELETE_PARTNERRESOURCE = "DELETE FROM goverresource WHERE GoverID=@GoverID";
        private const string SQL_UPDATE_PARTNERRESOURCE = "UPDATE goverresource SET UserID = @UserID, GoverCity =@GoverCity, OrganName =@OrganName, OrganIntro =@OrganIntro WHERE GoverID = @GoverID";
        private const string SQL_SELECT_PARTNERRESOURCE = "SELECT * FORM goverresource";
        private const string SQL_SELECT_PARTNERRESOURCE_BY_ID = "SELECT * FORM goverresource WHERE GoverID = @GoverID";





        #endregion




        #region IGoverResource Members


        /// <summary>
        /// 新增政府资料
        /// </summary>
        /// <param name="goverResourceInfo"></param>
        /// <returns></returns>
        int IGoverResource.InsertGoverResource(GoverResourceInfo goverResourceInfo)
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
                parms[0].Value = goverResourceInfo.UserID;
                parms[1].Value = goverResourceInfo.GoverCity;
                parms[2].Value = goverResourceInfo.OrganName;
                parms[3].Value = goverResourceInfo.OrganIntro;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PARTNERRESOURCE, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除政府资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IGoverResource.DeleteGoverResource(int id)
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
        /// 更新政府资料
        /// </summary>
        /// <param name="goverResourceInfo"></param>
        /// <returns></returns>
        int IGoverResource.UpdeteGoverResource(GoverResourceInfo goverResourceInfo)
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
               parms[0].Value = goverResourceInfo.UserID;
               parms[1].Value = goverResourceInfo.GoverCity;
               parms[2].Value = goverResourceInfo.OrganName;
               parms[3].Value = goverResourceInfo.OrganIntro;
               parms[4].Value = goverResourceInfo.GoverID;


               result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PARTNERRESOURCE, parms);
           }
           catch (MySqlException se)
           {
               Console.WriteLine(se.Message);
           }
           return result;

        }

        /// <summary>
        /// 查找政府资料
        /// </summary>
        /// <returns></returns>
        IList<GoverResourceInfo> IGoverResource.GetGoverResource()
        {
            IList<GoverResourceInfo> goverResources = new List<GoverResourceInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERRESOURCE, null))
                {
                    while (rdr.Read())
                    {
                        GoverResourceInfo goverResource = new GoverResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                        goverResources.Add(goverResource);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverResources;
        }

        /// <summary>
        /// 根据政府资料编号查找政府资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GoverResourceInfo IGoverResource.GetGoverResourceById(int id)
        {
            GoverResourceInfo goverResourceInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PARTNERID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PARTNERRESOURCE_BY_ID, parm))
                {
                    if (rdr.Read())
                        goverResourceInfo = new GoverResourceInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                    else
                        goverResourceInfo = new GoverResourceInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return goverResourceInfo;
        }

        #endregion
    }
}
