<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ModifyProject.aspx.cs" Inherits="web_Admin_ModifyProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="../../script/My97DatePicker/WdatePicker.js"></script>

    <link rel="stylesheet" type="text/css" href="../../script/My97DatePicker/skin/WdatePicker.css" />
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">项目管理</a><span class="divider">/编辑</span> </li>
        </ul>
        <div class="row">
            <form class="form-horizontal">
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目代号
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="lblProjectNum" Text="" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目名称
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox runat="Server" ID="lblProjectName" Text="" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    管理人员
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList runat="Server" ID="ddlAdmin">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    客户名称
                </label>
                <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlClient">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目类型
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList runat="Server" ID="ddlProjectType">
                            <asp:ListItem Value="临床试验"></asp:ListItem>
                            <asp:ListItem Value="注册"></asp:ListItem>
                            <asp:ListItem Value="咨询"></asp:ListItem>
                            <asp:ListItem Value="其他"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目简介
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:TextBox ID="txtProjectDes" class="span4" runat="Server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    开始日期
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iBeginDate" runat="Server" type="text" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    结束日期
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button ID="btnOk" class="btn btn-primary" runat="Server" Text="确定" OnClick="btnOk_Click" />
                    <asp:Button ID="btnCancel" class="btn" runat="Server" Text="取消" OnClick="btnCancel_Click"
                        CausesValidation="False" />
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
