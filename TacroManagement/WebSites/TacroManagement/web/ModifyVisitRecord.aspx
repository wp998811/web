<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyVisitRecord.aspx.cs" Inherits="web_ModifyVisitRecord" Title="修改拜访记录信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../script/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />

    <script src="../script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

        <div class="container">
        <div style="padding-top:10px"></div>
            <ul class="breadcrumb">
                <li>
                    <a href="VisitRecordList.aspx">拜访记录管理</a> <span class="divider">/</span>
                </li>
                  <li class="active">
                    <asp:Label ID="Label1" runat="Server" Text="编辑拜访记录"></asp:Label></li>
            </ul>
        <div class="row" style="align:middle">
            <form class="form-horizontal">
                <div class="form-horizontal control-group">
                    <label class="control-label">拜访记录</label>
                    <div class="controls">
                        <asp:TextBox ID="txtVisitDetail" runat="Server"  Width="300px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtVisitDetail"
                            ErrorMessage="输入过长" ValidationExpression="(.|\s){0,200}" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">拜访时间</label>
                    <div class="controls">
                        <input id="txtVisitTime" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtVisitTime"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="拜访时间不能为空"
                            ControlToValidate="txtVisitTime" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <div class="controls">
                        <asp:Button class="btn btn-primary" id="modifyVisitRecord" Text="确定" runat="server" OnClick="Modify_VisitRecord" />
                        <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" OnClick="Abort"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
