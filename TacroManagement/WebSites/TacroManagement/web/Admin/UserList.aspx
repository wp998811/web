<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="web_Admin_UserList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div>
        <h3>
            用户管理 > 用户列表</h3>
        <div style="width: 1000px; margin: 0 auto;">
            <div style="border-bottom: 2px solid gray; height: 20px;">
                <div style="float: left; width: 100px; text-align: center;">
                    用户名
                </div>
                <div style="float: left; width: 100px; text-align: center;">
                    用户密码
                </div>
                <div style="float: left; width: 100px; text-align: center;">
                    用户类别
                </div>
                <div style="float: left; width: 200px; text-align: center;">
                    用户邮箱
                </div>
                <div style="float: left; width: 200px; text-align: center;">
                    用户电话
                </div>
                <div style="float: left; width: 200px; text-align: center;">
                    所属部门
                </div>
            </div>
            <asp:DataList ID="dlUser" runat="server" Width="1000px" OnDeleteCommand="dlUser_DeleteCommand">
                <ItemTemplate>
                    <div style="border-bottom: 1px dashed gray; width: 1000px;">
                        <div style="float: left; text-align: center;">
                            <asp:Label ID="lblUserID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID")%>'
                                Visible="false"></asp:Label></a>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblUserName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblPassword" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Password")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblUserType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserType")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 200px; text-align: center;">
                            <asp:Label ID="lblUserEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserEmail")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 200px; text-align: center;">
                            <asp:Label ID="lblUserPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserPhone")%>'></asp:Label>
                        </div>
                        
                        <div style="float: left; width: 200px; text-align: center;">
                            <asp:Label ID="lblDepartment" runat="server" Text='<%# GetDepartName(Eval("DepartID").ToString())%>'></asp:Label>
                        </div>
                        
                        <div style="float: left; width: 50px; text-align: center;">
                            <a href='ModifyUser.aspx?userId=<%# DataBinder.Eval(Container.DataItem, "UserID")%>'>
                                <asp:Label ID="lblEditUser" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                        </div>
                        <div style="float: left; width: 50px; text-align: center;">
                            <asp:LinkButton ID="lbDeleteUser" Text="删除" CommandName="Delete" runat="server" OnClientClick="return confirm('确定删除吗？')"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
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

