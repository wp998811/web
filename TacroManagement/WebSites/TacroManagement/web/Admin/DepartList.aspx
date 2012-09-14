<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="DepartList.aspx.cs" Inherits="web_Admin_DepartList" %>

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
            <li><span class="divider">部门管理/部门信息</span> </li>
        </ul>
        <div width="100%">
            <span><strong>部门列表</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    部门名称
                </td>
                <td>
                    部门管理人员
                </td>
                <td>
                </td>
            </tr>
            <asp:Repeater ID="dlDepart" runat="Server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblDepartName" Text='<%#Eval("DepartName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblDepartAdmin" Text='<%#Eval("DepartAdmin") %>'></asp:Label>
                        </td>
                        <td>
                            <a href='ModifyDepart.aspx?departId=<%# DataBinder.Eval(Container.DataItem, "DepartID")%>'>
                                <asp:Label ID="lblEditDepart" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                            <asp:LinkButton OnCommand="lbDeleteDepart_Command" ID="lbDeleteDepart" runat="Server"
                                OnClientClick="return confirm('确定删除？');" CausesValidation="false" Text="删除" CommandName="del"
                                CommandArgument='<%# Eval("DepartID") %>'></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div style="height: 20px; text-align: center;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged"
                PageSize="5" PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True"
                ToolTip="分页" CustomInfoTextAlign="NotSet">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
