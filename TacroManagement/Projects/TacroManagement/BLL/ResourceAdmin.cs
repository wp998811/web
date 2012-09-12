using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ResourceAdmin
    {
        private static readonly IResourceAdmin dal = DALFactory.DataAccess.CreateResourceAdmin();

        #region 基本方法
        public int InsertResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            return dal.InsertResourceAdmin(resourceAdminInfo);
        }

        public int DeleteResourceAdmin(int id)
        {
            return dal.DeleteResourceAdmin(id);
        }

        public int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo)
        {
            return dal.UpdateResourceAdmin(resourceAdminInfo);
        }

        public IList<ResourceAdminInfo> GetResourceAdmins()
        {
            return dal.GetResourceAdmins();
        }

        public IList<ResourceAdminInfo> GetResourceAdminsByUserID(int userID)
        {
            return dal.GetResourceAdminsByUserID(userID);
        }

        public ResourceAdminInfo GetResourceAdminByID(int id)
        {
            return dal.GetResourceAdminByID(id);
        }
        #endregion


        #region 业务逻辑

        /// <summary>
        /// 修改资源管理关系
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public bool ModifyResourceAdmin(int id, int userID, string resourceType)
        {
            if (id < 1)
                return false;
            if (userID < 1)
                return false;

            ResourceAdminInfo resourceAdminInfo = GetResourceAdminByID(id);
            resourceAdminInfo.UserID = userID;
            resourceAdminInfo.ResourceType = resourceType;

            if (dal.UpdateResourceAdmin(resourceAdminInfo) == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public bool AddResourceAdmin(int userID, string resourceType)
        {
            if (userID < 1)
            {
                return false;
            }

            if (InsertResourceAdmin(new ResourceAdminInfo(userID, resourceType)) == 1)
            {
                return true;
            }

            return false;
        }


        #endregion
    }
}
