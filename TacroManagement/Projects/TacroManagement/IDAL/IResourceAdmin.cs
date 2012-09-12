using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IResourceAdmin
    {
        int InsertResourceAdmin(ResourceAdminInfo resourceAdminInfo);
        int DeleteResourceAdmin(int id);
        int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo);

        IList<ResourceAdminInfo> GetResourceAdmins();
        IList<ResourceAdminInfo> GetResourceAdminsByUserID(int userID);
        ResourceAdminInfo GetResourceAdminByID(int id);

    }
}
