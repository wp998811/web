<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddPartnerResource.aspx.cs" Inherits="web_AddPartnerResource"  Title="添加合作伙伴资源" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
<link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
                <legend>添加合作伙伴资源</legend>
                <div class="form-horizontal control-group">
                    <label class="control-label">负责人姓名</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_manager" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">城市</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_city" runat="server"/>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">组织名称</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_organName" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">组织简介</label>
                    <div class="controls">
                    <asp:TextBox id="textBox_organIntro" runat="server" />
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                    <asp:Button class="btn btn-primary" id="addPartnerResource" Text="确定" runat="server" OnClick="Add_PartnerResource" />
                    <asp:Button class="btn" ID="btnCancel" runat="server" Text="取消" />
                    </div>
                </div>
            </form>
        </div>
    </div>
<%--    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加合作伙伴资源"></asp:Label>
    
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
    	    <td><asp:Button id="addPartnerResource" Text="添加合作伙伴资源" runat="server" OnClick="Add_PartnerResource" /></td>
    	</tr>
    </table>--%>
</asp:Content>

