using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ContactRecord
    {
        private static readonly IContactRecord dal = DALFactory.DataAccess.CreateContactRecord();

        #region
        /// <summary>
        /// 新增拜访记录
        /// </summary>
        /// <param name="contactRecordInfo"></param>
        /// <returns></returns>
        public int InsertContactRecord(ContactRecordInfo contactRecordInfo)
        {
            return dal.InsertContactRecord(contactRecordInfo);
        }

        /// <summary>
        /// 更新拜访记录
        /// </summary>
        /// <param name="contactRecordInfo"></param>
        /// <returns></returns>
        public int UpdateContactRecord(ContactRecordInfo contactRecordInfo)
        {
            return dal.UpdateContactRecord(contactRecordInfo);
        }

        /// <summary>
        /// 删除拜访记录
        /// </summary>
        /// <param name="contactRecordInfo"></param>
        /// <returns></returns>
        public int DeleteContactRecord(int id)
        {
            return dal.DeleteContactRecord(id);
        }

        /// <summary>
        /// 查找所有拜访记录
        /// </summary>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecords()
        {
            return dal.GetContactRecords();
        }

        /// <summary>
        /// 通过ID查找拜访记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactRecordInfo GetContactRecordById(int id)
        {
            return dal.GetContactRecordById(id);
        }
        #endregion

        /// <summary>
        /// 通过联系人ID查找拜访记录
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecordsByContactId(int contactId)
        {
            return dal.GetContactRecordsByContactId(contactId);
        }

        /// <summary>
        /// 通过用户ID查找拜访记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ContactRecordInfo> GetContactRecordsByUserId(int userId)
        {
            return dal.GetContactRecordsByUserId(userId);
        }

        /// <summary>
        /// 新增拜访记录
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="visitDetail"></param>
        /// <param name="recordTime"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddContactRecord(int contactId, string visitDetail, string recordTime, int userID)
        {
            if (contactId < 0 || userID < 0)
                return false;
            if (1 == dal.InsertContactRecord(new ContactRecordInfo(contactId, visitDetail, recordTime, userID)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑拜访记录
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="visitDetail"></param>
        /// <param name="recordTime"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyContactRecord(int id, int contactId, string recordDetail, string recordTime, int userID)
        {
            if (contactId < 0 || userID < 0)
                return false;
            ContactRecordInfo contactRecordInfo = dal.GetContactRecordById(id);
            if (contactRecordInfo == null)
                return false;
            contactRecordInfo.ContactID = contactId;
            contactRecordInfo.RecordDetail = recordDetail;
            contactRecordInfo.RecordTime = recordTime;
            contactRecordInfo.UserID = userID;

            if (1 == dal.UpdateContactRecord(contactRecordInfo))
                return true;
            return false;
        }

    }
}

