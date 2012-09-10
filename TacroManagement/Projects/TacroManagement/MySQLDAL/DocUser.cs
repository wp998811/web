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
    public class DocUser : IDocUser
    {

        #region DocUser Constant String

        private const string PARM_ID = "@ID";
        private const string PARM_DOCID = "@DocID";
        private const string PARM_USERID = "@UserID";

        private const string SQL_INSERT_DOCUSER = "INSERT INTO docuser(DocID, UserID) VALUES (@DocID, @UserID) ";
        private const string SQL_DELETE_DOCUSER = "DELETE FROM docuser WHERE ID=@ID";
        private const string SQL_DELETE_DOCUSER_BY_DOC = "DELETE FROM docuser WHERE DocID=@DocID";
        private const string SQL_UPDATE_DOCUSER = "UPDATE docuser SET DocID = @DocID, UserID = @UserID WHERE ID = @ID";
        private const string SQL_SELECT_DOCUSER = "SELECT * FROM docuser";
        private const string SQL_SELECT_DOCUSER_BY_ID = "SELECT * FROM docuser WHERE ID = @ID";
        private const string SQL_SELECT_DOCUSER_BY_DOC_USER = "SELECT * FROM docuser WHERE DocID = @DocID AND UserID = @UserID";
        private const string SQL_SELECT_DOCUSER_BY_DOCID = "SELECT * FROM docuser WHERE DocID = @DocID";
       
        #endregion



        #region IDocUser Members

        /// <summary>
        /// 新增文档用户
        /// </summary>
        /// <param name="docUserInfo"></param>
        /// <returns></returns>
        int IDocUser.InsertDocUser(DocUserInfo docUserInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DOCID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,11) 
                };
                if (docUserInfo.DocID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = docUserInfo.DocID;

                if (docUserInfo.UserID == 0)
                    parms[1].Value = DBNull.Value;
                else
                    parms[1].Value = docUserInfo.UserID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_DOCUSER, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除文档用户
        /// </summary>
        /// <param name="docUserId"></param>
        /// <returns></returns>
        int IDocUser.DeleteDocUser(int docUserId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = docUserId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DOCUSER, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 通过文档ID删除文档用户
        /// </summary>
        /// <param name="docUserId"></param>
        /// <returns></returns>
        int IDocUser.DeleteDocUserByDocId(int docId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCID, MySqlDbType.Int32);
                parm.Value = docId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DOCUSER_BY_DOC, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新文档用户
        /// </summary>
        /// <param name="docUserInfo"></param>
        /// <returns></returns>
        int IDocUser.UpdateDocUser(DocUserInfo docUserInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DOCID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,11) ,
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,11)
                };
                if(docUserInfo.DocID == 0)
                    parms[0].Value= DBNull.Value;
                else
                    parms[0].Value =docUserInfo.DocID;

                if(docUserInfo.UserID == 0)
                    parms[1].Value=DBNull.Value;
                else
                    parms[1].Value  =docUserInfo.UserID;
                parms[2].Value = docUserInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_DOCUSER, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有文档用户
        /// </summary>
        /// <returns></returns>
        IList<DocUserInfo> IDocUser.GetDocUser()
        {
            IList<DocUserInfo> docUserInfos = new List<DocUserInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUSER, null))
                {
                    while (rdr.Read())
                    {
                        DocUserInfo docUserInfo = new DocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        docUserInfos.Add(docUserInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return docUserInfos;
        }

        /// <summary>
        /// 根据文档用户编号查找文档用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DocUserInfo IDocUser.GetDocUserById(int id)
        {
            DocUserInfo docUserInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUSER_BY_ID, parm))
                {
                    if (rdr.Read())
                        docUserInfo = new DocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        docUserInfo = new DocUserInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return docUserInfo;
        }


        /// <summary>
        /// 根据文档编号查找文档用户
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        IList<DocUserInfo>  IDocUser.GetDocUserByDocId(int docId)
        {
            IList<DocUserInfo> docUserInfos = new List<DocUserInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCID, MySqlDbType.Int32, 11);
                parm.Value = docId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUSER_BY_DOCID, parm))
                {
                    while (rdr.Read())
                    {
                        DocUserInfo docUserInfo = new DocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                        docUserInfos.Add(docUserInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return docUserInfos;
        }
        /// <summary>
        /// 根据文档和用户查找文档用户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="DocumentID"></param>
        /// <returns></returns>
        DocUserInfo IDocUser.GetDocUserByDocUser(int userID, int DocumentID)
        {
            DocUserInfo docUserInfo = null;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCID,MySqlDbType.Int32,11)
                };
                parms[0].Value = userID;
                parms[1].Value = DocumentID;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUSER_BY_DOC_USER, parms))
                {
                    if (rdr.Read())
                        docUserInfo = new DocUserInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2));
                    else
                        docUserInfo = new DocUserInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return docUserInfo;
        }

        #endregion
    }
}