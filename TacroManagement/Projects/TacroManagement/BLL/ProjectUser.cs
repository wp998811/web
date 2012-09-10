﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ProjectUser
    {
        private static readonly IProjectUser dal = DALFactory.DataAccess.CreateProjectUser();

        User userMange = new User();

        #region


        public int InsertProjectUser(ProjectUserInfo projectUserInfo)
        {
            return dal.InsertProjectUser(projectUserInfo);
        }

        public int DeleteProjectUser(int id)
        {
            return dal.DeleteProjectUser(id);
        }

        public int UpdateProjectUser(ProjectUserInfo projectUserInfo)
        {
            return dal.UpdateProjectUser(projectUserInfo);
        }

        public IList<ProjectUserInfo> GetProjectUsers()
        {
            return dal.GetProjectUsers();
        }

        public IList<ProjectUserInfo> GetProjectUsersByProjectNum(string projectNum)
        {
            return dal.GetProjectUsersByProjectNum(projectNum);
        }

        //获取项目所有员工的信息
        public IList<UserInfo> GetProjectUserInfosByProjectNum(string projectNum)
        {
            IList<UserInfo> userInfos = new List<UserInfo>();
            IList<ProjectUserInfo> projectUsers = GetProjectUsersByProjectNum(projectNum);
            foreach (ProjectUserInfo projectUserInfo in projectUsers)
            {
                UserInfo userInfo = userMange.GetUserById(projectUserInfo.UserId);
                if (userInfo != null)
                {
                    userInfos.Add(userInfo);
                }
            }
            return userInfos;
        }


        public IList<ProjectUserInfo> GetProjectUsersByUserId(int userId)
        {
            return dal.GetProjectUsersByUserId(userId);
        }

        public ProjectUserInfo GetProjectUserById(int id)
        {
            return dal.GetProjectUserById(id);
        }
        #endregion

        //根据projectNum和userId删除projectUser
        public int DeleteProjectUserByProjectNumAndUserID(string projectNum, int userId)
        {
            IList<ProjectUserInfo> projectUserInfoList = GetProjectUsersByProjectNum(projectNum);
            int id = -1;
            foreach (ProjectUserInfo projectUserInfo in projectUserInfoList)
            {
                if (projectUserInfo.UserId == userId)
                {
                    id = projectUserInfo.ID;
                    break;
                }
            }
            if (id != -1)
            {
                return DeleteProjectUser(id);
            }
            return -1;
        }
    }
}
