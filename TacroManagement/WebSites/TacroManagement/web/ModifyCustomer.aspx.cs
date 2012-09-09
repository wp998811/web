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

public partial class web_ModifyCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CustomerDataBind();
            ChangeUserGridLabelState();
        }
    }

    private void UserGridViewDataBind()
    {
        User user = new User();

        UserGridView.DataSource = user.SearchAllUsers();
        UserGridView.DataBind();

        ddl_UserPage.Items.Clear();
        for (int i = 1; i <= UserGridView.PageCount; i++)
        {
            ddl_UserPage.Items.Add(i.ToString());
        }
        if (ddl_UserPage.SelectedIndex != -1)
            ddl_UserPage.SelectedIndex = UserGridView.PageIndex;
    }

    private void ContactGridViewDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        CustomerContact customerContact = new CustomerContact();

        ContactGridView.DataSource = customerContact.SearchAllContactsByCustomerID(customerID);
        ContactGridView.DataBind();

        ddl_ContactPage.Items.Clear();
        for (int i = 1; i <= ContactGridView.PageCount; i++)
        {
            ddl_ContactPage.Items.Add(i.ToString());
        }
        if (ddl_ContactPage.SelectedIndex != -1)
            ddl_ContactPage.SelectedIndex = ContactGridView.PageIndex;
    }

    private void CustomerDataBind()
    {
        int customerID = Convert.ToInt32(Request["customerID"]);
        Customer customer = new Customer();
        User user = new User();
        CustomerInfo customerInfo = customer.GetCustomerById(customerID);
        if (customerInfo != null)
        {
            textBox_customerName.Text = customerInfo.CustomerName;
            UserInfo userInfo = user.GetUserById(customerInfo.UserID);
            textBox_manager.Text = userInfo.UserName;
            ArrayList customerTypeList = new ArrayList();
            customerTypeList.Add("外包");
            customerTypeList.Add("转包");
            ddl_clientType.Items.Clear();
            for (int i = 0; i < customerTypeList.Count; i++)
            {
                ddl_clientType.Items.Add(new ListItem(customerTypeList[i].ToString(), i.ToString()));
                if (customerInfo.CustomerType == customerTypeList[i].ToString())
                    ddl_clientType.SelectedIndex = i;
            }
            ArrayList productRangeList = new ArrayList();
            productRangeList.Add("激光");
            productRangeList.Add("超声");
            productRangeList.Add("体外诊断试剂");
            productRangeList.Add("监护");
            productRangeList.Add("影像");
            for (int i = 0; i < productRangeList.Count; i++)
            {
                ddl_productRange.Items.Add(new ListItem(productRangeList[i].ToString(), i.ToString()));
                if (customerInfo.ProductRange == productRangeList[i].ToString())
                    ddl_productRange.SelectedIndex = i;
            }
            textBox_city.Text = customerInfo.CustomerCity;
            textBox_level.Text = customerInfo.CustomerRank;
            textBox_taxID.Text = customerInfo.TaxID;
            textBox_organCode.Text = customerInfo.OrganCode;

            UserID_TextBox.Text = customerInfo.UserID.ToString();

            UserGridViewDataBind();
            ContactGridViewDataBind();
        }
    }

    protected void modify(object sender, EventArgs e)
    {
        Customer customer = new Customer();
        CustomerInfo customerInfo = customer.GetCustomerById(Convert.ToInt32(Request.QueryString["customerID"]));
        customerInfo.CustomerName = textBox_customerName.Text;
        customerInfo.UserID = Convert.ToInt32(UserID_TextBox.Text);
        customerInfo.CustomerCity = textBox_city.Text;
        customerInfo.CustomerType = ddl_clientType.SelectedItem.Text;
        customerInfo.CustomerRank = textBox_level.Text;
        customerInfo.ProductRange = ddl_productRange.SelectedItem.Text;
        customerInfo.TaxID = textBox_taxID.Text;
        customerInfo.OrganCode = textBox_organCode.Text;

        if (customer.UpdateCustomer(customerInfo) != -1)
        {
            Response.Write("<script  language='javascript'> alert('修改成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('修改失败'); </script>");
        }

        Response.Redirect("CustomerList.aspx");
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Contact_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ddl_ContactPage.SelectedIndex;
         ContactGridViewDataBind();
    }
    protected void Contact_FirstPage_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = 0;
        ContactGridViewDataBind();
    }
    protected void Contact_PrePage_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex > 0)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex - 1;
            ContactGridViewDataBind();
        }
    }
    protected void Contact_NextPage_Click(object sender, EventArgs e)
    {
        if (this.ContactGridView.PageIndex < this.ContactGridView.PageCount)
        {
            this.ContactGridView.PageIndex = this.ContactGridView.PageIndex + 1;
            ContactGridViewDataBind();
        }
    }
    protected void Contact_LastPage_Click(object sender, EventArgs e)
    {
        this.ContactGridView.PageIndex = this.ContactGridView.PageCount;
        ContactGridViewDataBind();
    }

    protected void ContactGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Contact contact = new Contact();
        CustomerContact customerContact = new CustomerContact();

        int contactId = Convert.ToInt32(ContactGridView.DataKeys[e.RowIndex][0].ToString());

        if (customerContact.DeleteCustomerContactByContactId(contactId) == 1 && contact.DeleteContact(contactId) == 1 )
        {
            Response.Write("<script  language='javascript'> window.alert('删除成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('删除失败'); </script>");
        }

        CustomerDataBind();
    }

    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void User_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.UserGridView.PageIndex = this.ddl_UserPage.SelectedIndex;
        UserGridViewDataBind();
    }
    protected void User_FirstPage_Click(object sender, EventArgs e)
    {
        this.UserGridView.PageIndex = 0;
        UserGridViewDataBind();
    }
    protected void User_PrePage_Click(object sender, EventArgs e)
    {
        if (this.UserGridView.PageIndex > 0)
        {
            this.UserGridView.PageIndex = this.UserGridView.PageIndex - 1;
            UserGridViewDataBind();
        }
    }
    protected void User_NextPage_Click(object sender, EventArgs e)
    {
        if (this.UserGridView.PageIndex < this.UserGridView.PageCount)
        {
            this.UserGridView.PageIndex = this.UserGridView.PageIndex + 1;
            UserGridViewDataBind();
        }
    }
    protected void User_LastPage_Click(object sender, EventArgs e)
    {
        this.UserGridView.PageIndex = this.UserGridView.PageCount;
        UserGridViewDataBind();
    }

    protected void UserGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.label_User_CurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.UserGridView.PageIndex + 1, this.UserGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = UserGridView.PageIndex * UserGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void ContactGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.label_Contact_CurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.ContactGridView.PageIndex + 1, this.ContactGridView.PageCount);

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = ContactGridView.PageIndex * ContactGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void Select_Manager(object sender, EventArgs e)
    {
       ChangeUserGridLabelState();
    }

    protected void Select_Contact(object sender, EventArgs e)
    {
        ContactGridViewDataBind();
        ChangeContactGridLabelState();
    }

    protected void Add_Contact(object sender, EventArgs e)
    {
        string customerID = Request.QueryString["customerID"];
        Response.Redirect("AddContact.aspx?customerID=" + customerID);
    }

    protected void ContactGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string contactId = ContactGridView.DataKeys[e.NewEditIndex][0].ToString();
        Response.Redirect("ModifyContact.aspx?contactID=" + contactId);
    }

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

    protected void ChangeUserGridLabelState()
    {
        UserGridView.Visible = !UserGridView.Visible;
        label_UserFirstPage.Visible = !label_UserFirstPage.Visible;
        label_UserPrePage.Visible = !label_UserPrePage.Visible;
        label_User_CurrentPage.Visible = !label_User_CurrentPage.Visible;
        label_UserNextPage.Visible = !label_UserNextPage.Visible;
        label_UserLastPage.Visible = !label_UserLastPage.Visible;
        label_UserGoto.Visible = !label_UserGoto.Visible;
        ddl_UserPage.Visible = !ddl_UserPage.Visible;
        label_UserPage.Visible = !label_UserPage.Visible;
    }

    protected void ChangeContactGridLabelState()
    {
        ContactGridView.Visible = !ContactGridView.Visible;
        label_ContactFirstPage.Visible = !label_ContactFirstPage.Visible;
        label_ContactPrePage.Visible = !label_ContactPrePage.Visible;
        label_Contact_CurrentPage.Visible = !label_Contact_CurrentPage.Visible;
        label_ContactNextPage.Visible = !label_ContactNextPage.Visible;
        label_ContactLastPage.Visible = !label_ContactLastPage.Visible;
        label_ContactGoto.Visible = !label_ContactGoto.Visible;
        ddl_ContactPage.Visible = !ddl_ContactPage.Visible;
        label_ContactPage.Visible = !label_ContactPage.Visible;
    }
}
