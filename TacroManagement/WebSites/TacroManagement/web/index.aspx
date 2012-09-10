<<<<<<< HEAD
<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="web_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width:100%">
        <div style="width:40%;float:left;">
            <table class="table table-condensed">
                <tr>
                    <td>事宜名称</td>
                    <td>到期时间</td>
                </tr>
                <asp:Repeater runat="Server" ID="rpTask">
                <ItemTemplate>
                    <tr>
                        <td>    
                            <a href="subTaskInfo.aspx?subTaskId=<%#Eval("TaskId") %>"><asp:Label ID="lblRpTaskName" runat="Server" Text='<%#Eval("TaskName") %>'></asp:Label></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRpTaskDate" runat="Server" Text='<%#Eval("TaskDate") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div style="width:60%;float:right;">
            <table class="table table-condensed">
            	<tr>
            		<td>动态</td>
            		<td>操作时间</td>
            		<td>操作人</td>
            		<td>项目名称</td>
            	</tr>
                <asp:Repeater runat="Server" ID="rpProjectState">
                <ItemTemplate>
=======
﻿<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="web_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width: 100%;">
        <div style="width: 100%; height: 10px;">
        </div>
        <div style="width: 100%">
            <div style="width: 40%; float: left;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" background="../images/tab_05.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="30">
                                        <img src="../images/tab_03.gif" width="12" height="30" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" valign="middle">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5%">
                                                                <div align="center">
                                                                    <img src="../images/tb.gif" width="16" height="16" /></div>
                                                            </td>
                                                            <td width="90%" class="STYLE1">
                                                                <span class="STYLE3">待办事宜</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="54%">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_07.gif" width="16" height="30" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
>>>>>>> e9c41c9142fc706bc282ac57b52204e5e3e806cf
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairDes" Text='<%#Eval("AffairDescription") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairTime" Text='<%#Eval("AffairTime") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairOperatorName" Text='<%#Eval("AffairOperator") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
            
        </div>
        
    </div>
    <div style="width:100%">
        <table class="table table-condensed">
            <tr>
                <td>文件名称</td>
                <td>文件类别</td>
                <td>部门</td>
                <td>上传人</td>
                <td>上传时间</td>
            </tr>
            <asp:Repeater runat="Server" ID="rpDocState">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="Server" ID="lblDocName" Text='<%#Eval("DocName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblDocType" Text='<%#Eval("DocCategory") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblDepartName" Text='<%#Eval("DepartName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblOperatpr" Text='<%#Eval("OperatorName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblUploadDate" Text='<%#Eval("UploadTime") %>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width:100%">
        <div style="width:40%;float:left;">
            <table class="table table-condensed">
                <tr>
                    <td>项目名称</td>
                    <td>客户名称</td>
                    <td>开始时间</td>
                </tr>
                <asp:Repeater runat="Server" ID="rpProject">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="projectInfo.aspx?projectNum=<%#Eval("ProjectNum") %>"><asp:Label runat="Server" ID="lblRpProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label></a>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblRpClientName" Text='<%#Eval("ProjectClientName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblBeginDate" Text='<%#Eval("BeginTime") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div style="width:60%;float:right;"></div>
    </div>
</asp:Content>
<<<<<<< HEAD

=======

>>>>>>> e9c41c9142fc706bc282ac57b52204e5e3e806cf
