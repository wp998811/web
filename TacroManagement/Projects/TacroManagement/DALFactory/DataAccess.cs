using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Configuration;
using IDAL;

namespace DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        public DataAccess()
        {
        }

        public static IDAL.IAdmin CreateAdmin()
        {
            string className = path + ".Admin";
            return (IDAL.IAdmin)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IUser CreateUser()
        {
            string className = path + ".User";
            return (IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IDepartment CreateDepartment()
        {
            string className = path + ".Department";
            return (IDAL.IDepartment)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IClient CreateClient()
        {
            string className = path + ".Client";
            return (IDAL.IClient)Assembly.Load(path).CreateInstance(className);
        }

    }
}
