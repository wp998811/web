<%@ Page Language="C#"  Async="true" enableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="UploadDoc.aspx.cs" Inherits="web_UploadDoc" Title="上传文档" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">

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
        
        function openAjax(val,b) 
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
            if (b == "true") 
            {
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
            else
            {
                 $('<%=SubTaskName.ClientID %>').options[0]=new Option("正在加载...",""); 
                 $('<%=SubTaskName.ClientID %>').disabled=true; 
                 try
                {
                    xmlHttp.open("get","GetSubTaskByProjectNum.aspx?ProjectNum="+val+"&date="+new Date(),true); 
                    //xmlHttp.open("get","GetCityByProvinceID.aspx?PID="+val,true); 
                    
                    xmlHttp.onreadystatechange=xmlHttpChange;             
               
                    xmlHttp.send(null);                
                }
                catch(e)
                {            
                    $('<%=SubTaskName.ClientID %>').options.length=0; 
                    $('<%=SubTaskName.ClientID %>').disabled=false;
                }    
            }

        } 
        
        function xmlHttpChange() 
        { 
            if(xmlHttp.readyState==4) 
            {             
                if(xmlHttp.status==200) 
                {   
                    var oTab=document.getElementById("<%=DocRadioButtonList.ClientID%>");
                    var arrRadio=oTab.getElementsByTagName('INPUT');
                     if (arrRadio[0].checked==true )
                     {
                        $('<%=DocCate.ClientID %>').options.length=0; 
                        $('<%=DocCate.ClientID %>').disabled=false;    
                        Bind(xmlHttp.responseText,"true"); 
                     }
                     else
                     {
                        $('<%=SubTaskName.ClientID %>').options.length=0; 
                        $('<%=SubTaskName.ClientID %>').disabled=false; 
                        Bind(xmlHttp.responseText,"false");    
                     }                         
                } 
            } 
        }    
        function getSubTask(val)
        {
            if(val=='0')
                return ;
            openAjax(val,"false");
        }
        function getDocCate(val)
        {
                if(val=='0')
                    return ;
                openAjax(val,"true");
        
        }
        function Bind(xmlStr,b)
        {    
            if (b == "true")
            {
                if(xmlStr=='')
                {
                    $('<%=DocCate.ClientID %>').disabled=true; 
                    return;
                }
                $('<%=DocCate.ClientID %>').options.add(new Option("选择文档类型", "0"));
                
                var subTaskIDAndNameList =xmlStr.split(";");
                var num =subTaskIDAndNameList[0];
                for(var i=1; i < num*2+1; i=i+2)
                {
                       $('<%=DocCate.ClientID %>').options.add(new Option(subTaskIDAndNameList[i+1],subTaskIDAndNameList[i]));

                }
                $('<%=DocCate.ClientID %>').disabled=false; 
            
            }   
            else
            {
                    if(xmlStr=='')
                    {
                        $('<%=SubTaskName.ClientID %>').disabled=true; 
                        return;
                    }
                    $('<%=SubTaskName.ClientID %>').options.add(new Option("选择子任务", "0"));
                    
                    var subTaskIDAndNameList =xmlStr.split(";");
                    var num =subTaskIDAndNameList[0];
                    for(var i=1; i < num*2+1; i=i+2)
                    {
                           $('<%=SubTaskName.ClientID %>').options.add(new Option(subTaskIDAndNameList[i+1],subTaskIDAndNameList[i]));

                    }
                    $('<%=SubTaskName.ClientID %>').disabled=false; 
             } 
       
            
            } 
            
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
                if (arrRadio[1].checked==true )
                {
                    setPojectDoc();
                }
                else
                {
                    arrRadio[0].checked ="true";
                    setDocumentDoc();
                }
            }
            showUsers();
        }
        function setPojectDoc()
        {
        
            document.getElementById("<%=DownLoadPremission.ClientID%>").options[2].text = "本项目用户";
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
            document.getElementById("<%=UserNameListView.ClientID%>").style.display ="none";
            document.getElementById("<%=DownLoadPremission.ClientID%>").options[2].text = "本部门用户";

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
        
        function showUsers() 
        {   
            var index = document.getElementById("<%=DownLoadPremission.ClientID%>").selectedIndex;
            if ( index == 3) 
            {
              document.getElementById("<%=UserNameListView.ClientID%>").style.display ="";
            }
            else
            {
             document.getElementById("<%=UserNameListView.ClientID%>").style.display ="none";
            }
        }

function setDocCateID(val)
{

    document.getElementById("<%=DocCateIDText.ClientID%>").value = val;

}
function setSubTaskID(val)
{
    document.getElementById("<%=SubTaskIDText.ClientID%>").value = val;

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
        <asp:DropDownList ID="DepartName" onchange="getDocCate(this.value)" runat="server" 
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
        <asp:DropDownList ID="SubTaskName" runat="server"  onchange="setSubTaskID(this.value)">
        </asp:DropDownList>
         <asp:HiddenField ID="SubTaskIDText" runat="server" />
    </div>
        <div>  
        <asp:Label ID="文档类别" runat="server" Text="文档类别"></asp:Label>   
        <asp:DropDownList ID="DocCate" runat="server" onchange="setDocCateID(this.value)">
        </asp:DropDownList>  
         <asp:HiddenField ID="DocCateIDText" runat="server" />
        <asp:DropDownList ID="ProjectDocCate" runat="server">
            <asp:ListItem>临床试验</asp:ListItem>
            <asp:ListItem>注册</asp:ListItem>
            <asp:ListItem>咨询</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>
        </asp:DropDownList>
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
            <asp:GridView ID="UserNameListView" runat="server"  AutoGenerateColumns="false" datakeynames="userID">
                <Columns>
                       <asp:TemplateField HeaderText="选择">   
                          <HeaderStyle HorizontalAlign="Center" Height="25px" Width="45px" />   
                          <ItemTemplate>   
                             <asp:CheckBox ID="ckb" runat="server" />   
                          </ItemTemplate>   
                       </asp:TemplateField> 
                       <asp:BoundField DataField="姓名" HeaderText="姓名" />
                        <asp:BoundField DataField="用户类别" HeaderText="用户类别" />
                        <asp:BoundField DataField="联系方式" HeaderText="联系方式" />
                        <asp:BoundField DataField="所属部门" HeaderText="所属部门" />
                        <asp:BoundField DataField="电子邮箱" HeaderText="电子邮箱" />
                </Columns>
            </asp:GridView>
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
    <asp:Button ID="UploadButton" runat="server" Text="上传文档" 
        onclick="UploadButton_Click"  />
    <script type="text/javascript">setDocCate();</script>
</asp:Content>

