
function switchSysBar(){ 
var locate=location.href.replace('middel.html','');
var ssrc=document.all("img1").src.replace(locate,'');
if (ssrc=="../images/main_55.gif")
{ 
document.all("img1").src="../images/main_55_1.gif";
document.all("frmTitle").style.display="none" 
} 
else
{ 
document.all("img1").src="../images/main_55.gif";
document.all("frmTitle").style.display="" 
} 
} 


function showsubmenu(sid)
{
whichEl = eval("submenu" + sid);
imgmenu = eval("imgmenu" + sid);
if (whichEl.style.display == "none")
{
eval("submenu" + sid + ".style.display=\"\";");
imgmenu.background="../images/main_47.gif";
}
else
{
eval("submenu" + sid + ".style.display=\"none\";");
imgmenu.background="../images/main_48.gif";
}
}
