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

        public static IDAL.IDepartDocCate CreateDepartDocCate()
        {
            string className = path + ".DepartDocCate";
            return (IDAL.IDepartDocCate)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IDocument CreateDocument()
        {
            string className = path + ".Document";
            return (IDAL.IDocument)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IDocUser CreateDocUser()
        {
            string className = path + ".DocUser";
            return (IDAL.IDocUser)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IGoverContact CreateGoverContact()
        {
            string className = path + ".GoverContact";
            return (IDAL.IGoverContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IGoverResource CreateGoverResource()
        {
            string className = path + ".GoverResource";
            return (IDAL.IGoverResource)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IPartnerContact CreatePartnerContact()
        {
            string className = path + ".PartnerContact";
            return (IDAL.IPartnerContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IPartnerResource CreatePartnerResource()
        {
            string className = path + ".PartnerResource";
            return (IDAL.IPartnerResource)Assembly.Load(path).CreateInstance(className);
        }

    }
}
