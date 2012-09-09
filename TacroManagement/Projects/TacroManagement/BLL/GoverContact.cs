using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class GoverContact:IGoverContact
    {

        private static readonly IGoverContact dal = DALFactory.DataAccess.CreateGoverContact();
        #region IGoverContact Members

       /// <summary>
        /// 新增政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int InsertGoverContact(GoverContactInfo goverContactInfo)
        {
            return dal.InsertGoverContact(goverContactInfo);
        }

        /// <summary>
        /// 删除政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoverContact(int id)
        {
            return dal.DeleteGoverContact(id);
        }

        /// <summary>
        /// 更新政府联系人
        /// </summary>
        /// <param name="goverContactInfo"></param>
        /// <returns></returns>
        public int UpdateGoverContact(GoverContactInfo goverContactInfo)
        {
            return dal.UpdateGoverContact(goverContactInfo);
        }

        /// <summary>
        /// 查找所有政府联系人
        /// </summary>
        /// <returns></returns>
        public IList<GoverContactInfo> GetGoverContact()
        {
            return dal.GetGoverContact();
        }
        
        /// <summary>
        /// 根据文档政府联系人编号查找政府联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoverContactInfo GetGoverContactById(int id)
        {
            return dal.GetGoverContactById(id);
        }

        public IList<GoverContactInfo> GetGoverContactByGover(int goverId)
        {
            return dal.GetGoverContactByGover(goverId);
        }

        /// <summary>
        /// 通过政府资料ID查找政府联系人
        /// </summary>
        /// <param name="goverId"></param>
        /// <returns></returns>
        public GoverContactInfo GetGoverContactByContactId(int contactId)
        {
            return dal.GetGoverContactByContactId(contactId);
        }
        #endregion
    }
}
