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
    public class Affair : IAffair
    {
        private const string PARM_AFFAIRID = "@AffairID";
        private const string PARM_AFFAIR_DESCRIPTION = "@AffairDescription";
        private const string PARM_AFFAIR_OPERATOR_ID = "@AffairOperatorID";
        private const string PARM_AFFAIR_TIME = "@AffairTime";
        private const string PARM_PROJECT_NUM = "@ProjectNum";

        private const string SQL_INSERT_AFFAIR = "insert into affair(AffairDescription, AffairOperatorID, AffairTime, ProjectNum) values(@AffairDescription, @AffairOperatorID, @AffairTime, @ProjectNum)";
        private const string SQL_DELETE_AFFAIR = "delete from affair where AffairID=@AffairID";
        private const string SQL_UPDATE_AFFAIR = "update affair set AffairDescription=@AffairDescription, AffairOperatorID=@AffairOperatorID, AffairTime=@AffairTime, ProjectNum=@ProjectNum where AffairID=@AffairID";
        private const string SQL_SELECT_AFFAIRS = "select * from affair";
        private const string SQL_SELECT_AFFAIR_BY_ID = "select * from affair where AffairID=@AffairID";
        private const string SQL_SELECT_AFFAIRS_BY_OPERATORID = "select * from affair where AffairOperatorID=@AffairOperatorID ORDER BY AffairTime DESC";
        private const string SQL_SELECT_AFFAIRS_BY_PROJECT_NUM = "select * from affair where ProjectNum=@ProjectNum ORDER BY AffairTime DESC";
        private const string SQL_SELECT_AFFAIRS_BY_DATE = "select * from affair where AffairTime=@AffairTime";


        #region IAffair 成员

        public int InsertAffair(AffairInfo affairInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_AFFAIR_DESCRIPTION, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_AFFAIR_OPERATOR_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_AFFAIR_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50)
                };
                parms[0].Value = affairInfo.AffairDescription;
                parms[1].Value = affairInfo.AffairOperatorId;
                parms[2].Value = affairInfo.AffairTime;
                parms[3].Value = affairInfo.ProjectNum;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_AFFAIR, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteAffair(int affairId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_AFFAIRID, MySqlDbType.Int32);
                parm.Value = affairId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_AFFAIR, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateAffair(AffairInfo affairInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_AFFAIR_DESCRIPTION, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_AFFAIR_OPERATOR_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_AFFAIR_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_AFFAIRID, MySqlDbType.Int32)
                };
                parms[0].Value = affairInfo.AffairDescription;
                parms[1].Value = affairInfo.AffairOperatorId;
                parms[2].Value = affairInfo.AffairTime;
                parms[3].Value = affairInfo.ProjectNum;
                parms[4].Value = affairInfo.AffairId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_AFFAIR, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<AffairInfo> GetAffairs()
        {
            IList<AffairInfo> affairs = new List<AffairInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_AFFAIRS, null))
                {
                    while (rdr.Read())
                    {
                        AffairInfo affair = new AffairInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                        affairs.Add(affair);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return affairs;
        }

        public IList<AffairInfo> GetAffairsByProjectNumDescending(string projectNum)
        {
            IList<AffairInfo> affairs = new List<AffairInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_AFFAIRS_BY_PROJECT_NUM, parm))
                {
                    while (rdr.Read())
                    {
                        AffairInfo affair = new AffairInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                        affairs.Add(affair);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return affairs;
        }

        public IList<AffairInfo> GetAffairsByOperatorIdDescending(int operatorId)
        {
            IList<AffairInfo> affairs = new List<AffairInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_AFFAIR_OPERATOR_ID, MySqlDbType.Int32);
                parm.Value = operatorId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_AFFAIRS_BY_OPERATORID, parm))
                {
                    while (rdr.Read())
                    {
                        AffairInfo affair = new AffairInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                        affairs.Add(affair);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return affairs;
        }

        public IList<AffairInfo> GetAffairsByDate(string date)
        {
            IList<AffairInfo> affairs = new List<AffairInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_AFFAIR_TIME, MySqlDbType.VarChar, 50);
                parm.Value = date;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_AFFAIRS_BY_DATE, parm))
                {
                    while (rdr.Read())
                    {
                        AffairInfo affair = new AffairInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                        affairs.Add(affair);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return affairs;
        }

        public AffairInfo GetAffairById(int affairId)
        {
            AffairInfo affair = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_AFFAIR_TIME, MySqlDbType.VarChar, 50);
                parm.Value = affairId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_AFFAIR_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        affair = new AffairInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                    }
                    else
                        affair = new AffairInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return affair;
        }

        #endregion
    }
}
