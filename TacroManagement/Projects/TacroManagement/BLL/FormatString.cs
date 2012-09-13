using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class FormatString
    {
        //格式化日期格式
        public string FormatDate(string strDate)
        {
            DateTime dtDate = Convert.ToDateTime(strDate);
            return dtDate.ToString("yyyy-MM-dd");
        }
    }
}
