using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

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
        /// 通过用户ID查找临床资源
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<ClinicalResourceInfo> GetClinicalResourceByUserId(int userId)
        {
            return dal.GetClinicalResourceByUserId(userId);
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

    }
}
