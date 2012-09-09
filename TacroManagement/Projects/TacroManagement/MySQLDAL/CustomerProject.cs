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
        private const string PARM_USERID = "@UserID";
        private const string PARM_CUSTOMERCITY = "@CustomerCity";
        private const string PARM_CUSTOMERTYPE = "@CustomerType";
        private const string PARM_CUSTOMERNAME = "@CustomerName";
        private const string PARM_PRODUCTNAME = "@ProductName";
        private const string PARM_SERVICE = "@Service";
        private const string PARM_PROGRESS = "@Progress";
        private const string PARM_PRODUCTCATEGORY = "@ProductCategory";
        private const string PARM_CONTRACTAMOUNT = "@ContractAmount";
        private const string PARM_PAYMENT = "@Payment";
        private const string PARM_PAYSTATE = "@PayState";
        private const string PARM_TAXID = "@TaxID";
        private const string PARM_ORGANCODE = "@OrganCode";

        private const string SQL_INSERT_CUSTOMERPROJ = "insert into customerproject(UserID,CustomerCity,CustomerType,CustomerName,ProductName,Service,Progress,ProductCategory,ContractAmount,Payment,PayState,TaxID,OrganCode) values(@UserID,@CustomerCity,@CustomerType,@CustomerName,@ProductName,@Service,@Progress,@ProductCategory,@ContractAmount,@Payment,@PayState,@TaxID,@OrganCode)";
        private const string SQL_DELETE_CUSTOMERPROJ = "delete from customerproject where ProjID=@ProjID";
        private const string SQL_UPDATE_CUSTOMERPROJ = "update customerproject set UserID=@UserID,CustomerCity=@CustomerCity,CustomerType=@CustomerType,CustomerName=@CustomerName,ProductName=@ProductName,Service=@Service" +
                                                                        ",Progress=@Progress,ProductCategory=@ProductCategory,ContractAmount=@ContractAmount,Payment=@Payment,PayState=@PayState,TaxID=@TaxID,OrganCode=@OrganCode where ProjID=@ProjID";
        private const string SQL_SELECT_CUSTOMERPROJS = "select * from customerproject";
        private const string SQL_SELECT_CUSTOMERPROJ_BY_USERID = "select * from customerproject where UserID=@UserID";
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
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CUSTOMERCITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SERVICE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROGRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTCATEGORY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CONTRACTAMOUNT,MySqlDbType.Float,50),
                    new MySqlParameter(PARM_PAYMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PAYSTATE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TAXID,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ORGANCODE,MySqlDbType.VarChar,50)
                };

                if (customerProject.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = customerProject.UserID;
                parms[1].Value = customerProject.CustomerCity;
                parms[2].Value = customerProject.CustomerType;
                parms[3].Value = customerProject.CustomerName;
                parms[4].Value = customerProject.ProductName;
                parms[5].Value = customerProject.Service;
                parms[6].Value = customerProject.Progress;
                parms[7].Value = customerProject.ProductCategory;
                parms[8].Value = customerProject.ContractAmount;
                parms[9].Value = customerProject.Payment;
                parms[10].Value = customerProject.PayState;
                parms[11].Value = customerProject.TaxID;
                parms[12].Value = customerProject.OrganCode;

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
                    new MySqlParameter(PARM_USERID,MySqlDbType.Int32,50),
                    new MySqlParameter(PARM_CUSTOMERCITY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERTYPE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CUSTOMERNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTNAME,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_SERVICE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROGRESS,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PRODUCTCATEGORY,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_CONTRACTAMOUNT,MySqlDbType.Float,50),
                    new MySqlParameter(PARM_PAYMENT,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PAYSTATE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_TAXID,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_ORGANCODE,MySqlDbType.VarChar,50),
                    new MySqlParameter(PARM_PROJID,MySqlDbType.Int32,50)
                };
                if (customerProject.UserID == 0)
                    parms[0].Value = DBNull.Value;
                else
                    parms[0].Value = customerProject.UserID;
                parms[1].Value = customerProject.CustomerCity;
                parms[2].Value = customerProject.CustomerType;
                parms[3].Value = customerProject.CustomerName;
                parms[4].Value = customerProject.ProductName;
                parms[5].Value = customerProject.Service;
                parms[6].Value = customerProject.Progress;
                parms[7].Value = customerProject.ProductCategory;
                parms[8].Value = customerProject.ContractAmount;
                parms[9].Value = customerProject.Payment;
                parms[10].Value = customerProject.PayState;
                parms[11].Value = customerProject.TaxID;
                parms[12].Value = customerProject.OrganCode;
                parms[13].Value = customerProject.ProjID;

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
                        CustomerProjectInfo customerProject = new CustomerProjectInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetFloat(9),
                                                                                                                                        rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetString(13));
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
        public IList<CustomerProjectInfo> GetCustomerProjectsByUserId(int userId)
        {
            IList<CustomerProjectInfo> customerProjects = new List<CustomerProjectInfo>();

            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_USERID, MySqlDbType.Int32, 50);
                parm.Value = userId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJ_BY_USERID, parm))
                {
                    while (rdr.Read())
                    {
                        CustomerProjectInfo customerProject = new CustomerProjectInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetFloat(9),
                                                                                                                                        rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetString(13));
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
        /// 根据客户项目ID查找客户项目
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        public CustomerProjectInfo GetCustomerProjectByProjectId(int projId)
        {
            CustomerProjectInfo customerProjInfo = null;
            try
            {
                MySqlParameter parm = new MySqlParameter(PARM_PROJID, MySqlDbType.Int32, 50);
                parm.Value = projId;

                using (MySqlDataReader rdr = DBUtility.MySqlHelper.ExecuteReader(DBUtility.MySqlHelper.ConnectionString, CommandType.Text, SQL_SELECT_CUSTOMERPROJ_BY_PROJID, parm))
                {
                    if (rdr.Read())
                        customerProjInfo = new CustomerProjectInfo(rdr.GetInt32(0), rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetFloat(9),
                                                                                                                                        rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetString(13));
                    else
                        customerProjInfo = new CustomerProjectInfo();
                }
            }
            catch (MySqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return customerProjInfo;
        }

        #endregion
    }
}

