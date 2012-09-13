using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Affair
    {
        private static readonly IAffair dal = DALFactory.DataAccess.CreateAffair();
        #region
        public int InsertAffair(AffairInfo affairInfo)
        {
            return dal.InsertAffair(affairInfo);
        }

        public int DeleteAffair(int affairId)
        {
            return dal.DeleteAffair(affairId);
        }

        public int UpdateAffair(AffairInfo affairInfo)
        {
            return dal.UpdateAffair(affairInfo);
        }

        public IList<AffairInfo> GetAffairs()
        {
            return dal.GetAffairs();
        }

        public IList<AffairInfo> GetAffairsByProjectNumDes(string projectNum)
        {
            return dal.GetAffairsByProjectNumDescending(projectNum);
        }

        public IList<AffairInfo> GetAffairsByOperatorIdDes(int operatorId)
        {
            return dal.GetAffairsByOperatorIdDescending(operatorId);
        }

        public IList<AffairInfo> GetAffairsByDate(string date)
        {
            return dal.GetAffairsByDate(date);
        }

        public AffairInfo GetAffairById(int id)
        {
            return dal.GetAffairById(id);
        }
        #endregion

        public IList<AffairInfo> GetAffairsByUserID(int userID)
        {
            ProjectUser projectUserManage = new ProjectUser();
            IList<AffairInfo> affairInfoList = new List<AffairInfo>();
            IList<ProjectUserInfo> projectUserInfoList = projectUserManage.GetProjectUsersByUserId(userID);

            foreach(ProjectUserInfo projectUserInfo in projectUserInfoList)
            {
                //affairInfoList.AddRange(GetAffairsByProjectNumDes(projectUserInfo.ProjectNum));
                IList<AffairInfo> list = GetAffairsByProjectNumDes(projectUserInfo.ProjectNum);

                foreach(AffairInfo affairInfo in list)
                {
                    affairInfoList.Add(affairInfo);
                }
            }
            var orderedList = affairInfoList.OrderBy(x => x.AffairTime).ToList();
            orderedList.Reverse();

            return (orderedList.ToList());
        }

        private static int SortA(AffairInfo a1, AffairInfo a2)
        {
            return a1.AffairTime.CompareTo(a2.AffairTime);
        }


    }
}
