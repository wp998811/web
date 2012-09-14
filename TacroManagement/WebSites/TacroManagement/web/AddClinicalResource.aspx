<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="AddClinicalResource.aspx.cs" Inherits="web_AddClinicalResource" Title="添加临床资源" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <ul class="breadcrumb">
                <li><a href="ClinicalResourceList.aspx">临床资源管理</a> <span class="divider">/</span> </li>
                <li class="active">
                    <asp:Label runat="Server" Text="添加临床资源"></asp:Label></li>
            </ul>
            <div class="form-horizontal control-group">
                <label class="control-label">
                负责人姓名
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtManager" onfocus="$('#myModal').modal({backdrop:false, keyboard:true,show:true})"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtManager"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="负责人不能为空"
                        ControlToValidate="txtManager" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="controls">
                    <asp:TextBox ID="txtHiddenUserID" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>
                            修改临床资源负责人</h3>
                    </div>
                    <div class="modal-body" style="margin: 0px auto">
                        <asp:DropDownList runat="server" ID="ddlUser">
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-primary" ID="lbtnSelectUser" runat="Server" CommandName="select"
                            CausesValidation="false" Text="确定" OnCommand="lbtnSelectUser_Command"></asp:LinkButton>
                        <a data-dismiss="modal" href="#" class="btn">关闭</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                城市
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtCity" runat="Server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                医院名称
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtHospital" runat="Server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtHospital"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="医院名称不能为空"
                        ControlToValidate="txtHospital" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                科室名称
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtDepartmentName" runat="Server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDepartmentName"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="科室名称不能为空"
                        ControlToValidate="txtHospital" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                科室简介
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtDepartmentIntro" runat="Server"  Width="300px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDepartmentIntro"
                        ErrorMessage="输入过长" ValidationExpression="(.|\s){0,200}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addClinicalResource" Text="确定" runat="server"
                        OnClick="Add_ClinicalResource" />
                    <asp:Button class="btn" ID="btnCancel" runat="Server" Text="取消"  OnClick="Abort"/>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
