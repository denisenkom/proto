<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderCard.aspx.vb" Inherits="WebUITesting.OrderCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrderCard</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" margingheight="0" marginwidth="0">
		<table width="100%" height="100%" cellpadding="0" cellspacing="0">
			<tr height="1">
				<td colspan="2"><h2>Карточка заказа № <span style="FONT-WEIGHT: bolder">
							<%=Number%>
							-<%=ShopId%></span></h2>
				</td>
			</tr>
			<tr>
				<td valign="top" bgcolor="lightskyblue" style="WIDTH: 3cm">
					<script>
var pages = new Array("Main","","Tasks","OrderTasks.aspx?Number=<%=Number%>&Year=<%=Year%>&ShopId=<%=ShopId%>","Paids","a2","Drafts","a3");
var selectedPage = 1;
function selectPage(page)
{
	menu.tBodies[0].children[pages[selectedPage]].style.background = "";
	selectedPage = page*2;
	menu.tBodies[0].children[pages[selectedPage]].style.background = "DodgerBlue";
	document.all.pageFrame.src = pages[selectedPage + 1];
}
					</script>
					<table id="menu" width=100% cellspacing="0">
						<tr id="Main" bgcolor="dodgerblue">
							<td>
								<a href='javascript:selectPage(0)'>Главная</a></td>
						</tr>
						<tr id="Tasks">
							<td>
								<a href='javascript:selectPage(1)'>Задания</a></td>
						</tr>
						<tr id="Paids">
							<td>
								<a href='javascript:selectPage(2)'>Оплаты</a></td>
						</tr>
						<tr id="Drafts">
							<td>
								<a href='javascript:selectPage(3)'>Эскиз</a></td>
						</tr>
					</table>
				</td>
				<td>
					<iframe id=pageFrame frameborder="no" width="100%" height="100%" src="OrderTasks.aspx?Number=<%=Number%>&amp;Year=<%=Year%>&amp;ShopId=<%=ShopId%>">
					</iframe>
				</td>
			</tr>
		</table>
	</body>
</HTML>
