using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class User
    {
        private static readonly IUser dal = DALFactory.DataAccess.CreateUser();

        #region 基本方法
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertUser(UserInfo userInfo)
        {
            return dal.InsertUser(userInfo);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateUser(UserInfo userInfo)
        {
            return dal.UpdateUser(userInfo);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int DeleteUser(int userID)
        {
            return dal.DeleteUser(userID);
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<UserInfo> GetUsers()
        {
            return dal.GetUsers();
        }

        /// <summary>
        /// 通过用户名查找用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo GetUserByName(string userName)
        {
            return dal.GetUserByName(userName);
        }

        /// <summary>
        /// 通过用户编号查找用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfo GetUserById(int userId)
        {
            return dal.GetUserById(userId);
        }
        #endregion


        #region 业务
        /// <summary>
        ///用户登录 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UserLogin(string userName,string password)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            UserInfo userInfo = dal.GetUserByName(userName);
            if (null==userInfo||1>userInfo.UserID)
            {
                return false;
            }
            if (userInfo.Password.Equals(password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUserNameExists(string userName)
        {
            UserInfo user = GetUserByName(userName);
            if (null == user || 1 > user.UserID)
                return false;
            return true;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <param name="userEmail"></param>
        /// <param name="userPhone"></param>
        /// <param name="departID"></param>
        /// <returns></returns>
        public bool AddUser(string userName,string password,string userType,string userEmail,string userPhone,int departID)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
                return false;
            if(departID<0)
                return false;
            if (1 == dal.InsertUser(new UserInfo(userName, password, userType, userEmail, userPhone, departID)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <param name="userEmail"></param>
        /// <param name="userPhone"></param>
        /// <param name="departID"></param>
        /// <returns></returns>
        public bool ModifyUser(int userID,string userName, string password, string userType, string userEmail, string userPhone, int departID)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
                return false;
            if (departID < 0)
                return false;
            UserInfo userInfo = dal.GetUserById(userID);
            if (userInfo == null)
                return false;
            userInfo.UserName = userName;
            userInfo.Password = password;
            userInfo.UserType = userType;
            userInfo.UserEmail = userEmail;
            userInfo.UserPhone = userPhone;
            userInfo.DepartID = departID;

            if (1 == dal.UpdateUser(userInfo))
                return true;
            return false;
        }

        public DataTable GetTableByUserList(IList<UserInfo> userInfos)
        {
            DataTable dataTable = new DataTable();
            DataColumn userIDColumn = new DataColumn("userID");
            DataColumn userNameColumn = new DataColumn("姓名");
            DataColumn userTypeColumn = new DataColumn("用户类别");
            DataColumn emailColumn = new DataColumn("电子邮箱");
            DataColumn phoneColumn = new DataColumn("联系方式");
            DataColumn departColumn = new DataColumn("所属部门");

            dataTable.Columns.Add(userIDColumn);
            dataTable.Columns.Add(userNameColumn);
            dataTable.Columns.Add(userTypeColumn);
            dataTable.Columns.Add(emailColumn);
            dataTable.Columns.Add(phoneColumn);
            dataTable.Columns.Add(departColumn);

            for (int i = 0; i < userInfos.Count; ++i)
            {
                UserInfo userInfo = userInfos[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["userID"] = userInfo.UserID;
                dataRow["姓名"] = userInfo.UserName;
                dataRow["用户类别"] = userInfo.UserType;
                dataRow["电子邮箱"] = userInfo.UserEmail;
                dataRow["联系方式"] = userInfo.UserPhone;

                Department department = new Department();
                DepartmentInfo departmentInfo = department.GetDepartmentByID(userInfo.DepartID);
                dataRow["所属部门"] = departmentInfo.DepartName;

                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        #endregion
    }
}
