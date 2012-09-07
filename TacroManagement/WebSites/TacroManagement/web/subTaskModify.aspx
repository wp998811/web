<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="subTaskModify.aspx.cs" Inherits="web_subTaskModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <link href="../script/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />

    <script src="../script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div style="padding-top:10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">项目管理</a><span class="divider">/</span> </li>
            <li><a href="#"><asp:Label runat="Server" ID="lblProjectName" Text=""></asp:Label></a> <span class="divider">/</span> </li>
            <li class="active"><asp:Label runat="server"  ID="lblSubTaskName" Text=""></asp:Label></li>
        </ul>
        <asp:Label runat="Server" ID="lblProjectNum" Visible="false" Text=""></asp:Label>
        <asp:Label runat="Server" ID="lblTaskID" Visible="false" Text=""></asp:Label>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>任务名称</td>
                <td>
                    <asp:TextBox runat="Server" ID="txtSubTaskName" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>工期</td>
                <td>
                    <asp:TextBox runat="Server" ID="txtSubTaskPeriod" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>开始时间</td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iBeginDate" runat="Server" type="text" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span>结束时间</span>
                </td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>产物</td>
                <td>
                    <asp:TextBox runat="Server" ID="txtProduct" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>前置任务</td>
                <td>
                    <asp:TextBox runat="Server" ID="txtForeTask" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>资源</td>
                <td>
                    <asp:TextBox runat="Server" Text="" ID="txtResource"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>负责人</td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlTaskManager" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>自动提醒</td>
                <td>
                    <asp:CheckBox runat="Server" ID="cbIsRemind" Text="" />
                </td>
            </tr>
            <tr>
                <td>任务状态</td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlTaskState">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnOk" class="btn-primary" runat="Server" Text="确定" OnClick="btnOk_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" class="btn" runat="Server" Text="取消" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

