<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="VisitRecordDetail.aspx.cs" Inherits="web_VisitRecordDetail" Title="拜访记录信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="拜访记录信息"></asp:Label>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
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
                <asp:Label ID="label_customerName1" runat="server" Text="客户名称" />
            </td>
            <td>
                <asp:Label ID="label_customerName2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_address1" runat="server" Text="地址" />
            </td>
            <td>
                <asp:Label ID="label_address2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_telephone1" runat="server" Text="手机" />
            </td>
            <td>
                <asp:Label ID="label_telephone2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_recordDetail1" runat="server" Text="拜访记录" />
            </td>
            <td>
                <asp:Label ID="label_recordDetail2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_recordTime1" runat="server" Text="拜访时间" />
            </td>
            <td>
                <asp:Label ID="label_recordTime2" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
