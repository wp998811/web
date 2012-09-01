using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class CustomerContact
    {
        private static readonly ICustomerContact dal = DALFactory.DataAccess.CreateCustomerContact();

        #region
        /// <summary>
        /// 新增客户联系人关系
        /// </summary>
        /// <param name="customerContactInfo"></param>
        /// <returns></returns>
        public int InsertCustomerContact(CustomerContactInfo customerContactInfo)
        {
            return dal.InsertCustomerContact(customerContactInfo);
        }

        /// <summary>
        /// 更新客户联系人关系
        /// </summary>
        /// <param name="customerContactInfo"></param>
        /// <returns></returns>
        public int UpdateCustomerContact(CustomerContactInfo customerContactInfo)
        {
            return dal.UpdateCustomerContact(customerContactInfo);
        }

        /// <summary>
        /// 删除客户联系人关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCustomerContact(int id)
        {
            return dal.DeleteCustomerContact(id);
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<CustomerContactInfo> GetCustomerContacts()
        {
            return dal.GetCustomerContacts();
        }

        /// <summary>
        /// 通过客户联系人ID查找客户联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerContactInfo GetCustomerContactById(int id)
        {
            return dal.GetCustomerContactById(id);
        }

        /// <summary>
        /// 通过客户ID查找客户联系人
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IList<ContactInfo> GetCustomerContactsByCustomerId(int customerId)
        {
            return dal.GetContactsByCustomerId(customerId);
        }

        #endregion

        /// <summary>
        /// 新增客户联系人
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool AddCustomerContact(int customerId, int contactId)
        {
            if (customerId < 0 || contactId < 0)
                return false;
            if (1 == dal.InsertCustomerContact(new CustomerContactInfo(customerId, contactId)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑客户联系人
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <param name="userEmail"></param>
        /// <param name="userPhone"></param>
        /// <param name="departID"></param>
        /// <returns></returns>
        public bool ModifyCustomerContact(int id, int customerId, int contactId)
        {
            if (customerId < 0 || contactId < 0)
                return false;
            CustomerContactInfo customerContactInfo = dal.GetCustomerContactById(id);
            if (customerContactInfo == null)
                return false;
            customerContactInfo.CustomerID = customerId;
            customerContactInfo.ContactID = contactId;

            if (1 == dal.UpdateCustomerContact(customerContactInfo))
                return true;
            return false;
        }

    }
}

