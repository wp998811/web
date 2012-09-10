using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IAffair
    {
        int InsertAffair(AffairInfo affairInfo);
        int DeleteAffair(int affairId);
        int UpdateAffair(AffairInfo affairInfo);

        IList<AffairInfo> GetAffairs();
        //以降序的方式获得项目动态，即最新的在最前
        IList<AffairInfo> GetAffairsByProjectNumDescending(string projectNum);
        IList<AffairInfo> GetAffairsByOperatorIdDescending(int operatorId);
        IList<AffairInfo> GetAffairsByDate(string date);
        AffairInfo GetAffairById(int affairId);
    }
}
