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
        /// 新增政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int InsertGoverResource(GoverResourceInfo goverResourceInfo)
        {
            return dal.InsertGoverResource(goverResourceInfo);
        }

        /// <summary>
        /// 删除政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoverResource(int id)
        {
            return dal.DeleteGoverResource(id);
        }

        /// <summary>
        /// 更新政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int UpdeteGoverResource(GoverResourceInfo goverResourceInfo)
        {
            return dal.UpdeteGoverResource(goverResourceInfo);
        }

        /// <summary>
        /// 查找所有政府联系人
        /// </summary>
        /// <returns></returns>
        public IList<GoverResourceInfo> GetGoverResource()
        {
            return dal.GetGoverResource();
        }

        /// <summary>
        /// 根据文档政府联系人编号查找政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoverResourceInfo GetGoverResourceById(int id)
        {
            return dal.GetGoverResourceById(id);
        }

        #endregion
    }
}
