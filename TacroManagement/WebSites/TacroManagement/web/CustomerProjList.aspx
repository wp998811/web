<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerProjList.aspx.cs" Inherits="web_CustomerProjList" Title="客户项目列表" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" width="100%">
        <ul class="breadcrumb">
            <li class="active">
                <asp:Label ID="Label1" runat="Server" Text="客户项目管理"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label3" runat="Server" Text=""></asp:Label></li>
        </ul>
        <div class="modal hide fade" id="myModal">
            <div class="modal-header">
                <a class="close" data-dismiss="modal">×</a>
                <h3>
                    查询客户项目</h3>
            </div>
            <div class="modal-body" style="margin: 0px auto">
            <div class="row" style="align: middle">
                <form class="form-horizontal">
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        负责人</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtManager"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        城市</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCity"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        客户类型</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCustomerType"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        项目类型</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtProjectType"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        项目进程</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtProgress"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        客户名称</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtCustomerName"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        服务项目</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtService"></asp:TextBox>
                    </div>
                </div>
                <div class="form-horizontal control-group">
                    <label class="control-label">
                        产品类型</label>
                    <div class="controls">
                        <asp:TextBox runat="Server" ID="txtProductType"></asp:TextBox>
                    </div>
                </div>
                </form>
            </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton class="btn btn-primary" ID="lbtnQueryCustomerProj" runat="Server" CommandName="add"  OnClick="Query_CustomerProject"
                    CausesValidation="false" Text="确定"></asp:LinkButton>
                <a data-dismiss="modal" href="#" class="btn">关闭</a>
            </div>
        </div>
        <div width="100%">
            <span><strong>客户项目信息</strong> </span>
            <i class="icon-plus-sign"></i><a href="AddCustomerProj.aspx">添加</a>
            <i class="icon-search"></i><a  data-toggle="modal" href="#myModal" data-keyboard="false" data-backdrop="false">搜索</a>
        </div>
        <div width="100%">
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            <strong>城市</strong>
                        </td>
                        <td align="center">
                            <strong>客户类型</strong>
                        </td>
                        <td align="center">
                            <strong>客户名称</strong>
                        </td>
                        <td align="center">
                            <strong>产品名称</strong>
                        </td>
                        <td align="center">
                            <strong>服务项目</strong>
                        </td>
                        <td align="center">
                            <strong>项目进程</strong>
                        </td>
                        <td align="center">
                            <strong>产品类别</strong>
                        </td>
                        <td align="center">
                            <strong>项目类型</strong>
                        </td>
                        <td align="center">
                            <strong>合同金额</strong>
                        </td>
                        <td align="center">
                            <strong>付款方式</strong>
                        </td>
                        <td align="center">
                            <strong>付款情况</strong>
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpCustomerProjList" OnItemCommand="rpCustomerProjList_ItemCommand">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCity" Text='<%#Eval("城市") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCustomerType" Text='<%#Eval("客户类型") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCustomerName" Text='<%#Eval("客户名称") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpProductName" Text='<%#Eval("产品名称") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpService" Text='<%#Eval("服务项目") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpProgress" Text='<%#Eval("项目进程") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpProductType" Text='<%#Eval("产品类别") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpProjectType" Text='<%#Eval("项目类型") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpContractAmount" Text='<%#Eval("合同金额") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpPayment" Text='<%#Eval("付款方式") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpPayState" Text='<%#Eval("付款情况") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton runat="Server" ID="lbtnRpDetail" CommandName="detail" Text="详细" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户项目ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户项目ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                        CommandArgument='<%#Eval("客户项目ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="height: 20px; text-align: center;">
                    <webdiyer:aspnetpager id="CustomerProjPager" runat="server" alwaysshow="True" buttonimagealign="Middle"
                        cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                        custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                        inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                        numericbuttontextformatstring="[{0}]" onpagechanged="CustomerProj_PageChanged" pagesize="5"
                        prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True" tooltip="分页"
                        custominfotextalign="NotSet">
                    </webdiyer:aspnetpager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
