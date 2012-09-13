<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="ModifyDepart.aspx.cs" Inherits="web_Admin_ModifyDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <asp:RequiredFieldValidator ID="rfvDepartName" runat="server" 
                        ErrorMessage="请输入部门名称" ControlToValidate="txtDepartName"></asp:RequiredFieldValidator>
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
</asp:Content>

