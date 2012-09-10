<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="VisitRecordList.aspx.cs" Inherits="web_VisitRecordList" Title="拜访记录列表" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="拜访记录列表"></asp:Label>
    
    </div>
        <asp:GridView ID="VisitRecordGridView" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
        onrowediting="VisitRecordGridView_RowEditing" datakeynames="拜访记录ID" 
        onrowdeleting="VisitRecordGridView_RowDeleting" AllowPaging="True" ShowFooter="false"
        onrowdatabound="VisitRecordGridView_RowDataBound" 
        onrowcommand="VisitRecordGridView_RowCommand">
        <Columns>
            <asp:BoundField  HeaderText="序号" ReadOnly="True" />
            <asp:BoundField DataField="联系人姓名" HeaderText="联系人姓名" ReadOnly="True" />
            <asp:BoundField DataField="地址" HeaderText="地址" ReadOnly="True" />
            <asp:BoundField DataField="客户名称" HeaderText="客户名称" ReadOnly="True" />
            <asp:BoundField DataField="手机" HeaderText="手机" ReadOnly="True" />
<%--            <asp:BoundField DataField="拜访记录" HeaderText="拜访记录" ReadOnly="True" />  --%>                                                        
            <asp:BoundField DataField="拜访时间" HeaderText="拜访时间" ReadOnly="True" />
               <asp:TemplateField HeaderText="详细">
            <ItemTemplate>
                <asp:LinkButton ID="VisitRecordDetail" runat="server" Text="详细" CommandName="Detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
              <asp:CommandField HeaderText="编辑" ShowEditButton="True"/>
          <asp:TemplateField HeaderText="删除">
            <ItemTemplate>
                <asp:LinkButton ID="Delete_VisitRecord" runat="server" OnClientClick="return confirm('确定删除？')" CommandName="Delete" Text="删除"></asp:LinkButton>
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
    <asp:Button id="addCustomer" Text="添加拜访记录" runat="server" OnClick="Add_VisitRecord" />
            <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton> 
        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 
        <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton> 
跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> 
        </asp:DropDownList>页
</asp:Content>
