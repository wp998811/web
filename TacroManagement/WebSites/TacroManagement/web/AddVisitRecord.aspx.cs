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

public partial class web_AddVisitRecord : System.Web.UI.Page
{
    Customer customer = new Customer();
    CustomerContact customerContact = new CustomerContact();
    Contact contact = new Contact();
    VisitRecord visitRecord = new VisitRecord();
    User user = new User();
    public static string contactID = "";
    public static string resourceID = "";
    public static string resourceType = "";
    public static string href1 = "";
    public static string href2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.Params["contactID"] != null && Request.Params["contactID"].Trim() != "" &&
                Request.Params["ID"] != null && Request.Params["ID"].Trim() != "" &&
                Request.Params["resourceType"] != null && Request.Params["resourceType"].Trim() != "")
            {
                contactID = Request.Params["contactID"];
                resourceID = Request.Params["ID"];
                resourceType = Request.Params["resourceType"];
                VisitRecordDataBind();
            }
        }
    }

    private void VisitRecordDataBind()
    {
        switch (resourceType)
        {
            case "客户":
                {
                    href1 = "CustomerList.aspx";
                    href2 = "ModifyCustomer.aspx?customerID=" + ID;
                    label1.Text = "客户资源管理";
                    label2.Text = "编辑客户资源";
                    break;
                }
            case "临床":
                {
                    href1 = "ClinicalResourceList.aspx";
                    href2 = "ModifyClinicalResource.aspx?clinicalResourceID=" + ID;
                    label1.Text = "临床资源管理";
                    label2.Text = "编辑临床资源";
                    break;
                }
            case "政府":
                {
                    href1 = "GoverResourceList.aspx";
                    href2 = "ModifyGoverResource.aspx?goverResourceID=" + ID;
                    label1.Text = "政府资源管理";
                    label2.Text = "编辑政府资源";
                    break;
                }
            case "合作伙伴":
                {
                    href1 = "PartnerResourceList.aspx";
                    href2 = "ModifyPartnerResource.aspx?partnerResourceID=" + ID;
                    label1.Text = "合作伙伴资源管理";
                    label2.Text = "编辑合作伙伴资源";
                    break;
                }
        }
    }

    protected void Add_VisitRecord(object sender, EventArgs e)
    {
        VisitRecordInfo visitRecordInfo = new VisitRecordInfo();
        visitRecordInfo.ContactID = Convert.ToInt32(contactID);
        visitRecordInfo.RecordTime = txtVisitTime.Value;
        visitRecordInfo.VisitDetail = txtVisitDetail.Text;
        visitRecordInfo.UserID = Convert.ToInt32(Session["userID"].ToString());

        if (visitRecord.InsertVisitRecord(visitRecordInfo) == 1)
        {
            Response.Write("<script  language='javascript'> window.alert('添加成功'); </script>");
        }
        else
        {
            Response.Write("<script  language='javascript'> alert('添加失败'); </script>");
        }

        switch (resourceType)
        {
            case "客户":
                {
                    Response.Redirect("ModifyCustomer.aspx?customerID=" + resourceID.ToString());
                    break;
                }
            case "临床":
                {
                    Response.Redirect("ModifyClinicalResource.aspx?clinicalResourceID=" + resourceID.ToString());
                    break;
                }
            case "政府":
                {
                    Response.Redirect("ModifyGoverResource.aspx?goverResourceID=" + resourceID.ToString());
                    break;
                }
            case "合作伙伴":
                {
                    Response.Redirect("ModifyPartnerResource.aspx?partnerResourceID=" + resourceID.ToString());
                    break;
                }
        }
    }

    protected void Abort(object sender, EventArgs e)
    {
        Response.Write("VisitRecordList.aspx");
    }

    protected bool isUserLogin()
    {
        if (Session["userID"].ToString() == "")
            return false;

        int userID = Convert.ToInt32(Session["userID"].ToString());
        if (user.GetUserById(userID) == null)
            return false;

        return true;
    }
}
