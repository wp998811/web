using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class GoverResource:IGoverResource
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
        /// 根据文档政府联系人编号查找政府资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoverResourceInfo GetGoverResourceById(int id)
        {
            return dal.GetGoverResourceById(id);
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
        #endregion

         public DataTable GetGoverResourceAndContactByCondition(string userName, string cityName, string organName, string contactName)
         {

             string condition = "";
             if (!string.IsNullOrEmpty(userName))
             {
                 User user = new User();
                 UserInfo userInfo = user.GetUserByName(userName);
                 if (string.IsNullOrEmpty(userInfo.UserName))
                 {
                     return new DataTable();
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



             //    IList<GoverResourceInfo> goverResourceInfos = GetGoverResourceByCondition(condition);

                 DataTable dataTable = new DataTable();
             //    DataColumn userNameColumn = new DataColumn("负责人");
             //    DataColumn cityNameColumn = new DataColumn("所属城市");
             //    DataColumn organNameColumn = new DataColumn("机构名称");
             //    DataColumn contactNameColumn = new DataColumn("联系人姓名");
             //    DataColumn positionColumn = new DataColumn("职位");
             //    DataColumn mobilephoneColumn = new DataColumn("手机");
             //    DataColumn telephoneColumn= new DataColumn("固定电话");
             //    DataColumn emailColumn = new DataColumn("电子邮箱");
             //    DataColumn addressColumn = new DataColumn("地址");
             //    DataColumn postCodeColumn = new DataColumn("邮编");
             //    DataColumn faxNumberColumn = new DataColumn("传真");

             //    dataTable.Columns.Add(userNameColumn);
             //    dataTable.Columns.Add(cityNameColumn);
             //    dataTable.Columns.Add(organNameColumn);
             //    dataTable.Columns.Add(contactNameColumn);
             //    dataTable.Columns.Add(positionColumn);
             //    dataTable.Columns.Add(mobilephoneColumn);
             //    dataTable.Columns.Add(telephoneColumn);
             //    dataTable.Columns.Add(emailColumn);
             //    dataTable.Columns.Add(addressColumn);
             //    dataTable.Columns.Add(postCodeColumn);
             //    dataTable.Columns.Add(faxNumberColumn);

             //   // Contact contact = new Contact();
             //   // ContactInfo contactInfo = new ContactInfo();
             //    if (!string.IsNullOrEmpty(contactName))
             //    {

             //        //contactInfo = new contact.GetContactByName(contactName);
             //        if (string.IsNullOrEmpty(contactInfo.ContactName))
             //        {
             //            return new DataTable();
             //        }
             //    }
             //    for (int i = 0; i < goverResourceInfos.Count;++i )
             //    {
             //        GoverResourceInfo goverResourceInfo = goverResourceInfos[i];
             //        GoverContact goverContact = new GoverContact();
             //        GoverContactInfo goverContactInfo = goverContact.GetGoverContactByGover(goverResourceInfo.GoverID);              
             //        if (string.IsNullOrEmpty(contactInfo.ContactName))
             //        {
             //            //contactInfo = new contact.GetContactById(goverContactInfo.ContactID);
             //        }
             //        else
             //        {
             //            if (contactInfo.ContactID != goverContactInfo.ContactID)
             //            {
             //                continue;
             //            }
             //        }

             //        DataRow dataRow = dataTable.NewRow();
             //        User user1 = new User();
             //        UserInfo userInfo1 = user1.GetUserById(goverResourceInfo.UserID);
             //        dataRow["负责人"] = userInfo1.UserName;
             //        dataRow["所属城市"] = goverResourceInfo.GoverCity;
             //        dataRow["机构名称"] = goverResourceInfo.OrganName;
             //        dataRow["联系人姓名"] = contactInfo.ContactName;
             //        dataRow["职位"] = contactInfo.Position;
             //        dataRow["手机"] = contactInfo.Mobilephone;
             //        dataRow["固定电话"] = contactInfo.Telephone;
             //        dataRow["电子邮箱"] = contactInfo.Email;
             //        dataRow["地址"] = contactInfo.Address;
             //        dataRow["邮编"] = contactInfo.PostCode;
             //        dataRow["传真"] = contactInfo.FaxNumber;

             //        dataTable.Rows.Add(dataRow);
             //    }
                return dataTable;

             }
        
    }
}
