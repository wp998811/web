using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using BLL;
using Model;

public partial class web_GetDocCateByDepartID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int departID = Convert.ToInt32(Request.QueryString["DepartID"]);
        if (departID != 0)
        {
            DepartDocCate departDocCate = new DepartDocCate();
            IList<DepartDocCateInfo> departDocCateInfos = departDocCate.GetDepartDocCateByDepartId(departID);

            string docCateString = departDocCateInfos.Count + ";";
            for (int i = 0; i < departDocCateInfos.Count; ++i)
            {
                docCateString += departDocCateInfos[i].Id + ";" + departDocCateInfos[i].CategoryName + ";";
            }
            Response.Clear();
            Response.Write(docCateString);
            Response.Flush();
        }
        
    }
}
