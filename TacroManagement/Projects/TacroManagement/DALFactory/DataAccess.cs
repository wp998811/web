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


        public static IDAL.IProject CreateProject()
        {
            string className = path + ".Project";
            return (IDAL.IProject)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IProjectUser CreateProjectUser()
        {
            string className = path + ".ProjectUser";
            return (IDAL.IProjectUser)Assembly.Load(path).CreateInstance(className);
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



        public static IDAL.IProjectClient CreateProjectClient()
        {
            string className = path + ".ProjectClient";
            return (IDAL.IProjectClient)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IProjectDoc CreateProjectDoc()
        {
            string className = path + ".ProjectDoc";
            return (IDAL.IProjectDoc)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IProjectDocUser CreateProjectDocUser()
        {
            string className = path + ".ProjectDocUser";
            return (IDAL.IProjectDocUser)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.ISubTask CreateSubTask()
        {
            string className = path + ".SubTask";
            return (IDAL.ISubTask)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.IAffair CreateAffair()
        {
            string className = path + ".Affair";
            return (IDAL.IAffair)Assembly.Load(path).CreateInstance(className);
        }

        public static IDAL.ISchedule CreateSchedule()
        {
            string className = path + ".Schedule";
            return (IDAL.ISchedule)Assembly.Load(path).CreateInstance(className);
        }
    }
}
