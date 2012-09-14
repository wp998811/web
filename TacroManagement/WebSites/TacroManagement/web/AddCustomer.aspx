<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddCustomer.aspx.cs" Inherits="web_AddCustomer"  Title="添加客户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
                <legend>添加客户</legend>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户名称
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="textBox_customerName"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户负责人
                    </label>
                    <div class="controls">
                        <asp:dropdownlist id="dropDown_customerManager" runat="server"/>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    所在城市
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="textBox_city"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户类别
                    </label>
                    <div class="controls">
                        <asp:DropDownList id="ddl_clientType" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    级别
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="textBox_level"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    产品范围
                    </label>
                    <div class="controls">
                        <asp:DropDownList id="ddl_productRange" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    税务登记号
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="textBox_taxID"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    组织机构代码
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="textBox_organCode"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                        <asp:Button class="btn btn-primary" id="addCustomer" Text="确定" runat="server" OnClick="Add_Customer" />
                        <asp:Button class="btn" id="btnCancel" Text="取消" runat="server"/>
                    </div>
                </div>
             </form>
         </div>
     </div>
    <%--<div>
    
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
    </table>--%>
</asp:Content>