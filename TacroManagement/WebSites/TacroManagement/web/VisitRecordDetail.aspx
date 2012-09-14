<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="VisitRecordDetail.aspx.cs" Inherits="web_VisitRecordDetail" Title="拜访记录信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
        <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="VisitRecordList.aspx">拜访记录管理</a> <span class="divider">/</span> </li>
            <li class="active">
                <asp:Label ID="Label2" runat="Server" Text="拜访记录信息"></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>拜访记录信息</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0"
            cellpadding="0" border="0">
            <tr>
                <td>
                    <strong>联系人姓名</strong>
                </td>
                <td>
                    <asp:Label ID="lblContactName" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>地址</strong>
                </td>
                <td>
                    <asp:Label ID="lblAddress" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>手机</strong>
                </td>
                <td>
                    <asp:Label ID="lblTelephone" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>拜访时间</strong>
                </td>
                <td>
                    <asp:Label ID="lblVisitTime" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <div>
                <span><strong>拜访记录</strong></span>
            </div>
            <div class="well">
                <asp:Label ID="lblVisitDetail" runat="Server" Text=""></asp:Label>
            </div>
        </div>
</asp:Content>
