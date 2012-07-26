using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Admin
    {
        private static readonly IAdmin dal = DALFactory.DataAccess.CreateAdmin();

        public AdminInfo GetAdminByName(string adminName)
        {
            return dal.GetAdminByName(adminName);
        }

        public int UpdateAdmin(AdminInfo adminInfo)
        {
            return dal.UpdateAdmin(adminInfo);
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPassword"></param>
        /// <returns></returns>
        public bool Login(string adminName, string adminPassword)
        {
            Admin admin = new Admin();
            AdminInfo adminInfo = admin.GetAdminByName(adminName);

            if (adminInfo != null)
            {
                if ((!string.IsNullOrEmpty(adminInfo.AdminName)) && (!string.IsNullOrEmpty(adminInfo.AdminPassword)))
                {
                    string password = adminInfo.AdminPassword;
                    if (password == adminPassword)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

    }
}
