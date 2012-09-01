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
    public class Client : IClient
    {
        private const string PARM_CLIENTID = "@ClientID";
        private const string PARM_CLIENTNAME = "@ClientName";
        private const string PARM_CLIENTCOMPANY = "@ClientCompany";

        private const string SQL_INSERT_CLIENT = "insert into client(ClientName,ClientCompany) values(@ClientName,@ClientCompany)";
        private const string SQL_DELETE_CLIENT = "delete from client where ClientID=@ClientID";
        private const string SQL_UPDATE_CLIENT = "update client set ClientName=@ClientName,ClientCompany=@ClientCompany where ClientID=@ClientID";
        private const string SQL_SELECT_CLIENTS = "select * from client";
        private const string SQL_SELECT_CLIENT_BY_NAME = "select * from client where ClientName=@ClientName";
        private const string SQL_SELECT_CLIENT_BY_ID = "select * from client where ClientID=@ClientID";

        #region IClient 成员

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public int InsertClient(ClientInfo clientInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CLIENTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CLIENTCOMPANY,MySqlDbType.VarChar,50),
                };
                parms[0].Value = clientInfo.ClientName;
                parms[1].Value = clientInfo.ClientCompany;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CLIENT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public int DeleteClient(int clientID)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLIENTID, MySqlDbType.Int32);
                parm.Value = clientID;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CLIENT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public int UpdateClient(ClientInfo clientInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_CLIENTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CLIENTCOMPANY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CLIENTID,MySqlDbType.Int32)
                };
                parms[0].Value = clientInfo.ClientName;
                parms[1].Value = clientInfo.ClientCompany;
                parms[2].Value = clientInfo.ClientID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CLIENT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有客户
        /// </summary>
        /// <returns></returns>
        public IList<ClientInfo> GetClients()
        {
            IList<ClientInfo> clients = new List<ClientInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLIENTS, null))
                {
                    while (rdr.Read())
                    {
                        ClientInfo client = new ClientInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                        clients.Add(client);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clients;
        }

        /// <summary>
        /// 根据客户名称查找客户
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public ClientInfo GetClientByName(string clientName)
        {
            ClientInfo clientInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLIENTNAME, MySqlDbType.VarChar, 50);
                parm.Value = clientName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLIENT_BY_NAME, parm))
                {
                    if (rdr.Read())
                        clientInfo = new ClientInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                    else
                        clientInfo = new ClientInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return clientInfo;
        }

        /// <summary>
        /// 根据客户编号查找客户
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public ClientInfo GetClientById(int clientID)
        {
            ClientInfo clientInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CLIENTID, MySqlDbType.Int32);
                parm.Value = clientID;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CLIENT_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        clientInfo = new ClientInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                    }
                    else
                        clientInfo = new ClientInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return clientInfo;
        }

        #endregion
    }
}