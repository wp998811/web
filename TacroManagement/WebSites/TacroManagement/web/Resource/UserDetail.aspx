<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="web_UserDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <legend>个人信息</legend>
        <form class="form-horizontal">
        <div class="control-group form-horizontal">
            <label class="control-label">
                用户名</label>
            <div class="controls">
                <asp:Label ID="lblUserName" runat="server" Width="180px"></asp:Label>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                用户类型</label>
            <div class="controls">
                <asp:Label ID="lblUserType" runat="server" Width="180px"></asp:Label>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                用户邮箱</label>
            <div class="controls">
                <asp:Label ID="lblEmail" runat="server" Width="180px"></asp:Label>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                用户手机</label>
            <div class="controls">
                <asp:Label ID="lblPhone" runat="server" Width="180px"></asp:Label>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                所属部门</label>
            <div class="controls">
                <asp:Label ID="lblDepart" runat="server" Width="180px"></asp:Label>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <div class="controls">
                <asp:HyperLink class="btn btn-primary" ID="ModifyUserLink" runat="server" NavigateUrl="ModifyUser.aspx">修改信息</asp:HyperLink>
                <asp:HyperLink class="btn btn-primary" ID="ModifyPassLink" runat="server" NavigateUrl="ModifyPassword.aspx">修改密码</asp:HyperLink>
                <asp:Button class="btn" ID="CancelButton" runat="server" Text="返回" 
                    onclick="CancelButton_Click" />
            </div>
        </div>
        </form>
    </div>
</asp:Content>

