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
    public class User:IUser
    {

        private const string PARM_USERID = "@UserID";
        private const string PARM_USERNAME = "@UserName";
        private const string PARM_PASSWORD = "@Password";
        private const string PARM_USERTYPE = "@UserType";
        private const string PARM_USEREMAIL = "@UserEmail";
        private const string PARM_USERPHONE = "@UserPhone";
        private const string PARM_DepartID = "@DepartID";

        private const string SQL_INSERT_USER = "insert into user(UserName,Password,UserType,UserEmail,UserPhone,DepartID) values(@UserName,@Password,@UserType,@UserEmail,@UserPhone,@DepartID)";
        private const string SQL_DELETE_USER = "delete from user where UserID=@UserID";
        private const string SQL_UPDATE_USER = "update user set UserName=@UserName,Password=@Password,UserType=@UserType,UserEmail=@UserEmail,UserPhone=@UserPhone,DepartID=@DepartID where UserID=@UserID";
        private const string SQL_SELECT_USERS = "select * from user";
        private const string SQL_SELECT_USER_BY_NAME = "select * from user where UserName=@UserName";
        private const string SQL_SELECT_USER_BY_ID = "select * from user where UserID=@UserID";


        #region IUser 成员

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertUser(UserInfo userInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PASSWORD,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USEREMAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DepartID,MySqlDbType.Int32,50)
                };
                parms[0].Value = userInfo.UserName;
                parms[1].Value = userInfo.Password;
                parms[2].Value = userInfo.UserType;
                parms[3].Value = userInfo.UserEmail;
                parms[4].Value = userInfo.UserPhone;
                parms[5].Value = userInfo.DepartID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString,CommandType.Text,SQL_INSERT_USER,parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUser(int userId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID,MySqlDbType.Int32);
                parm.Value = userId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString,CommandType.Text,SQL_DELETE_USER,parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);    
            }
            return result;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateUser(UserInfo userInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_USERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PASSWORD,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USEREMAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERPHONE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DepartID,MySqlDbType.Int32),
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32)
                };
                parms[0].Value = userInfo.UserName;
                parms[1].Value = userInfo.Password;
                parms[2].Value = userInfo.UserType;
                parms[3].Value = userInfo.UserEmail;
                parms[4].Value = userInfo.UserPhone;
                parms[5].Value = userInfo.DepartID;
                parms[6].Value = userInfo.UserID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString,CommandType.Text,SQL_UPDATE_USER,parms);
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
        public IList<UserInfo> GetUsers()
        {
            IList<UserInfo> users = new List<UserInfo>();

            try
            {
                using(MySqlDataReader rdr=DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString,CommandType.Text,SQL_SELECT_USERS,null))
                {
                    while(rdr.Read())
                    {
                        UserInfo user = new UserInfo(rdr.GetInt32(0),rdr.GetString(1),rdr.GetString(2),rdr.GetString(3),rdr.GetString(4),rdr.GetString(5),rdr.GetInt32(6));
                        users.Add(user);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return users;

        }

        /// <summary>
        /// 根据用户名查找用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo GetUserByName(string userName)
        {
            UserInfo userInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERNAME,MySqlDbType.VarChar,50);
                parm.Value = userName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_USER_BY_NAME,parm))
                {
                    if (rdr.Read())
                        userInfo = new UserInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetInt32(6));
                    else
                        userInfo = new UserInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return userInfo;
        }

        /// <summary>
        /// 根据用户编号查找用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfo GetUserById(int userId)
        {
            UserInfo userInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID,MySqlDbType.Int32);
                parm.Value = userId;

                using(MySqlDataReader rdr=DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString,CommandType.Text,SQL_SELECT_USER_BY_ID,parm))
                {
                    if (rdr.Read())
                    {
                        userInfo = new UserInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetInt32(6));
                    }
                    else
                        userInfo = new UserInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return userInfo;
        }

        #endregion
    }
}
