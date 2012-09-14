<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyCustomer.aspx.cs" Inherits="web_ModifyCustomer" Title="编辑客户" %>
    
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top: 10px">
    </div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <ul class="breadcrumb">
                <li>
                    <a href="CustomerList.aspx">客户管理</a> <span class="divider">/</span>
                </li>
                <li class="active">
                    <asp:Label runat="Server" Text="编辑客户"></asp:Label></li>
            </ul>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    客户名称
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtCustomerName"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    负责人
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtManager" onfocus="$('#myModal').modal({backdrop:false, keyboard:true,show:true})"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtManager"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="controls">
                    <asp:TextBox ID="txtHiddenUserID" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>
                            修改项目负责人</h3>
                    </div>
                    <div class="modal-body" style="margin: 0px auto">
                        <asp:DropDownList runat="server" ID="ddlUser">
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-primary" ID="lbtnSelectUser" runat="Server" CommandName="select"
                            CausesValidation="false" Text="确定" OnCommand="lbtnSelectUser_Command"></asp:LinkButton>
                        <a data-dismiss="modal" href="#" class="btn">关闭</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    所在城市
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtCity"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    客户类别
                </label>
                <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlCustomerType">
                    </asp:DropDownList>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ddlCustomerType"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    级别
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtCustomerRank"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCustomerRank"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    产品范围
                </label>
                <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlProductRange">
                    </asp:DropDownList>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="ddlProductRange"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    税务登记号
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtTaxID"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTaxID"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    组织机构代码
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtOrganCode"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtOrganCode"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div width="100%">
                <span><strong>客户联系人信息</strong> </span><i class="icon-plus-sign"></i><a href="AddCustomerContact.aspx?customerID=<%=customerID %>">
                    添加</a>
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
                    <td align="center">
                    </td>
                </tr>
                <asp:Repeater runat="Server" ID="rpContactList" OnItemCommand="rpContactList_ItemCommand">
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
                            <td align="center">
                                <asp:LinkButton runat="Server" ID="lbtnRpAddVisitRecord" CommandName="addVisitRecord" Text="添加拜访记录" CausesValidation="false"
                                    CommandArgument='<%#Eval("联系人ID") %>'></asp:LinkButton>
                                <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                    CommandArgument='<%#Eval("联系人ID") %>'></asp:LinkButton>
                                <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                    CommandArgument='<%#Eval("联系人ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div style="height: 20px; text-align: center;">
                <webdiyer:AspNetPager ID="ContactPager" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                    CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                    CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                    InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                    NumericButtonTextFormatString="[{0}]" OnPageChanged="Contact_PageChanged" PageSize="5"
                    PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True" ToolTip="分页"
                    CustomInfoTextAlign="NotSet">
                </webdiyer:AspNetPager>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addCustomer" Text="确定" runat="server" OnClick="ModifyContact" />
                    <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" OnClick="Abort"/>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
