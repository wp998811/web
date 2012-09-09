<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddContact.aspx.cs" Inherits="web_AddContact"  Title="添加联系人" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加联系人"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td><asp:label id="label_contactName" runat="server" Text="联系人姓名"/></td>
    		<td><asp:TextBox id="textBox_contactName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_position" runat="server" Text="职位"/></td>
    		<td><asp:TextBox id="textBox_position" runat="server"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_mobilephone" runat="server" Text="手机"/></td>
    		<td><asp:TextBox id="textBox_mobilephone" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_telephone" runat="server" Text="固定电话"/></td>
    		<td><asp:TextBox id="textBox_telephone" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_email" runat="server" Text="电子邮件"/></td>
    		<td><asp:TextBox id="textBox_email" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_address" runat="server" Text="地址"/></td>
    		<td><asp:TextBox id="textBox_address" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_postCode" runat="server" Text="邮政编码"/></td>
    		<td><asp:TextBox id="textBox_postCode" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_faxNumber" runat="server" Text="传真号"/></td>
    		<td><asp:TextBox id="textBox_faxNumber" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td><asp:Button id="addCustomer" Text="添加联系人" runat="server" OnClick="Add_Contact" /></td>
    	</tr>
    </table>
</asp:Content>
