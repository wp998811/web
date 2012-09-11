using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class PartnerResource : IPartnerResource
    {

        private static readonly IPartnerResource dal = DALFactory.DataAccess.CreatePartnerResource();

        #region IPartnerResource Members

        /// <summary>
        /// 新增合作伙伴资料
        /// </summary>
        /// <param name="partnerResourceInfo"></param>
        /// <returns></returns>
        public int InsertPartnerResource(PartnerResourceInfo PartnerResourceInfo)
        {
            return dal.InsertPartnerResource(PartnerResourceInfo);
        }

        /// <summary>
        /// 删除合作伙伴资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePartnerResource(int id)
        {
            return dal.DeletePartnerResource(id);
        }

        /// <summary>
        /// 更新合作伙伴资料
        /// </summary>
        /// <param name="partnerResourceInfo"></param>
        /// <returns></returns>
        public int UpdetePartnerResource(PartnerResourceInfo PartnerResourceInfo)
        {
            return dal.UpdetePartnerResource(PartnerResourceInfo);
        }

        /// <summary>
        /// 查找所有合作伙伴资料
        /// </summary>
        /// <returns></returns>
        public IList<PartnerResourceInfo> GetPartnerResource()
        {
            return dal.GetPartnerResource();
        }

        /// <summary>
        /// 根据文档合作伙伴资料编号查找合作伙伴资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartnerResourceInfo GetPartnerResourceById(int id)
        {
            return dal.GetPartnerResourceById(id);
        }

        /// <summary>
        /// 根据查询条件查找合作伙伴资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<PartnerResourceInfo> GetPartnerResourceByCondition(string selectCondition)
        {
            return dal.GetPartnerResourceByCondition(selectCondition);
        }

        public IList<ContactInfo> GetContactsByPartnerResourceId(int partnerResourceId)
        {
            return dal.GetContactsByPartnerResourceId(partnerResourceId);
        }

        /// <summary>
        /// 根据查询条件生成sql查询语句
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <returns>sql查询条件</returns>
        public string GetPartnerResourceSearchCondition(string userName, string cityName, string organName)
        {

            string condition = "";

            if (!string.IsNullOrEmpty(userName))
            {
                User user = new User();
                UserInfo userInfo = user.GetUserByName(userName);
                if (string.IsNullOrEmpty(userInfo.UserName))
                {
                    return "";
                }
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UserID = '" + userInfo.UserID + "' ";
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " PartnerCity LIKE '%" + cityName + "%' ";
            }

            if (!string.IsNullOrEmpty(organName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " OrganName LIKE '%" + organName + "%' ";
            }
            return condition;

        }

        /// <summary>
        /// 通过合作者资料List返回DataTable
        /// </summary>
        /// <param name="partnerResourceInfos"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPartnerList(IList<PartnerResourceInfo> partnerResourceInfos)
        {
            DataTable dataTable = new DataTable();

            DataColumn partnerIDColumn = new DataColumn("合作伙伴资源ID");
            DataColumn userNameColumn = new DataColumn("负责人姓名");
            DataColumn cityNameColumn = new DataColumn("城市");
            DataColumn organNameColumn = new DataColumn("组织名称");
            DataColumn organIntroColumn = new DataColumn("组织简介");

            dataTable.Columns.Add(partnerIDColumn);
            dataTable.Columns.Add(userNameColumn);
            dataTable.Columns.Add(cityNameColumn);
            dataTable.Columns.Add(organNameColumn);
            dataTable.Columns.Add(organIntroColumn);

            for (int i = 0; i < partnerResourceInfos.Count; ++i)
            {
                PartnerResourceInfo partnerResourceInfo = partnerResourceInfos[i];

                DataRow dataRow = dataTable.NewRow();
                User user = new User();
                dataRow["合作伙伴资源ID"] = partnerResourceInfo.PartnerID;
                UserInfo userInfo = user.GetUserById(partnerResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;
                dataRow["城市"] = partnerResourceInfo.PartnerCity;
                dataRow["组织名称"] = partnerResourceInfo.OrganName;
                dataRow["组织简介"] = partnerResourceInfo.OrganIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 通过查询条件获取合作者资料List
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <param name="contactName"></param>
        /// <returns>符合查询条件的List</returns>
        public IList<PartnerResourceInfo> GetPartnerResearchBySearch(string userName, string cityName, string organName, string contactName)
        {
            string condition = GetPartnerResourceSearchCondition(userName, cityName, organName);
            IList<PartnerResourceInfo> partnerResourceInfos = GetPartnerResourceByCondition(condition);
            if (!string.IsNullOrEmpty(contactName))
            {
                Contact contact = new Contact();
                ContactInfo contactInfo = contact.GetContactByContactName(contactName);
                if (string.IsNullOrEmpty(contactInfo.ContactName))
                {
                    return new List<PartnerResourceInfo>();
                }

                PartnerContact partnerContact = new PartnerContact();
                PartnerContactInfo partnerContactInfo = partnerContact.GetPartnerContactByContactId(contactInfo.ContactID);
                if (partnerContactInfo.ContactID != contactInfo.ContactID)
                {
                    return new List<PartnerResourceInfo>();
                }

                IList<PartnerResourceInfo> pRIs = new List<PartnerResourceInfo>();
                for (int i = 0; i < partnerResourceInfos.Count; ++i)
                {
                    if (partnerResourceInfos[i].PartnerID == partnerContactInfo.PartnerID)
                    {
                        pRIs.Add(partnerResourceInfos[i]);
                    }
                }
                partnerResourceInfos = pRIs;
            }

            return partnerResourceInfos;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllPartnerResources()
        {
            DataTable dataTable = new DataTable();
            DataColumn clinicalResourceID = new DataColumn("合作伙伴资源ID");
            DataColumn userName = new DataColumn("负责人姓名");
            DataColumn city = new DataColumn("城市");
            DataColumn organName = new DataColumn("组织名称");
            DataColumn organIntro = new DataColumn("组织简介");

            dataTable.Columns.Add(clinicalResourceID);
            dataTable.Columns.Add(userName);
            dataTable.Columns.Add(city);
            dataTable.Columns.Add(organName);
            dataTable.Columns.Add(organIntro);

            IList<PartnerResourceInfo> partnerResourceInfos = GetPartnerResource(); //查询语句
            PartnerResource partnerResource = new PartnerResource();
            User user = new User();

            for (int i = 0; i < partnerResourceInfos.Count; ++i)
            {
                PartnerResourceInfo partnerResourceInfo = partnerResourceInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["合作伙伴资源ID"] = partnerResourceInfo.PartnerID;

                UserInfo userInfo = user.GetUserById(partnerResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;

                dataRow["城市"] = partnerResourceInfo.PartnerCity;
                dataRow["组织名称"] = partnerResourceInfo.OrganName;
                dataRow["组织简介"] = partnerResourceInfo.OrganIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByPartnerResourceID(int partnerResourceId)
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

            IList<ContactInfo> contactInfos = GetContactsByPartnerResourceId(partnerResourceId); //查询语句
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
