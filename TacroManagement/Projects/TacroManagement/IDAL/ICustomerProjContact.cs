using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ICustomerProjContact
    {
        int InsertCustomerProjContact(CustomerProjContactInfo customerProjContact);//新增客户项目联系人关系
        int DeleteCustomerProjContact(int id);//删除客户项目联系人关系
        int UpdateCustomerProjContact(CustomerProjContactInfo customerProjContact);//更新客户项目联系人关系

        IList<CustomerProjContactInfo> GetCustomerProjContacts();//查找客户项目联系人关系
        CustomerProjContactInfo GetCustomerProjContactById(int id);//通过ID查找客户项目联系人关系
        //IList<CustomerProjContactInfo> GetCustomerProjContactByContactId(int contactID);//通过联系人ID查找客户项目联系人关系
        //IList<CustomerProjContactInfo> GetCustomerProjContactByCustomerProjID(int customerProjID);//通过客户项目ID查找客户项目联系人关系
    }
}