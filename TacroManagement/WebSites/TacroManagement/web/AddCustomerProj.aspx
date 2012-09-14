<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="AddCustomerProj.aspx.cs" Inherits="web_AddCustomerProj" Title="添加客户项目" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="container">
        <div style="padding-top:10px"></div>
    <ul class="breadcrumb">
        <li><a href="CustomerProjList.aspx">客户项目管理</a> <span class="divider">/</span> </li>
        <li class="active">
            <asp:Label ID="Label1" runat="Server" Text="添加客户项目"></asp:Label></li>
    </ul>
        <div class="row" style="align:middle">
            <form class="form-horizontal">
                <div class="form-horizontal control-group">
                    <label class="control-label">客户名称</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCustomerName" onfocus="$('#myModal').modal({backdrop:false, keyboard:true,show:true})"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomerName"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="客户名称不能为空"
                            ControlToValidate="txtCustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="controls">
                        <asp:TextBox ID="txtHiddenCustomerID" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    <div class="modal hide fade" id="myModal">
                        <div class="modal-header">
                            <a class="close" data-dismiss="modal">×</a>
                            <h3> 选择客户</h3>
                        </div>
                        <div class="modal-body" style="margin: 0px auto">
                            <asp:DropDownList runat="server" ID="ddlCustomer">
                            </asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton class="btn btn-primary" ID="lbtnSelectCustomer" runat="Server" CommandName="select"
                                CausesValidation="false" Text="确定" OnCommand="lbtnSelectCustomer_Command"></asp:LinkButton>
                            <a data-dismiss="modal" href="#" class="btn">关闭</a>
                        </div>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">服务项目</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtService"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtService"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">项目进程</label>
                    <div class="controls">
                        <asp:DropDownList runat="Server" ID="ddlProgress"></asp:DropDownList>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ddlProgress"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">产品名称</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtProductName"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtProductName"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">项目类型</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtProjectType"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtProjectType"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">合同金额</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtContractAmount"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtContractAmount"
                            ErrorMessage="请输入整数" ValidationExpression="([0-9]){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">付款方式</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtPayment"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPayment"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">付款情况</label>
                    <div class="controls">
                        <asp:DropDownList runat="Server" ID="ddlPayState"></asp:DropDownList>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="ddlPayState"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                        <asp:Button class="btn btn-primary" id="addCustomerProj" Text="确定" runat="server"  OnClick="Add_CustomerProj"/>
                        <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" />
                    </div>
                </div>
                
            </form>
        </div>
    </div>
</asp:Content>
