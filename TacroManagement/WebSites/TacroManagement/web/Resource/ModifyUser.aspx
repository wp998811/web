<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ModifyUser.aspx.cs" Inherits="web_ModifyUser" Title="编辑个人信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">

    <legend>编辑个人信息</legend>
    <form class="form-horizontal">
    <div class="control-group form-horizontal">
        <label class="control-label">
            用户名</label>
        <div class="controls">
            <asp:TextBox ID="txtUserName" runat="server" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtUserName"
                ErrorMessage="请输入用户名" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:Label ID="lblUserName" Text="用户名已存在" runat="server" Visible="false" Style="color: Red"></asp:Label>
        </div>
    </div>
    <div class="control-group form-horizontal">
            <label class="control-label">
               用户邮箱</label>
             <div class="controls">
             <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="16" AutoCompleteType="Disabled"></asp:TextBox>
             <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="邮箱格式不正确" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
             </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
               用户手机</label>
             <div class="controls">
             <asp:TextBox ID="txtPhone" runat="server" Width="180px"></asp:TextBox>
             <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                        ControlToValidate="txtPhone" ErrorMessage="手机号码格式不正确" 
                        ValidationExpression="^(13[1-9]|15[0-9]|188[8|9])\d{8}$"></asp:RegularExpressionValidator>
             </div>
        </div>
        <div class="control-group form-horizontal">
             <div class="controls">
             <asp:Button class="btn btn-primary" ID="ModifyButton" runat="server" Text="确定" 
                    onclick="ModifyButton_Click" />
             <asp:Button class="btn" ID="CancelButton" runat="server" Text="返回" 
                    onclick="CancelButton_Click" />
             <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
             </div>
        </div>
    </form>
    </div>
</asp:Content>

