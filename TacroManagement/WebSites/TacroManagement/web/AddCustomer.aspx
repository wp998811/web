<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddCustomer.aspx.cs" Inherits="web_AddCustomer"  Title="添加客户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <ul class="breadcrumb">
                <li><a href="CustomerList.aspx">客户管理</a> <span class="divider">/</span> </li>
                <li class="active">
                    <asp:Label ID="Label1" runat="Server" Text="添加客户"></asp:Label></li>
            </ul>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户名称
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCustomerName"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCustomerName"
                    ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="客户名称不能为空"
                    ControlToValidate="txtCustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户负责人
                    </label>
                    <div class="controls">
                        <asp:dropdownlist id="ddlManager" runat="server"/>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ddlManager"
                    ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="负责人不能为空"
                    ControlToValidate="ddlManager" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    所在城市
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCity"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    客户类别
                    </label>
                    <div class="controls">
                        <asp:DropDownList id="ddlCustomerType" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ddlCustomerType"
                            ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    级别
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtLevel"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtLevel"
                            ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    产品范围
                    </label>
                    <div class="controls">
                        <asp:DropDownList id="ddlProductRange" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="ddlProductRange"
                            ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    税务登记号
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtTaxID"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTaxID"
                            ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                    组织机构代码
                    </label>
                    <div class="controls">
                       <asp:TextBox runat="Server" ID="txtOrganCode"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtOrganCode"
                            ErrorMessage="输入有误" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                        <asp:Button class="btn btn-primary" id="addCustomer" Text="确定" runat="server" OnClick="Add_Customer" />
                        <asp:Button class="btn" id="btnCancel" Text="取消" runat="server" OnClick="Abort"/>
                    </div>
                </div>
             </form>
         </div>
     </div>
</asp:Content>