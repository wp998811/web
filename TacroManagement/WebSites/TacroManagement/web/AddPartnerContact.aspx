<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddPartnerContact.aspx.cs" Inherits="web_AddPartnerContact"  Title="添加合作伙伴资源联系人" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
                <legend>添加合作伙伴资源联系人</legend>
                <div class="form-horizontal control-group">
                    <label class="control-label">联系人姓名</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_contactName" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">职位</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_position" runat="server"/>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">手机</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_mobilephone" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">固定电话</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_telephone" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">电子邮件</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_email" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">地址</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_address" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">邮政编码</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_postCode" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">传真号</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_faxNumber" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                    <asp:Button class="btn btn-primary" id="addPartnerContact" Text="确定" runat="server" OnClick="Add_PartnerContact" />
                    <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" />
                    </div>
                </div>
            </form>
        </div>
    </div>
   <%-- <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加合作伙伴资源联系人"></asp:Label>
    
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
    	    <td><asp:Button id="addPartnerContact" Text="添加合作伙伴资源联系人" runat="server" OnClick="Add_PartnerContact" /></td>
    	</tr>
    </table>--%>
</asp:Content>


