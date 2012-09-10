<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddClinicalResource.aspx.cs" Inherits="web_AddClinicalResource"  Title="添加临床资源" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加临床资源"></asp:Label>
    
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
    		<td><asp:label id="label_hospital" runat="server" Text="医院名称"/></td>
    		<td><asp:TextBox id="textBox_hospital" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_departmentName" runat="server" Text="科室名称"/></td>
    		<td><asp:TextBox id="textBox_departmentName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_departIntro" runat="server" Text="科室简介"/></td>
    		<td><asp:TextBox id="textBox_departIntro" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td><asp:Button id="addClinicalResource" Text="添加临床资源" runat="server" OnClick="Add_ClinicalResource" /></td>
    	</tr>
    </table>
</asp:Content>
