using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IDepartment
    {
        int InsertDepartment(DepartmentInfo departmentInfo);//新建部门
        int DeleteDepartment(int departID);//删除部门
        int UpdateDepartment(DepartmentInfo departmentInfo);//编辑部门

        IList<DepartmentInfo> GetDepartments();//查找所有部门
        DepartmentInfo GetDepartmentByName(string departName);//通过部门名查找部门
        DepartmentInfo GetDepartmentByID(int departID);//通过部门编号查找部门

    }
}