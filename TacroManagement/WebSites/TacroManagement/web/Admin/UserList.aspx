<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="web_Admin_UserList" %>

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
            <li><span class="divider">用户管理/用户信息</span> </li>
        </ul>
        <div width="100%">
            <span><strong>用户列表</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    用户名
                </td>
                <td>
                    用户密码
                </td>
                <td>
                    用户类别
                </td>
                <td>
                    用户邮箱
                </td>
                <td>
                    用户电话
                </td>
                <td>
                    所属部门
                </td>
                <td>
                  
                </td>
            </tr>
            <asp:Repeater ID="dlUser" runat="Server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblUserName" Text='<%#Eval("UserName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblPassword" Text='<%#Eval("Password") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblUserType" Text='<%#Eval("UserType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblUserEmail" Text='<%#Eval("UserEmail") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblUserPhone" Text='<%#Eval("UserPhone") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblDepartment" Text='<%# GetDepartName(Eval("DepartID").ToString())%>'></asp:Label>
                        </td>
                        <td>
                            <a href='ModifyUser.aspx?userId=<%# DataBinder.Eval(Container.DataItem, "UserID")%>'>
                                <asp:Label ID="lblEditUser" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                            <asp:LinkButton OnCommand="lbDeleteUser_Command" ID="lbDeleteUser" runat="Server"
                                OnClientClick="return confirm('确定删除？');" CausesValidation="false" Text="删除" CommandName="del"
                                CommandArgument='<%# Eval("UserID") %>'></asp:LinkButton>
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
