using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

public partial class web_Admin_DepartmentLists : System.Web.UI.Page
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

    protected void dlUser_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string strID = "";
        strID = ((Label)e.Item.FindControl("lblDepartID")).Text;
        int departID = Int32.Parse(strID);


        departBLL.DeleteDepartment(departID);
        dlDepart.EditItemIndex = -1;
        BindDepartments();
    }
}
