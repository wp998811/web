<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="ResourceAdminList.aspx.cs" Inherits="web_Admin_ResourceAdminList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><span class="divider">资源管理/信息</span> </li>
        </ul>
        <div width="100%">
            <span><strong>资源管理列表</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    资源类型
                </td>
                <td>
                    管理人员
                </td>
                <td>
                </td>
            </tr>
            <asp:Repeater ID="dlResourceAdmin" runat="Server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblResourceType" Text='<%#Eval("ResourceType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblUserID" Text='<%#GetUserName(Eval("UserID").ToString())%>'></asp:Label>
                        </td>
                        <td>
                            <a href='ModifyResourceAdmin.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>'>
                                <asp:Label ID="lblEditProject" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                            <asp:LinkButton OnCommand="lbDeleteRA_Command" ID="lbDeleteProject" runat="Server"
                                OnClientClick="return confirm('确定删除？');" CausesValidation="false" Text="删除" CommandName="del"
                                CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>





         
           
        <div style="height: 20px; text-align: center;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged"
                PageSize="5" PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True"
                ToolTip="分页" CustomInfoTextAlign="NotSet">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>

