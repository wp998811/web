<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="NewResourceAdmin.aspx.cs" Inherits="web_Admin_NewResourceAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
</asp:Content>

