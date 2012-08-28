<%@ Page Language="C#"  Async="true" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="UploadDoc.aspx.cs" Inherits="web_UploadDoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">


 function setDocCate()
        {
            var oTab=document.getElementById("<%=DocRadioButtonList.ClientID%>");
            var arrRadio=oTab.getElementsByTagName('INPUT');
            if (arrRadio[0].checked==true )
            {
                setDocumentDoc();
            }
            else
            {
                setPojectDoc();
            }
        }
        function setPojectDoc()
        {
        
            document.getElementById("<%=项目名称.ClientID%>").style.display ="";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="";
            document.getElementById("<%=子任务名.ClientID%>").style.display ="";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="";
             
            
            document.getElementById("<%=文档版本.ClientID%>").style.display ="none";
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="none";          
            document.getElementById("<%=文档所属部门.ClientID%>").style.display ="none";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="none";
             document.getElementById("<%=文档状态.ClientID%>").style.display ="none";
            document.getElementById("<%=DocState.ClientID%>").style.display ="none";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="none";
        }
        
        function setDocumentDoc()
        {
            document.getElementById("<%=项目名称.ClientID%>").style.display ="none";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="none";
            document.getElementById("<%=子任务名.ClientID%>").style.display ="none";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="none";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="none";
             
            
            document.getElementById("<%=文档版本.ClientID%>").style.display ="";
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="";          
            document.getElementById("<%=文档所属部门.ClientID%>").style.display ="";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="";
             document.getElementById("<%=文档状态.ClientID%>").style.display ="";
            document.getElementById("<%=DocState.ClientID%>").style.display ="";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="";
            
        }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div align="center">
    <asp:RadioButtonList ID="DocRadioButtonList" runat="server" 
        RepeatDirection="Horizontal" 
        onclick="setDocCate()"
       >
        <asp:ListItem Value="Document">资料文档</asp:ListItem>
        <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
</div>
<div>  
        <asp:Label ID="文档名称" runat="server" Text="文档名称"></asp:Label>   
        <asp:TextBox ID="DocNameText" runat="server"></asp:TextBox> 
    </div>
    <div >  
        <asp:Label ID="文档版本" runat="server" Text="文档版本"></asp:Label>   
        <asp:TextBox ID="DocVersionText" runat="server"></asp:TextBox> 
    </div>
    <div>
            <asp:Label ID="文档简介" runat="server" Text="文档简介"></asp:Label>   
    </div>
    <div>
    
        <asp:TextBox ID="DocDescription" runat="server" Height="152px" Width="363px" 
            TextMode="MultiLine"></asp:TextBox>
    
    </div>
    <div>  
        <asp:Label ID="关键词" runat="server" Text="关键词"></asp:Label>
        <asp:TextBox ID="DocKeyText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="文档所属部门" runat="server" Text="文档所属部门"></asp:Label>   
        <asp:DropDownList ID="DepartName" runat="server" 
           >
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="项目名称" runat="server" Text="项目名称"></asp:Label>   
        <asp:DropDownList ID="ProjectName" onchange="getSubTask(this.value)" runat="server" 
                >
        </asp:DropDownList>
    </div>
     <div>  
        <asp:Label ID="子任务名" runat="server" Text="子任务名"></asp:Label>   
        <asp:DropDownList ID="SubTaskName" runat="server" >
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="文档类别" runat="server" Text="文档类别"></asp:Label>   
        <asp:DropDownList ID="DocCate" runat="server">
        </asp:DropDownList>  
        <asp:DropDownList ID="ProjectDocCate" runat="server">
            <asp:ListItem>临床试验</asp:ListItem>
            <asp:ListItem>注册</asp:ListItem>
            <asp:ListItem>咨询</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="下载权限" runat="server" Text="下载权限"></asp:Label>     
         <asp:DropDownList ID="DownLoadPremission" runat="server">
        </asp:DropDownList>  
            <asp:CheckBoxList ID="UserNameList" runat="server">
            </asp:CheckBoxList>
    </div>
     <div>  
        <asp:Label ID="文档状态" runat="server" Text="文档状态"></asp:Label>   
         <asp:DropDownList ID="DocState" runat="server">
             <asp:ListItem>受控</asp:ListItem>
             <asp:ListItem>作废留用</asp:ListItem>
             <asp:ListItem>作废</asp:ListItem>
         </asp:DropDownList>
    </div>
     <div>  
       <br />
        
    </div>
        <asp:GridView ID="DocGridView" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" >
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="名称" HeaderText="名称" />
            <asp:BoundField DataField="版本" HeaderText="版本" />
            <asp:BoundField DataField="类别" HeaderText="类别" />
            <asp:BoundField DataField="所属部门" HeaderText="所属部门" />
            <asp:BoundField DataField="项目子任务" HeaderText="项目子任务" />
            <asp:BoundField DataField="上传人" HeaderText="上传人" />
            <asp:BoundField DataField="上传时间" HeaderText="上传时间" />
            <asp:HyperLinkField HeaderText="浏览" Text="浏览" />
            <asp:HyperLinkField HeaderText="编辑" Text="编辑" />
            <asp:HyperLinkField HeaderText="删除" Text="删除" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:Button ID="UploadButton" runat="server" Text="上传文档" 
        onclick="UploadButton_Click" />
</asp:Content>

