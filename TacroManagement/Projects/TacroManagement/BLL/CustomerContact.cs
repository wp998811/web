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
        /// 根据联系人ID删除客户联系人信息
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public int DeleteCustomerContactByContactId(int contactId)
        {
            return dal.DeleteCustomerContactByContactId(contactId);
        }

        /// <summary>
        /// 根据客户ID删除客户联系人信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int DeleteCustomerContactByCustomerId(int customerId)
        {
            return dal.DeleteCustomerContactByCustomerId(customerId);
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

        public CustomerInfo GetCustomerByContactId(int contactId)
        {
            return dal.GetCustomerByContactId(contactId);
        }

        
        /// <summary>
        /// 根据CustomerID查询所有联系人信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByCustomerID(int customerID)
        {
            DataTable dataTable = new DataTable();
            DataColumn contactID = new DataColumn("联系人ID");
            DataColumn contactName = new DataColumn("联系人姓名");
            DataColumn position = new DataColumn("职位");
            DataColumn mobilephone = new DataColumn("手机");
            DataColumn telephone = new DataColumn("固定电话");
            DataColumn email = new DataColumn("邮箱");
            DataColumn address = new DataColumn("地址");
            DataColumn postcode = new DataColumn("邮编");
            DataColumn fax = new DataColumn("传真号");

            dataTable.Columns.Add(contactID);
            dataTable.Columns.Add(contactName);
            dataTable.Columns.Add(position);
            dataTable.Columns.Add(mobilephone);
            dataTable.Columns.Add(telephone);
            dataTable.Columns.Add(email);
            dataTable.Columns.Add(address);
            dataTable.Columns.Add(postcode);
            dataTable.Columns.Add(fax);

            IList<ContactInfo> contactInfos = GetCustomerContactsByCustomerId(customerID); //查询语句
            Customer customer = new Customer();
            User user = new User();

            for (int i = 0; i < contactInfos.Count; ++i)
            {
                ContactInfo contactInfo = contactInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["联系人ID"] = contactInfo.ContactID;
                dataRow["联系人姓名"] = contactInfo.ContactName;
                dataRow["职位"] = contactInfo.Position;
                dataRow["手机"] = contactInfo.Mobilephone;
                dataRow["固定电话"] = contactInfo.Telephone;
                dataRow["邮箱"] = contactInfo.Email;
                dataRow["地址"] = contactInfo.Address;
                dataRow["邮编"] = contactInfo.PostCode;
                dataRow["传真号"] = contactInfo.FaxNumber;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
}

