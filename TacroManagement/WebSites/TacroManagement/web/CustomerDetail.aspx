<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="CustomerDetail.aspx.cs" Inherits="web_CustomerDetail"  Title="详细客户信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="客户详细信息"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td><asp:label id="label_customerName1" runat="server" Text="客户名称"/></td>
    		<td><asp:label id="label_customerName2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_customerManager1" runat="server" Text="客户负责人"/></td>
    		<td><asp:label id="label_customerManager2" runat="server"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_city1" runat="server" Text="所在城市"/></td>
    		<td><asp:label id="label_city2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_clientType1" runat="server" Text="客户类别"/></td>
    		<td><asp:label id="label_clientType2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_level1" runat="server" Text="级别"/></td>
    		<td><asp:label id="label_level2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_productRange1" runat="server" Text="产品范围"/></td>
    		<td><asp:label id="label_productRange2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_taxID1" runat="server" Text="税务登记号"/></td>
    		<td><asp:label id="label_taxID2" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_organCode1" runat="server" Text="组织机构代码"/></td>
    		<td><asp:label id="label_organCode2" runat="server" /></td>
    	</tr>
    	</table>
        <asp:GridView ID="ContactGridView" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
        datakeynames="联系人ID" AllowPaging="True" ShowFooter="false" 
        onrowdatabound="ContactGridView_RowDataBound">
        <Columns>
            <asp:BoundField  HeaderText="序号" ReadOnly="True" />
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
        <PagerStyle BackColor="White" ForeColor="#66FFCC" HorizontalAlign="Center" 
                BorderStyle="None" Wrap="False" />
                <PagerSettings Visible="False" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
                <asp:LinkButton ID="label_ContactFirstPage" runat="server" OnClick="Contact_FirstPage_Click">首页</asp:LinkButton>
                <asp:LinkButton ID="label_ContactPrePage" runat="server" OnClick="Contact_PrePage_Click">上一页</asp:LinkButton>
                <asp:Label ID="label_Contact_CurrentPage" runat="server"></asp:Label>
                <asp:LinkButton ID="label_ContactNextPage" runat="server" OnClick="Contact_NextPage_Click">下一页</asp:LinkButton>
                <asp:LinkButton ID="label_ContactLastPage" runat="server" OnClick="Contact_LastPage_Click">尾页</asp:LinkButton>
                <asp:Label ID="label_ContactGoto" runat="server" Text="跳转到第" />
                <asp:DropDownList ID="ddl_ContactPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Contact_DropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="label_ContactPage" runat="server" Text="页" />
</asp:Content>
