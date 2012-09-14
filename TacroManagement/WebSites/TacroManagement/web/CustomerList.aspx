<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerList.aspx.cs" Inherits="web_CustomerList" Title="客户列表" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li class="active"><asp:Label runat="Server" Text="客户管理"></asp:Label> </li>
            <li>
                <asp:Label ID="lblProjectName" runat="Server" Text=""></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>客户信息</strong> </span><i class="icon-plus-sign"></i><a href="AddCustomer.aspx">
                添加</a>
        </div>
        <div width="100%">
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            <strong>客户名称</strong>
                        </td>
                        <td align="center">
                            <strong>客户负责人</strong>
                        </td>
                        <td align="center">
                            <strong>所在城市</strong>
                        </td>
                        <td align="center">
                            <strong>客户类别</strong>
                        </td>
                        <td align="center">
                            <strong>级别</strong>
                        </td>
                        <td align="center">
                            <strong>产品范围</strong>
                        </td>
                        <td align="center">
                            <strong>税务登记号</strong>
                        </td>
                        <td align="center">
                            <strong>组织机构代码</strong>
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpCustomerList" OnItemCommand="rpCustomerList_ItemCommand"  OnItemDataBound="rpCustomerList_ItemDataBound">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCustomerName" Text='<%#Eval("客户名称") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpManager" Text='<%#Eval("客户负责人") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCity" Text='<%#Eval("所在城市") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCustomerType" Text='<%#Eval("客户类别") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpPosition" Text='<%#Eval("级别") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpProductRange" Text='<%#Eval("产品范围") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpTaxID" Text='<%#Eval("税务登记号") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblOrganCode" Text='<%#Eval("组织机构代码") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton runat="Server" ID="lbtnRpDetail" CommandName="detail" Text="详细" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="height: 20px; text-align: center;">
                    <webdiyer:AspNetPager ID="CustomerPager" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                        CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                        CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                        InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                        NumericButtonTextFormatString="[{0}]" OnPageChanged="Customer_PageChanged" PageSize="5"
                        PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True" ToolTip="分页"
                        CustomInfoTextAlign="NotSet">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
