<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="web_Home" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

