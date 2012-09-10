<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerProjDetail.aspx.cs" Inherits="web_CustomerProjDetail" Title="详细客户项目信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="详细客户项目信息"></asp:Label>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="label_customerName1" runat="server" Text="客户名称" />
            </td>
            <td>
                <asp:Label ID="label_customerName2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="CustomerGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" DataKeyNames="客户ID" AllowPaging="True" ShowFooter="false">
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
        <tr>
            <td>
                <asp:Label ID="label_service1" runat="server" Text="服务项目" />
            </td>
            <td>
                <asp:Label ID="label_service2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_progress1" runat="server" Text="项目进程" />
            </td>
            <td>
                <asp:Label ID="label_progress2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_productName1" runat="server" Text="产品名称" />
            </td>
            <td>
                <asp:Label ID="label_productName2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_projectType1" runat="server" Text="项目类型" />
            </td>
            <td>
                <asp:Label ID="label_projectType2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_contractAmount1" runat="server" Text="合同金额" />
            </td>
            <td>
                <asp:Label ID="label_contractAmount2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_payment1" runat="server" Text="付款方式" />
            </td>
            <td>
                <asp:Label ID="label_payment2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_payState1" runat="server" Text="付款情况" />
            </td>
            <td>
                <asp:Label ID="label_payState2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_contactName1" runat="server" Text="联系人姓名" />
            </td>
            <td>
                <asp:Label ID="label_contactName2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="ContactGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" DataKeyNames="联系人ID" AllowPaging="True" ShowFooter="false">
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
            </td>
        </tr>
    </table>
</asp:Content>
