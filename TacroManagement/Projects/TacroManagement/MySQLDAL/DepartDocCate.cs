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
    public class DepartDocCate:IDepartDocCate
    {


        #region DepartDocCate Constant String

        private const string PARM_ID = "@ID";
        private const string PARM_DEPARTID = "@DepartID";
        private const string PARM_VISIBILITY = "@Visibility";
        private const string PARM_CATEGORYNAME = "@CategoryName";

        private const string SQL_INSERT_DEPARTDOCCATE= "INSERT INTO departdoccate(DepartID,Visibility,CategoryName ) VALUES (@DepartID, @Visibility, @CategoryName)";
        private const string SQL_DELETE_DEPARTDOCCATE = "DELETE FROM departdoccate WHERE ID=@ID";
        private const string SQL_UPDATE_DEPARTDOCCATE = "UPDATE departdoccate SET DepartID = @DepartID, Visibility = @Visibility, CategoryName = @CategoryName WHERE ID = @ID";
        private const string SQL_SELECT_DEPARTDOCCATE = "SELECT * FROM departdoccate";
        private const string SQL_SELECT_DEPARTDOCCATE_BY_ID = "SELECT * FROM departdoccate WHERE ID = @ID";
        private const string SQL_SELECT_DEPARTDOCCATE_BY_DEPARTID = "SELECT * FROM departdoccate WHERE DepartID = @DepartID";
        private const string SQL_SELECT_DEPARTDOCCATE_BY_DEPART_CATEGORY = "SELECT * FROM departdoccate WHERE DepartID = @DepartID AND CategoryName = @CategoryName";

        #endregion




        #region IDepartDocCate Members


        /// <summary>
        /// 新增部门文档类型
        /// </summary>
        /// <param name="departDocCateInfo"></param>
        /// <returns></returns>
        int IDepartDocCate.InsertDepartDocCate(DepartDocCateInfo departDocCateInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_VISIBILITY,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CATEGORYNAME,MySqlDbType.VarChar,50)
                };
                parms[0].Value = departDocCateInfo.DepartID;
                parms[1].Value = departDocCateInfo.Visibility;
                parms[2].Value = departDocCateInfo.CategoryName;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_DEPARTDOCCATE, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除部门文档类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IDepartDocCate.DeleteDepartDocCate(int id)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32);
                parm.Value = id;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_DEPARTDOCCATE, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新部门文档类型
        /// </summary>
        /// <param name="departDocCateInfo"></param>
        /// <returns></returns>
        int IDepartDocCate.UpdateDepartDocCate(DepartDocCateInfo departDocCateInfo)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_VISIBILITY,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CATEGORYNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ID,MySqlDbType.Int32,11)
                };
                parms[0].Value = departDocCateInfo.DepartID;
                parms[1].Value = departDocCateInfo.Visibility;
                parms[2].Value = departDocCateInfo.CategoryName;
                parms[3].Value = departDocCateInfo.Id;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_DEPARTDOCCATE, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找部门文档类型
        /// </summary>
        /// <returns></returns>
        IList<DepartDocCateInfo> IDepartDocCate.GetDepartDocCate()
        {
            IList<DepartDocCateInfo> departDocCates = new List<DepartDocCateInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTDOCCATE, null))
                {
                    while (rdr.Read())
                    {
                        DepartDocCateInfo departDocCate = new DepartDocCateInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3));
                        departDocCates.Add(departDocCate);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departDocCates;
        }

        /// <summary>
        /// 根据部门文档类型编号查找部门文档类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DepartDocCateInfo IDepartDocCate.GetDepartDocCateById(int id)
        {
            DepartDocCateInfo departDocCateInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_ID, MySqlDbType.Int32, 11);
                parm.Value = id;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTDOCCATE_BY_ID, parm))
                {
                    if (rdr.Read())
                        departDocCateInfo = new DepartDocCateInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3));
                    else
                        departDocCateInfo = new DepartDocCateInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departDocCateInfo;
        }

        /// <summary>
        /// 通过部门编号查找部门文档类型 
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        IList<DepartDocCateInfo> IDepartDocCate.GetDepartDocCateByDepartId(int departId)
        {
            IList<DepartDocCateInfo> departDocCates = new List<DepartDocCateInfo>();
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_DEPARTID, MySqlDbType.Int32, 11);
                parm.Value = departId;
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTDOCCATE_BY_DEPARTID, parm))
                {
                    while (rdr.Read())
                    {
                        DepartDocCateInfo departDocCate = new DepartDocCateInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3));
                        departDocCates.Add(departDocCate);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departDocCates;
        }

        /// <summary>
        /// 根据部门和文档类型查找部门文档类型
        /// </summary>
        /// <param name="departID"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        DepartDocCateInfo IDepartDocCate.GetDepartDocCateByDepartCategory(int departID, string categoryName)
        {
            DepartDocCateInfo departDocCateInfo = null;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_DEPARTID,MySqlDbType.Int32,11),
                    new MySqlParameter(PARM_CATEGORYNAME,MySqlDbType.VarChar,50)
                };
                parms[0].Value = departID;
                parms[1].Value = categoryName;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_DEPARTDOCCATE_BY_DEPART_CATEGORY, parms))
                {
                    if (rdr.Read())
                        departDocCateInfo = new DepartDocCateInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3));
                    else
                        departDocCateInfo = new DepartDocCateInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return departDocCateInfo;
        }

        #endregion
    }
}
