<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddResourceAdmin.aspx.cs" Inherits="web_Admin_AddResourceAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>指定用户管理资源</title>
  <style type="text/css">
        .style6
        {
            height: 38px;
            width: 75px;
        }
        .style7
        {
            width: 183px;
            height: 38px;
        }
        .style8
        {
            width: 271px;
            height: 38px;
        }
        .style9
        {
            height: 27px;
            width: 75px;
        }
        .style10
        {
            width: 183px;
            height: 27px;
        }
        .style11
        {
            width: 271px;
            height: 27px;
        }
        .style12
        {
            height: 29px;
            width: 75px;
        }
        .style13
        {
            width: 183px;
            height: 29px;
        }
        .style14
        {
            width: 271px;
            height: 29px;
        }
        .style15
        {
            height: 35px;
            width: 75px;
        }
        .style16
        {
            width: 183px;
            height: 35px;
        }
        .style17
        {
            width: 271px;
            height: 35px;
        }
        .style18
        {
            height: 32px;
            width: 75px;
        }
        .style19
        {
            width: 183px;
            height: 32px;
        }
        .style20
        {
            width: 271px;
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h3>
        资源管理 > 指定用户</h3>
    <div style="margin: 0 auto; font-size: 12px; font-weight: bold;">
        <table>
            <tr>
                <td class="style18">
                    资源类型:
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddlResourceType" runat="server">
                        <asp:ListItem Value="客户资源"></asp:ListItem>
                        <asp:ListItem Value="临床资源"></asp:ListItem>
                        <asp:ListItem Value="合作伙伴资源"></asp:ListItem>
                        <asp:ListItem Value="政府资源"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style20">
                </td>
            </tr>
            <tr>
                <td class="style15">
                    管理人员:
                </td>
                <td class="style16">
                    <asp:DropDownList ID="ddlAdmin" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style17">
                </td>
            </tr>
            <tr>
                <td class="style6">
                </td>
                <td class="style7">
                    <asp:Button ID="btComfirm" runat="server" Text="确认" OnClick="btComfirm_Click" />
                    <asp:Button ID="btnCancle" runat="server" Text="返回" OnClick="btnCancle_Click" CausesValidation="False"
                        Width="40px" />
                </td>
                <td class="style8">
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
