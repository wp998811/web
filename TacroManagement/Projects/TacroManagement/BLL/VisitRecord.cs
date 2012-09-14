using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;
using System.Data;


namespace BLL
{
    public class VisitRecord
    {
        private static readonly IVisitRecord dal = DALFactory.DataAccess.CreateVisitRecord();

        #region
        /// <summary>
        /// 新增拜访记录
        /// </summary>
        /// <param name="visitRecordInfo"></param>
        /// <returns></returns>
        public int InsertVisitRecord(VisitRecordInfo visitRecordInfo)
        {
            return dal.InsertVisitRecord(visitRecordInfo);
        }

        /// <summary>
        /// 更新拜访记录
        /// </summary>
        /// <param name="visitRecordInfo"></param>
        /// <returns></returns>
        public int UpdateVisitRecord(VisitRecordInfo visitRecordInfo)
        {
            return dal.UpdateVisitRecord(visitRecordInfo);
        }

        /// <summary>
        /// 删除拜访记录
        /// </summary>
        /// <param name="visitRecordInfo"></param>
        /// <returns></returns>
        public int DeleteVisitRecord(int id)
        {
            return dal.DeleteVisitRecord(id);
        }

        /// <summary>
        /// 查找所有拜访记录
        /// </summary>
        /// <returns></returns>
        public IList<VisitRecordInfo> GetVisitRecords()
        {
            return dal.GetVisitRecords();
        }

        /// <summary>
        /// 通过ID查找拜访记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VisitRecordInfo GetVisitRecordById(int id)
        {
            return dal.GetVisitRecordById(id);
        }
        #endregion

        /// <summary>
        /// 通过联系人ID查找拜访记录
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IList<VisitRecordInfo> GetVisitRecordsByContactId(int contactId)
        {
            return dal.GetVisitRecordsByContactId(contactId);
        }

        /// <summary>
        /// 通过用户ID查找拜访记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<VisitRecordInfo> GetVisitRecordsByUserId(int userId)
        {
            return dal.GetVisitRecordsByUserId(userId);
        }

        /// <summary>
        /// 新增拜访记录
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="visitDetail"></param>
        /// <param name="recordTime"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddVisitRecord(int contactId, string visitDetail, string recordTime, int userID)
        {
            if (contactId < 0 || userID < 0)
                return false;
            if (1 == dal.InsertVisitRecord(new VisitRecordInfo(contactId, visitDetail, recordTime, userID)))
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
        public bool ModifyVisitRecord(int id, int contactId, string visitDetail, string recordTime, int userID)
        {
            if (contactId < 0 || userID < 0)
                return false;
            VisitRecordInfo visitRecordInfo = dal.GetVisitRecordById(id);
            if (visitRecordInfo == null)
                return false;
            visitRecordInfo.ContactID = contactId;
            visitRecordInfo.VisitDetail = visitDetail;
            visitRecordInfo.RecordTime = recordTime;
            visitRecordInfo.UserID = userID;

            if (1 == dal.UpdateVisitRecord(visitRecordInfo))
                return true;
            return false;
        }

        /// <summary>
        /// 查询所有拜访记录信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllVisitRecords()
        {
            DataTable dataTable = new DataTable();
            DataColumn visitRecordID = new DataColumn("拜访记录ID");
            DataColumn contactName = new DataColumn("联系人姓名");
            DataColumn customerName = new DataColumn("客户名称");
            DataColumn address = new DataColumn("地址");
            DataColumn mobilephone = new DataColumn("手机");
            DataColumn visitDetail = new DataColumn("拜访记录");
            DataColumn visitTime = new DataColumn("拜访时间");

            dataTable.Columns.Add(visitRecordID);
            dataTable.Columns.Add(contactName);
            dataTable.Columns.Add(customerName);
            dataTable.Columns.Add(address);
            dataTable.Columns.Add(mobilephone);
            dataTable.Columns.Add(visitDetail);
            dataTable.Columns.Add(visitTime);

            IList<VisitRecordInfo> visitRecordInfos = GetVisitRecords(); //查询语句
            Customer customer = new Customer();
            User user = new User();
            Contact contact = new Contact();
            CustomerContact customerContact = new CustomerContact();

            for (int i = 0; i < visitRecordInfos.Count; ++i)
            {
                VisitRecordInfo vistiRecordInfo = visitRecordInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["拜访记录ID"] = vistiRecordInfo.ID;

                ContactInfo contactInfo = contact.GetContactById(vistiRecordInfo.ContactID);
                dataRow["联系人姓名"] = contactInfo.ContactName;
                dataRow["地址"] = contactInfo.Address;
                CustomerInfo customerInfo = customerContact.GetCustomerByContactId(contactInfo.ContactID);
                dataRow["客户名称"] = customerInfo.CustomerName;
                dataRow["手机"] = contactInfo.Telephone;

                dataRow["拜访记录"] = vistiRecordInfo.VisitDetail;
                dataRow["拜访时间"] = vistiRecordInfo.RecordTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 查询所有拜访记录信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllVisitRecordsByUserID(int userID)
        {
            DataTable dataTable = new DataTable();
            DataColumn visitRecordID = new DataColumn("拜访记录ID");
            DataColumn contactName = new DataColumn("联系人姓名");
            DataColumn address = new DataColumn("地址");
            DataColumn mobilephone = new DataColumn("手机");
            DataColumn visitDetail = new DataColumn("拜访记录");
            DataColumn visitTime = new DataColumn("拜访时间");

            dataTable.Columns.Add(visitRecordID);
            dataTable.Columns.Add(contactName);
            dataTable.Columns.Add(address);
            dataTable.Columns.Add(mobilephone);
            dataTable.Columns.Add(visitDetail);
            dataTable.Columns.Add(visitTime);

            IList<VisitRecordInfo> visitRecordInfos = GetVisitRecordsByUserId(userID);
            Customer customer = new Customer();
            User user = new User();
            Contact contact = new Contact();
            CustomerContact customerContact = new CustomerContact();

            for (int i = 0; i < visitRecordInfos.Count; ++i)
            {
                VisitRecordInfo vistiRecordInfo = visitRecordInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["拜访记录ID"] = vistiRecordInfo.ID;

                ContactInfo contactInfo = contact.GetContactById(vistiRecordInfo.ContactID);
                dataRow["联系人姓名"] = contactInfo.ContactName;
                dataRow["地址"] = contactInfo.Address;
                dataRow["手机"] = contactInfo.Telephone;

                dataRow["拜访记录"] = vistiRecordInfo.VisitDetail;
                dataRow["拜访时间"] = vistiRecordInfo.RecordTime;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

    }
}

