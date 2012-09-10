using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class DepartDocCate:IDepartDocCate
    {
        private static readonly IDepartDocCate dal = DALFactory.DataAccess.CreateDepartDocCate();


        /// <summary>
        /// 新增部门文档类型
        /// </summary>
        /// <param name="departDocCateInfo"></param>
        /// <returns></returns>
        public int InsertDepartDocCate(DepartDocCateInfo departDocCateInfo)
        {
            return dal.InsertDepartDocCate(departDocCateInfo);
        }

        /// <summary>
        /// 删除部门文档类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDepartDocCate(int id)
        {
            return dal.DeleteDepartDocCate(id);
        }

        /// <summary>
        /// 更新部门文档类型
        /// </summary>
        /// <param name="departDocCateInfo"></param>
        /// <returns></returns>
        public int UpdateDepartDocCate(DepartDocCateInfo departDoCateInfo)
        {
            return dal.UpdateDepartDocCate(departDoCateInfo);
        }

        /// <summary>
        /// 查找部门文档类型
        /// </summary>
        /// <returns></returns>
        /// 
         public IList<DepartDocCateInfo> GetDepartDocCate()
        {
            return dal.GetDepartDocCate();
        }

        /// <summary>
        /// 根据部门文档类型编号查找部门文档类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartDocCateInfo GetDepartDocCateById(int id)
         {
             return dal.GetDepartDocCateById(id);
         }

        public IList<DepartDocCateInfo> GetDepartDocCateByDepartId(int departId)
        {
            return dal.GetDepartDocCateByDepartId(departId);
        }
        /// <summary>
        /// 根据部门和文档类型查找部门文档类型
        /// </summary>
        /// <param name="departID"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
       public  DepartDocCateInfo GetDepartDocCateByDepartCategory(int departID, string categoryName)
        {
            return dal.GetDepartDocCateByDepartCategory(departID, categoryName);
        }

        
    }
}
