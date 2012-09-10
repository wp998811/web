using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IContactRecord
    {
        int InsertContactRecord(ContactRecordInfo contactRecord);//新增联系人记录
        int DeleteContactRecord(int ID);//删除联系人记录
        int UpdateContactRecord(ContactRecordInfo contactRecord);//更新联系人记录

        IList<ContactRecordInfo> GetContactRecords();//查找所有联系人记录
        ContactRecordInfo GetContactRecordById(int id);//通过联系人记录ID查找联系人记录
        IList<ContactRecordInfo> GetContactRecordsByUserId(int userId);//通过用户ID查找联系人记录
        IList<ContactRecordInfo> GetContactRecordsByContactId(int contactId);//通过联系人ID查找联系人记录
    }
}