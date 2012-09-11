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
    public class ClinicalResource
    {
        private static readonly IClinicalResource dal = DALFactory.DataAccess.CreateClinicalResource();

        #region
        /// <summary>
        /// 新增临床资源
        /// </summary>
        /// <param name="clinicalResourceInfo"></param>
        /// <returns></returns>
        public int InsertClinicalResource(ClinicalResourceInfo clinicalResourceInfo)
        {
            return dal.InsertClinicalResource(clinicalResourceInfo);
        }

        /// <summary>
        /// 更新临床资源
        /// </summary>
        /// <param name="clinicalResourceInfo"></param>
        /// <returns></returns>
        public int UpdateClinicalResource(ClinicalResourceInfo clinicalResourceInfo)
        {
            return dal.UpdateClinicalResource(clinicalResourceInfo);
        }

        /// <summary>
        /// 删除临床资源
        /// </summary>
        /// <param name="clinicalResourceId"></param>
        /// <returns></returns>
        public int DeleteClinicalResource(int clinicalResourceId)
        {
            return dal.DeleteClinicalResource(clinicalResourceId);
        }

        /// <summary>
        /// 查找所有临床资源
        /// </summary>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResources()
        {
            return dal.GetClinicalResources();
        }

        /// <summary>
        /// 通过ID查找临床资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalResourceInfo GetClinicalResourceById(int id)
        {
            return dal.GetClinicalResourceById(id);
        }

        /// <summary>
        /// 根据查询条件查找合作伙伴资料
        /// </summary>
        /// <param name="selectCondition"></param>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResourceByCondition(string selectCondition)
        {
            return dal.GetClinicalResourceByCondition(selectCondition);
        }

        /// <summary>
        /// 通过用户ID查找临床资源
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResourceByUserId(int userId)
        {
            return dal.GetClinicalResourceByUserId(userId);
        }

        public IList<ContactInfo> GetContactByClinicalResourceId(int clinicalResourceId)
        {
            return dal.GetContactByClinicalResourceId(clinicalResourceId);
        }

        #endregion

        /// <summary>
        /// 新增临床资源
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="city"></param>
        /// <param name="hospital"></param>
        /// <param name="department"></param>
        /// <param name="departIntro"></param>
        /// <returns></returns>
        public bool AddClinicalResource(int userId, string city, string hospital, string department, string departIntro)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (userId < 0)
                return false;
            if (1 == dal.InsertClinicalResource(new ClinicalResourceInfo(userId, city, hospital, department, departIntro)))
                return true;
            return false;
        }


        /// <summary>
        /// 通过合作者资料List返回DataTable
        /// </summary>
        /// <param name="partnerResourceInfos"></param>
        /// <returns></returns>
        public DataTable GetDataTableByClinicalList(IList<ClinicalResourceInfo> clinicalResourceInfos)
        {
            DataTable dataTable = new DataTable();

            DataColumn clinicalIDColumn = new DataColumn("临床资源ID");
            DataColumn userNameColumn = new DataColumn("负责人姓名");
            DataColumn cityNameColumn = new DataColumn("城市");
            DataColumn hospitalName = new DataColumn("医院名称");
            DataColumn departmentName = new DataColumn("科室名称");
            DataColumn departIntro = new DataColumn("科室简介");

            dataTable.Columns.Add(clinicalIDColumn);
            dataTable.Columns.Add(userNameColumn);
            dataTable.Columns.Add(cityNameColumn);
            dataTable.Columns.Add(hospitalName);
            dataTable.Columns.Add(departmentName);
            dataTable.Columns.Add(departIntro);

            User user = new User();

            for (int i = 0; i < clinicalResourceInfos.Count; ++i)
            {
                ClinicalResourceInfo clinicalResourceInfo = clinicalResourceInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["临床资源ID"] = clinicalResourceInfo.ClinicalID;

                UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;

                dataRow["城市"] = clinicalResourceInfo.City;
                dataRow["医院名称"] = clinicalResourceInfo.Hospital;
                dataRow["科室名称"] = clinicalResourceInfo.Department;
                dataRow["科室简介"] = clinicalResourceInfo.DepartIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;

        }

        /// <summary>
        /// 根据查询条件生成sql查询语句
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <returns>sql查询条件</returns>
        public string GetClinicalResourceSearchCondition(string userName, string cityName, string hosipital, string departmentName)
        {

            string condition = "";

            if (!string.IsNullOrEmpty(userName))
            {
                User user = new User();
                UserInfo userInfo = user.GetUserByName(userName);
                if (string.IsNullOrEmpty(userInfo.UserName))
                {
                    return "";
                }
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " UserID = '" + userInfo.UserID + "' ";
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " City LIKE '%" + cityName + "%' ";
            }

            if (!string.IsNullOrEmpty(hosipital))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " Hospital LIKE '%" + hosipital + "%' ";
            }

            if (!string.IsNullOrEmpty(departmentName))
            {
                if (condition != "")
                {
                    condition += " AND ";
                }
                condition += " Department LIKE '%" + departmentName + "%' ";
            }
            return condition;
        }

        /// <summary>
        /// 通过查询条件获取合作者资料List
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cityName"></param>
        /// <param name="organName"></param>
        /// <param name="contactName"></param>
        /// <returns>符合查询条件的List</returns>
        public IList<ClinicalResourceInfo> GetClinicalResearchBySearch(string userName, string cityName, string hospital, string departmentName, string contactName)
        {
            string condition = GetClinicalResourceSearchCondition(userName, cityName, hospital, departmentName);
            IList<ClinicalResourceInfo> clinicalResourceInfos = GetClinicalResourceByCondition(condition);
            if (!string.IsNullOrEmpty(contactName))
            {
                Contact contact = new Contact();
                ContactInfo contactInfo = contact.GetContactByContactName(contactName);
                if (string.IsNullOrEmpty(contactInfo.ContactName))
                {
                    return new List<ClinicalResourceInfo>();
                }

                ClinicalContact clinicalContact = new ClinicalContact();
                ClinicalContactInfo clinicalContactnfo = clinicalContact.GetClinicalContactByContactId(contactInfo.ContactID);
                if (clinicalContactnfo.ContactID != contactInfo.ContactID)
                {
                    return new List<ClinicalResourceInfo>();
                }

                IList<ClinicalResourceInfo> pRIs = new List<ClinicalResourceInfo>();
                for (int i = 0; i < clinicalResourceInfos.Count; ++i)
                {
                    if (clinicalResourceInfos[i].ClinicalID == clinicalContactnfo.ClinicalID)
                    {
                        pRIs.Add(clinicalResourceInfos[i]);
                    }
                }
                clinicalResourceInfos = pRIs;
            }

            return clinicalResourceInfos;
        }

        /// <summary>
        /// 修改临床资源
        /// </summary>
        /// <param name="clinicalId"></param>
        /// <param name="userId"></param>
        /// <param name="city"></param>
        /// <param name="hospital"></param>
        /// <param name="department"></param>
        /// <param name="departIntro"></param>
        /// <returns></returns>
        public bool ModifyClinicalResource(int clinicalId, int userId, string city, string hospital, string department, string departIntro)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (userId < 0)
                return false;
            ClinicalResourceInfo clinicalResourceInfo = dal.GetClinicalResourceById(clinicalId);
            if (clinicalResourceInfo == null)
                return false;
            clinicalResourceInfo.UserID = userId;
            clinicalResourceInfo.City = city;
            clinicalResourceInfo.Hospital = hospital;
            clinicalResourceInfo.Department = department;
            clinicalResourceInfo.DepartIntro = departIntro;

            if (1 == dal.UpdateClinicalResource(clinicalResourceInfo))
                return true;
            return false;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllClinicalResources()
        {
            DataTable dataTable = new DataTable();
            DataColumn clinicalResourceID = new DataColumn("临床资源ID");
            DataColumn userName = new DataColumn("负责人姓名");
            DataColumn city = new DataColumn("城市");
            DataColumn hospitalName = new DataColumn("医院名称");
            DataColumn departmentName = new DataColumn("科室名称");
            DataColumn departIntro = new DataColumn("科室简介");

            dataTable.Columns.Add(clinicalResourceID);
            dataTable.Columns.Add(userName);
            dataTable.Columns.Add(city);
            dataTable.Columns.Add(hospitalName);
            dataTable.Columns.Add(departmentName);
            dataTable.Columns.Add(departIntro);

            IList<ClinicalResourceInfo> clinicalResourceInfos = GetClinicalResources(); //查询语句
            ClinicalResource clinicalResource = new ClinicalResource();
            User user = new User();

            for (int i = 0; i < clinicalResourceInfos.Count; ++i)
            {
                ClinicalResourceInfo clinicalResourceInfo = clinicalResourceInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["临床资源ID"] = clinicalResourceInfo.ClinicalID;

                UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);
                dataRow["负责人姓名"] = userInfo.UserName;

                dataRow["城市"] = clinicalResourceInfo.City;
                dataRow["医院名称"] = clinicalResourceInfo.Hospital;
                dataRow["科室名称"] = clinicalResourceInfo.Department;
                dataRow["科室简介"] = clinicalResourceInfo.DepartIntro;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable SearchAllContactsByClinicalResourceID(int clinicalResourceId)
        {
            DataTable dataTable = new DataTable();
            DataColumn contactID = new DataColumn("联系人ID");
            DataColumn contactName = new DataColumn("联系人姓名");
            DataColumn position = new DataColumn("职位");
            DataColumn mobilephone = new DataColumn("手机");
            DataColumn telephone = new DataColumn("固定电话");
            DataColumn email = new DataColumn("邮箱");
            DataColumn address = new DataColumn("地址");
            DataColumn postcode = new DataColumn("邮编");
            DataColumn fax = new DataColumn("传真号");

            dataTable.Columns.Add(contactID);
            dataTable.Columns.Add(contactName);
            dataTable.Columns.Add(position);
            dataTable.Columns.Add(mobilephone);
            dataTable.Columns.Add(telephone);
            dataTable.Columns.Add(email);
            dataTable.Columns.Add(address);
            dataTable.Columns.Add(postcode);
            dataTable.Columns.Add(fax);

            IList<ContactInfo> contactInfos = GetContactByClinicalResourceId(clinicalResourceId); //查询语句
            Customer customer = new Customer();
            User user = new User();

            for (int i = 0; i < contactInfos.Count; ++i)
            {
                ContactInfo contactInfo = contactInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["联系人ID"] = contactInfo.ContactID;
                dataRow["联系人姓名"] = contactInfo.ContactName;
                dataRow["职位"] = contactInfo.Position;
                dataRow["手机"] = contactInfo.Mobilephone;
                dataRow["固定电话"] = contactInfo.Telephone;
                dataRow["邮箱"] = contactInfo.Email;
                dataRow["地址"] = contactInfo.Address;
                dataRow["邮编"] = contactInfo.PostCode;
                dataRow["传真号"] = contactInfo.FaxNumber;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
}
