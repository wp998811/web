<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ProjectList.aspx.cs" Inherits="web_Admin_ProjectList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><span class="divider">项目管理/项目信息</span> </li>
        </ul>
        <div width="100%">
            <span><strong>项目列表</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    项目代号
                </td>
                <td>
                    项目名称
                </td>
                <td>
                    项目管理人员
                </td>
                <td>
                    项目类型
                </td>
                <td>
                    客户
                </td>
                <td>
                    开始时间
                </td>
                <td>
                    结束时间
                </td>
                <td>
                </td>
            </tr>
            <asp:Repeater ID="dlProject" runat="Server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectNum" Text='<%#Eval("ProjectNum") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectAdmin" Text='<%# GetAdminName(Eval("ProjectAdminID").ToString()) %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectType" Text='<%#Eval("ProjectType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectClientName" Text='<%#Eval("ProjectClientName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblBeginTime" Text='<%# FormatDate(Eval("BeginTime").ToString())%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblEndTime" Text='<%# FormatDate(Eval("EndTime").ToString())%>'></asp:Label>
                        </td>
                        <td>
                            <a href='ModifyProject.aspx?projectNum=<%# DataBinder.Eval(Container.DataItem, "ProjectNum")%>'>
                                <asp:Label ID="lblEditProject" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                            <asp:LinkButton OnCommand="lbDeleteProject_Command" ID="lbDeleteProject" runat="Server"
                                OnClientClick="return confirm('确定删除？');" CausesValidation="false" Text="删除" CommandName="del"
                                CommandArgument='<%# Eval("ProjectNum") %>'></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div style="height: 20px; text-align: center;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                CurrentPageButtonClass="p_num_currentPage" CustomInfoClass="" CustomInfoStyle=""
                FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False" InputBoxStyle="p_input"
                LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8" NumericButtonTextFormatString="[{0}]"
                OnPageChanged="AspNetPager1_PageChanged" PageSize="5" PrevPageText="[前一页]" ShowInputBox="Never"
                ShowNavigationToolTip="True" ToolTip="分页" CustomInfoTextAlign="NotSet">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
