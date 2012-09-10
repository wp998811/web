using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IClient
    {
        int InsertClient(ClientInfo clientInfo);//新增用户
        int DeleteClient(int clientID);//删除用户
        int UpdateClient(ClientInfo clientInfo);//更新用户

        IList<ClientInfo> GetClients();//查找所有用户
        ClientInfo GetClientByName(string clientName);//通过用户名查找用户信息
        ClientInfo GetClientById(int clientID);//通过用户编号查找用户信息
    }
}
