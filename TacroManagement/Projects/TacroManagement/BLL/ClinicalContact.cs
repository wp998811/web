using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class ClinicalContact
    {
        private static readonly IClinicalContact dal = DALFactory.DataAccess.CreateClinicalContact();

        #region
        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            return dal.InsertClinicalContact(clinicalContactInfo);
        }

        /// <summary>
        /// 更新临床联系人
        /// </summary>
        /// <param name="clinicalContactInfo"></param>
        /// <returns></returns>
        public int UpdateClinicalContact(ClinicalContactInfo clinicalContactInfo)
        {
            return dal.UpdateClinicalContact(clinicalContactInfo);
        }

        /// <summary>
        /// 删除临床联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteClinicalContact(int id)
        {
            return dal.DeleteClinicalContact(id);
        }

        /// <summary>
        /// 查找所有临床联系人
        /// </summary>
        /// <returns></returns>
        public IList<ClinicalContactInfo> GetClinicalContacts()
        {
            return dal.GetClinicalContacts();
        }

        /// <summary>
        /// 通过ID查找用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalContactInfo GetClinicalContactById(int id)
        {
            return dal.GetClinicalContactById(id);
        }
        #endregion

        /// <summary>
        /// 新增临床联系人
        /// </summary>
        /// <param name="clinicalId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool AddClinicalContact(int clinicalId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (clinicalId < 0 || contactId < 0)
                return false;
            if (1 == dal.InsertClinicalContact(new ClinicalContactInfo(clinicalId, contactId)))
                return true;
            return false;
        }

        /// <summary>
        /// 编辑临床联系人
        /// </summary>
        /// <param name="clinicalId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool ModifyClinicalContact(int id, int clinicalId, int contactId)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            //    return false;
            if (clinicalId < 0 || contactId < 0)
                return false;
            ClinicalContactInfo clinicalContactInfo = dal.GetClinicalContactById(id);
            if (clinicalContactInfo == null)
                return false;
            clinicalContactInfo.ClinicalID = clinicalId;
            clinicalContactInfo.ContactID = contactId;

            if (1 == dal.UpdateClinicalContact(clinicalContactInfo))
                return true;
            return false;
        }

    }
}

