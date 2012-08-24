using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class CustomerProject
    {
        private static readonly ICustomerProject dal = DALFactory.DataAccess.CreateCustomerProject();

        #region
        /// <summary>
        /// 新增客户项目
        /// </summary>
        /// <param name="customerProjectInfo"></param>
        /// <returns></returns>
        public int InsertCustomerProject(CustomerProjectInfo customerProjectInfo)
        {
            return dal.InsertCustomerProject(customerProjectInfo);
        }

        /// <summary>
        /// 更新客户项目
        /// </summary>
        /// <param name="customerProjectInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerProject(CustomerProjectInfo customerProjectInfo)
        {
            return dal.UpdateCustomerProject(customerProjectInfo);
        }

        /// <summary>
        /// 删除客户项目
        /// </summary>
        /// <param name="customerProjectID"></param>
        /// <returns></returns>
        public int DeleteCustomerProject(int customerProjectID)
        {
            return dal.DeleteCustomerProject(customerProjectID);
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjects()
        {
            return dal.GetCustomerProjects();
        }

        /// <summary>
        /// 根据负责人ID查找所有客户项目
        /// </summary>
        /// <returns></returns>
        public IList<CustomerProjectInfo> GetCustomerProjectsByUserId(int userId)
        {
            return dal.GetCustomerProjectsByUserId(userId);
        }

        /// <summary>
        /// 通过ID查找客户项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerProjectInfo GetCustomerProjectByProjectId(int id)
        {
            return dal.GetCustomerProjectByProjectId(id);
        }
        #endregion

        /// <summary>
        /// 新增客户项目信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerCity"></param>
        ///  <param name="customerType"></param>       
        /// <param name="customerName"></param>
        /// <param name="productName"></param>
        /// <param name="service"></param>
        /// <param name="progress"></param>
        /// <param name="productCategory"></param>
        /// <param name="contractAmount"></param>
        /// <param name="payment"></param>
        /// <param name="payState"></param>
        /// <param name="taxID"></param>
        /// <param name="organCode"></param>
        /// <returns></returns>
        public bool AddCustomerProject(int userId, string customerCity, string customerType, string customerName, string productName, string service,
                                                    string progress, string productCategory, float contractAmount, string payment, string payState, string taxID, string organCode)
        {
            if (userId < 0)
                return false;
            if (1 == dal.InsertCustomerProject(new CustomerProjectInfo(userId, customerCity, customerType, customerName, productName, service,
                                                    progress, productCategory, contractAmount, payment, payState, taxID, organCode)))
                return true;
            return false;
        }

        /// <summary>
        ///编辑客户项目信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerCity"></param>
        ///  <param name="customerType"></param>       
        /// <param name="customerName"></param>
        /// <param name="productName"></param>
        /// <param name="service"></param>
        /// <param name="progress"></param>
        /// <param name="productCategory"></param>
        /// <param name="contractAmount"></param>
        /// <param name="payment"></param>
        /// <param name="payState"></param>
        /// <param name="taxID"></param>
        /// <param name="organCode"></param>
        /// <returns></returns>
        public bool ModifyCustomerProject(int projId, int userId, string customerCity, string customerType, string customerName, string productName, string service,
                                                    string progress, string productCategory, float contractAmount, string payment, string payState, string taxID, string organCode)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (userId < 0)
                return false;
            CustomerProjectInfo customerProjectInfo = dal.GetCustomerProjectByProjectId(projId);
            if (customerProjectInfo == null)
                return false;
            customerProjectInfo.UserID = userId;
            customerProjectInfo.CustomerCity = customerCity;
            customerProjectInfo.CustomerType = customerType;
            customerProjectInfo.CustomerName = customerName;
            customerProjectInfo.ProductName = productName;
            customerProjectInfo.Service = service;
            customerProjectInfo.Progress = progress;
            customerProjectInfo.ProductCategory = productCategory;
            customerProjectInfo.ContractAmount = contractAmount;
            customerProjectInfo.Payment = payment;
            customerProjectInfo.PayState = payState;
            customerProjectInfo.TaxID = taxID;
            customerProjectInfo.OrganCode = organCode;

            if (1 == dal.UpdateCustomerProject(customerProjectInfo))
                return true;
            return false;
        }

    }
}
