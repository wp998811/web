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

public partial class web_ModifyClinicalResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["userID"].ToString() == "")
            {
                Response.Redirect("login.aspx");
            }

            ClinicalResourceDataBind();

            ContactGridView.Visible = false;
            UserGridView.Visible = false;
        }
    }

    private void ClinicalResourceDataBind()
    {
        ClinicalResource clinicalResource = new ClinicalResource();
        Contact contact = new Contact();
        User user = new User();

        int clinicalResourceID = Convert.ToInt32(Request["clinicalResourceID"]);
        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(clinicalResourceID);
        UserInfo userInfo = user.GetUserById(clinicalResourceInfo.UserID);

        textBox_manager.Text = userInfo.UserName;
        textBox_city.Text = clinicalResourceInfo.City;
        UserID_TextBox.Text = userInfo.UserID.ToString();
        textBox_hospital.Text = clinicalResourceInfo.Hospital;
        textBox_department.Text = clinicalResourceInfo.Department;
        textBox_departIntro.Text = clinicalResourceInfo.DepartIntro;

        UserGridView.DataSource = user.SearchAllUsers();
        UserGridView.DataBind();

        if (UserID_TextBox.Text != "")
        {
            int userID = Convert.ToInt32(UserID_TextBox.Text);
            UserGridView.DataSource = user.SearchAllUsers();
        }

        ClinicalContact  clinicalContact  = new ClinicalContact();
        ContactGridView.DataSource = clinicalContact.SearchAllContactsByClinicalID(clinicalResourceID);
        ContactGridView.DataBind();
    }

    protected void Modify_ClinicalResource(object sender, EventArgs e)
    {
        ClinicalResource clinicalResource = new ClinicalResource();
        ClinicalResourceInfo clinicalResourceInfo = clinicalResource.GetClinicalResourceById(Convert.ToInt32(Request["clinicalResourceID"]));
        clinicalResourceInfo.UserID = Convert.ToInt32(UserID_TextBox.Text);
        clinicalResourceInfo.City = textBox_city.Text;
        clinicalResourceInfo.Department = textBox_department.Text;
        clinicalResourceInfo.DepartIntro = textBox_departIntro.Text;
        clinicalResourceInfo.Hospital = textBox_hospital.Text;

        if (clinicalResource.UpdateClinicalResource(clinicalResourceInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("ClinicalResourceList.aspx");
    }

    protected void Select_Manager(object sender, EventArgs e)
    {
        UserGridView.Visible = true;
        User_Hidden.Visible = true;
    }

    protected void Select_Contact(object sender, EventArgs e)
    {
        ContactGridView.Visible = true;
        Contact_Hidden.Visible = true;
        addContact.Visible = true;
        ClinicalResourceDataBind();
    }

    //protected void CustomerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        CheckBox mycb = new CheckBox();
    //        mycb = (CheckBox)e.Row.FindControl("CheckBox1");
    //        if (mycb != null)
    //        {
    //            //if (e.Row.RowType == DataControlRowType.DataRow)
    //            //{
    //            //    mycb.Attributes.Add("onclick", "select_customer(this.name)");
    //            //}
    //        }
    //    }
    //} 

    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UserCheckBoxChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= UserGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(UserGridView.Rows[i].FindControl("User_CheckBox"));
            if (cbox != (CheckBox)sender)
                cbox.Checked = false;
        }
        int userID = Convert.ToInt32(GetUserID());
        User user = new User();
        UserInfo userInfo = user.GetUserById(userID);
        textBox_manager.Text = userInfo.UserName;
        UserID_TextBox.Text = userInfo.UserID.ToString();
    }

    public string GetUserID()
    {
        //取选中的事件编号
        string streid = "";
        if (UserGridView != null)
        {
            int i, row;
            i = 0;
            row = UserGridView.Rows.Count;
            CheckBox mycb = new CheckBox();
            for (i = 0; i < row; i++)
            {
                mycb = (CheckBox)UserGridView.Rows[i].FindControl("User_CheckBox");
                if (mycb != null)
                {
                    if (mycb.Checked)
                    {
                        TextBox mytb = new TextBox();
                        mytb = (TextBox)UserGridView.Rows[i].FindControl("User_TextBox");
                        if (mytb != null)
                        {
                            streid = streid + mytb.Text.Trim() + ",";
                        }
                    }
                }
            }
        }
        if (streid.Length > 0)
        {
            streid = streid.Remove(streid.Length - 1);
        }
        return streid;
    }

    protected void UserList_Hidden(object sender, EventArgs e)
    {
        UserGridView.Visible = false;
        User_Hidden.Visible = false;
    }

    protected void ContactList_Hidden(object sender, EventArgs e)
    {
        ContactGridView.Visible = false;
        Contact_Hidden.Visible = false;
        addContact.Visible = false;
    }

    protected void Add_ClinicalContact(object sender, EventArgs e)
    {
        string clinicalResourceID = Request.QueryString["clinicalResourceID"];
        Response.Redirect("AddClinicalContact.aspx?clinicalResourceID=" + clinicalResourceID);
    }

    protected void modify(object sender, EventArgs e)
    {

    }
}
