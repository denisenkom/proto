<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrdersRegister.aspx.vb" Inherits="WebUI.OrdersRegister"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrdersRegister</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
		<script src="scripts\database.js" charset="windows-1251"></script>
		<script src="scripts\OrderScripts.js" charset="windows-1251"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post">
			<INPUT type="hidden" id="Number" name="Number"> <INPUT type="hidden" id="Action" name="Action">
			<h2>Форма регистрации заказов на <input type="text" name="Date" id="Date" size="14" value="<%=[Date]%>" onchange="Action.value='datechange';submit()" autocomplete=off></h2>
			<table>
				<tbody>
					<tr>
						<th>
							номер</th><th>дата выдачи</th><th>магазин</th><th>продавец</th></tr>
					<tr>
						<td><input type="text" name="HumanNumber" id="HumanNumber" size="5" onchange="return HumanNumber_onchange()"
								autocomplete="off"></td>
						<td><input type="text" name="DateOfRelease" id="DateOfRelease" size="14" autocomplete="off"></td>
						<td><SELECT name="ShopId" id="ShopId" onchange="return ShopId_onchange()">
								<OPTION selected></OPTION>
								<%
Dim rdr As Data.SqlClient.SqlDataReader
rdr = conn.ExecuteReader("SELECT Id, [Desc] FROM SubUnits WHERE class='shop'")
While rdr.Read()%>
								<OPTION value=<%=rdr(0)%>><%=rdr(0) & ": " & rdr(1)%></OPTION>
								<%
End While
conn.Close()%>
							</SELECT></td>
						<td><SELECT id="SellerId" name="SellerId">
								<OPTION selected></OPTION>
							</SELECT></td>
					</tr>
					<tr>
						<th colspan="4">
							доставка и адрес</th></tr>
					<tr>
					<tr>
						<td colspan="4" align="center">
							<input type="checkbox" name="HaveDelivery" id="HaveDelivery" onclick="return HaveDelivery_onclick()">
							<input type="text" name="DeliveryAddress" id="DeliveryAddress" size="65" disabled autocomplete="off">
						</td>
					</tr>
					<tr>
						<th colspan="4">
							описание</th></tr>
					<tr>
						<td colspan="4"><TEXTAREA id="Description" name="Description" rows="5" cols="55"></TEXTAREA></td>
					</tr>
					<tr>
						<td colspan="4" align="center"><input type="button" value="Регистр." onclick="Action.value='register';submit()"></td>
					</tr>
				</tbody>
			</table>
			<h2>Зарегистированные заказы на
				<%=[Date]%>
			</h2>
			<table border="1" bordercolor="black" cellspacing="2">
				<thead>
					<tr>
						<th>
							№<br>
							п.п.</th>
						<th>
							номер</th><th>дата выдачи</th><th>д</th><th>адрес</th><th>описание</th></tr>
				</thead>
				<tbody>
					<%
rdr = conn.ExecuteReader(String.Format("SELECT Number, ShopId, DateOfRelease, " _
	& "HaveDelivery, DeliveryAddress, Description FROM Orders " _
	& " WHERE Date='{0:dd/MM/yyyy}'", [Date]))
Dim OrderCount = 1
While rdr.Read()%>
					<TR>
						<TD align="right"><%=OrderCount%></TD>
						<TD align="right"><%=rdr(0) & "-" & rdr(1)%></TD>
						<TD><%=String.Format("{0:d MMMM}", rdr(2))%></TD>
						<TD align="center"><INPUT type="checkbox" <%If rdr(3) Then%>checked<%End If%> disabled></TD>
						<TD>&nbsp;<%=rdr(4)%></TD>
						<TD>&nbsp;<%=rdr(5)%></TD>
					</TR>
					<%
    OrderCount = OrderCount + 1
End While
conn.Close()%>
				</tbody>
			</table>
		</form>
		<table><tr><td><a href='OrdersList.aspx'>Список заказов</a></td></tr></table>
	</body>
</HTML>
