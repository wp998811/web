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
