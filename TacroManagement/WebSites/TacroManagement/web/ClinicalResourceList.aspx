<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ClinicalResourceList.aspx.cs" Inherits="web_ClinicalResourceList" Title="临床资源管理" %>

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
            <li class="active">
                <asp:Label ID="Label2" runat="Server" Text="临床资源管理"></asp:Label>
            </li>
            <li>
                <asp:Label runat="Server" Text=""></asp:Label></li>
        </ul>
        <div class="modal hide fade" id="myModal">
            <div class="modal-header">
                <a class="close" data-dismiss="modal">×</a>
                <h3>查询临床资源</h3>
            </div>
            <div class="modal-body" style="margin: 0px auto">
                <div class="row" style="align: middle">
                    <form class="form-horizontal">
                    <div class="form-horizontal control-group">
                        <label class="control-label" id="lblManager" runat="Server">
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
                            医院名称</label>
                        <div class="controls">
                            <asp:TextBox runat="Server" ID="txtHospital"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-horizontal control-group">
                        <label class="control-label">
                            科室名称</label>
                        <div class="controls">
                            <asp:TextBox runat="Server" ID="txtDepartmentName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-horizontal control-group">
                        <label class="control-label">
                            联系人姓名</label>
                        <div class="controls">
                            <asp:TextBox runat="Server" ID="txtContactName"></asp:TextBox>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton class="btn btn-primary" ID="lbtnQueryCustomerProj" runat="Server"
                    CommandName="add" OnClick="Query_ClinicalResource" CausesValidation="false" Text="确定"></asp:LinkButton>
                <a data-dismiss="modal" href="#" class="btn">关闭</a>
            </div>
        </div>
        <div width="100%">
            <span><strong>临床资源信息</strong> </span><i   runat="Server" id="icon" class="icon-plus-sign"></i><a  id="hrefAdd" runat="Server" href="AddClinicalResource.aspx">
                添加</a> <i class="icon-search"></i><a data-toggle="modal" href="#myModal" data-keyboard="false"
                    data-backdrop="false">搜索</a>
        </div>
        <div width="100%">
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            <strong>负责人</strong>
                        </td>
                        <td align="center">
                            <strong>城市</strong>
                        </td>
                        <td align="center">
                            <strong>医院名称</strong>
                        </td>
                        <td align="center">
                            <strong>科室名称</strong>
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpClinicalResourceList" OnItemCommand="rpClinicalResourceList_ItemCommand" OnItemDataBound="ClinicalResourceRepeater_ItemDataBound">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpManager" Text='<%#Eval("负责人姓名") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpCity" Text='<%#Eval("城市") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpHospital" Text='<%#Eval("医院名称") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpDepartmentName" Text='<%#Eval("科室名称") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton runat="Server" ID="lbtnRpDetail" CommandName="detail" Text="详细" CausesValidation="false"
                                        CommandArgument='<%#Eval("临床资源ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                        CommandArgument='<%#Eval("临床资源ID") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                        CommandArgument='<%#Eval("临床资源ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="height: 20px; text-align: center;">
                   <webdiyer:AspNetPager ID="ClinicalResourcePager" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                        CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                        CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                        InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                        NumericButtonTextFormatString="[{0}]" OnPageChanged="ClinicalResource_PageChanged" PageSize="5"
                        PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True" ToolTip="分页"
                        CustomInfoTextAlign="NotSet">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
