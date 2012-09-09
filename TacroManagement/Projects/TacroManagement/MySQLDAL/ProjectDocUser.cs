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
    public class ProjectDocUser : IProjectDocUser
    {
        private const string PARM_ID = "@ID";
        private const string PARM_PROJECTDOC_ID = "@ProjDocID";
        private const string PARM_USERID = "@UserID";

        private const string SQL_INSERT_PROJECTDOC_USER = "insert into projectdocuser(ProjDocID, UserID) values(@ProjDocID, @UserID)";
        private const string SQL_DELETE_PROJECTDOC_USER = "delete from projectdocuser where ID=@ID";
        private const string SQL_DELETE_PROJECTDOC_USER_BY_PROJDOCID = "delete from projectdocuser where ProjDocID=@ProjDocID";
        private const string SQL_UPDATE_PROJECTDOC_USER = "update projectdocuser set ProjDocID=@ProjDocID, UserID=@UserID where ID=@ID";
        private const string SQL_SELECT_PROJECTDOC_USERS = "select * from projectdocuser";
        private const string SQL_SELECT_PROJECTDOC_USER_BY_ID = "select * from projectdocuser where ID=@ID";
        private const string SQL_SELECT_PROJECTDOC_USER_BY_USERID = "select * from projectdocuser where UserID=@UserID";
        private const string SQL_SELECT_PROJECTDOC_USER_BY_PROJECTDOC_ID = "select * from projectdocuser where ProjDocID=@ProjDocID";
        private const string SQL_SELECT_PROJECTDOC_USER_BY_PROJECTDOC_USER = "select * from projectdocuser where ProjDocID=@ProjDocID and UserID=@UserID";


        #region IProjectDocUser 成员

        public int InsertProjectDocUser(ProjDocUserInfo projectDocInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECTDOC_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_USERID, MySqlDbType.VarChar,50)
                };
               
                if (projectDocInfo.ProjDocId == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = projectDocInfo.ProjDocId;

                if ( projectDocInfo.UserId == "")
                    parms[1].Value=DBNull.Value;
                else
                    parms[1].Value = projectDocInfo.UserId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PROJECTDOC_USER, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProjectDocUser(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJECTDOC_USER, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProjectDocUserByDocId(int ProjDocId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECTDOC_ID, MySqlDbType.Int32);
                parm.Value = ProjDocId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJECTDOC_USER_BY_PROJDOCID, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateProjectDocUser(ProjDocUserInfo projectDocInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECTDOC_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_USERID, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ID, MySqlDbType.Int32)
                };

                if (projectDocInfo.ProjDocId == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = projectDocInfo.ProjDocId;

                if (projectDocInfo.UserId == "")
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = projectDocInfo.UserId;
                parms[2].Value = projectDocInfo.Id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PROJECTDOC_USER, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public ProjDocUserInfo GetProjectDocUserById(int id)
        {
            ProjDocUserInfo projectDocUser = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTDOC_USER_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        projectDocUser = new ProjDocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? "" : rdr.GetString(2));
                    }
                    else
                        projectDocUser = new ProjDocUserInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocUser;
        }

        public IList<ProjDocUserInfo> GetProjectDocUsers()
        {
            IList<ProjDocUserInfo> projectDocUsers = new List<ProjDocUserInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTDOC_USERS, null))
                {
                    while (rdr.Read())
                    {
                        ProjDocUserInfo projectDocUser = new ProjDocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? "" : rdr.GetString(2));
                        projectDocUsers.Add(projectDocUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocUsers;
        }

        public IList<ProjDocUserInfo> GetProjectDocUserByDocId(int docId)
        {
            IList<ProjDocUserInfo> projectDocUsers = new List<ProjDocUserInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECTDOC_ID, MySqlDbType.Int32);
                parm.Value = docId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTDOC_USER_BY_PROJECTDOC_ID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjDocUserInfo projectDocUser = new ProjDocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? "" : rdr.GetString(2));
                        projectDocUsers.Add(projectDocUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocUsers;
        }

        public IList<ProjDocUserInfo> GetProjectDocUserByUserId(int userId)
        {
            IList<ProjDocUserInfo> projectDocUsers = new List<ProjDocUserInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.VarChar, 50);
                parm.Value = userId.ToString();
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTDOC_USER_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjDocUserInfo projectDocUser = new ProjDocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? "" : rdr.GetString(2));
                        projectDocUsers.Add(projectDocUser);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocUsers;
        }

        public ProjDocUserInfo GetProjectDocUserByProjectDocUser(int docID,int userID)
        {
            ProjDocUserInfo projectDocUser = null;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECTDOC_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_USERID, MySqlDbType.Int32),
                };
                parms[0].Value = docID;
                parms[1].Value = userID;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTDOC_USER_BY_PROJECTDOC_USER, parms))
                {
                    if (rdr.Read())
                    {
                        projectDocUser = new ProjDocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? "" : rdr.GetString(2));
                    }
                    else
                        projectDocUser = new ProjDocUserInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocUser;
        }
        #endregion
    }
}
