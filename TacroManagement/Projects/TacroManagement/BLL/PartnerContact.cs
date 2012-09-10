using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class PartnerContact:IPartnerContact
    {
        private static readonly IPartnerContact dal = DALFactory.DataAccess.CreatePartnerContact();

        #region IPartnerContact Members

        /// <summary>
        /// 新增合作伙伴联系人
        /// </summary>
        /// <param name="partnerContactInfo"></param>
        /// <returns></returns>
        public int InsertPartnerContact(PartnerContactInfo PartnerContactInfo)
        {
            return dal.InsertPartnerContact(PartnerContactInfo);
        }

        /// <summary>
        /// 删除合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePartnerContact(int id)
        {
            return dal.DeletePartnerContact(id);
        }

        public int DeletePartnerContactByPartnerId(int partnerId)
        {
            return dal.DeletePartnerContactByPartnerId(partnerId);
        }

        public int DeletePartnerContactByContactId(int contactId)
        {
            return dal.DeletePartnerContactByContactId(contactId);
        }

        /// <summary>
        /// 更新合作伙伴联系人
        /// </summary>
        /// <param name="partnerContactInfo"></param>
        /// <returns></returns>
        public int UpdatePartnerContact(PartnerContactInfo PartnerContactInfo)
        {
            return dal.UpdatePartnerContact(PartnerContactInfo);
        }

        /// <summary>
        /// 查找所有合作伙伴联系人
        /// </summary>
        /// <returns></returns>
        public IList<PartnerContactInfo> GetPartnerContact()
        {
            return dal.GetPartnerContact();
        }

        /// <summary>
        /// 根据合作伙伴联系人编号查找合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartnerContactInfo GetPartnerContactById(int id)
        {
            return dal.GetPartnerContactById(id);
        }

        /// <summary>
        /// 根据合作伙伴ID查找合作伙伴联系人
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        public IList<PartnerContactInfo> GetPartnerContactByPartner(int partnerId)
        {
            return dal.GetPartnerContactByPartner(partnerId);
        }

        /// <summary>
        /// 根据联系人ID查找合作伙伴联系人
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public PartnerContactInfo GetPartnerContactByContactId(int contactId)
        {
            return dal.GetPartnerContactByContactId(contactId);
        }

        public IList<ContactInfo> GetContactsByPartnerId(int partnerID)
        {
            return dal.GetContactsByPartnerId(partnerID);
        }

        /// <summary>
        /// 根据CustomerID查询所有联系人信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByPartnerID(int partnerID)
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

            IList<ContactInfo> contactInfos = GetContactsByPartnerId(partnerID); //查询语句
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

        #endregion


    }
}
