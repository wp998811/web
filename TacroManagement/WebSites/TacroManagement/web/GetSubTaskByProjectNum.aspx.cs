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

public partial class web_GetSubTaskByProjectNum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string projectNum = Request.QueryString["ProjectNum"];
        if (!string.IsNullOrEmpty(projectNum))
        {
            SubTask subTask = new SubTask();
            IList<SubTaskInfo> subTaskInfos = subTask.GetSubTasksByProjectNum(projectNum);
           
            if (subTaskInfos.Count >0 )
            {
                string subTaskString =subTaskInfos.Count+";";
                for (int i = 0; i < subTaskInfos.Count;++i )
                {
                    subTaskString += subTaskInfos[i].TaskId + ";" + subTaskInfos[i].TaskName + ";";
                }
                Response.Clear();
                Response.Write(subTaskString);
                Response.Flush();
   //             Response.Close();
            }
            
        }

    }
}
