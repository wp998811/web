using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IUser
    {
        int InsertUser(UserInfo userInfo);//新增用户
        int DeleteUser(int userId);//删除用户
        int UpdateUser(UserInfo userInfo);//更新用户
      
        IList<UserInfo> GetUsers();//查找所有用户
        UserInfo GetUserByName(string userName);//通过用户名查找用户信息
        UserInfo GetUserById(int userId);//通过用户编号查找用户信息
    }
}
