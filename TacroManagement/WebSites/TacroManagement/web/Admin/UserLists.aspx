<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLists.aspx.cs" Inherits="web_Admin_UserLists" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
            用户管理 > 用户信息</h3>
        <div style="width: 800px; margin: 0 auto;">
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
            </div>
            <asp:DataList ID="dlUser" runat="server" Width="599px" OnDeleteCommand="dlUser_DeleteCommand">
                <ItemTemplate>
                    <div style="border-bottom: 1px dashed gray; width: 800px;">
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
                        <div style="float: left; width: 50px; text-align: center;">
                            <a href='EditUser.aspx?userId=<%# DataBinder.Eval(Container.DataItem, "UserID")%>'>
                                <asp:Label ID="lblEditUser" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                        </div>
                        <div style="float: left; width: 50px; text-align: center;">
                            <asp:LinkButton ID="lbDeleteUser" Text="删除" CommandName="Delete" runat="server"></asp:LinkButton>
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
    </form>
</body>
</html>
