<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyCustomerProject.aspx.cs" Inherits="web_ModifyCustomerProjContact"
    Title="修改客户项目" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="修改客户项目"></asp:Label>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="label_customerName" runat="server" Text="客户名称" />
            </td>
            <td>
                <asp:TextBox ID="textBox_customerName" runat="server" />
            </td>
            <td>
                <asp:Button ID="select_customer" Text="选择客户" runat="server" OnClick="Select_Customer" />
            </td>
            <asp:TextBox ID="CustomerID_TextBox" runat="server" Visible="false"></asp:TextBox>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="CustomerGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" DataKeyNames="客户ID" AllowPaging="True" ShowFooter="false"
                    Visible="False">
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
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="Customer_CheckBox" runat="server" OnCheckedChanged="CustomerCheckBoxChanged"
                                    AutoPostBack="True" />
                                <asp:TextBox ID="Customer_TextBox" runat="server" Text='<%# Eval("客户ID") %>' Visible="false"></asp:TextBox>
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
            <td>
                <asp:Button ID="Customer_Hidden" Text="收起" runat="server" OnClick="CustomerList_Hidden"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_service" runat="server" Text="服务项目" />
            </td>
            <td>
                <asp:TextBox ID="textBox_service" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_progress" runat="server" Text="项目进程" />
            </td>
            <td>
                <asp:DropDownList ID="ddl_progress" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_productName" runat="server" Text="产品名称" />
            </td>
            <td>
                <asp:TextBox ID="textBox_productName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_projectType" runat="server" Text="项目类型" />
            </td>
            <td>
                <asp:TextBox ID="textBox_projectType" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_contractAmount" runat="server" Text="合同金额" />
            </td>
            <td>
                <asp:TextBox ID="textBox_contractAmount" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_payment" runat="server" Text="付款方式" />
            </td>
            <td>
                <asp:TextBox ID="textBox_payment" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_payState" runat="server" Text="付款情况" />
            </td>
            <td>
                <asp:DropDownList ID="ddl_payState" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_contactName" runat="server" Text="联系人姓名" />
            </td>
            <td>
                <asp:Button ID="button_selectContact" Text="查看" runat="server" OnClick="Select_Contact" />
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
            <td>
                <asp:Button ID="Contact_Hidden" Text="收起" runat="server" OnClick="ContactList_Hidden"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="modifyCustomerProj" Text="修改客户项目" runat="server" OnClick="Modify_CustomerProj" />
            </td>
        </tr>
    </table>
</asp:Content>
