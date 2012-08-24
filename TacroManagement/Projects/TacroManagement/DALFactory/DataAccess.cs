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

        public static IDAL.ICustomer CreateCustomer()
        {
            string className = path + ".Customer";
            return (IDAL.ICustomer)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IContact CreateContact()
        {
            string className = path + ".Customer";
            return (IDAL.IContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.ICustomerContact CreateCustomerContact()
        {
            string className = path + ".Customer";
            return (IDAL.ICustomerContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IVisitRecord CreateVisitRecord()
        {
            string className = path + ".Customer";
            return (IDAL.IVisitRecord)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.ICustomerProject CreateCustomerProject()
        {
            string className = path + ".Customer";
            return (IDAL.ICustomerProject)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.ICustomerProjContact CreateCustomerProjContact()
        {
            string className = path + ".Customer";
            return (IDAL.ICustomerProjContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IClinicalResource CreateClinicalResource()
        {
            string className = path + ".Customer";
            return (IDAL.IClinicalResource)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IClinicalContact CreateClinicalContact()
        {
            string className = path + ".Customer";
            return (IDAL.IClinicalContact)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IContactRecord CreateContactRecord()
        {
            string className = path + ".Customer";
            return (IDAL.IContactRecord)Assembly.Load(path).CreateInstance(className);
        }

    }
}
