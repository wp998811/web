<%@ Page Language="C#" Async="true"   EnableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="web_AdvancedSearch" Title="高级查询" %>

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
            
//            var xmlDoc;
//            if(window.ActiveXObject)
//            {
//                xmlDoc    = new ActiveXObject('MSXML2.DOMDocument');
//                xmlDoc.async    = false;    
//                xmlDoc.loadXML(xmlStr);                 
//                if(xmlDoc.parseError.errorCode!=0)   
//                {                     
//                    alert("出错！"+xmlDoc.parseError.reason);   
//                }           
//            }
//            else if (document.implementation&&document.implementation.createDocument)
//            {
//                xmlDoc  = document.implementation.createDocument('', '', null);
//                xmlDoc.async=false;
//                xmlDoc.loadXML(xmlStr);   
//            }
//            var elementList;
//            elementList = xmlDoc.getElementsByTagName('City');
//            // 遍历
//            for (var j = 0;j < elementList.length; j++) {                        
//                if(elementList[j].childNodes.length==3)
//                {
//                    $('<%=SubTaskName.ClientID %>').options.add(new Option(elementList[j].childNodes[1].text,elementList[j].childNodes[0].text));
//                }                        
//            }
//            $('<%=SubTaskName.ClientID %>').options[1].selected=true;
        
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
        }
        function setPojectDoc()
        {       
            document.getElementById("<%=Label9.ClientID%>").style.display ="";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="";
            document.getElementById("<%=Label10.ClientID%>").style.display ="";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="";
             
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="none";
            document.getElementById("<%=Label2.ClientID%>").style.display ="none";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="none";
            document.getElementById("<%=Label4.ClientID%>").style.display ="none";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="none";
            
        }
        
        function setDocumentDoc()
        {
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="";
            document.getElementById("<%=Label2.ClientID%>").style.display ="";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="";
            document.getElementById("<%=Label4.ClientID%>").style.display ="";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="";
            
            document.getElementById("<%=Label9.ClientID%>").style.display ="none";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="none";
            document.getElementById("<%=Label10.ClientID%>").style.display ="none";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="none";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="none";
            
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
        onclick="setDocCate()">
        <asp:ListItem Value="Document">资料文档</asp:ListItem>
        <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div>  
        <asp:Label ID="Label1" runat="server" Text="文档名称"></asp:Label>   
        <asp:TextBox ID="DocNameText" runat="server"></asp:TextBox> 
    </div>
    <div >  
        <asp:Label ID="Label2" runat="server" Text="文档版本"></asp:Label>   
        <asp:TextBox ID="DocVersionText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="Label3" runat="server" Text="关键词"></asp:Label>
        <asp:TextBox ID="DocKeyText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="Label4" runat="server" Text="文档所属部门"></asp:Label>   
        <asp:DropDownList ID="DepartName" onchange="getDocCate(this.value)" runat="server">
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label9" runat="server" Text="项目名称"></asp:Label>   
        <asp:DropDownList ID="ProjectName" onchange="getSubTask(this.value)" runat="server">
        </asp:DropDownList>
    </div>
     <div>    
        <asp:Label ID="Label10" runat="server" Text="子任务名"></asp:Label>   
        <asp:DropDownList ID="SubTaskName" runat="server"  onchange="setSubTaskID(this.value)">
        </asp:DropDownList>
          <asp:HiddenField ID="SubTaskIDText" runat="server" />
    </div>
        <div>  
        <asp:Label ID="Label8" runat="server" Text="文档类别"></asp:Label>   
         <asp:DropDownList ID="DocCate" runat="server" onchange="setDocCateID(this.value)">
        </asp:DropDownList>        
         <asp:HiddenField ID="DocCateIDText" runat="server" />
        <asp:DropDownList ID="ProjectDocCate" runat="server">
            <asp:ListItem Value="0">选择类别</asp:ListItem>
            <asp:ListItem Value="1">临床试验</asp:ListItem>
            <asp:ListItem Value="2">注册</asp:ListItem>
            <asp:ListItem Value="3">咨询</asp:ListItem>
            <asp:ListItem Value="4">其他</asp:ListItem>
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label5" runat="server" Text="上传人"></asp:Label>     
        <asp:TextBox ID="UploadUserName" runat="server"></asp:TextBox> 
    </div>
     <div>  
        <asp:Label ID="Label6" runat="server" Text="上传时间上限"></asp:Label>   
        <asp:TextBox ID="UploadTimeBeginText" runat="server"></asp:TextBox> 
    </div>
     <div>  
        <asp:Label ID="Label7" runat="server" Text="上传时间下限"></asp:Label>   
        <asp:TextBox ID="UploadTimeEndText" runat="server"></asp:TextBox> 
    </div>
        <asp:GridView ID="DocGridView" runat="server" CellPadding="4" AutoGenerateColumns="false"
        ForeColor="#333333" GridLines="None" onrowcommand="DocGridView_RowCommand" datakeynames="docID">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="名称" HeaderText="名称" />
            <asp:BoundField DataField="版本" HeaderText="版本" />
            <asp:BoundField DataField="类别" HeaderText="类别" />
            <asp:BoundField DataField="所属部门" HeaderText="所属部门" />
            <asp:BoundField DataField="项目子任务" HeaderText="项目子任务" />
            <asp:BoundField DataField="上传人" HeaderText="上传人" />
            <asp:BoundField DataField="上传时间" HeaderText="上传时间" />  
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ExploreButton" runat="server" 
                  NavigateUrl="~/Search.aspx" 
                  CommandName="ExploreDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="浏览" />
             </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ModifyButton" runat="server"
                CommandName="ModifyDocument"
                CommandArgument ="<%# ((GridViewRow) Container).RowIndex %>"
               Text="修改" />
             </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="DownloadButton" runat="server" 
                  CommandName="DownloadDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="下载" /> 
              </ItemTemplate>
             </asp:TemplateField>  
        <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="DeleteButton" runat="server" 
                  CommandName="DeleteDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="删除" /> 
              </ItemTemplate>
             </asp:TemplateField> 
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:Button ID="AdvancedSearchButton" runat="server" Text="高级查询" 
        onclick="AdvancedSearchButton_Click" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/web/Search.aspx" >一般查询</asp:HyperLink>
        <script type="text/javascript">setDocCate();</script>
</asp:Content>

