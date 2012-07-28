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
        /// 根据文档合作伙伴联系人编号查找合作伙伴联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartnerContactInfo GetPartnerContactById(int id)
        {
            return dal.GetPartnerContactById(id);
        }

        #endregion
    }
}
