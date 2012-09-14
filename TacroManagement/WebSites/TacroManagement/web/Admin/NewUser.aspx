<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="NewUser.aspx.cs" Inherits="web_Admin_NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">用户管理</a><span class="divider">/添加</span> </li>
        </ul>
        <div class="row">
            <form class="form-horizontal">
            <div class="form-horizontal control-group">
                <label class="control-label">
                    用户名
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtUserName" Text=""></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="请输入用户名" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblUserName" Text="用户名已存在" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    用户密码
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtPassword" Text="" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ErrorMessage="请输入密码" ControlToValidate="txtPassword"
                        Display="Dynamic"></asp:RequiredFieldValidator></div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    确认密码
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtConfirmPassword" Text="" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入确认密码"
                        ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致"
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:CompareValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    用户类型
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList ID="ddlUserType" runat="server">
                            <asp:ListItem Value="系统管理员">系统管理员</asp:ListItem>
                            <asp:ListItem Value="项目管理员">项目管理员</asp:ListItem>
                            <asp:ListItem Value="部门管理员">部门管理员</asp:ListItem>
                            <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
                            <asp:ListItem Value="客户">客户</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    用户邮箱
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtEmail" Text=""></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="邮箱格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    用户手机
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="txtPhone" Text=""></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="手机号码格式不正确" ValidationExpression="^(13[1-9]|15[0-9]|18[8|9])\d{8}$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    所属部门
                </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlDepart" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button ID="btAdd" class="btn btn-primary" runat="Server" Text="确定" OnClick="btAdd_Click" />
                    <asp:Button ID="btnCancle" class="btn" runat="Server" Text="取消" OnClick="btnCancle_Click"
                        CausesValidation="False" />
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
