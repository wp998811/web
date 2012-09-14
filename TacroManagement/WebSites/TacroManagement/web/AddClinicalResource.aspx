<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="AddClinicalResource.aspx.cs" Inherits="web_AddClinicalResource" Title="添加临床资源" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <legend>添加临床资源</legend>
            <div class="form-horizontal control-group">
                <label class="control-label">
                负责人姓名
                </label>
                <div class="controls">
                    <asp:TextBox ID="textBox_manager" runat="Server"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                城市
                </label>
                <div class="controls">
                    <asp:TextBox ID="textBox_city" runat="Server"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                医院名称
                </label>
                <div class="controls">
                    <asp:TextBox ID="textBox_hospital" runat="Server"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                科室名称
                </label>
                <div class="controls">
                    <asp:TextBox ID="textBox_departmentName" runat="Server"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                科室简介
                </label>
                <div class="controls">
                    <asp:TextBox ID="textBox_departIntro" runat="Server"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addClinicalResource" Text="确定" runat="server"
                        OnClick="Add_ClinicalResource" />
                    <asp:Button class="btn" ID="btnCancel" runat="Server" Text="取消" />
                </div>
            </div>
            </form>
        </div>
        <%--<table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td align="right"><asp:label id="label_manager" runat="server" Text="负责人姓名"/></td>
    		<td><asp:TextBox id="textBox_manager" runat="server" /></td>
    	</tr>
    	<tr>
    		<td align="right"><asp:label id="label_city" runat="server" Text="城市"/></td>
    		<td><asp:TextBox id="textBox_city" runat="server"/></td>
    	</tr>
    	<tr>
    		<td align="right"><asp:label id="label_hospital" runat="server" Text="医院名称"/></td>
    		<td><asp:TextBox id="textBox_hospital" runat="server" /></td>
    	</tr>
    	<tr>
    		<td align="right"><asp:label id="label_departmentName" runat="server" Text="科室名称"/></td>
    		<td><asp:TextBox id="textBox_departmentName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td align="right"><asp:label id="label_departIntro" runat="server" Text="科室简介"/></td>
    		<td><asp:TextBox id="textBox_departIntro" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td></td>
    	    <td>
    	    <asp:Button class="btn btn-primary" id="addClinicalResource" Text="确定" runat="server" OnClick="Add_ClinicalResource" />
    	    <asp:Button class="btn" ID="btnCancel" runat="Server" Text="取消" />
    	    </td>
    	</tr>
    </table>--%>
    </div>
</asp:Content>
