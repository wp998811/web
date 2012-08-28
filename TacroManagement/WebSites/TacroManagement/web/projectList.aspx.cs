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

public partial class web_projectList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitProject();
    }

    private void InitProject()
    {
        //Project project = new Project();
        //IList<ProjectInfo> projectInfos = project.GetProjects();

        //ProjectGridView.DataSource = project.SearchAllProjects();
        //ProjectGridView.DataBind();
    }
}
