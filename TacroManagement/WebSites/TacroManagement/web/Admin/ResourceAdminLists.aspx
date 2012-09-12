<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceAdminLists.aspx.cs" Inherits="web_Admin_ResourceAdminLists" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源管理列表</title>
</head>
<body>
    <form id="form1" runat="server">
  <div>
        <h3>
            资源管理 > 资源管理列表</h3>
        <div style="width: 400px; margin: 0 auto;">
            <div style="border-bottom: 2px solid gray; height: 20px;">
                <div style="float: left; width: 150px; text-align: center;">
                    资源类型
                </div>
                <div style="float: left; width: 150px; text-align: center;">
                    管理人员
                </div>
            </div>
            <asp:DataList ID="dlResourceAdmin" runat="server" Width="400px" OnDeleteCommand="dlResourceAdmin_DeleteCommand">
                <ItemTemplate>
                    <div style="border-bottom: 1px dashed gray; width: 400px;">
                       <div style="float: left; text-align: center;">
                            <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                Visible="false"></asp:Label></a>
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblResourceType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceType")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblUserID" runat="server" Text='<%#GetUserName(Eval("UserID").ToString())%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 50px; text-align: center;">
                            <a href='EditResourceAdmin.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>'>
                                <asp:Label ID="lblEditProject" Text="编辑" runat="server">
                                </asp:Label>
                            </a>
                        </div>
                        <div style="float: left; width: 50px; text-align: center;">
                            <asp:LinkButton ID="lbDeleteProject" Text="删除" CommandName="Delete" runat="server" OnClientClick="return confirm('确定删除吗？')"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
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
    </form>
</body>
</html>
