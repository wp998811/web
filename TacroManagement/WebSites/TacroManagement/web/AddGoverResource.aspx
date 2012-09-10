<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddGoverResource.aspx.cs" Inherits="web_AddGoverResource"  Title="添加政府资源" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加政府资源"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td><asp:label id="label_manager" runat="server" Text="负责人姓名"/></td>
    		<td><asp:TextBox id="textBox_manager" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_city" runat="server" Text="城市"/></td>
    		<td><asp:TextBox id="textBox_city" runat="server"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_organName" runat="server" Text="组织名称"/></td>
    		<td><asp:TextBox id="textBox_organName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_organIntro" runat="server" Text="组织简介"/></td>
    		<td><asp:TextBox id="textBox_organIntro" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td><asp:Button id="addGoverResource" Text="添加政府资源" runat="server" OnClick="Add_GoverResource" /></td>
    	</tr>
    </table>
</asp:Content>





