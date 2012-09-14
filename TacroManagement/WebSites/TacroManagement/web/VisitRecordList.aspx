<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="VisitRecordList.aspx.cs" Inherits="web_VisitRecordList" Title="拜访记录列表" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
 <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li class="active"><asp:Label ID="Label2" runat="Server" Text="拜访记录管理"></asp:Label> </li>
            <li>
                <asp:Label ID="lblProjectName" runat="Server" Text=""></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>拜访记录信息</strong> </span>
        </div>
        <div width="100%">
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            <strong>联系人姓名</strong>
                        </td>
                        <td align="center">
                            <strong>地址</strong>
                        </td>
                        <td align="center">
                            <strong>手机</strong>
                        </td>
                        <td align="center">
                            <strong>拜访时间</strong>
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpVisitRecordList" OnItemCommand="rpVisitRecordList_ItemCommand">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpContactName" Text='<%#Eval("联系人姓名") %>'></asp:Label>
                                </td>
                                 <td align="center">
                                    <asp:Label runat="Server" ID="Label1" Text='<%#Eval("地址") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpMobilephone" Text='<%#Eval("手机") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpVisitRecord" Text='<%#Eval("拜访时间") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton runat="Server" ID="lbtnRpDetail" CommandName="detail" Text="详细" CausesValidation="false"
                                        CommandArgument='<%#Eval("拜访记录ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                        CommandArgument='<%#Eval("拜访记录ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                        CommandArgument='<%#Eval("拜访记录ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="height: 20px; text-align: center;">
                    <webdiyer:AspNetPager ID="VisitRecordPager" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                        CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                        CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                        InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                        NumericButtonTextFormatString="[{0}]" OnPageChanged="VisitRecord_PageChanged" PageSize="5"
                        PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True" ToolTip="分页"
                        CustomInfoTextAlign="NotSet">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
