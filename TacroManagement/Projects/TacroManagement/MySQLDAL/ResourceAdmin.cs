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
    class ResourceAdmin : IResourceAdmin
    {
        private const string PARM_RESOURCEID = "@Id";
        private const string PARM_USERID = "@UserId";
        private const string PARM_RESOURCETYPE = "@ResourceType";

        private const string SQL_UPDATE_RESOURCEADMIN = "update resourceadmin set UserId=@UserId,ResourceType=@ResourceType";
        private const string SELECT_USER_BY_RESOURCETYPE_AND_USERID= "select * from resourceadmin where ResourceType=@ResourceType and UserId=@UserId";

        #region IResourceAdmin 成员

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_RESOURCETYPE,MySqlDbType.VarChar,50)
                };
                parms[0].Value = resourceAdminInfo.UserID;
                parms[1].Value = resourceAdminInfo.ResourceType;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_RESOURCEADMIN, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据用户编号查找用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResourceAdminInfo GetResourceAdminByResourceTypeAndUserID(int userID, string resourceType)
        {
            ResourceAdminInfo resourceAdminInfo = null;

            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_RESOURCETYPE,MySqlDbType.VarChar,50)
                };
                parms[0].Value = userID;
                parms[1].Value = resourceType;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SELECT_USER_BY_RESOURCETYPE_AND_USERID, parms))
                {
                    if (rdr.Read())
                    {
                        resourceAdminInfo = new ResourceAdminInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2));
                    }
                    else
                        resourceAdminInfo = new ResourceAdminInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return resourceAdminInfo;
        }

        #endregion
    }
}
