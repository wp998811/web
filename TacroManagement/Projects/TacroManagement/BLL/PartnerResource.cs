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

        #endregion
    }
}
