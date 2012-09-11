using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class GoverResource : IGoverResource
    {

        private static readonly IGoverResource dal = DALFactory.DataAccess.CreateGoverResource();

        #region IGoverResource Members

        /// <summary>
        /// 新增政府资料
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int InsertGoverResource(GoverResourceInfo goverResourceInfo)
        {
            return dal.InsertGoverResource(goverResourceInfo);
        }

        /// <summary>
        /// 删除政府资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoverResource(int id)
        {
            return dal.DeleteGoverResource(id);
        }

        /// <summary>
        /// 更新政府资料
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int UpdeteGoverResource(GoverResourceInfo goverResourceInfo)
        {
            return dal.UpdeteGoverResource(goverResourceInfo);
        }

        /// <summary>
        /// 查找所有政府资料
        /// </summary>
        /// <returns></returns>
        public IList<GoverResourceInfo> GetGoverResource()
        {
            return dal.GetGoverResource();
        }

        /// <summary>
        /// 根据政府联系人编号查找政府资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoverResourceInfo GetGoverResourceById(int id)
        {
            return dal.GetGoverResourceById(id);
        }

        /// <summary>
        /// 根据政府机构名称查找政府资料
        /// </summary>
        /// <param name="organName"></param>
        /// <returns></returns>
        public GoverResourceInfo GetGoverResourceByOrganName(string organName)
        {
            return dal.GetGoverResourceByOrganName(organName);
        }

        /// <summary>
        /// 根据查询条件查找政府资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<GoverResourceInfo> GetGoverResourceByCondition(string selectCondition)
        {
            return dal.GetGoverResourceByCondition(selectCondition);
        }

        public IList<ContactInfo> GetContactsByGoverResourceId(int goverResourceId)
        {
            return dal.GetContactsByGoverResourceId(goverResourceId);
        }

        #endregion

        /// <summary>
        /// 通过政府资料List返回DataTable
        /// </summary>
        /// <param name="goverResourceInfos"></param>
        /// <returns></returns>
        public DataTable GetDataTableByGoverList(IList<GoverResourceInfo> goverResourceInfos)
        {
            DataTable dataTable = new DataTable();

            DataColumn goverIDColumn = new DataColumn("政府资源ID");
            DataColumn userNameColumn = new DataColumn("负责人姓名");
            DataColumn cityNameColumn = new DataColumn("城市");
            DataColumn organNameColumn = new DataColumn("组织名称");
            DataColumn organIntroColumn = new DataColumn("组织简介");

            dataTable.Columns.Add(goverIDColumn);
            dataTable.Columns.Add(userNameColumn);
            dataTable.Columns.Add(cityNameColumn);
            dataTable.Columns.Add(organNameColumn);
            dataTable.Columns.Add(organIntroColumn);

            for (int i = 0; i < goverResourceInfos.Count; ++i)
            {
                GoverResourceInfo goverResourceInfo = goverResourceInfos[i];

                DataRow dataRow = dataTable.NewRow();
                User user = new User();
                UserInfo userInfo = user.GetUserById(goverResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;
                dataRow["政府资源ID"] = goverResourceInfo.GoverID;
                dataRow["城市"] = goverResourceInfo.GoverCity;
                dataRow["组织名称"] = goverResourceInfo.OrganName;
                dataRow["组织简介"] = goverResourceInfo.OrganIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;

        }

        /// <summary>
        /// 通过用户输入的条件查询GoverResource
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <param name="contactName"></param>
        /// <returns>符合查询条件的List</returns>
        public IList<GoverResourceInfo> GetGoverResourceBySearch(string userName, string cityName, string organName, string contactName)
        {
            string condition = GetGoverResourceSearchCondition(userName, cityName, organName);
            IList<GoverResourceInfo> goverResourceInfos = GetGoverResourceByCondition(condition);
            if (!string.IsNullOrEmpty(contactName))
            {
                Contact contact = new Contact();
                ContactInfo contactInfo = contact.GetContactByContactName(contactName);
                if (string.IsNullOrEmpty(contactInfo.ContactName))
                {
                    return new List<GoverResourceInfo>();
                }

                GoverContact goverContact = new GoverContact();
                GoverContactInfo goverContactInfo = goverContact.GetGoverContactByContactId(contactInfo.ContactID);
                if (goverContactInfo.ContactID != contactInfo.ContactID)
                {
                    return new List<GoverResourceInfo>();
                }

                IList<GoverResourceInfo> gRfs = new List<GoverResourceInfo>();
                for (int i = 0; i < goverResourceInfos.Count; ++i)
                {
                    if (goverResourceInfos[i].GoverID == goverContactInfo.GoverID)
                    {

                        gRfs.Add(goverResourceInfos[i]);
                    }
                }

                goverResourceInfos = gRfs;
            }

            return goverResourceInfos;
        }


        //int userID, string cityName, string organName, string organIntro, string contactName,string position, string mobilephone, string telephone, string email, string address, string postCode, string faxNumber
        /// <summary>
        /// 增加GoverResource记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <param name="organIntro"></param>
        /// <returns>增加是否成功</returns>
        public bool AddGoverResource(int userID, string cityName, string organName, string organIntro)
        {
            GoverResource goverResource = new GoverResource();
            GoverResourceInfo goverResourceInfo = new GoverResourceInfo();
            goverResourceInfo.UserID = userID;
            goverResourceInfo.GoverCity = cityName;
            goverResourceInfo.OrganName = organName;
            goverResourceInfo.OrganIntro = organIntro;

            int isInsert = goverResource.InsertGoverResource(goverResourceInfo);
            if (isInsert != 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据查询条件生成sql查询语句
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <returns>sql查询条件</returns>
        public string GetGoverResourceSearchCondition(string userName, string cityName, string organName)
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
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllGoverResources()
        {
            DataTable dataTable = new DataTable();
            DataColumn goverResourceID = new DataColumn("政府资源ID");
            DataColumn userName = new DataColumn("负责人姓名");
            DataColumn city = new DataColumn("城市");
            DataColumn organName = new DataColumn("组织名称");
            DataColumn organIntro = new DataColumn("组织简介");

            dataTable.Columns.Add(goverResourceID);
            dataTable.Columns.Add(userName);
            dataTable.Columns.Add(city);
            dataTable.Columns.Add(organName);
            dataTable.Columns.Add(organIntro);

            IList<GoverResourceInfo> goverResourceInfos = GetGoverResource(); //查询语句
            GoverResource partnerResource = new GoverResource();
            User user = new User();

            for (int i = 0; i < goverResourceInfos.Count; ++i)
            {
                GoverResourceInfo goverResourceInfo = goverResourceInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["政府资源ID"] = goverResourceInfo.GoverID;

                UserInfo userInfo = user.GetUserById(goverResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;

                dataRow["城市"] = goverResourceInfo.GoverCity;
                dataRow["组织名称"] = goverResourceInfo.OrganName;
                dataRow["组织简介"] = goverResourceInfo.OrganIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByGoverResourceID(int goverResourceId)
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

            IList<ContactInfo> contactInfos = GetContactsByGoverResourceId(goverResourceId); //查询语句
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
