using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Department
    {
        private static readonly IDepartment dal = DALFactory.DataAccess.CreateDepartment();

        #region 基本方法

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public int InsertDepartment(DepartmentInfo departmentInfo)
        {
            return dal.InsertDepartment(departmentInfo);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="departID"></param>
        /// <returns></returns>
        public int DeleteDepartment(int departID)
        {
            return dal.DeleteDepartment(departID);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public int UpdateDepartment(DepartmentInfo departmentInfo)
        {
            return dal.UpdateDepartment(departmentInfo);
        }

        /// <summary>
        /// 查找所有部门
        /// </summary>
        /// <returns></returns>
        public IList<DepartmentInfo> GetDepartments()
        {
            return dal.GetDepartments();
        }

        /// <summary>
        /// 根据部门名称查找部门
        /// </summary>
        /// <param name="departName"></param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentByName(string departName)
        {
            return dal.GetDepartmentByName(departName);
        }

        /// <summary>
        /// 根据部门编号查找部门
        /// </summary>
        /// <param name="departID"></param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentByID(int departID)
        {
            return dal.GetDepartmentByID(departID);
        }

        #endregion

        #region 业务


        /// <summary>
        /// 判断部门是否已存在
        /// </summary>
        /// <param name="departName"></param>
        /// <returns></returns>
        public bool IsDepartmentExists(string departName)
        {
            DepartmentInfo department = GetDepartmentByName(departName);
            if (null == department || 1 > department.DepartID)
                return false;
            return true;
        }

        /// <summary>
        /// 新建部门
        /// </summary>
        /// <param name="departName"></param>
        /// <param name="departAdmin"></param>
        /// <returns></returns>
        public bool AddDepartment(string departName, string departAdmin)
        {
            if (string.IsNullOrEmpty(departName) || string.IsNullOrEmpty(departAdmin))
                return false;
            if (1 == dal.InsertDepartment(new DepartmentInfo(departName, departAdmin)))
                return true;
            return false;
        }


        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <param name="departID"></param>
        /// <param name="departName"></param>
        /// <param name="departAdmin"></param>
        /// <returns></returns>
        public bool EditDepartment(int departID, string departName, string departAdmin)
        {
            if (string.IsNullOrEmpty(departName) || string.IsNullOrEmpty(departAdmin))
            {
                return false;
            }
            DepartmentInfo departmentInfo = dal.GetDepartmentByID(departID);
            if (departmentInfo == null)
                return false;
            departmentInfo.DepartName = departName;
            departmentInfo.DepartAdmin = departAdmin;

            if (1 == dal.UpdateDepartment(departmentInfo))
            {
                return true;
            }
            return false;

        }
        #endregion

    }
}
