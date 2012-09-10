<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerList.aspx.cs" Inherits="web_CustomerList" Title="客户列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="客户列表"></asp:Label>
    </div>
    <asp:GridView ID="CustomerGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
        AutoGenerateColumns="False" OnRowEditing="CustomerGridView_RowEditing" DataKeyNames="客户ID"
        OnRowDeleting="CustomerGridView_RowDeleting" AllowPaging="True" ShowFooter="false"
        OnRowDataBound="CustomerGridView_RowDataBound" OnRowCommand="CustomerGridView_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="序号" ReadOnly="True" />
            <asp:BoundField DataField="客户名称" HeaderText="客户名称" ReadOnly="True" />
            <asp:BoundField DataField="客户负责人" HeaderText="客户负责人" ReadOnly="True" />
            <asp:BoundField DataField="所在城市" HeaderText="所在城市" ReadOnly="True" />
            <asp:BoundField DataField="客户类别" HeaderText="客户类别" ReadOnly="True" />
            <asp:BoundField DataField="级别" HeaderText="级别" ReadOnly="True" />
            <asp:BoundField DataField="产品范围" HeaderText="产品范围" ReadOnly="True" />
            <asp:BoundField DataField="税务登记号" HeaderText="税务登记号" ReadOnly="True" />
            <asp:BoundField DataField="组织机构代码" HeaderText="组织机构代码" ReadOnly="True" />
            <asp:TemplateField HeaderText="详细">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="详细" CommandName="Detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton runat="server" OnClientClick="return confirm('确定删除？')" CommandName="Delete"
                        Text="删除"></asp:LinkButton>
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
    <asp:LinkButton ID="label_CustomerFirstPage" runat="server" OnClick="Customer_FirstPage_Click">首页</asp:LinkButton>
    <asp:LinkButton ID="label_CustomerPrePage" runat="server" OnClick="Customer_PrePage_Click">上一页</asp:LinkButton>
    <asp:Label ID="label_Customer_CurrentPage" runat="server"></asp:Label>
    <asp:LinkButton ID="label_CustomerNextPage" runat="server" OnClick="Customer_NextPage_Click">下一页</asp:LinkButton>
    <asp:LinkButton ID="label_CustomerLastPage" runat="server" OnClick="Customer_LastPage_Click">尾页</asp:LinkButton>
    <asp:Label ID="label_CustomerGoto" runat="server" Text="跳转到第" />
    <asp:DropDownList ID="ddl_CustomerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Customer_DropDownList_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Label ID="label_CustomerPage" runat="server" Text="页" /> 
    <asp:Button ID="addCustomer" Text="添加客户" runat="server" OnClick="Add_Customer" />
</asp:Content>
