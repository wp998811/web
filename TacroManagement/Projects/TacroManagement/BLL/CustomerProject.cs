using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;
using System.Data;

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

        public IList<CustomerProjectInfo> GetCustomerProjectInfoByCondition(string selectCondition)
        {
            return dal.GetCustomerProjectInfoByCondition(selectCondition);
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
        public IList<CustomerProjectInfo> GetCustomerProjectsByCustomerId(int customerId)
        {
            return dal.GetCustomerProjectsByCustomerId(customerId);
        }

        /// <summary>
        /// 通过ID查找客户项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerProjectInfo GetCustomerProjByPorjId(int id)
        {
            return dal.GetCustomerProjByPorjId(id);
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
        public bool AddCustomerProject(int customerID, string productName, string service, string progress, float contractAmount,
                                                string payment, string payState, string projectType)
        {
            if (customerID < 0)
                return false;
            if (1 == dal.InsertCustomerProject(new CustomerProjectInfo(customerID, productName, service, progress, contractAmount,
                                                            payment, payState, projectType)))
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
        public bool ModifyCustomerProject(int projID, int customerID, string productName, string service, string progress, float contractAmount,
                                                string payment, string payState)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (customerID < 0)
                return false;
            CustomerProjectInfo customerProjectInfo = dal.GetCustomerProjByPorjId(projID);
            if (customerProjectInfo == null)
                return false;
            customerProjectInfo.CustomerID = customerID;
            customerProjectInfo.ProductName = productName;
            customerProjectInfo.Service = service;
            customerProjectInfo.Progress = progress;
            customerProjectInfo.ContractAmount = contractAmount;
            customerProjectInfo.Payment = payment;
            customerProjectInfo.PayState = payState;

            if (1 == dal.UpdateCustomerProject(customerProjectInfo))
                return true;
            return false;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllCustomerProjs()
        {
            DataTable dataTable = new DataTable();
            DataColumn customerProjID = new DataColumn("客户项目ID");
            DataColumn customerCity = new DataColumn("城市");
            DataColumn customerType = new DataColumn("客户类型");
            DataColumn customerName = new DataColumn("客户名称");
            DataColumn productName = new DataColumn("产品名称");
            DataColumn service = new DataColumn("服务项目");
            DataColumn progress = new DataColumn("项目进程");
            DataColumn productCategory = new DataColumn("产品类别");
            DataColumn projectType = new DataColumn("项目类型");
            DataColumn contractAmount = new DataColumn("合同金额");
            DataColumn payment = new DataColumn("付款方式");
            DataColumn payState = new DataColumn("付款情况");
            DataColumn taxID = new DataColumn("税务登记号");
            DataColumn organCode = new DataColumn("组织机构代码");

            dataTable.Columns.Add(customerProjID);
            dataTable.Columns.Add(customerCity);
            dataTable.Columns.Add(customerType);
            dataTable.Columns.Add(customerName);
            dataTable.Columns.Add(productName);
            dataTable.Columns.Add(service);
            dataTable.Columns.Add(progress);
            dataTable.Columns.Add(productCategory);
            dataTable.Columns.Add(projectType);
            dataTable.Columns.Add(contractAmount);
            dataTable.Columns.Add(payment);
            dataTable.Columns.Add(payState);
            dataTable.Columns.Add(taxID);
            dataTable.Columns.Add(organCode);

            IList<CustomerProjectInfo> customerProjectInfos = GetCustomerProjects(); //查询语句
            Customer customer = new Customer();
            User user = new User();

            for (int i = 0; i < customerProjectInfos.Count; ++i)
            {
                CustomerProjectInfo customerProjectInfo = customerProjectInfos[i];
                DataRow dataRow = dataTable.NewRow();
                CustomerInfo customerInfo = customer.GetCustomerById(customerProjectInfo.CustomerID);
                dataRow["客户项目ID"] = customerProjectInfo.ProjID;
                dataRow["城市"] = customerInfo.CustomerCity;
                dataRow["客户类型"] = customerInfo.CustomerType;
                dataRow["客户名称"] = customerInfo.CustomerName;
                dataRow["产品名称"] = customerProjectInfo.ProductName;
                dataRow["服务项目"] = customerProjectInfo.Service;
                dataRow["项目进程"] = customerProjectInfo.Progress;
                dataRow["产品类别"] = customerInfo.ProductRange;
                dataRow["项目类型"] = customerProjectInfo.ProjectType;
                dataRow["合同金额"] = customerProjectInfo.ContractAmount;
                dataRow["付款方式"] = customerProjectInfo.Payment;
                dataRow["付款情况"] = customerProjectInfo.PayState;
                dataRow["税务登记号"] = customerInfo.TaxID;
                dataRow["组织机构代码"] = customerInfo.OrganCode;
                

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchCustomerByProjID(int projID)
        {
            DataTable dataTable = new DataTable();
            DataColumn customerID = new DataColumn("客户ID");
            DataColumn customerName = new DataColumn("客户名称");
            DataColumn customerManager = new DataColumn("客户负责人");
            DataColumn customerCity = new DataColumn("所在城市");
            DataColumn customerType = new DataColumn("客户类别");
            DataColumn customerRank = new DataColumn("级别");
            DataColumn productRange = new DataColumn("产品范围");
            DataColumn projectType = new DataColumn("项目类型");
            DataColumn taxID = new DataColumn("税务登记号");
            DataColumn organCode = new DataColumn("组织机构代码");

            dataTable.Columns.Add(customerID);
            dataTable.Columns.Add(customerName);
            dataTable.Columns.Add(customerManager);
            dataTable.Columns.Add(customerCity);
            dataTable.Columns.Add(customerType);
            dataTable.Columns.Add(customerRank);
            dataTable.Columns.Add(productRange);
            dataTable.Columns.Add(projectType);
            dataTable.Columns.Add(taxID);
            dataTable.Columns.Add(organCode);

            CustomerProjectInfo customerProjectInfo = GetCustomerProjByPorjId(projID); //查询语句
            Customer customer = new Customer();
            CustomerInfo customerInfo = customer.GetCustomerById(customerProjectInfo.CustomerID);
            User user = new User();

            if (customerInfo != null)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["客户ID"] = customerInfo.CustomerID;
                dataRow["客户名称"] = customerInfo.CustomerName;

                UserInfo userInfo = user.GetUserById(customerInfo.UserID);
                dataRow["客户负责人"] = userInfo.UserName;

                dataRow["所在城市"] = customerInfo.CustomerCity;
                dataRow["客户类别"] = customerInfo.CustomerType;
                dataRow["级别"] = customerInfo.CustomerRank;
                dataRow["产品范围"] = customerInfo.ProductRange;
                dataRow["项目类型"] = customerProjectInfo.ProjectType;
                dataRow["税务登记号"] = customerInfo.TaxID;
                dataRow["组织机构代码"] = customerInfo.OrganCode;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 根据查询条件生成sql查询语句
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <returns>sql查询条件</returns>
        public string GetCustomerProjSearchCondition(string userName, string city, string customerType, string projectType, string progress, string customerName, string service, string productRange, string contactName)
        {
            string searchCondition = "select * from customerproject where ProjectType like '%" + projectType + "%' and Progress like '%" + progress + "%' and Service like '%" + service + "%' and CustomerID in (select CustomerID from customercontact where ContactID in (select ContactID from contact where ContactName like '%" + contactName + "%') and CustomerID in (select CustomerID from customer where UserID in (select UserID from user where UserName like '%" + userName + "%') and CustomerCity like '%" + city + "%' and CustomerType like '%" + customerType + "%' and CustomerName like '%" + customerName + "%' and ProductRange like '%" + productRange + "%'))";

            return searchCondition;
        }

        /// <summary>
        /// 通过查询条件获取合作者资料List
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <param name="contactName"></param>
        /// <returns>符合查询条件的List</returns>
        public IList<CustomerProjectInfo> GetCustomerProjectResearchBySearch(string userName, string city, string customerType, string projectType, string progress, string customerName, string service, string productRange, string contactName)
        {
            string condition = GetCustomerProjSearchCondition(userName, city, customerType, projectType, progress, customerName, service, productRange, contactName);
            IList<CustomerProjectInfo> customerProjectInfos = GetCustomerProjectInfoByCondition(condition);
            return customerProjectInfos;
        }

        /// <summary>
        /// 通过合作者资料List返回DataTable
        /// </summary>
        /// <param name="partnerResourceInfos"></param>
        /// <returns></returns>
        public DataTable GetDataTableByCustomerProjList(IList<CustomerProjectInfo> customerProjectInfos)
        {
            DataTable dataTable = new DataTable();
            DataColumn customerProjID = new DataColumn("客户项目ID");
            DataColumn customerCity = new DataColumn("城市");
            DataColumn customerType = new DataColumn("客户类型");
            DataColumn customerName = new DataColumn("客户名称");
            DataColumn productName = new DataColumn("产品名称");
            DataColumn service = new DataColumn("服务项目");
            DataColumn progress = new DataColumn("项目进程");
            DataColumn productCategory = new DataColumn("产品类别");
            DataColumn projectType = new DataColumn("项目类型");
            DataColumn contractAmount = new DataColumn("合同金额");
            DataColumn payment = new DataColumn("付款方式");
            DataColumn payState = new DataColumn("付款情况");
            DataColumn taxID = new DataColumn("税务登记号");
            DataColumn organCode = new DataColumn("组织机构代码");

            dataTable.Columns.Add(customerProjID);
            dataTable.Columns.Add(customerCity);
            dataTable.Columns.Add(customerType);
            dataTable.Columns.Add(customerName);
            dataTable.Columns.Add(productName);
            dataTable.Columns.Add(service);
            dataTable.Columns.Add(progress);
            dataTable.Columns.Add(productCategory);
            dataTable.Columns.Add(projectType);
            dataTable.Columns.Add(contractAmount);
            dataTable.Columns.Add(payment);
            dataTable.Columns.Add(payState);
            dataTable.Columns.Add(taxID);
            dataTable.Columns.Add(organCode);

            Customer customer = new Customer();
            User user = new User();

            for (int i = 0; i < customerProjectInfos.Count; ++i)
            {
                CustomerProjectInfo customerProjectInfo = customerProjectInfos[i];
                DataRow dataRow = dataTable.NewRow();
                CustomerInfo customerInfo = customer.GetCustomerById(customerProjectInfo.CustomerID);
                dataRow["客户项目ID"] = customerProjectInfo.ProjID;
                dataRow["城市"] = customerInfo.CustomerCity;
                dataRow["客户类型"] = customerInfo.CustomerType;
                dataRow["客户名称"] = customerInfo.CustomerName;
                dataRow["产品名称"] = customerProjectInfo.ProductName;
                dataRow["服务项目"] = customerProjectInfo.Service;
                dataRow["项目进程"] = customerProjectInfo.Progress;
                dataRow["产品类别"] = customerInfo.ProductRange;
                dataRow["项目类型"] = customerProjectInfo.ProjectType;
                dataRow["合同金额"] = customerProjectInfo.ContractAmount;
                dataRow["付款方式"] = customerProjectInfo.Payment;
                dataRow["付款情况"] = customerProjectInfo.PayState;
                dataRow["税务登记号"] = customerInfo.TaxID;
                dataRow["组织机构代码"] = customerInfo.OrganCode;


                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
}
