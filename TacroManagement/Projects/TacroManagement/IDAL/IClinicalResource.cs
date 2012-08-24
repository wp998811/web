using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface IClinicalResource
    {
        int InsertClinicalResource(ClinicalResourceInfo clinicalResource);//新增临床资源
        int DeleteClinicalResource(int clinicalID);//删除临床资源
        int UpdateClinicalResource(ClinicalResourceInfo clinicalResource);//更新临床资源

        IList<ClinicalResourceInfo> GetClinicalResources();//查找所有临床资源
        ClinicalResourceInfo GetClinicalResourceById(int id);//通过临床资源ID查找临床资源
        IList<ClinicalResourceInfo> GetClinicalResourceByUserId(int userId);//通过用户ID查找临床资源
    }
}
