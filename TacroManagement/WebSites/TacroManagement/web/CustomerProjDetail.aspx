<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerProjDetail.aspx.cs" Inherits="web_CustomerProjDetail" Title="详细客户项目信息" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="CustomerProjList.aspx">客户项目管理</a> <span class="divider">/</span> </li>
            <li class="active">
                <asp:Label runat="Server" Text="客户项目信息"></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>客户项目信息</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0"
            cellpadding="0" border="0">
            <tr>
                <td>
                    <strong>客户名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblCustomerName" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>服务项目</strong>
                </td>
                <td>
                    <asp:Label ID="lblService" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>项目进程</strong>
                </td>
                <td>
                    <asp:Label ID="lblProgress" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>产品名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblProductName" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>项目类型</strong>
                </td>
                <td>
                    <asp:Label ID="lblProjectType" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>合同金额</strong>
                </td>
                <td>
                    <asp:Label ID="lblContractAmount" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>付款方式</strong>
                </td>
                <td>
                    <asp:Label ID="lblPayment" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>付款情况</strong>
                </td>
                <td>
                    <asp:Label ID="lblPayState" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div width="100%">
            <div width="100%">
                <span><strong>客户名称</strong> </span>
            </div>
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
                    </tr>
                    <asp:Repeater runat="Server" ID="rpCustomerList">
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
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div width="100%">
                <span><strong>客户联系人</strong> </span>
            </div>
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
                            <strong>职位</strong>
                        </td>
                        <td align="center">
                            <strong>手机</strong>
                        </td>
                        <td align="center">
                            <strong>固定电话</strong>
                        </td>
                        <td align="center">
                            <strong>邮箱</strong>
                        </td>
                        <td align="center">
                            <strong>地址</strong>
                        </td>
                        <td align="center">
                            <strong>邮编</strong>
                        </td>
                        <td align="center">
                            <strong>传真号</strong>
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpContactList">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpContactName" Text='<%#Eval("联系人姓名") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpPosition" Text='<%#Eval("职位") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpMobilephone" Text='<%#Eval("手机") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpTelephone" Text='<%#Eval("固定电话") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpEmail" Text='<%#Eval("邮箱") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpAddress" Text='<%#Eval("地址") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblPostCode" Text='<%#Eval("邮编") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblFaxNumber" Text='<%#Eval("传真号") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="height: 20px; text-align: center;">
                    <webdiyer:aspnetpager id="ContactPager" runat="server" alwaysshow="True" buttonimagealign="Middle"
                        cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                        custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                        inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                        numericbuttontextformatstring="[{0}]" onpagechanged="Contact_PageChanged" pagesize="5"
                        prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True" tooltip="分页"
                        custominfotextalign="NotSet">
                    </webdiyer:aspnetpager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
