using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IContact
    {
        int InsertContact(ContactInfo contactInfo);//新增联系人
        int DeleteContact(int contactId);//删除联系人
        int UpdateContact(ContactInfo contactInfo);//更新联系人

        IList<ContactInfo> GetContacts();//查找所有联系人
        ContactInfo GetContactByName(string contactName);//通过联系人姓名查找联系人信息
        ContactInfo GetContactById(int contactId);//通过联系人编号查找联系人信息
    }
}
