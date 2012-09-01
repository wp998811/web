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
    public class Department : IDepartment
    {
        private const string PARM_DEPARTID = "@DepartID";
        private const string PARM_DEPARTNAME = "@DepartName";
        private const string PARM_DEPARTADMIN = "@DepartAdmin";

        private const string SQL_INSERT_DEPARTMENT = "insert into department(DepartName,DepartAdmin) values(@DepartName,@DepartAdmin)";
        private const string SQL_DELETE_DEPARTMENT = "delete from department where DepartID=@DepartID";
        private const string SQL_UPDATE_DEPARTMENT = "update department set DepartName=@DepartName,DepartAdmin=@DepartAdmin where DepartID=@DepartID";
        private const string SQL_SELECT_DEPARTMENTS = "select * from department";
        private const string SQL_SELECT_DEPARTMENT_BY_NAME = "select * from department where DepartName=@DepartName";
        private const string SQL_SELECT_DEPARTMENT_BY_ID = "select * from department where DepartID=@DepartID";

        #region IDepartment 成员

        /// <summary>
        /// 新建部门
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public int InsertDepartment(DepartmentInfo departmentInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DEPARTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTADMIN,MySqlDbType.VarChar,50),
                };
                parms[0].Value = departmentInfo.DepartName;
                parms[1].Value = departmentInfo.DepartAdmin;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_DEPARTMENT, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="departID"></param>
        /// <returns></returns>
        public int DeleteDepartment(int departID)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DEPARTID, MySqlDbType.Int32);
                parm.Value = departID;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DEPARTMENT, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public int UpdateDepartment(DepartmentInfo departmentInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] {
                    new MySqlParameter(PARM_DEPARTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTADMIN,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32)
                };
                parms[0].Value = departmentInfo.DepartName;
                parms[1].Value = departmentInfo.DepartAdmin;
                parms[2].Value = departmentInfo.DepartID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_DEPARTMENT, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有部门
        /// </summary>
        /// <returns></returns>
        public IList<DepartmentInfo> GetDepartments()
        {
            IList<DepartmentInfo> departments = new List<DepartmentInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTMENTS, null))
                {
                    while (rdr.Read())
                    {
                        DepartmentInfo department = new DepartmentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                        departments.Add(department);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departments;
        }

        /// <summary>
        /// 根据部门名称查找部门
        /// </summary>
        /// <param name="departName"></param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentByName(string departName)
        {
            DepartmentInfo departmentInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DEPARTNAME, MySqlDbType.VarChar, 50);
                parm.Value = departName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTMENT_BY_NAME, parm))
                {
                    if (rdr.Read())
                        departmentInfo = new DepartmentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                    else
                        departmentInfo = new DepartmentInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departmentInfo;
        }

        /// <summary>
        /// 根据部门编号查找部门
        /// </summary>
        /// <param name="departID"></param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentByID(int departID)
        {
            DepartmentInfo departmentInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DEPARTID, MySqlDbType.Int32);
                parm.Value = departID;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTMENT_BY_ID, parm))
                {
                    if (rdr.Read())
                    {
                        departmentInfo = new DepartmentInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                    }
                    else
                        departmentInfo = new DepartmentInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return departmentInfo;
        }

        #endregion
    }
}