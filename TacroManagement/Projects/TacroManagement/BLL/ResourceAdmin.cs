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
    public class ResourceAdmin
    {
        private static readonly IResourceAdmin dal = DALFactory.DataAccess.CreateResourceAdmin();

        #region
        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            return dal.UpdateResourceAdmin(resourceAdminInfo);
        }

        /// <summary>
        /// 更新临床联系人
        /// </summary>
        /// <param name="clinicalContactInfo"></param>
        /// <returns></returns>
        public ResourceAdminInfo GetResourceAdminByResourceTypeAndUserID(int userID, string resourceType)
        {
            return dal.GetResourceAdminByResourceTypeAndUserID(userID, resourceType);
        }

        #endregion
    }
}
