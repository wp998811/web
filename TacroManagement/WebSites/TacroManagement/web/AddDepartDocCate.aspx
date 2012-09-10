<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="AddDepartDocCate.aspx.cs" Inherits="web_AddProjDocCate" Title="增加部门文档类型" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    部门:<asp:DropDownList ID="DepartName" runat="server">
    </asp:DropDownList>
&nbsp;文档范围:<asp:DropDownList ID="InOutDoc" runat="server">
        <asp:ListItem Value="1">内部文档</asp:ListItem>
        <asp:ListItem Value="2">外部文档</asp:ListItem>
    </asp:DropDownList>
    文档名称:<asp:TextBox ID="CategoryName" runat="server"></asp:TextBox>
    <asp:ImageButton ID="AddButton" runat="server" 
        onclick="AddButton_Click" />

</asp:Content>

