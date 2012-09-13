<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="subTaskInfo.aspx.cs" Inherits="web_project_subTaskInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
        <ul class="breadcrumb">
            <li><a href="projectInfo.aspx?projectNum=<%=projectNum %>">
                <asp:Label runat="Server" ID="lblNavProjectName" Text=""></asp:Label>
            </a> <span class="divider">/</span></li>
            <li class="active">
                <asp:Label runat="Server" ID="lblNavSubTaskName" Text=""></asp:Label>
            </li>
        </ul>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td><strong>任务名称</strong></td>
                <td><asp:Label runat="Server" ID="lblTaskName" Text=""></asp:Label></td>
                <td><strong>工期</strong></td>
                <td><asp:Label runat="Server" ID="lblPeriod" Text=""></asp:Label></td>
                <td><strong>负责人</strong></td>
                <td><asp:Label runat="Server" ID="lblManager" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><strong>开始时间</strong></td>
                <td><asp:Label runat="Server" ID="lblBeginDate" Text=""></asp:Label></td>
                <td><strong>结束时间</strong></td>
                <td><asp:Label runat="Server" ID="lblEndDate" Text=""></asp:Label></td>
                <td><strong>任务状态</strong></td>
                <td><asp:Label runat="Server" ID="lblTaskState" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><strong>产物</strong></td>
                <td><asp:Label runat="Server" ID="lblProduct" Text=""></asp:Label></td>
                <td><strong>前置任务</strong></td>
                <td><asp:Label runat="Server" ID="lblForeTask" Text=""></asp:Label></td>
                <td><strong>资源</strong></td>
                <td><<asp:Label runat="Server" ID="lblResource" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><strong>自动提醒</strong></td>
                <td><asp:Label runat="Server" ID="lblIsRemind" Text=""></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <%--<form class="form-horizontal">
            <div class="control-group form-horizontal">
                <label class="control-label">任务名称</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblTaskName" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">工期</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblPeriod" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">开始时间</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblBeginDate" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">结束时间</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblEndDate" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">产物</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblProduct" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">前置任务</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblForeTask" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">资源</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblResource" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">负责人</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblManager" Text=""></asp:Label>
                </div>
             </div>
             <div class="control-group form-horizontal">
                <label class="control-label">任务状态</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblTaskState" Text=""></asp:Label>
                </div>
            </div>
            <div class="control-group form-horizontal">
                <label class="control-label">自动提醒</label>
                <div class="controls">
                    <asp:Label runat="Server" ID="lblIsRemind" Text=""></asp:Label>
                </div>
            </div>
        </form>--%>
    </div>
</asp:Content>

