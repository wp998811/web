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
    public class ResourceAdmin : IResourceAdmin
    {
        private const string PARM_ID = "@ID";
        private const string PARM_USER_ID = "@UserID";
        private const string PARM_RESOURCE_TYPE = "@ResourceType";

        private const string SQL_INSERT_RESOURC_ADMIN = "insert into resourceadmin(UserID, ResourceType) values(@UserID, @ResourceType)";
        private const string SQL_DELETE_RESOURC_ADMIN = "delete from resourceadmin where ID=@ID";
        private const string SQL_UPDATE_RESOURC_ADMIN = "update resourceadmin set UserID=@UserID, ResourceType=@ResourceType where ID=@ID";

        private const string SQL_SELECT_RESOURC_ADMINS = "select * from resourceadmin";
        private const string SQL_SELECT_RESOURC_ADMIN_BY_ID = "select * from resourceadmin where ID=@ID";
        private const string SQL_SELECT_RESOURC_ADMIN_BY_USERID = "select * from resourceadmin where UserID=@UserID";


        #region IResourceAdmin 成员

        public int InsertResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_RESOURCE_TYPE, MySqlDbType.VarChar,50)
                };

                if (resourceAdminInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = resourceAdminInfo.UserID;

                parms[1].Value = resourceAdminInfo.ResourceType;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_RESOURC_ADMIN, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteResourceAdmin(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_RESOURC_ADMIN, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_RESOURCE_TYPE, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ID, MySqlDbType.Int32)
                };

                if (resourceAdminInfo.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = resourceAdminInfo.UserID;

                parms[1].Value = resourceAdminInfo.ResourceType;
                parms[2].Value = resourceAdminInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_RESOURC_ADMIN, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ResourceAdminInfo> GetResourceAdmins()
        {
            IList<ResourceAdminInfo> resourceAdmins = new List<ResourceAdminInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_RESOURC_ADMINS, null))
                {
                    while (rdr.Read())
                    {
                        ResourceAdminInfo resourceAdmin;
                        if (rdr.IsDBNull(1))
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), 0, rdr.GetString(2));
                        else
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2));
                        resourceAdmins.Add(resourceAdmin);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resourceAdmins;
        }

        public IList<ResourceAdminInfo> GetResourceAdminsByUserID(int userID)
        {

            IList<ResourceAdminInfo> resourceAdmins = new List<ResourceAdminInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USER_ID, MySqlDbType.VarChar, 50);
                parm.Value = userID;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_RESOURC_ADMIN_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ResourceAdminInfo resourceAdmin;
                        if (rdr.IsDBNull(1))
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), 0, rdr.GetString(2));
                        else
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2));
                        resourceAdmins.Add(resourceAdmin);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resourceAdmins;
        }

        public ResourceAdminInfo GetResourceAdminByID(int id)
        {
            ResourceAdminInfo resourceAdmin = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_RESOURC_ADMIN_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        if (rdr.IsDBNull(1))
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), 0, rdr.GetString(2));
                        else
                            resourceAdmin = new ResourceAdminInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2));
                    }
                    else
                        resourceAdmin = new ResourceAdminInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resourceAdmin;
        }

        #endregion
    }
}
