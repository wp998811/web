using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using BLL;
using Model;

public partial class web_Admin_DepartList : System.Web.UI.Page
{
    Department departBLL = new Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartments();
        }
    }

    private void BindDepartments()
    {
        IList<DepartmentInfo> departmentInfos = departBLL.GetDepartments();
        this.AspNetPager1.RecordCount = departmentInfos.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = departmentInfos;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        dlDepart.DataSource = pds;
        dlDepart.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindDepartments();
    }


    protected void lbDeleteDepart_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int departID = Convert.ToInt32(e.CommandArgument.ToString());
            if (departBLL.DeleteDepartment(departID) == 1)
            {
                BindDepartments();
            }
        }
    }
    
}
