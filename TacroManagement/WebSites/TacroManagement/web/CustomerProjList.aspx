<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerProjList.aspx.cs" Inherits="web_CustomerProjList" Title="客户项目列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="客户项目列表"></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblManager" runat="server" Text="负责人" />
            </td>
            <td>
                <asp:TextBox ID="txtManager" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="城市" />
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomerType" runat="server" Text="客户类型" />
            </td>
            <td>
                <asp:TextBox ID="txtCustomerType" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProjectType" runat="server" Text="项目类型" />
            </td>
            <td>
                <asp:TextBox ID="txtProjectType" runat="server" />
            </td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="lblProgress" runat="server" Text="项目进程" />
            </td>
            <td>
                <asp:TextBox ID="txtProgress" runat="server" />
            </td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="lblCustomerName" runat="server" Text="客户名称" />
            </td>
            <td>
                <asp:TextBox ID="txtCustomerName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblService" runat="server" Text="服务项目" />
            </td>
            <td>
                <asp:TextBox ID="txtService" runat="server" />
            </td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="lblProductName" runat="server" Text="产品类型" />
            </td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" />
            </td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="lblContactName" runat="server" Text="联系人姓名" />
            </td>
            <td>
                <asp:TextBox ID="txtContactName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="Query_CustomerProject" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="CustomerProjGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" OnRowEditing="CustomerProjGridView_RowEditing" DataKeyNames="客户项目ID"
                    OnRowDeleting="CustomerProjGridView_RowDeleting" AllowPaging="True" ShowFooter="false"
                    OnRowDataBound="CustomerProjGridView_RowDataBound" OnRowCommand="CustomerProjGridView_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="序号" ReadOnly="True" />
                        <asp:BoundField DataField="城市" HeaderText="城市" ReadOnly="True" />
                        <asp:BoundField DataField="客户类型" HeaderText="客户类型" ReadOnly="True" />
                        <asp:BoundField DataField="客户名称" HeaderText="客户名称" ReadOnly="True" />
                        <asp:BoundField DataField="产品名称" HeaderText="产品名称" ReadOnly="True" />
                        <asp:BoundField DataField="服务项目" HeaderText="服务项目" ReadOnly="True" />
                        <asp:BoundField DataField="项目进程" HeaderText="项目进程" ReadOnly="True" />
                        <asp:BoundField DataField="产品类别" HeaderText="产品类别" ReadOnly="True" />
                        <asp:BoundField DataField="项目类型" HeaderText="项目类型" ReadOnly="True" />
                        <asp:BoundField DataField="合同金额" HeaderText="合同金额" ReadOnly="True" />
                        <asp:BoundField DataField="付款方式" HeaderText="付款方式" ReadOnly="True" />
                        <asp:BoundField DataField="付款情况" HeaderText="付款情况" ReadOnly="True" />
                        <asp:BoundField DataField="税务登记号" HeaderText="税务登记号" ReadOnly="True" />
                        <asp:BoundField DataField="组织机构代码" HeaderText="组织机构代码" ReadOnly="True" />
                        <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="button_detail" runat="server" Text="详细" CommandName="Detail"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="button_delete" runat="server" OnClientClick="return confirm('确定删除？')"
                                    CommandName="Delete" Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="White" ForeColor="#66FFCC" HorizontalAlign="Center" BorderStyle="None"
                        Wrap="False" />
                    <PagerSettings Visible="False" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Button ID="addCustomerProj" Text="添加客户项目" runat="server" OnClick="Add_CustomerProj" />
    <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton>
    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton>
    跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    页
</asp:Content>
