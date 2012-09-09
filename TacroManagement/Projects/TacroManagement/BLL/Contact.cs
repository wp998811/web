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
    public class Contact
    {
        private static readonly IContact dal = DALFactory.DataAccess.CreateContact();

        #region
        /// <summary>
        /// 新增联系人
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public int InsertContact(ContactInfo contactInfo)
        {
            return dal.InsertContact(contactInfo);
        }

        /// <summary>
        /// 更新联系人
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public int UpdateContact(ContactInfo contactInfo)
        {
            return dal.UpdateContact(contactInfo);
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public int DeleteContact(int contactID)
        {
            return dal.DeleteContact(contactID);
        }

        /// <summary>
        /// 查找所有联系人
        /// </summary>
        /// <returns></returns>
        public IList<ContactInfo> GetContacts()
        {
            return dal.GetContacts();
        }

        /// <summary>
        /// 通过联系人ID查找联系人
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public ContactInfo GetContactById(int contactId)
        {
            return dal.GetContactById(contactId);
        }

        /// <summary>
        /// 通过联系人名字查找联系人
        /// </summary>
        /// <param name="contactName"></param>
        /// <returns></returns>
        public ContactInfo GetContactByContactName(string contactName)
        {
            return dal.GetContactByName(contactName);
        }

        /// <summary>
        /// 通过联系人名字和电话查找联系人
        /// </summary>
        /// <param name="contactName"></param>
        /// <returns></returns>
        public ContactInfo GetContactByContactNameAndTelephone(string contactName, string telephone)
        {
            return dal.GetContactByNameAndTelephone(contactName, telephone);
        }

        #endregion

        /// <summary>
        /// 新增联系人
        /// </summary>
        /// <param name="contactName"></param>
        /// <param name="position"></param>
        /// <param name="mobilephone"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="postCode"></param>
        /// <param name="faxNumber"></param>
        /// <returns></returns>
        public bool AddContact(string contactName, string position, string mobilephone, string telephone, string email, string address, string postCode, string faxNumber)
        {
            if (string.IsNullOrEmpty(contactName))
                return false;
            if (1 == dal.InsertContact(new ContactInfo(contactName, position, mobilephone, telephone, email, address, postCode, faxNumber)))
                return true;
            return false;
        }

        /// <summary>
        ///编辑联系人
        /// </summary>
        /// <param name="contactName"></param>
        /// <param name="position"></param>
        /// <param name="mobilephone"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="postCode"></param>
        /// <param name="faxNumber"></param>
        /// <returns></returns>
        public bool ModifyContact(int userID, string contactName, string position, string mobilephone, string telephone, string email, string address, string postCode, string faxNumber)
        {
            if (string.IsNullOrEmpty(contactName))
                return false;
            if (userID < 0)
                return false;
            ContactInfo contactInfo = dal.GetContactById(userID);
            if (contactInfo == null)
                return false;
            contactInfo.ContactName = contactName;
            contactInfo.Position = position;
            contactInfo.Mobilephone = mobilephone;
            contactInfo.Telephone = telephone;
            contactInfo.Email = email;
            contactInfo.Address = address;
            contactInfo.PostCode = postCode;
            contactInfo.FaxNumber = faxNumber;

            if (1 == dal.UpdateContact(contactInfo))
                return true;
            return false;
        }

        /// <summary>
        /// 根据CustomerID查询所有联系人信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContacts()
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

            IList<ContactInfo> contactInfos = GetContacts(); //查询语句
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
