using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
