using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IPartnerResource
    {
        int InsertPartnerResource(PartnerResourceInfo PartnerResourceInfo);    //增加合作人资源
        int DeletePartnerResource(int id);                                                           //删除合作人资源
        int UpdetePartnerResource(PartnerResourceInfo PartnerResourceInfo);  //更新合作人资源

        IList<PartnerResourceInfo> GetPartnerResource();                                // 查找所有合作人资源
        PartnerResourceInfo GetPartnerResourceById(int id);                            //通过合作人资源ID查找合作人资源
        IList<PartnerResourceInfo> GetPartnerResourceByCondition(string selectCondition);   //通过查询条件查找合作人资料
        IList<ContactInfo> GetContactsByPartnerResourceId(int partnerResourceId);
    }
}
