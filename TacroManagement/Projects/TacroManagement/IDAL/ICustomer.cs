using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ICustomer
    {
        int InsertCustomer(CustomerInfo customerInfo);//新增客户
        int DeleteCustomer(int userId);//删除客户
        int UpdateCustomer(CustomerInfo customerInfo);//更新客户

        IList<CustomerInfo> GetCustomers();//查找所有客户
        CustomerInfo GetCustomerByCustomerName(string customerName);//通过客户名查找客户信息
        CustomerInfo GetCustomerById(int customerId);//通过客户编号查找客户信息
    }
}