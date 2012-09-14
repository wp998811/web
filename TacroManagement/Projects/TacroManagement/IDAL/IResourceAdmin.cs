using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IResourceAdmin
    {
        int UpdateResourceAdmin(ResourceAdminInfo resourceAdminInfo);
        ResourceAdminInfo GetResourceAdminByResourceTypeAndUserID(int userID, string resourceType);
    }
}
