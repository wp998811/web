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
    public class ProjectUser : IProjectUser
    {
        private const string PARM_ID = "@ID";
        private const string PARM_PROJECT_NUM = "@ProjectNum";
        private const string PARM_USER_ID = "@UserID";

        private const string SQL_INSERT_PROJECT_USER = "insert into projectuser(ProjectNum, UserID) values(@ProjectNum, @UserID)";
        private const string SQL_DELETE_PROJECT_USER = "delete from projectuser where ID=@ID";
        private const string SQL_UPDATE_PROJECT_USER = "update projectuser set ProjectNum=@ProjectNum, UserID=@UserID where ID=@ID";
        private const string SQL_SELECT_PROJECT_USERS = "select * from projectuser";
        private const string SQL_SELECT_PROJECT_USER_BY_ID = "select * from projectuser where ID=@ID";
        private const string SQL_SELECT_PROJECT_USER_BY_USERID = "select * from projectuser where UserID=@UserID";
        private const string SQL_SELECT_PROJECT_USER_BY_PROJECT_NUM = "select * from projectuser where ProjectNum=@ProjectNum";
        private const string SQL_SELECT_PROJECT_USER_BY_USERID_PROJECT_NUM = "select * from projectuser where ProjectNum=@ProjectNum and UserID=@UserID";

        #region IProjectUser 成员

        public int InsertProjectUser(ProjectUserInfo projectUserInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32)
                };
               
                if (projectUserInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else  
                    parms[0].Value = projectUserInfo.ProjectNum;

                if (projectUserInfo.UserId == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = projectUserInfo.UserId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PROJECT_USER, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProjectUser(int Id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJECT_USER, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateProjectUser(ProjectUserInfo projectUserInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_ID, MySqlDbType.Int32)
                };

                if (projectUserInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = projectUserInfo.ProjectNum;

                if (projectUserInfo.UserId == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = projectUserInfo.UserId;
                parms[2].Value = projectUserInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PROJECT_USER, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ProjectUserInfo> GetProjectUsers()
        {
            IList<ProjectUserInfo> projectUsers = new List<ProjectUserInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_USERS, null))
                {
                    while (rdr.Read())
                    {
                        ProjectUserInfo projectUser = new ProjectUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectUsers.Add(projectUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectUsers;
        }

        public IList<ProjectUserInfo> GetProjectUsersByProjectNum(string projectNum)
        {
            IList<ProjectUserInfo> projectUsers = new List<ProjectUserInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_USER_BY_PROJECT_NUM, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectUserInfo projectUser = new ProjectUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectUsers.Add(projectUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectUsers;
        }

        public IList<ProjectUserInfo> GetProjectUsersByUserId(int userId)
        {
            IList<ProjectUserInfo> projectUsers = new List<ProjectUserInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32);
                parm.Value = userId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_USER_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectUserInfo projectUser = new ProjectUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectUsers.Add(projectUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectUsers;
        }

        public ProjectUserInfo GetProjectUserByProjectUser(string projectNum,int userId)
        {
            ProjectUserInfo projectUser = null;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_USER_ID, MySqlDbType.Int32)
                };

                parms[0].Value = projectNum;
                parms[1].Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_USER_BY_USERID_PROJECT_NUM, parms))
                {
                    if (rdr.Read())
                    {
                        projectUser = new ProjectUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    }
                    else
                        projectUser = new ProjectUserInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectUser;
        }


        public ProjectUserInfo GetProjectUserById(int id)
        {
            ProjectUserInfo projectUser = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_USER_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        projectUser = new ProjectUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    }
                    else
                        projectUser = new ProjectUserInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectUser;
        }

        #endregion
    }
}
