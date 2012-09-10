using System;
using System.Collections;
using System.Collections.Generic;
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

using BLL;
using Model;

public partial class web_AddProjDocCate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Department department = new Department();
            IList<DepartmentInfo> departmentInfos = department.GetDepartments();
            DepartName.Items.Clear();
            DepartName.Items.Add(new ListItem("选择部门", "0"));
            for (int i = 0; i < departmentInfos.Count; ++i)
            {
                ListItem listItem = new ListItem();
                listItem.Text = departmentInfos[i].DepartName;
                listItem.Value = Convert.ToString(departmentInfos[i].DepartID);
                DepartName.Items.Add(listItem);
            }
        }



    }
    protected void AddButton_Click(object sender, ImageClickEventArgs e)
    {
        DepartDocCate departDocCate = new DepartDocCate();
        DepartDocCateInfo departDocCateInfo = new DepartDocCateInfo();
        string departID = DepartName.SelectedValue;
        string isvisible = InOutDoc.SelectedValue;
        string docCate = CategoryName.Text.Trim();

        departDocCateInfo.DepartID = Convert.ToInt32(departID);
        departDocCateInfo.Visibility = Convert.ToInt32(isvisible);
        departDocCateInfo.CategoryName = docCate;

        if (departDocCate.GetDepartDocCateByDepartCategory(departDocCateInfo.DepartID,departDocCateInfo.CategoryName).CategoryName == departDocCateInfo.CategoryName)
        {
            Response.Write("<script   language=javascript> window.alert( ' 文档类型已存在  '); </script>");
            return;
        }
        int isInsert =departDocCate.InsertDepartDocCate(departDocCateInfo);

        if (isInsert == 1)
        {
            Response.Write("<script   language=javascript> window.alert( ' 文档类型添加成功  '); </script>");
        }
        else
        {
            Response.Write("<script   language=javascript> window.alert( ' 文档类型添加失败  '); </script>");
        }
        
    }
}
