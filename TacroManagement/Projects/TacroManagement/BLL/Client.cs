using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Client
    {
        private static readonly IClient dal = DALFactory.DataAccess.CreateClient();

        #region 基本方法
        /// <summary>
        /// 插入客户
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public int InsertClient(ClientInfo clientInfo)
        {
            return dal.InsertClient(clientInfo);
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public int DeleteClient(int clientID)
        {
            return dal.DeleteClient(clientID);
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public int UpdateClient(ClientInfo clientInfo)
        {
            return dal.UpdateClient(clientInfo);
        }

        /// <summary>
        /// 查找所有客户
        /// </summary>
        /// <returns></returns>
        public IList<ClientInfo> GetClients()
        {
            return dal.GetClients();
        }


        /// <summary>
        /// 根据编号查找客户
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public ClientInfo GetClientByID(int clientID)
        {
            return dal.GetClientById(clientID);
        }

        /// <summary>
        /// 根据名称查找客户
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public ClientInfo GetClientByName(string clientName)
        {
            return dal.GetClientByName(clientName);
        }
        #endregion



        #region 业务

        /// <summary>
        /// 判断客户是否存在
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public bool IsClientExists(string clientName)
        {
            ClientInfo client = GetClientByName(clientName);
            if (null == client || 1 > client.ClientID)
                return false;
            return true;
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="clientCompany"></param>
        /// <returns></returns>
        public bool AddClient(string clientName, string clientCompany)
        {
            if (string.IsNullOrEmpty(clientName) || string.IsNullOrEmpty(clientCompany))
                return false;
            if (1 == dal.InsertClient(new ClientInfo(clientName, clientCompany)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientName"></param>
        /// <param name="clientCompany"></param>
        /// <returns></returns>
        public bool EditClient(int clientID, string clientName, string clientCompany)
        {
            if (string.IsNullOrEmpty(clientName) || string.IsNullOrEmpty(clientCompany))
            {
                return false;
            }
            ClientInfo clientInfo = dal.GetClientById(clientID);
            if (clientInfo == null)
                return false;
            clientInfo.ClientName = clientName;
            clientInfo.ClientCompany = clientCompany;

            if (1 == dal.UpdateClient(clientInfo))
            {
                return true;
            }
            return false;
        }

        #endregion
    }

}
