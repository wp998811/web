using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IVisitRecord
    {
        int InsertVisitRecord(VisitRecordInfo visitRecord);//新增拜访记录
        int DeleteVisitRecord(int userId);//删除拜访记录
        int UpdateVisitRecord(VisitRecordInfo visitRecord);//更新拜访记录

        IList<VisitRecordInfo> GetVisitRecords();//查找所有拜访记录
        IList<VisitRecordInfo> GetVisitRecordsByUserId(int userID);//通过用户ID查找拜访记录
        IList<VisitRecordInfo> GetVisitRecordsByContactId(int contactID);//通过联系人ID查找拜访记录
        VisitRecordInfo GetVisitRecordById(int id);//通过ID查找拜访记录
    }
}
