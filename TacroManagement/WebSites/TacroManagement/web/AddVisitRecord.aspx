<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="AddVisitRecord.aspx.cs" Inherits="web_AddVisitRecord"  Title="添加拜访记录信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../script/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <div>
        <asp:Label ID="Label1" runat="server" Text="添加拜访记录信息"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
    		<td><asp:label id="label_customerName" runat="server" Text="客户名称"/></td>
    		<td><asp:TextBox id="textBox_customerName" runat="server"/></td>
    		<td><asp:Button id="select_customer" Text="选择客户" runat="server" OnClick="Select_Customer" /></td>
    		<asp:TextBox ID="CustomerID_TextBox" runat="server" Text='<%# Eval("客户ID") %>' Visible="false"></asp:TextBox>
    	</tr>
    	<tr>
    	<td>
        <asp:GridView ID="CustomerGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            AutoGenerateColumns="False" DataKeyNames="客户ID"
             AllowPaging="True" ShowFooter="false" Visible="False" >
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
                    <asp:CheckBox ID="Customer_CheckBox" runat="server"   OnCheckedChanged="CustomerCheckBoxChanged" AutoPostBack="True"  />
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
            <asp:Button id="Customer_Hidden" Text="收起" runat="server" OnClick="CustomerList_Hidden"  Visible="False"/>
        </td>
        </tr>
    	<tr>
    		<td><asp:label id="label_contactName" runat="server" Text="联系人姓名"/></td>
    		<td><asp:TextBox id="textBox_contactName" runat="server" /></td>
    		<td><asp:Button id="button_selectContact" Text="选择联系人" runat="server" OnClick="Select_Contact" /></td>
    	</tr>
    	<tr>
    	<td>
        <asp:GridView ID="ContactGridView" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
        datakeynames="联系人ID" AllowPaging="True" ShowFooter="false" >
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
                <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="Contact_CheckBox" runat="server"   OnCheckedChanged="ContactCheckBoxChanged" AutoPostBack="True"  />
                    <asp:TextBox ID="Contact_TextBox" runat="server" Text='<%# Eval("联系人ID") %>' Visible="false"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
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
        </td>
        <td>
            <asp:Button id="Contact_Hidden" Text="收起" runat="server" OnClick="ContactList_Hidden"  Visible="False"/>
        </td>
        </tr>
    	 <tr>
    		<td><asp:label id="label_recordDetail" runat="server" Text="拜访记录"/></td>
    		<td><asp:TextBox id="textBox_recordDetail" runat="server"  TextMode="MultiLine"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_recordTime" runat="server" Text="拜访时间"/></td>
    		<td>
    		    <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
            </td>
    	</tr>
    	<tr>
    	    <td>
    	        <asp:Button id="button_addVisitRecord" Text="添加拜访记录" runat="server" OnClick="Add_VisitRecord"/>
    	    </td>
    	</tr>
    	</table>

</asp:Content>

