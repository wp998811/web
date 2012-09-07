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
    //TODO 在数据库中增加ProjectClientName字段
    public class Project : IProject
    {
        private const string PARM_PROJECT_NUM = "@ProjectNum";
        private const string PARM_PROJECT_NAME = "@ProjectName";
        private const string PARM_PROEJCT_ADMIN_ID = "@ProjectAdminID";
        private const string PARM_PROJECT_DESCRIPTION = "@ProjectDescription";
        private const string PARM_PROJECT_TYPE = "@ProjectType";
        private const string PARM_PROJECT_CLIENT_NAME = "@ProjectClientName";
        private const string PARM_BEGIN_TIME = "@BeginTime";
        private const string PARM_END_TIME = "@EndTime";

        private const string SQL_INSERT_PROJECT = "insert into project(ProjectName, ProjectAdminID, ProjectDescription, ProjectType, ProjectClientName, BeginTime, EndTime) values(@ProjectName, @ProjectAdminID, @ProjectDescription, @ProjectType, @ProjectClientName, @BeginTime, @EndTime)";
        private const string SQL_DELETE_PROJECT = "delete from project where ProjectNum=@ProjectNum";
        private const string SQL_UPDATE_PROJECT = "update project set ProjectName=@ProjectName, ProjectAdminID=@ProjectAdminID, ProjectDescription=@ProjectDescription, ProjectType=@ProjectType, ProjectClientName=@ProjectClientName, BeginTime=@BeginTime, EndTime=@EndTime where ProjectNum=@ProjectNum";
        private const string SQL_SELECT_PROJECTS = "select * from project";
        private const string SQL_SELECT_PROJECT_BY_NUM = "select * from project where ProjectNum=@ProjectNum";
        private const string SQL_SELECT_PROJECT_BY_ADMIN_ID = "select * from project where ProjectAdminID=@ProjectAdminID";
        private const string SQL_GET_PROJECT_TIME_LENGHT = "select ABS(DATEDIFF(BeginTime, EndTime)) from project where ProjectNum=@ProjectNum";
        private const string SQL_GET_PROJECT_SPARE_TIME = "select ABS(DATEDIFF(BeginTime, Now())) from project where ProjectNum=@ProjectNum";


        #region IProject 成员

        public int GetProjectTimeLength(string projectNum)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_GET_PROJECT_TIME_LENGHT, parm))
                {
                    if (rdr.Read())
                    {
                        result = rdr.GetInt32(0);
                    }
                }
                
            }
            catch (MySqlException ex)
            {
            	Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int GetProjectSpareTime(string projectNum)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_GET_PROJECT_SPARE_TIME, parm))
                {
                    if (rdr.Read())
                    {
                        result = rdr.GetInt32(0);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int InsertProject(ProjectInfo projectInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROEJCT_ADMIN_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_PROJECT_DESCRIPTION, MySqlDbType.VarChar, 200),
                    new MySqlParameter(PARM_PROJECT_TYPE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROJECT_CLIENT_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_BEGIN_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_END_TIME, MySqlDbType.VarChar, 50)
                };

                parms[0].Value = projectInfo.ProjectName;
                parms[1].Value = projectInfo.ProjectAdminID;
                parms[2].Value = projectInfo.ProjectDescription;
                parms[3].Value = projectInfo.ProjectType;
                parms[4].Value = projectInfo.ProjectClientName;
                parms[5].Value = projectInfo.BeginTime;
                parms[6].Value = projectInfo.EndTime;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_PROJECT, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int DeleteProject(string projectNum)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_PROJECT, parm);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int UpdateProject(ProjectInfo projectInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[]{
                    new MySqlParameter(PARM_PROJECT_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROEJCT_ADMIN_ID, MySqlDbType.Int32),
                    new MySqlParameter(PARM_PROJECT_DESCRIPTION, MySqlDbType.VarChar, 200),
                    new MySqlParameter(PARM_PROJECT_TYPE, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROJECT_CLIENT_NAME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_BEGIN_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_END_TIME, MySqlDbType.VarChar, 50),
                    new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50)
                };

                parms[0].Value = projectInfo.ProjectName;
                parms[1].Value = projectInfo.ProjectAdminID;
                parms[2].Value = projectInfo.ProjectDescription;
                parms[3].Value = projectInfo.ProjectType;
                parms[4].Value = projectInfo.ProjectClientName;
                parms[5].Value = projectInfo.BeginTime;
                parms[6].Value = projectInfo.EndTime;
                parms[7].Value = projectInfo.ProjectNum;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_PROJECT, parms);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public IList<ProjectInfo> GetProjects()
        {
            IList<ProjectInfo> projects = new List<ProjectInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECTS, null))
                {
                    while (rdr.Read())
                    {
                        ProjectInfo project = new ProjectInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7));
                        projects.Add(project);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projects;
        }

        public ProjectInfo GetProjectByProjectNum(string projectNum)
        {
            ProjectInfo projectInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJECT_NUM, MySqlDbType.VarChar, 50);
                parm.Value = projectNum;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_BY_NUM, parm))
                {
                    if(rdr.Read())
                    {
                        projectInfo = new ProjectInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7));
                    }
                    else
                        projectInfo = new ProjectInfo();
                }
            }
            catch (MySqlException ex)
            {
            	Console.WriteLine(ex.Message);
            }
            return projectInfo;
        }

        public IList<ProjectInfo> GetProjectByAdminId(int adminId)
        {
            IList<ProjectInfo> projects = new List<ProjectInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROEJCT_ADMIN_ID, MySqlDbType.Int32);
                parm.Value = adminId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_PROJECT_BY_ADMIN_ID, parm))
                {
                    while (rdr.Read())
                    {
                        ProjectInfo project = new ProjectInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7));
                        projects.Add(project);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projects;
        }

        #endregion
    }
}
