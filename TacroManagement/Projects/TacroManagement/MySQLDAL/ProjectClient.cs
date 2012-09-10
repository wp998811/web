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
    public class ProjectClient : IProjectClient
    {
        private const string PARM_ID = "@ID";
        private const string PARM_PROJECT_NUM = "@ProjectNum";
        private const string PARM_CLIENT_ID = "@ClientID";

        private const string SQL_INSERT_PROJECT_CLIENT = "insert into projectclient(ProjectNum, ClientID) values(@ProjectNum, @ClientID)";
        private const string SQL_DELETE_PROJECT_CLIENT = "delete from projectclient where ID=@ID";
        private const string SQL_UPDATE_PROJECT_CLIENT = "update projectclient set ProjectNum=@ProjectNum, ClientID=@ClientID where ID=@ID";
        private const string SQL_SELECT_PROJECT_CLIENTS = "select * from projectclient";
        private const string SQL_SELECT_PROJECT_CLIENT_BY_ID = "select * from projectclient where ID=@ID";
        private const string SQL_SELECT_PROJECT_CLIENT_BY_CLIENTID = "select * from projectclient where ClientID=@ClientID";
        private const string SQL_SELECT_PROJECT_CLIENT_BY_PROJECT_NUM = "select * from projectclient where ProjectNum=@ProjectNum";

        #region IProjectClient 成员

        public int InsertProjectClient(ProjectClientInfo projectClientInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_CLIENT_ID, MySqlDbType.Int32)
                };

                if (projectClientInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = projectClientInfo.ProjectNum;
               
                if(projectClientInfo.ClientId == 0)
                    parms[1].Value=DBNull.Value;
                else
                    parms[1].Value=projectClientInfo.ClientId;
             
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PROJECT_CLIENT, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProjectClient(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJECT_CLIENT, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateProjectClient(ProjectClientInfo projectClientInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_CLIENT_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_ID, MySqlDbType.Int32)
                };
                if (projectClientInfo.ProjectNum == "")
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = projectClientInfo.ProjectNum;

                if (projectClientInfo.ClientId == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = projectClientInfo.ClientId;
                parms[2].Value = projectClientInfo.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PROJECT_CLIENT, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ProjectClientInfo> GetProjectClients()
        {
            IList<ProjectClientInfo> projectClients = new List<ProjectClientInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_CLIENTS, null))
                {
                    while (rdr.Read())
                    {
                        ProjectClientInfo projectClient = new ProjectClientInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectClients.Add(projectClient);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectClients;
        }

        public ProjectClientInfo GetProjectClientById(int id)
        {
            ProjectClientInfo projectClient = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_CLIENT_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        projectClient = new ProjectClientInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    }
                    else
                        projectClient = new ProjectClientInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectClient;
        }

        public IList<ProjectClientInfo> GetProjectClientsByProjectNum(string projectNum)
        {
            IList<ProjectClientInfo> projectClients = new List<ProjectClientInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_CLIENT_BY_ID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectClientInfo projectClient = new ProjectClientInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectClients.Add(projectClient);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectClients;
        }

        public IList<ProjectClientInfo> GetProjectClientsByClientId(int clientId)
        {
            IList<ProjectClientInfo> projectClients = new List<ProjectClientInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLIENT_ID, MySqlDbType.Int32);
                parm.Value = clientId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_CLIENT_BY_CLIENTID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectClientInfo projectClient = new ProjectClientInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? "" : rdr.GetString(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        projectClients.Add(projectClient);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectClients;
        }

        #endregion
    }
}
