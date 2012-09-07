using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IClinicalContact
    {
        int InsertClinicalContact(ClinicalContactInfo clinicalContact);//新增临床资源联系人关系
        int DeleteClinicalContact(int id);//删除临床资源联系人关系
        int UpdateClinicalContact(ClinicalContactInfo clinicalContact);//更新临床资源联系人关系

        IList<ClinicalContactInfo> GetClinicalContacts();//查找所有临床资源联系人关系
        ClinicalContactInfo GetClinicalContactById(int id);//通过资源ID查找临床资源联系人关系
    }
}