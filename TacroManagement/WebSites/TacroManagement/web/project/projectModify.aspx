<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true"
    CodeFile="projectModify.aspx.cs" Inherits="web_projectModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    

    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="padding-top:10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">项目管理</a> <span class="divider">/</span> </li>
            <li class="active">项目编辑</li>
        </ul>
        <div class="row">
            <form class="form-horizontal">
                <div class="control-group form-horizontal">
                    <label class="control-label">项目名称</label>
                    <div class="controls">
                    <span class="input-large uneditable-input">
                        <asp:Label runat="Server" ID="lblProjectName" Text=""></asp:Label>
                    </span>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">管理人员</label>
                    <div class="controls">
                    <span class="input-large uneditable-input">
                        <asp:Label runat="Server" ID="lblProjectManager" Text=""></asp:Label>
                    </span>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">客户名称</label>
                    <div class="controls">
                    <asp:TextBox runat="Server" ID="txtClientName" Text=""></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">项目类型</label>
                    <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlProjectType">
                    </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">项目简介</label>
                    <div class="controls">
                    <asp:TextBox ID="txtProjectDes" class="span4" runat="Server" Rows="6" TextMode="MultiLine"
                        EnableTheming="true"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">开始日期</label>
                    <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iBeginDate" runat="Server" type="text" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                    </div>
                </div>
                <div class="control-group form-horizontal">
                    <label class="control-label">结束日期</label>
                    <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                    </div>
                </div>
                <div class="control-group form-horizontal">

                    <div class="controls">
                        <asp:Button ID="btnOk" class="btn btn-primary" runat="Server" Text="确定" OnClick="btnOk_Click" />
                        <asp:Button ID="btnCancel" class="btn" runat="Server" Text="取消" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
    <%--<div class="container">
        <div style="padding-top:10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">项目管理</a> <span class="divider">/</span> </li>
            <li class="active">项目编辑</li>
        </ul>
        <table>
            <tr>
                <td>
                    <label>
                        项目名称 </label>
                </td>
                <td>
                    <span class="input-large uneditable-input">
                        <asp:Label runat="Server" ID="lblProjectName" Text=""></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>管理人员 </span>
                </td>
                <td>
                    <span class="input-large uneditable-input">
                        <asp:Label runat="Server" ID="lblProjectManager" Text=""></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>客户名称 </span>
                </td>
                <td>
                    <asp:TextBox runat="Server" ID="txtClientName" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>项目类型 </span>
                </td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlProjectType">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>项目简介 </span>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectDes" class="span4" runat="Server" Rows="6" TextMode="MultiLine"
                        EnableTheming="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>开始日期</span>
                </td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iBeginDate" runat="Server" type="text" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span>结束日期</span>
                </td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
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
    </div>--%>
</asp:Content>
