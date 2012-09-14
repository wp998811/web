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
            InitDepartment();
        }
        InitDocCate();


    }
    private void InitDepartment()
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

    private void InitDocCate()
    {
        string DepartID = DepartName.SelectedValue;
        if (string.IsNullOrEmpty(DepartID))
        {
            return;
        }

        string DocVisiblity = InOutDoc.SelectedValue;

        DepartVisiblity.Text = DepartName.SelectedItem.Text+ ">" + InOutDoc.SelectedItem.Text + ">";
        DepartLabel.Text = DepartName.SelectedItem.Text + ">";
        DepartDocCate departDocCate = new DepartDocCate();
        IList<DepartDocCateInfo> departDocCates = departDocCate.GetDepartDocCateByDepartVisiblity(Convert.ToInt32(DepartID), Convert.ToInt32(DocVisiblity));

        DocCateName.Items.Clear();
        for (int j = 0; j < departDocCates.Count; ++j)
        {
            ListItem listItem = new ListItem();
            listItem.Text = departDocCates[j].CategoryName;
            listItem.Value = Convert.ToString(departDocCates[j].Id);
            DocCateName.Items.Add(listItem);
        }
    }
    protected void AddButton_Click(object sender, EventArgs  e)
    {
        DepartDocCate departDocCate = new DepartDocCate();
        DepartDocCateInfo departDocCateInfo = new DepartDocCateInfo();
        string departID = DepartName.SelectedValue;
        if (departID =="0" || string.IsNullOrEmpty(departID))
        {
            return;
        }
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
        InitDocCate();
    }


//     public void InitDocCate()
//     {
//         Department department = new Department();
//         IList<DepartmentInfo> departmentInfos = department.GetDepartments();
//         DocCate.Items.Clear();
//         DocCate.Items.Add(new ListItem("选择文档", "0"));
//         for (int i = 0; i < departmentInfos.Count; ++i)
//         {
//             ListItem listItem = new ListItem();
//             listItem.Text = departmentInfos[i].DepartName;
//             listItem.Value = Convert.ToString(departmentInfos[i].DepartID);
//             DocCate.Items.Add(listItem);
// 
//             DepartDocCate departDocCate=new DepartDocCate();
//             IList<DepartDocCateInfo> departDocCates=departDocCate.GetDepartDocCateByDepartId(departmentInfos[i].DepartID);
// 
//             int docVisible = 0;
//             for (int j = 0; j < departDocCates.Count;++j )
//             {
//                 
//                 if (docVisible == 0 || docVisible != departDocCates[j].Visibility)
//                 {
//                     docVisible = departDocCates[j].Visibility;
//                     ListItem listItem1 = new ListItem();
//                     if (docVisible==1)
//                     {                      
//                         listItem1.Text = "==外部文档==";
//                         listItem1.Value = "0";
//                     } 
//                     else
//                     {
//                         listItem1.Text = "==内部文档==";
//                         listItem1.Value = "0";
//                     }
//                     DocCate.Items.Add(listItem1);
//                 }
// 
//                 ListItem listItem2 = new ListItem();
//                 listItem2.Text = "===="+departDocCates[j].CategoryName+"====";
//                 listItem2.Value = Convert.ToString(departDocCates[j].DepartID);
//                 DocCate.Items.Add(listItem2);
// 
//             }
//            
//         }
//     }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        DepartDocCate departDocCate = new DepartDocCate();
        string docCateID = DocCateName.SelectedValue;
        if (string.IsNullOrEmpty(docCateID) || docCateID == "0")
        {
            return;
        }
        departDocCate.DeleteDepartDocCate(Convert.ToInt32(docCateID));
        InitDocCate();
    }

    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        DepartDocCate departDocCate = new DepartDocCate();
        DepartDocCateInfo departDocCateInfo = new DepartDocCateInfo();
        string departID = DepartName.SelectedValue;
        if (departID == "0"||string.IsNullOrEmpty(departID))
        {
            return;
        }
        string strId = ModifyID.Value;
        string isvisible = ModifyInOrOut.SelectedValue;
        string docCate = ModifyCategoryName.Text.Trim();

        departDocCateInfo.Id = Convert.ToInt32(strId);
        departDocCateInfo.DepartID = Convert.ToInt32(departID);
        departDocCateInfo.Visibility = Convert.ToInt32(isvisible);
        departDocCateInfo.CategoryName = docCate;

        int isInsert = departDocCate.UpdateDepartDocCate(departDocCateInfo);

        if (isInsert == 1)
        {
            //Response.Write("<script   language=javascript> window.alert( ' 文档类型修改成功  '); </script>");
        }
        else
        {
            //Response.Write("<script   language=javascript> window.alert( ' 文档类型修改失败  '); </script>");
        }
        InitDocCate();
    }
}
