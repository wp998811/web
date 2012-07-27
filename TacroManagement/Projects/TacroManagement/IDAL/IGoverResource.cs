﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace IDAL
{
    public interface IGoverResource
    {
        int InsertGoverResource(GoverResourceInfo goverResourceInfo);    //增加政府资源
        int DeleteGoverResource(int id);                                                       //删除政府资源
        int UpdeteGoverResource(GoverResourceInfo goverResourceInfo);  //更新政府资源

        IList<GoverResourceInfo> GetGoverResource();                                // 查找所有政府资源
        GoverResourceInfo GetGoverResourceById(int id);                            //通过政府资源ID查找政府资源

    }
}
