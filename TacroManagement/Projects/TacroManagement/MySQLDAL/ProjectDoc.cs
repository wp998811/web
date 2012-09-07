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
    public class ProjectDoc : IProjectDoc
    {
        private const string PARM_PROJDOC_ID = "@ProjDocID";
        private const string PARM_TASK_ID = "@TaskID";
        private const string PARM_PROJDOC_CATE = "@ProjDocCate";
        private const string PARM_DOC_NAME = "@DocName";
        private const string PARM_DOC_KEY = "@DocKey";
        private const string PARM_DOC_DESCRIPTION = "@DocDescription";
        private const string PARM_DOC_URL = "@DocUrl";
        private const string PARM_DOC_PERMISSION = "@DocPermission";
        private const string PARM_UPLOAD_TIME = "@UploadTime";
        private const string PARM_UPLOAD_USERID = "@UploadUserID";


        private const string SQL_INSERT_PROJDOC = "insert into projectdoc(TaskID, ProjDocCate, DocName, DocKey, DocDescription, DocUrl, DocPermission, UploadTime, UploadUserID) values(@TaskID, @ProjDocCate, @DocName, @DocKey, @DocDescription, @DocUrl, @DocPermission, @UploadTime, @UploadUserID)";
        private const string SQL_DELETE_PROJDOC = "delete from projectdoc where ProjDocID=@ProjDocID";
        private const string SQL_UPDATE_PROJDOC = "update projectdoc set TaskID, ProjDocCate, DocName=@DocName, DocKey=@DocKey, DocDescription=@DocDescripttion, DocUrl=@DocUrl, DocPermission=@DocPermission, UploadTime=@UploadTime, UploadUserID=@UploadUserID";
        private const string SQL_SELECT_PROJDOCS = "select * from projectdoc";
        private const string SQL_SELECT_PROJDOC_BY_ID = "select * from projectdoc where ProjDocID=@ProjDocID";
        private const string SQL_SELECT_PROJDOCS_BY_TASKID = "select * from projectdoc where TaskID=@TaskID";
        private const string SQL_SELECT_PROJDOCS_BY_UPLOADUSER_ID = "select * from projectdoc where UploadUserID=@UploadUserID";

        #region IProjectDoc 成员

        public int InsertProjectDoc(ProjectDocInfo projectDocInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_TASK_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_PROJDOC_CATE, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOC_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_KEY, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_DESCRIPTION, MySqlDbType.VarChar, 200),
                    new MySqlParameter(PARM_DOC_URL, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_PERMISSION, MySqlDbType.Int32),
                    new MySqlParameter(PARM_UPLOAD_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_UPLOAD_USERID, MySqlDbType.Int32)
                };
                parms[0].Value = projectDocInfo.TaskId;
                parms[1].Value = projectDocInfo.ProjDocCate;
                parms[2].Value = projectDocInfo.DocName;
                parms[3].Value = projectDocInfo.DocKey;
                parms[4].Value = projectDocInfo.DocDescription;
                parms[5].Value = projectDocInfo.DocUrl;
                parms[6].Value = projectDocInfo.DocPermission;
                parms[7].Value = projectDocInfo.UploadTime;
                parms[8].Value = projectDocInfo.UploadUserId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PROJDOC, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProjectDoc(int projectDocId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJDOC_ID, MySqlDbType.Int32);
                parm.Value = projectDocId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJDOC, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateProjectDoc(ProjectDocInfo projectDocInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_TASK_ID, MySqlDbType.Int32),

                     new MySqlParameter(PARM_PROJDOC_CATE, MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DOC_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_KEY, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_DESCRIPTION, MySqlDbType.VarChar, 200),
                    new MySqlParameter(PARM_DOC_URL, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_DOC_PERMISSION, MySqlDbType.Int32),
                    new MySqlParameter(PARM_UPLOAD_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_UPLOAD_USERID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_PROJDOC_ID, MySqlDbType.Int32)
                };
                parms[0].Value = projectDocInfo.TaskId;
                parms[1].Value = projectDocInfo.ProjDocCate;
                parms[2].Value = projectDocInfo.DocName;
                parms[3].Value = projectDocInfo.DocKey;
                parms[4].Value = projectDocInfo.DocDescription;
                parms[5].Value = projectDocInfo.DocUrl;
                parms[6].Value = projectDocInfo.DocPermission;
                parms[7].Value = projectDocInfo.UploadTime;
                parms[8].Value = projectDocInfo.UploadUserId;
                parms[9].Value = projectDocInfo.ProjDocId;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PROJDOC, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ProjectDocInfo> GetProjectDocs()
        {
            IList<ProjectDocInfo> projectDocs = new List<ProjectDocInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJDOCS, null))
                {
                    while (rdr.Read())
                    {

                        ProjectDocInfo projectDoc = new ProjectDocInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9));
                        projectDocs.Add(projectDoc);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocs;
        }

        public ProjectDocInfo GetProjectDocById(int projectDocId)
        {
            ProjectDocInfo projectDoc = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJDOC_ID, MySqlDbType.Int32);
                parm.Value = projectDocId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJDOC_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        projectDoc = new ProjectDocInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9));
                    }
                    else
                        projectDoc = new ProjectDocInfo();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDoc;
        }

        public IList<ProjectDocInfo> GetProjectDocsByTaskId(int taskId)
        {
            IList<ProjectDocInfo> projectDocs = new List<ProjectDocInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_TASK_ID, MySqlDbType.Int32);
                parm.Value = taskId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJDOCS_BY_TASKID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectDocInfo projectDoc = new ProjectDocInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9));
                        projectDocs.Add(projectDoc);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocs;
        }

        public IList<ProjectDocInfo> GetProjectDocsByUpLoadUserId(int userId)
        {
            IList<ProjectDocInfo> projectDocs = new List<ProjectDocInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_UPLOAD_USERID, MySqlDbType.Int32);
                parm.Value = userId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJDOCS_BY_UPLOADUSER_ID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectDocInfo projectDoc = new ProjectDocInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9));
                        projectDocs.Add(projectDoc);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocs;
        }


        public IList<ProjectDocInfo> GetProjectDocs(string projectDocCate, string projectDocName, string projectDocKey, int projectDocTaskId, int uploadUserId, string uploadTime)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectDocInfo> GetProjectDocBySearchCondition(string selectCondition)
        {

            string sqlString;
            if (selectCondition == "")
            {
                sqlString = "SELECT * FROM projectdoc ";
            }
            else
            {
                sqlString = "SELECT * FROM projectdoc WHERE " + selectCondition;
            }
            IList<ProjectDocInfo> projectDocs = new List<ProjectDocInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, sqlString, null))
                {
                    while (rdr.Read())
                    {
                        ProjectDocInfo projectDoc = new ProjectDocInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9));
                        projectDocs.Add(projectDoc);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projectDocs;
        }

        #endregion
    }
}
