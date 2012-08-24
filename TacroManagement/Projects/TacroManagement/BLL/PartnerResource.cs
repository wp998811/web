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

        public DataTable GetPartnerResourceAndContactByCondition()
        {

            DataTable dataTable = new DataTable();

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

            return dataTable;
        }
        #endregion
    }
}
