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
    public class VisitRecord : IVisitRecord
    {
        private const string PARM_ID = "@ID";
        private const string PARM_CONTACTID = "@ContactID";
        private const string PARM_VISITDETAIL = "@VisitDetail";
        private const string PARM_RECORDTIME = "@RecordTime";
        private const string PARM_USERID = "@UserID";

        private const string SQL_INSERT_VISITRECORD = "insert into visitrecord(ContactID,VisitDetail,RecordTime,UserID) values(@ContactID,@VisitDetail,@RecordTime,@UserID)";
        private const string SQL_DELETE_VISITRECORD = "delete from visitrecord where ID=@ID";
        private const string SQL_UPDATE_VISITRECORD = "update visitrecord set ContactID=@ContactID,VisitDetail=@VisitDetail,RecordTime=@RecordTime,UserID=@UserID where ID=@ID";
        private const string SQL_SELECT_VISITRECORDS = "select * from visitrecord";
        private const string SQL_SELECT_VISITRECORD_BY_ID = "select * from visitrecord where ID=@ID";
        private const string SQL_SELECT_VISITRECORD_BY_CONTACTID = "select * from visitrecord where ContactID=@ContactID";
        private const string SQL_SELECT_VISITRECORD_BY_USERID = "select * from visitrecord where UserID=@UserID";

        #region IVisitRecord 成员

        /// <summary>
        /// 新增拜访记录
        /// </summary>
        /// <param name="visitRecord"></param>
        /// <returns></returns>
        public int InsertVisitRecord(VisitRecordInfo visitRecord)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_VISITDETAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_RECORDTIME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50)
                };
                parms[0].Value = visitRecord.ContactID;
                parms[1].Value = visitRecord.VisitDetail;
                parms[2].Value = visitRecord.RecordTime;
                parms[3].Value = visitRecord.UserID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_VISITRECORD, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除拜访记录
        /// </summary>
        /// <param name="visitRecordId"></param>
        /// <returns></returns>
        public int DeleteVisitRecord(int visitRecordId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = visitRecordId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_VISITRECORD, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新拜访记录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateVisitRecord(VisitRecordInfo visitRecord)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CONTACTID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_VISITDETAIL,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_RECORDTIME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,50)
                };
                parms[0].Value = visitRecord.ContactID;
                parms[1].Value = visitRecord.VisitDetail;
                parms[2].Value = visitRecord.RecordTime;
                parms[3].Value = visitRecord.UserID;
                parms[4].Value = visitRecord.ID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_VISITRECORD, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有拜访记录
        /// </summary>
        /// <returns></returns>
        public IList<VisitRecordInfo> GetVisitRecords()
        {
            IList<VisitRecordInfo> visitRecords = new List<VisitRecordInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_VISITRECORDS, null))
                {
                    while (rdr.Read())
                    {
                        VisitRecordInfo visitRecord = new VisitRecordInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4));
                        visitRecords.Add(visitRecord);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return visitRecords;

        }

        /// <summary>
        /// 根据联系人ID查找拜访记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public VisitRecordInfo GetVisitRecordsByContactID(int contactId)
        {
            VisitRecordInfo visitRecord = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CONTACTID, MySqlDbType.Int32, 50);
                parm.Value = contactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_VISITRECORD_BY_CONTACTID, parm))
                {
                    if (rdr.Read())
                        visitRecord = new VisitRecordInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4));
                    else
                        visitRecord = new VisitRecordInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return visitRecord;
        }

        /// <summary>
        /// 根据联用户ID查找拜访记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public VisitRecordInfo GetVisitRecordsByUserID(int userId)
        {
            VisitRecordInfo visitRecord = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32, 50);
                parm.Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_VISITRECORD_BY_USERID, parm))
                {
                    if (rdr.Read())
                        visitRecord = new VisitRecordInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4));
                    else
                        visitRecord = new VisitRecordInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return visitRecord;
        }

        #endregion
    }
}

