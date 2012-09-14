﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IDepartDocCate
    {
        int InsertDepartDocCate(DepartDocCateInfo departDocCateInfo);    //增加部门文档类型
        int DeleteDepartDocCate(int id );                                                       //删除部门文档类型
        int UpdateDepartDocCate(DepartDocCateInfo departDocCateInfo);  //更新部门文档类型

        IList<DepartDocCateInfo> GetDepartDocCate();                                // 查找所有部门文档类型
        DepartDocCateInfo GetDepartDocCateById(int id);                            //通过部门文档类型ID查找部门文档类型
        IList<DepartDocCateInfo> GetDepartDocCateByDepartId(int departId);                                        //通过部门编号查找部门文档类型
        DepartDocCateInfo GetDepartDocCateByDepartCategory(int departID, string categoryName);     //通过部门ID和文档类型查找部门文档类型
        IList<DepartDocCateInfo> GetDepartDocCateByDepartVisiblity(int departID, int visiblity);                       //通过部门ID和文档范围查找部门文档类型


    }
}
