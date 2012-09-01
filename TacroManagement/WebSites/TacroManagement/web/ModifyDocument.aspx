<%@ Page Language="C#" Async ="true"  enableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ModifyDocument.aspx.cs" Inherits="web_ModifyDocument" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/jscript">

        var xmlHttp=null;              
        function $(id)
        {
            return document.getElementById(id);
        }
        function createXMLHttpRequest() 
        { 
            if(xmlHttp == null){
                if(window.XMLHttpRequest) {
                    //Mozilla 浏览器
                    xmlHttp = new XMLHttpRequest();
                }else if(window.ActiveXObject) {
                    // IE浏览器
                    try {
                        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
                    } catch (e) {
                        try {
                            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                        } catch (e) {
                        }
                    }
                }
            }
        } 
        
        function openAjax(val) 
        {   
            
            if( xmlHttp == null)
            {                
                createXMLHttpRequest();  
                if( xmlHttp == null)
                {
                    //alert('出错');
                    return ;
                }
            }
             $('<%=DocCate.ClientID %>').options[0]=new Option("正在加载...",""); 
             $('<%=DocCate.ClientID %>').disabled=true; 
             try
            {
                xmlHttp.open("get","GetDocCateByDepartId.aspx?DepartID="+val+"&date="+new Date(),true); 
                //xmlHttp.open("get","GetCityByProvinceID.aspx?PID="+val,true); 
                
                xmlHttp.onreadystatechange=xmlHttpChange;             
           
                xmlHttp.send(null);                
            }
            catch(e)
            {            
                $('<%=DocCate.ClientID %>').options.length=0; 
                $('<%=DocCate.ClientID %>').disabled=false;
            }  
        } 
        
        function xmlHttpChange() 
        { 
            if(xmlHttp.readyState==4) 
            {             
                if(xmlHttp.status==200) 
                {   
                        $('<%=DocCate.ClientID %>').options.length=0; 
                        $('<%=DocCate.ClientID %>').disabled=false;    
                        Bind(xmlHttp.responseText);                  
                } 
            } 
        }    
        
        function getDocCate(val)
        {
                if(val=='0')
                    return ;
                openAjax(val);
        
        }
        function Bind(xmlStr)
        {    
                if(xmlStr=='')
                {
                    $('<%=DocCate.ClientID %>').disabled=true; 
                    return;
                }
                $('<%=DocCate.ClientID %>').options.add(new Option("选择文档类型", "0"));
                
                var DocCateIDAndNameList =xmlStr.split(";");
                var num =DocCateIDAndNameList[0];
                for(var i=1; i < num*2+1; i=i+2)
                {
                       $('<%=DocCate.ClientID %>').options.add(new Option(DocCateIDAndNameList[i+1],DocCateIDAndNameList[i]));

                }
                $('<%=DocCate.ClientID %>').disabled=false; 
            } 
            
            function setDocCateID(val)
            {
                document.getElementById("<%=DocCateIDText.ClientID%>").value = val;
            }
        function showUsers() 
        {   
            var index = document.getElementById("<%=DownLoadPremission.ClientID%>").selectedIndex;
            if ( index == 3) 
            {
              document.getElementById("<%=UserNameList.ClientID%>").style.display ="";
            }
            else
            {
             document.getElementById("<%=UserNameList.ClientID%>").style.display ="none";
            }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <asp:DropDownList ID="DepartName" onchange="getDocCate(this.value)" runat="server" 
           >
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="文档类别" runat="server" Text="文档类别"></asp:Label>   
        <asp:DropDownList ID="DocCate" runat="server" onchange="setDocCateID(this.value)">
        </asp:DropDownList>  
        <asp:HiddenField ID="DocCateIDText" runat="server" />
    </div>
        <div>  
        <asp:Label ID="下载权限" runat="server" Text="下载权限"></asp:Label>     
         <asp:DropDownList ID="DownLoadPremission" onchange="showUsers()" runat="server">
             <asp:ListItem Value="0">下载权限</asp:ListItem>
             <asp:ListItem Value="1">所有用户</asp:ListItem>
             <asp:ListItem Value="2">本部门用户</asp:ListItem>
             <asp:ListItem Value="3">自定义用户</asp:ListItem>
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
       <asp:Label ID="上传人" runat="server" Text="上传人"></asp:Label>   
        <asp:TextBox ID="UploadUserName" runat="server"></asp:TextBox> 
    </div>
         <div>  
       <asp:Label ID="上传时间" runat="server" Text="上传时间"></asp:Label>   
        <asp:TextBox ID="uploadTime" runat="server"></asp:TextBox> 
             <asp:Label ID="DocID" runat="server" Visible="False"></asp:Label>
    </div>
    <asp:Button ID="ModifyButton" runat="server" Text="保存修改" 
        onclick="ModifyButton_Click" />
        <script type="text/javascript">showUsers();</script>
</asp:Content>

