using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class PartnerResource:IPartnerResource
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
        public IList<PartnerResourceInfo> GetPartnerResourceByCondition(string selectCondition )
        {
            return dal.GetPartnerResourceByCondition(selectCondition);
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
                condition += " GoverCity LIKE '%" + cityName + "%' ";
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
        public DataTable GetDataTableByGoverList(IList<PartnerResourceInfo> partnerResourceInfos)
        {
            DataTable dataTable = new DataTable();

            DataColumn userNameColumn = new DataColumn("负责人");
            DataColumn cityNameColumn = new DataColumn("所属城市");
            DataColumn organNameColumn = new DataColumn("机构名称");
            DataColumn organIntroColumn = new DataColumn("机构简介");

            dataTable.Columns.Add(userNameColumn);
            dataTable.Columns.Add(cityNameColumn);
            dataTable.Columns.Add(organNameColumn);
            dataTable.Columns.Add(organIntroColumn);

            for (int i = 0; i < partnerResourceInfos.Count; ++i)
            {
                PartnerResourceInfo partnerResourceInfo = partnerResourceInfos[i];

                DataRow dataRow = dataTable.NewRow();
                User user = new User();
                UserInfo userInfo = user.GetUserById(partnerResourceInfo.UserID);
                dataRow["负责人"] = userInfo.UserName;
                dataRow["所属城市"] = partnerResourceInfo.PartnerCity;
                dataRow["机构名称"] = partnerResourceInfo.OrganName;
                dataRow["机构简介"] = partnerResourceInfo.OrganIntro;

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
        #endregion
    }
}
