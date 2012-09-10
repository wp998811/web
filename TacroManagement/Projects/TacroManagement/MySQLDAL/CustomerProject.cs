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
    public class CustomerProject : ICustomerProject
    {
        private const string PARM_PROJID = "@ProjID";
        private const string PARM_CUSTOMERID = "@CustomerID";
        private const string PARM_PRODUCTNAME = "@ProductName";
        private const string PARM_SERVICE = "@Service";
        private const string PARM_PROGRESS = "@Progress";
        private const string PARM_CONTRACTAMOUNT = "@ContractAmount";
        private const string PARM_PAYMENT = "@Payment";
        private const string PARM_PAYSTATE = "@PayState";
        private const string PARM_PROJTYPE = "@ProjectType";

        private const string SQL_INSERT_CUSTOMERPROJ = "insert into customerproject(CustomerID,ProductName,Service,Progress,ContractAmount,Payment,PayState,ProjectType) values(@CustomerID,@ProductName, @Service, @Progress,@ContractAmount,@Payment,@PayState,@ProjectType)";
        private const string SQL_DELETE_CUSTOMERPROJ = "delete from customerproject where ProjID=@ProjID";
        private const string SQL_UPDATE_CUSTOMERPROJ = "update customerproject set CustomerID=@CustomerID, ProductName=@ProductName,Service=@Service" +
                                                                        ",Progress=@Progress, ContractAmount=@ContractAmount,Payment=@Payment,PayState=@PayState, ProjectType=@ProjectType where ProjID=@ProjID";
        private const string SQL_SELECT_CUSTOMERPROJS = "select * from customerproject";
        private const string SQL_SELECT_CUSTOMERPROJ_BY_CUSTOMERID = "select * from customerproject where CustomerID=@CustomerID";
        private const string SQL_SELECT_CUSTOMERPROJ_BY_PROJID = "select * from customerproject where ProjID=@ProjID";

        #region ICustomerProject 成员

        /// <summary>
        /// 新增客户项目
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertCustomerProject(CustomerProjectInfo  customerProject)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CUSTOMERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_PRODUCTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SERVICE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROGRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CONTRACTAMOUNT,MySqlDbType.Float,50),
                    new MySqlParameter(PARM_PAYMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PAYSTATE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROJTYPE,MySqlDbType.VarChar,50)
                };

                parms[0].Value = customerProject.CustomerID;
                parms[1].Value = customerProject.ProductName;
                parms[2].Value = customerProject.Service;
                parms[3].Value = customerProject.Progress;
                parms[4].Value = customerProject.ContractAmount;
                parms[5].Value = customerProject.Payment;
                parms[6].Value = customerProject.PayState;
                parms[7].Value = customerProject.ProjectType;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_INSERT_CUSTOMERPROJ, parms);

            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除客户项目
        /// </summary>
        /// <param name="customerProjectId"></param>
        /// <returns></returns>
        public int DeleteCustomerProject(int customerProjectId)
        {
            int result = -1;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJID, MySqlDbType.Int32);
                parm.Value = customerProjectId;
                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_DELETE_CUSTOMERPROJ, parm);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }


        /// <summary>
        /// 根据查询条件查找政府资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjByCondition(string selectCondition)
        {

            string sqlString;
            if (selectCondition == "")
            {
                sqlString = "SELECT * FROM customerproject ";
            }
            else
            {
                //sqlString = "SELECT goverresouece.GoverID,goverresouece.UserID,goverresouece.GoverCity,goverresouece.OrgonName,goverresouece.OrganIntro"
                //    + " FROM goverresouece,govercontact,contact WHERE " + selectCondition;
                sqlString = "SELECT * FROM customerproject where " + selectCondition;
            }
            IList<CustomerProjectInfo> customerProjects = new List<CustomerProjectInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, sqlString, null))
                {
                    while (rdr.Read())
                    {
                        CustomerProjectInfo customerProject = new CustomerProjectInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetFloat(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        customerProjects.Add(customerProject);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjects;
        }

        /// <summary>
        /// 更新客户项目
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerProject(CustomerProjectInfo customerProject)
        {
            int result = -1;
            try
            {
                MySqlParameter[] parms = new MySqlParameter[] { 
                    new MySqlParameter(PARM_CUSTOMERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_PRODUCTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SERVICE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROGRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CONTRACTAMOUNT,MySqlDbType.Float,50),
                    new MySqlParameter(PARM_PAYMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PAYSTATE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROJID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_PROJTYPE,MySqlDbType.VarChar,50)
                };
                parms[0].Value = customerProject.CustomerID;
                parms[1].Value = customerProject.ProductName;
                parms[2].Value = customerProject.Service;
                parms[3].Value = customerProject.Progress;
                parms[4].Value = customerProject.ContractAmount;
                parms[5].Value = customerProject.Payment;
                parms[6].Value = customerProject.PayState;
                parms[7].Value = customerProject.ProjectType;
                parms[8].Value = customerProject.ProjID;

                result = DBUtility.MySqlHelper.ExecuteNonQuery(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_UPDATE_CUSTOMERPROJ, parms);
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return result;
        }

        /// <summary>
        /// 查找所有客户项目
        /// </summary>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjects()
        {
            IList<CustomerProjectInfo> customerProjects = new List<CustomerProjectInfo>();

            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJS, null))
                {
                    while (rdr.Read())
                    {
                        CustomerProjectInfo customerProject = new CustomerProjectInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetFloat(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        customerProjects.Add(customerProject);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjects;

        }

        /// <summary>
        /// 根据用户ID查找客户项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjectsByCustomerId(int customerId)
        {
            IList<CustomerProjectInfo> customerProjects = new List<CustomerProjectInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_CUSTOMERID, MySqlDbType.Int32, 50);
                parm.Value = customerId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJ_BY_CUSTOMERID, parm))
                {
                    while (rdr.Read())
                    {
                        CustomerProjectInfo customerProjectInfo = new CustomerProjectInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetFloat(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        customerProjects.Add(customerProjectInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjects;
        }

        /// <summary>
        /// 根据ID查找客户联系人
        /// </summary>
        /// <param name="customerContactId"></param>
        /// <returns></returns>
        public CustomerProjectInfo GetCustomerProjByPorjId(int customerContactId)
        {
            CustomerProjectInfo customerProjectInfo = null;

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJID, MySqlDbType.Int32);
                parm.Value = customerContactId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJ_BY_PROJID, parm))
                {
                    if (rdr.Read())
                    {
                        customerProjectInfo = new CustomerProjectInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetFloat(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                    }
                    else
                        customerProjectInfo = new CustomerProjectInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return customerProjectInfo;
        }

        /// <summary>
        /// 根据查询条件查找合作伙伴资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjectInfoByCondition(string selectCondition)
        {
            IList<CustomerProjectInfo> customerProjectInfos = new List<CustomerProjectInfo>();
            try
            {
                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, selectCondition, null))
                {
                    while (rdr.Read())
                    {
                        CustomerProjectInfo customerResourceInfo = new CustomerProjectInfo(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetFloat(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8));
                        customerProjectInfos.Add(customerResourceInfo);
                    }
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjectInfos;
        }

        #endregion
    }
}

