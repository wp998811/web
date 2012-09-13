<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="web_Home" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
    <table style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td style="vertical-align:top">
                <table style="width: 100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 40%; padding-right:10px;vertical-align:top">
                            <ul class="breadcrumb">
                                <li>
                                    <strong>
                                        <asp:LinkButton OnCommand="lBtnTaskMore_Command" runat="Server" ID="lBtnTaskMore" CommandName="more" CausesValidation="false" Text="待办事宜"></asp:LinkButton>
                                    </strong>
                                </li>
                            </ul>
                            
                            <table class="table table-striped table-bordered table-condensed">
                                <tr>
                                    <td>
                                        事宜名称
                                    </td>
                                    <td>
                                        到期时间
                                    </td>
                                </tr>
                                <asp:Repeater runat="Server" ID="rpTask">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="../project/subTaskInfo.aspx?subTaskId=<%#Eval("TaskId") %>&projectNum=<%#Eval("ProjectNum") %>">
                                                    <asp:Label ID="lblRpTaskName" runat="Server" Text='<%#Eval("TaskName") %>'></asp:Label></a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRpTaskDate" runat="Server" Text='<%#Eval("RemindTime") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                        <td style="width: 60%;vertical-align:top">
                            <ul class="breadcrumb">
                                <li>
                                    <strong>
                                        <asp:LinkButton OnCommand="lBtnProjectStateMore_Command" runat="Server" ID="lBtnProjectStateMore" CommandName="more" CausesValidation="false" Text="项目动态"></asp:LinkButton>
                                    </strong>
                                </li>
                            </ul>
                            <table class="table table-striped table-bordered table-condensed">
                                <tr>
                                    <td>
                                        动态
                                    </td>
                                    <td>
                                        操作时间
                                    </td>
                                    <td>
                                        操作人
                                    </td>
                                    <td>
                                        项目名称
                                    </td>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top">
                <ul class="breadcrumb">
                    <li><strong>
                        <asp:LinkButton runat="Server" ID="lBtnDocStateMore" CommandName="more" CausesValidation="false"
                            Text="知识库动态"></asp:LinkButton>
                    </strong></li>
                </ul>
            <table class="table table-striped table-bordered table-condensed">
                <tr>
                    <td>
                        文件名称
                    </td>
                    <td>
                        文件类别
                    </td>
                    <td>
                        部门
                    </td>
                    <td>
                        上传人
                    </td>
                    <td>
                        上传时间
                    </td>
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
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <table  style="width:100%" cellpadding="0" cellpadding="0" border="0">
                    <tr>
                        <td style="width: 40%">
                            <ul class="breadcrumb">
                                <li><strong>
                                    <asp:LinkButton OnCommand="lBtnProjectMore_Command" runat="Server" ID="lBtnProjectMore" CommandName="more" CausesValidation="false"
                                        Text="项目管理"></asp:LinkButton>
                                </strong></li>
                            </ul>
                            <table class="table table-striped table-bordered table-condensed">
                                <tr>
                                    <td>
                                        项目名称
                                    </td>
                                    <td>
                                        客户名称
                                    </td>
                                    <td>
                                        开始时间
                                    </td>
                                </tr>
                                <asp:Repeater runat="Server" ID="rpProject">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="../project/projectInfo.aspx?projectNum=<%#Eval("ProjectNum") %>">
                                                    <asp:Label runat="Server" ID="lblRpProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label></a>
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
                        </td>
                        <td style="width: 60%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
