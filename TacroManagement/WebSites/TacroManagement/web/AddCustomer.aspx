<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddCustomer.aspx.cs" Inherits="web_AddCustomer"  Title="添加客户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加客户"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td><asp:label id="label_customerName" runat="server" Text="客户名称"/></td>
    		<td><asp:TextBox id="textBox_customerName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_customerManager" runat="server" Text="客户负责人"/></td>
    		<td><asp:dropdownlist id="dropDown_customerManager" runat="server"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_city" runat="server" Text="所在城市"/></td>
    		<td><asp:TextBox id="textBox_city" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_clientType" runat="server" Text="客户类别"/></td>
    		<td><asp:DropDownList id="ddl_clientType" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_level" runat="server" Text="级别"/></td>
    		<td><asp:TextBox id="textBox_level" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_productRange" runat="server" Text="产品范围"/></td>
    		<td><asp:DropDownList id="ddl_productRange" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_taxID" runat="server" Text="税务登记号"/></td>
    		<td><asp:TextBox id="textBox_taxID" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_organCode" runat="server" Text="组织机构代码"/></td>
    		<td><asp:TextBox id="textBox_organCode" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td><asp:Button id="addCustomer" Text="添加客户" runat="server" OnClick="Add_Customer" /></td>
    	</tr>
    </table>
</asp:Content>