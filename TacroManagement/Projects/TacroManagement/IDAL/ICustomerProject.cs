using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ICustomerProject
    {
        int InsertCustomerProject(CustomerProjectInfo customerProject);//新增客户项目关系
        int DeleteCustomerProject(int projID);//删除客户项目关系
        int UpdateCustomerProject(CustomerProjectInfo customerProject);//更新客户项目关系

        IList<CustomerProjectInfo> GetCustomerProjects();//查找所有客户项目
        IList<CustomerProjectInfo> GetCustomerProjectsByCustomerId(int customerID);// 通过负责人ID查找客户项目
        CustomerProjectInfo GetCustomerProjByPorjId(int customerContactId);
        IList<CustomerProjectInfo> GetCustomerProjectInfoByCondition(string selectCondition);
    }
}
