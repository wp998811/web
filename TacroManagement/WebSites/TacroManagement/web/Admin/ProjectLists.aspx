<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectLists.aspx.cs" Inherits="web_Admin_ProjectLists" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
            项目管理 > 项目列表</h3>
        <div style="width: 1000px; margin: 0 auto;">
            <div style="border-bottom: 2px solid gray; height: 20px;">
                <div style="float: left; width: 150px; text-align: center;">
                    项目代号
                </div>
                <div style="float: left; width: 150px; text-align: center;">
                    项目名称
                </div>
                <div style="float: left; width: 150px; text-align: center;">
                    项目管理人员
                </div>
                <div style="float: left; width: 100px; text-align: center;">
                    项目类型
                </div>
                <div style="float: left; width: 150px; text-align: center;">
                    客户
                </div>
                <div style="float: left; width: 100px; text-align: center;">
                    开始时间
                </div>
                <div style="float: left; width: 100px; text-align: center;">
                    结束时间
                </div>
            </div>
            <asp:DataList ID="dlProject" runat="server" Width="1000px" OnDeleteCommand="dlProject_DeleteCommand">
                <ItemTemplate>
                    <div style="border-bottom: 1px dashed gray; width: 1000px;">
                        <div style="float: left; text-align: center;">
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblProjectNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectNum")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblProjectName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectName")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblProjectAdmin" runat="server" Text='<%# GetAdminName(Eval("ProjectAdminID").ToString())%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblProjectType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectType")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 150px; text-align: center;">
                            <asp:Label ID="lblProjectClientName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectClientName")%>'></asp:Label>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblBeginTime" runat="server" Text='<%# FormatDate(Eval("BeginTime").ToString()) %>'></asp:Label>
                        </div>
                        <div style="float: left; width: 100px; text-align: center;">
                            <asp:Label ID="lblEndTime" runat="server" Text='<%# FormatDate(Eval("EndTime").ToString()) %>'></asp:Label>
                        </div>
                        <div style="float: left; width: 50px; text-align: center;">
                            <a href='EditProject.aspx?projectNum=<%# DataBinder.Eval(Container.DataItem, "ProjectNum")%>'>
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
