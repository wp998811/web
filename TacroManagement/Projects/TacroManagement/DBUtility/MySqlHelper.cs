using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Configuration;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace DBUtility
{
    public abstract class MySqlHelper
    {
        //数据库连接字符串(web.config来配置)
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            cmd.Parameters.Clear();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                {
                    MySqlParameter clonedParm = (MySqlParameter)((ICloneable)parm).Clone();
                    cmd.Parameters.Add(clonedParm);
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {

            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            //connection.Close();
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            // trans.Connection.Close();
            return val;

        }

        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                cmd.Parameters.Clear();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                //conn.Close();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                //connection.Close();
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            // connection.Close();
            return val;
        }
    }
}
