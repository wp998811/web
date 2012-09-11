<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="web_Admin_AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
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
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <h3>
        用户管理 > 用户列表</h3>
    <div style="margin: 0 auto; font-size: 12px; font-weight: bold;">
        <table>
            <tr>
                <td class="style18">
                    用户名:
                </td>
                <td class="style19">
                    <asp:TextBox ID="txtUserName" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                        ControlToValidate="txtUserName" ErrorMessage="请输入用户名" Display="Dynamic"></asp:RequiredFieldValidator>
                   <asp:Label ID="lblUserName" Text="用户名已存在" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    用户密码:
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtPassword" runat="server" Width="180px" AutoCompleteType="Disabled"
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNickName" runat="server" ErrorMessage="请输入密码"
                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    确认密码:
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" Width="180px" 
                        AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入确认密码"
                        ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="两次密码不一致"
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    用户类型:
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value="系统管理员">系统管理员</asp:ListItem>
                        <asp:ListItem Value="项目管理员">项目管理员</asp:ListItem>
                        <asp:ListItem Value="部门管理员">部门管理员</asp:ListItem>
                        <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
                        <asp:ListItem Value="客户">客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style12">
                    用户邮箱:
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="16" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="邮箱格式不正确" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    用户手机:
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtPhone" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                        ControlToValidate="txtPhone" ErrorMessage="手机号码格式不正确" 
                        ValidationExpression="^(13[1-9]|15[0-9]|188[8|9])\d{8}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style12">
                    所属部门:
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlDepart" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
            </tr>
            
            <tr>
                <td class="style6">
                </td>
                <td class="style7">
                    <asp:Button ID="btAdd" runat="server" Text="添加" onclick="btAdd_Click"/>
                    <asp:Button ID="btnCancle" runat="server" Text="返回" OnClick="btnCancle_Click" 
                        CausesValidation="False" Width="40px" style="height: 26px" />
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
