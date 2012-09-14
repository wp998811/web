<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddGoverContact.aspx.cs" Inherits="web_AddGoverContact"  Title="添加政府资源联系人" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
           <ul class="breadcrumb">
                <li>
                    <a href="GoverResourceList.aspx">政府资源管理</a> <span class="divider">/</span>
                </li>
                <li>
                    <a href="ModifyGoverResource.aspx?goverResourceID=<%=goverResourceID %>">编辑政府资源</a> <span class="divider">/</span>
                 </li>
                  <li class="active">
                    <asp:Label ID="Label1" runat="Server" Text="添加政府资源联系人"></asp:Label></li>
            </ul>
                        <div class="row" style="align:middle">
            <form class="form-horizontal">
            <div class="form-horizontal control-group">
                <label class="control-label">
                    联系人姓名</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtContactName"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactName"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="联系人姓名不能为空"
                        ControlToValidate="txtContactName" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    职位</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtPosition"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPosition"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    手机</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtMobilephone"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobilephone"
                        ErrorMessage="手机格式不正确" ValidationExpression="^(13[1-9]|15[0-9]|188[8|9])\d{8}$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    固定电话</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtTelephone"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTelephone"
                        ErrorMessage="电话格式不正确" ValidationExpression="[0-9|-]{0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    电子邮件</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtEmail"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="邮件格式不正确" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    地址</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtAddress"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtAddress"
                        ErrorMessage="地址格式不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    邮政编码</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtPostCode"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPostCode"
                        ErrorMessage="邮编格式不正确" ValidationExpression="([0-9]){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    传真号</label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtFaxNumber"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFaxNumber"
                        ErrorMessage="传真号格式不正确" ValidationExpression="([0-9]|-){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addGoverContact" Text="确定" runat="server"
                        OnClick="Add_GoverContact" />
                    <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" OnClick="Abort" />
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>



