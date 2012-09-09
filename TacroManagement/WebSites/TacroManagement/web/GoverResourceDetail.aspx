<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="GoverResourceDetail.aspx.cs" Inherits="web_GoverResourceDetail"
    Title="详细政府资源信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="详细政府资源信息"></asp:Label>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="label_manager1" runat="server" Text="负责人姓名" />
            </td>
            <td>
                <asp:Label ID="label_manager2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_city1" runat="server" Text="城市" />
            </td>
            <td>
                <asp:Label ID="label_city2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_organName1" runat="server" Text="组织名称" />
            </td>
            <td>
                <asp:Label ID="label_organName2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_organIntro1" runat="server" Text="组织简介" />
            </td>
            <td>
                <asp:Label ID="label_organIntro2" runat="server" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="ContactGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
        AutoGenerateColumns="False" DataKeyNames="联系人ID" AllowPaging="True" ShowFooter="false"
        OnRowDataBound="ContactGridView_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="序号" ReadOnly="True" />
            <asp:BoundField DataField="联系人姓名" HeaderText="联系人姓名" ReadOnly="True" />
            <asp:BoundField DataField="职位" HeaderText="职位" ReadOnly="True" />
            <asp:BoundField DataField="手机" HeaderText="手机" ReadOnly="True" />
            <asp:BoundField DataField="固定电话" HeaderText="固定电话" ReadOnly="True" />
            <asp:BoundField DataField="邮箱" HeaderText="邮箱" ReadOnly="True" />
            <asp:BoundField DataField="地址" HeaderText="地址" ReadOnly="True" />
            <asp:BoundField DataField="邮编" HeaderText="邮编" ReadOnly="True" />
            <asp:BoundField DataField="传真号" HeaderText="传真号" ReadOnly="True" />
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
    <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton>
    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton>
    跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    页
</asp:Content>


