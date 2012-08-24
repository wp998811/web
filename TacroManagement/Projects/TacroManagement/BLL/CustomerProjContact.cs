using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class CustomerProjContact
    {
        private static readonly ICustomerProjContact dal = DALFactory.DataAccess.CreateCustomerProjContact();

        #region
        /// <summary>
        /// 新增客户项目联系人关系
        /// </summary>
        /// <param name="customerProjContactInfo"></param>
        /// <returns></returns>
        public int InsertCustomerProjContact(CustomerProjContactInfo customerProjContactInfo)
        {
            return dal.InsertCustomerProjContact(customerProjContactInfo);
        }

        /// <summary>
        /// 更新客户项目联系人关系
        /// </summary>
        /// <param name="customerProjContactInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerProjContact(CustomerProjContactInfo customerProjContactInfo)
        {
            return dal.UpdateCustomerProjContact(customerProjContactInfo);
        }

        /// <summary>
        /// 删除客户项目联系人关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCustomerProjContact(int id)
        {
            return dal.DeleteCustomerProjContact(id);
        }

        /// <summary>
        /// 查找所有客户项目联系人关系
        /// </summary>
        /// <returns></returns>
        public IList<CustomerProjContactInfo> GetCustomerProjContacts()
        {
            return dal.GetCustomerProjContacts();
        }

        /// <summary>
        /// 通过ID查找客户项目联系人关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerProjContactInfo GetCustomerProjContactById(int id)
        {
            return dal.GetCustomerProjContactById(id);
        }
        #endregion

        /// <summary>
        /// 新增客户项目联系人关系
        /// </summary>
        /// <param name="customerProjId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool AddCustomerProjContact(int customerProjId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (customerProjId < 0 || contactId < 0)
                return false;
            if (1 == dal.InsertCustomerProjContact(new CustomerProjContactInfo(customerProjId, contactId)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑客户项目联系人关系
        /// </summary>
        /// <param name="customerProjId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool ModifyCustomerProjContact(int id, int customerProjId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (customerProjId < 0 || contactId < 0)
                return false;
            CustomerProjContactInfo customerProjContactInfo = dal.GetCustomerProjContactById(id);
            if (customerProjContactInfo == null)
                return false;
            customerProjContactInfo.CustomerProjID = customerProjId;
            customerProjContactInfo.ContactID = contactId;

            if (1 == dal.UpdateCustomerProjContact(customerProjContactInfo))
                return true;
            return false;
        }

    }
}

