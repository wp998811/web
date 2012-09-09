<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="web_Admin_AddDepartment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新建部门</title>
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
        部门管理 > 部门信息</h3>
    <div style="margin: 0 auto; font-size: 12px; font-weight: bold;">
        <table>
            <tr>
                <td class="style18">
                    部门名称:
                </td>
                <td class="style19">
                    <asp:TextBox ID="txtDepartName" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="rfvDepartName" runat="server" ErrorMessage="请输入部门名称"
                        ControlToValidate="txtDepartName" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblDepartName" Text="部门已存在" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    部门管理员:
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtDepartAdmin" runat="server" Width="180px" 
                        AutoCompleteType="Disabled"></asp:TextBox>
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
