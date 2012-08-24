using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ICustomerContact
    {
        int InsertCustomerContact(CustomerContactInfo userInfo);//新增客户联系人信息
        int DeleteCustomerContact(int id);//删除客户联系人信息
        int UpdateCustomerContact(CustomerContactInfo userInfo);//更新客户联系人信息

        IList<ContactInfo> GetContactsByCustomerId(int customerId);//根据客户ID查找所有联系人信息
        IList<CustomerContactInfo> GetCustomerContacts();//查找所有客户联系人信息
        CustomerContactInfo GetCustomerContactById(int id);//根据ID查询所有联系人信息
    }
}
