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
    public class ClinicalContact
    {
        private static readonly IClinicalContact dal = DALFactory.DataAccess.CreateClinicalContact();

        #region
        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            return dal.InsertClinicalContact(clinicalContactInfo);
        }

        /// <summary>
        /// 更新临床联系人
        /// </summary>
        /// <param name="clinicalContactInfo"></param>
        /// <returns></returns>
        public int UpdateClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            return dal.UpdateClinicalContact(clinicalContactInfo);
        }

        /// <summary>
        /// 删除临床联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteClinicalContact(int id)
        {
            return dal.DeleteClinicalContact(id);
        }

        /// <summary>
        /// 查找所有临床联系人
        /// </summary>
        /// <returns></returns>
        public IList<ClinicalContactInfo> GetClinicalContacts()
        {
            return dal.GetClinicalContacts();
        }

        public ClinicalContactInfo GetClinicalContactByContactId(int contactId)
        {
            return dal.GetClinicalContactByContactId(contactId);
        }

        /// <summary>
        /// 通过ID查找用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalContactInfo GetClinicalContactById(int id)
        {
            return dal.GetClinicalContactById(id);
        }

        public IList<ContactInfo> GetContactsByClinicalID(int clinicalID)
        {
            return dal.GetContactsByClinicalID(clinicalID);
        }

        #endregion

        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="clinicalId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool AddClinicalContact(int clinicalId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (clinicalId < 0 || contactId < 0)
                return false;
            if (1 == dal.InsertClinicalContact(new ClinicalContactInfo(clinicalId, contactId)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑临床联系人
        /// </summary>
        /// <param name="clinicalId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool ModifyClinicalContact(int id, int clinicalId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (clinicalId < 0 || contactId < 0)
                return false;
            ClinicalContactInfo clinicalContactInfo = dal.GetClinicalContactById(id);
            if (clinicalContactInfo == null)
                return false;
            clinicalContactInfo.ClinicalID = clinicalId;
            clinicalContactInfo.ContactID = contactId;

            if (1 == dal.UpdateClinicalContact(clinicalContactInfo))
                return true;
            return false;
        }

        /// <summary>
        /// 根据CustomerID查询所有联系人信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByClinicalID(int clinicalID)
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

            IList<ContactInfo> contactInfos = GetContactsByClinicalID(clinicalID); //查询语句
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

