<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ModifyDepart.aspx.cs" Inherits="web_Admin_ModifyDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">部门管理</a><span class="divider">/编辑</span> </li>
        </ul>
        <div class="row">
            <form class="form-horizontal">
            <div class="form-horizontal control-group">
                <label class="control-label">
                    部门名称
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtDepartName" Text="" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    部门管理员
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtDepartAdmin" Text=""></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvDepartAdmin" runat="server" ErrorMessage="请输入管理员名"
                        ControlToValidate="txtDepartAdmin"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button ID="btComfirm" class="btn btn-primary" runat="Server" Text="确定" OnClick="btComfirm_Click" />
                    <asp:Button ID="btnCancle" class="btn" runat="Server" Text="取消" OnClick="btnCancle_Click"
                        CausesValidation="False" />
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
