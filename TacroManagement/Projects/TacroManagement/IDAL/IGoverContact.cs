using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IGoverContact
    {
        int InsertGoverContact(GoverContactInfo goverContactInfo);      //增加政府联系人
        int DeleteGoverContact(int id);        //删除政府联系人
        int DeleteGoverContactByContactId(int contactId);
        int UpdateGoverContact(GoverContactInfo goverContactInfo);   //更新政府联系人

        IList<GoverContactInfo> GetGoverContact();                             //查找所以政府联系人
        GoverContactInfo GetGoverContactById(int id);                         //通过ID查找政府联系人
        IList<GoverContactInfo> GetGoverContactByGover(int goverId);          //通过政府资料ID查找政府联系人
        GoverContactInfo GetGoverContactByContactId(int contactId);           //通过联系人Id查找政府联系人
        
    }
}
