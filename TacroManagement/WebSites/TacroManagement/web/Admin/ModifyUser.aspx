<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="ModifyUser.aspx.cs" Inherits="web_Admin_ModifyUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h3>
        用户管理 > 用户信息</h3>
    <div style="margin: 0 auto; font-size: 12px; font-weight: bold;">
        <table>
            <tr>
                <td class="style18">
                    用户名:
                </td>
                <td class="style19">
                    <asp:TextBox ID="txtUserName" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    &nbsp;
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
                    <asp:Button ID="btComfirm" runat="server" Text="确认" OnClick="btComfirm_Click" />
                    <asp:Button ID="btnCancle" runat="server" Text="返回" OnClick="btnCancle_Click" 
                        CausesValidation="False" Width="40px" />
                </td>
                <td class="style8">
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

