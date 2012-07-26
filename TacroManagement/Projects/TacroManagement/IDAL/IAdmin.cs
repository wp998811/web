using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IAdmin
    {
        AdminInfo GetAdminByName(string adminName);//通过管理员名得到管理员信息

        int UpdateAdmin(AdminInfo adminInfo);//更新管理员
    }
}
