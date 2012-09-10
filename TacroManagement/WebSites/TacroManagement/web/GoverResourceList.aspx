<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="GoverResourceList.aspx.cs" Inherits="web_GoverResourceList" Title="政府资源列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="政府资源列表"></asp:Label>
    </div>
    <table>
    <tr>
    <td>
        <asp:Label ID="lblManager" runat="server" Text="负责人"/>
    </td>
        <td>
        <asp:TextBox ID="txtManager" runat="server" />
    </td>
    </tr>
        <tr>
    <td>
        <asp:Label ID="lblCity" runat="server" Text="城市"/>
    </td>
        <td>
        <asp:TextBox ID="txtCity" runat="server" />
    </td>
    </tr>
        <tr>
    <td>
        <asp:Label ID="lblOrganName" runat="server" Text="机构名称"/>
    </td>
        <td>
        <asp:TextBox ID="txtOrganName" runat="server" />
    </td>
    </tr>
        <tr>
    <td>
        <asp:Label ID="lblContactName" runat="server" Text="联系人姓名"/>
    </td>
        <td>
        <asp:TextBox ID="txtContactName" runat="server" />
    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="Query_GoverResource"/>
    </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GoverResourceGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
        AutoGenerateColumns="False" OnRowEditing="GoverResourceGridView_RowEditing" DataKeyNames="政府资源ID"
        OnRowDeleting="GoverResourceGridView_RowDeleting" AllowPaging="True" ShowFooter="false"
        OnRowDataBound="GoverResourceGridView_RowDataBound" OnRowCommand="GoverResourceGridView_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="序号" ReadOnly="True" />
            <asp:BoundField DataField="负责人姓名" HeaderText="负责人姓名" ReadOnly="True" />
            <asp:BoundField DataField="城市" HeaderText="城市" ReadOnly="True" />
            <asp:BoundField DataField="组织名称" HeaderText="组织名称" ReadOnly="True" />
            <asp:BoundField DataField="组织简介" HeaderText="组织简介" ReadOnly="True" />
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
    <asp:Button ID="addGoverResource" Text="添加政府资源" runat="server" OnClick="Add_GoverResource" />
    <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton>
    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton>
    跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    页
</asp:Content>
