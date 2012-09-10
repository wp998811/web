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
    public class Document : IDocument
    {

        #region Document Constand String
        private const string PARM_DOCID = "@DocID";
        private const string PARM_DOCNAME = "@DocName";
        private const string PARM_DOCVERSION = "@DocVersion";
        private const string PARM_DOCDESCRIPTION = "@DocDescription";
        private const string PARM_DOCKEY = "@DocKey";
        private const string PARM_DEPARTID = "@DepartID";
        private const string PARM_DOCCATEGORYID = "@DocCategoryID";
        private const string PARM_DOCSTATE = "@DocState";
        private const string PARM_UPLOADPATH = "@UploadPath";
        private const string PARM_SAVEPATH = "@SavePath";
        private const string PARM_DOCPERMISSION = "@DocPermission";
        private const string PARM_UPLOADUSERID = "@uploadUserID";
        private const string PARM_UPLOADTIME = "@uploadTime";
        private const string PARM_UPLOADTIMEBEGIN = "@uploadTimeBegin";
        private const string PARM_UPLOADTIMEEND = "@uploadTimeEnd";

        private const string SQL_INSERT_DOCUMENT = "INSERT INTO document(DocName, DocVersion, DocDescription, DocKey, DepartID,DocCategoryID, DocState, UploadPath,SavePath,DocPermission,uploadUSerID, uploadTime ) VALUES (@DocName, @DocVersion, @DocDescription, @DocKey, @DepartID,@DocCategoryID, @DocState, @UploadPath,@SavePath,@DocPermission,@UploadUSerID, @UploadTime)";
        private const string SQL_DELETE_DOCUMENT = "DELETE FROM document WHERE DocID=@DocID";
        private const string SQL_DELETE_DOCUMENT_BY_NAME = "DELETE FROM document WHERE DocName=@DocName";
        private const string SQL_UPDATE_DOCUMENT = "UPDATE document SET DocName=@DocName, DocVersion=@DocVersion, DocDescription=@DocDescription, DocKey=@DocKey, DepartID=@DepartID,DocCategoryID=@DocCategoryID, DocState=@DocState, UploadPath=@UploadPath, SavePath=@SavePath, DocPermission = @DocPermission, UploadUserID=@UploadUSerID, UploadTime = @UploadTime WHERE  DocID=@DocID";
        private const string SQL_SELECT_DOCUMENT = "SELECT * FROM document";
        private const string SQL_SELECT_DOCUMENT_BY_NAME = "SELECT * FROM Document WHERE DocName=@DocName";
        private const string SQL_SELECT_DOCUMENT_BY_ID = "SELECT * FROM Document WHERE DocID=@DocID";
        private const string SQL_SELECT_DOCUMENT_BY_LATELYTIME = "SELECT * FROM Document WHERE UploadTime >= @UploadTime";

        #endregion

        #region IDocument Members

        /// <summary>
        /// 新增文档
        /// </summary>
        /// <param name="documentInfo"></param>
        /// <returns></returns>
        int IDocument.InsertDocument(DocumentInfo documentInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DOCNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCVERSION,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCDESCRIPTION,MySqlDbType.VarChar,1000),
                    new MySqlParameter(PARM_DOCKEY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCCATEGORYID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCSTATE, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_UPLOADPATH,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SAVEPATH,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCPERMISSION,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_UPLOADUSERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_UPLOADTIME,MySqlDbType.DateTime)
                  
                };

                parms[0].Value = documentInfo.DocName;
                parms[1].Value = documentInfo.DocVersion;
                parms[2].Value = documentInfo.DocDescription;
                parms[3].Value = documentInfo.DocKey;
                parms[4].Value = documentInfo.DepartID;
                parms[5].Value = documentInfo.DocCategoryID;
                parms[6].Value = documentInfo.DocState;
                parms[7].Value = documentInfo.UploadPath;
                parms[8].Value = documentInfo.SavePath;
                parms[9].Value = documentInfo.DocPermission;
                parms[10].Value = documentInfo.UploadUserID;
                parms[11].Value = documentInfo.UploadTime;


                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_DOCUMENT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }


        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        int IDocument.DeleteDocument(int documentId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCID, MySqlDbType.Int32);
                parm.Value = documentId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DOCUMENT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新文档
        /// </summary>
        /// <param name="documentInfo"></param>
        /// <returns></returns>
        int IDocument.UpdateDocument(DocumentInfo documentInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                   // new MySqlParameter(PARM_DOCID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCVERSION,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCDESCRIPTION,MySqlDbType.VarChar,1000),
                    new MySqlParameter(PARM_DOCKEY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCCATEGORYID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_DOCSTATE, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_UPLOADPATH,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SAVEPATH,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOCPERMISSION,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_UPLOADUSERID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_UPLOADTIME,MySqlDbType.DateTime),
                    new MySqlParameter(PARM_DOCID,MySqlDbType.Int32,11)

                };

                parms[0].Value = documentInfo.DocName;
                parms[1].Value = documentInfo.DocVersion;
                parms[2].Value = documentInfo.DocDescription;
                parms[3].Value = documentInfo.DocKey;
                parms[4].Value = documentInfo.DepartID;
                parms[5].Value = documentInfo.DocCategoryID;
                parms[6].Value = documentInfo.DocState;
                parms[7].Value = documentInfo.UploadPath;
                parms[8].Value = documentInfo.SavePath;
                parms[9].Value = documentInfo.DocPermission;
                parms[10].Value = documentInfo.UploadUserID;
                parms[11].Value = documentInfo.UploadTime;
                parms[12].Value = documentInfo.DocID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_DOCUMENT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }


        /// <summary>
        /// 查找所有文档
        /// </summary>
        /// <returns></returns>
        IList<DocumentInfo> IDocument.GetDocument()
        {
            IList<DocumentInfo> documents = new List<DocumentInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUMENT, null))
                {
                    while (rdr.Read())
                    {
                        DocumentInfo document = new DocumentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5), rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10), rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11), rdr.GetString(12)); documents.Add(document);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return documents;
        }

        /// <summary>
        /// 根据文档名查找文档
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        DocumentInfo IDocument.GetDocumentByName(string docName)
        {
            DocumentInfo documentInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCNAME, MySqlDbType.VarChar, 50);
                parm.Value = docName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUMENT_BY_NAME, parm))
                {
                    if (rdr.Read())
                        documentInfo = new DocumentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5), rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10), rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11), rdr.GetString(12));
                    else
                        documentInfo = new DocumentInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return documentInfo;
        }

        /// <summary>
        /// 根据文档编号查找文档
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        DocumentInfo IDocument.GetDocumentById(int docId)
        {
            DocumentInfo documentInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCID, MySqlDbType.Int32, 11);
                parm.Value = docId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUMENT_BY_ID, parm))
                {
                    if (rdr.Read())
                        documentInfo = new DocumentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5), rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10), rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11), rdr.GetString(12));
                    else
                        documentInfo = new DocumentInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return documentInfo;
        }

        /// <summary>
        /// 根据文档名称删除用户
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        int IDocument.DeleteDocumentByName(string docName)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DOCNAME, MySqlDbType.VarString);
                parm.Value = docName;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DOCUMENT_BY_NAME, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        // string docName, string docVersion, string docKey, int DepertId, int docCategoryID, int uploadUserID, string updateTimeBegin, string updateTimeEnd
        IList<DocumentInfo> IDocument.GetDocumentBySearchCondition(string selectCondition)
        {

            string sqlString;
            if (selectCondition == "")
            {
                sqlString = "SELECT * FROM document ";
            }
            else
            {
                sqlString = "SELECT * FROM document WHERE " + selectCondition;
            }

            IList<DocumentInfo> documents = new List<DocumentInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, sqlString, null))
                {
                    while (rdr.Read())
                    {
                        DocumentInfo document = new DocumentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5), rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10), rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11), rdr.GetString(12));
                        documents.Add(document);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return documents;
        }


        IList<DocumentInfo> IDocument.GetDocumentByLatelyTime(string latelyTime)
        {

            IList<DocumentInfo> documents = new List<DocumentInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_UPLOADTIME, MySqlDbType.DateTime);
                parm.Value = latelyTime;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DOCUMENT_BY_LATELYTIME, parm))
                {
                    while (rdr.Read())
                    {
                        DocumentInfo document = new DocumentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5), rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10), rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11), rdr.GetString(12));
                        documents.Add(document);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return documents;
        }
        #endregion
    }
}