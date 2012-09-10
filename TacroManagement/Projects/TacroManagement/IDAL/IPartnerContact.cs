using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IPartnerContact
    {

        int InsertPartnerContact(PartnerContactInfo PartnerContactInfo);    //增加合作伙伴联系人
        int DeletePartnerContact(int id);                                                        //删除合作伙伴联系人
        int DeletePartnerContactByPartnerId(int partnerId);
        int DeletePartnerContactByContactId(int contactId);
        int UpdatePartnerContact(PartnerContactInfo PartnerContactInfo);  //更新合作伙伴联系人

        IList<PartnerContactInfo> GetPartnerContact();                                // 查找所有合作伙伴联系人
        PartnerContactInfo GetPartnerContactById(int id);                            //通过合作伙伴联系人ID查找合作伙伴联系人
        IList<PartnerContactInfo> GetPartnerContactByPartner(int PartnerId);   //通过合作伙伴的ID查找合作伙伴联系人
        PartnerContactInfo GetPartnerContactByContactId(int contactId);          //通过联系人ID查找合作伙伴联系人
        IList<ContactInfo> GetContactsByPartnerId(int partnerID);
    }
}
