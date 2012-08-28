<%@ Page Language="C#" Async="true" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="web_AdvancedSearch" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        
        function xmlHttpChange() 
        { 
            if(xmlHttp.readyState==4) 
            {             
                if(xmlHttp.status==200) 
                {                                                                
                    $('<%=SubTaskName.ClientID %>').options.length=0; 
                    $('<%=SubTaskName.ClientID %>').disabled=false;                    
                    Bind(xmlHttp.responseText);                    
                } 
            } 
        }    
        function getSubTask(val)
        {
            if(val=='0')
                return ;
            openAjax(val);
        }
        function Bind(xmlStr)
        {        
            if(xmlStr=='')
            {
                $('<%=SubTaskName.ClientID %>').disabled=true; 
                return;
            }
            $('<%=SubTaskName.ClientID %>').options.add(new Option("——请选择——", "0"));
            
            var subTaskIDAndNameList =xmlStr.split(";");
            var num =subTaskIDAndNameList[0];
            for(var i=1; i < num*2+1; i=i+2)
            {
                   $('<%=SubTaskName.ClientID %>').options.add(new Option(subTaskIDAndNameList[i+1],subTaskIDAndNameList[i]));

            }
            $('<%=SubTaskName.ClientID %>').disabled=false; 
            
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
        } 
            
</script>
<div align="center">
    <asp:RadioButtonList ID="DocRadioButtonList" runat="server" 
        RepeatDirection="Horizontal" 
        onchange="setDocCate(this.value)"
        onselectedindexchanged="DocRadioButtonList_SelectedIndexChanged">
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
        <asp:DropDownList ID="DepartName" runat="server" 
            onselectedindexchanged="DepartName_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label9" runat="server" Text="项目名称"></asp:Label>   
        <asp:DropDownList ID="ProjectName" onchange="getSubTask(this.value)" runat="server" 
                onselectedindexchanged="ProjectName_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
     <div>  
        <asp:Label ID="Label10" runat="server" Text="子任务名"></asp:Label>   
        <asp:DropDownList ID="SubTaskName" runat="server" >
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label8" runat="server" Text="文档类别"></asp:Label>   
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
        <asp:GridView ID="DocGridView" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" onrowcommand="DocGridView_RowCommand" >
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
           <asp:TemplateField>
              <ItemTemplate>
               <asp:LinkButton ID="ExploreButton" runat="server" 
                  NavigateUrl="~/Search.aspx" 
                  CommandName="ExploreDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="浏览" />
                   <%--<asp:HyperLink ID ="ExploreLink" runat="server" NavigateUrl='<%# String.Format("~/Search.aspx?id={0}", GetDocumentName(((GridViewRow) Container).RowIndex))%>' -->
                         Target="_blank">liulan</asp:HyperLink>--%> 
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
</asp:Content>

