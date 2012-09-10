using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserInfo
    {
        private int userID;
        private string userName;
        private string password;
        private string userType;
        private string userEmail;
        private string userPhone;
        private int departID;


        public UserInfo()
        {
        }

        public UserInfo(string userName,string password,string userType,string userEmail,string userPhone,int departID)
        {
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.departID = departID;
        }

        public UserInfo(int userID,string userName, string password, string userType, string userEmail, string userPhone, int departID)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.departID = departID;
        }

        public int UserID
        {
            get { return userID; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        public string UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }

        public int DepartID
        {
            get { return departID; }
            set { departID = value; }
        }

    }
}
