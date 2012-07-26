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
    public class Admin:IAdmin
    {
        private const string SQL_SELECT_ADMIN_BY_NAME = "SELECT * FROM Admin WHERE AdminName=@AdminName";
        private const string SQL_UPDATE_ADMIN = "UPDATE Admin SET AdminName = @AdminName, AdminPassword = @AdminPassword WHERE ID = @ID";

        private const string PARM_ID = "@ID";
        private const string PARM_ADMIN_NAME = "@AdminName";
        private const string PARM_ADMIN_PASSWORD = "@AdminPassword";

        MySqlParameter[] parms = { new MySqlParameter(Admin.PARM_ID,MySqlDbType.Int32),
                                 new MySqlParameter(Admin.PARM_ADMIN_NAME,MySqlDbType.VarChar,16),
                                 new MySqlParameter(Admin.PARM_ADMIN_PASSWORD,MySqlDbType.VarChar,16)};

        #region IAdmin 成员
        /// <summary>
        /// 根据名称得到管理员信息
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public AdminInfo GetAdminByName(string adminName)
        {
            AdminInfo admin=null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ADMIN_NAME,MySqlDbType.VarChar,16);
                parm.Value = adminName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_ADMIN_BY_NAME, parm))
                {
                    if (rdr.Read())
                    {
                        admin = new AdminInfo(rdr.GetString(1), rdr.GetString(2));
                    }
                    else
                        admin = new AdminInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return admin;
        }

        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="adminInfo"></param>
        /// <returns></returns>
        public int UpdateAdmin(AdminInfo adminInfo)
        {
            int result = -1;
            if (null == adminInfo)
            {
                return result;
            }
            try
            {
                parms[0].Value = adminInfo.ID;
                parms[1].Value = adminInfo.AdminName;
                parms[2].Value = adminInfo.AdminPassword;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, Admin.SQL_UPDATE_ADMIN, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return result;
        }

        #endregion
    }
}
