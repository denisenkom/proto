<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderTasks.aspx.vb" Inherits="WebUI.OrderTasks"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrderTasks</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post">
			<input type="hidden" name="Action" id="Action"> <input type=hidden name="Number" value="<%=Number%>">
			<input type=hidden name="Year" value="<%=Year%>"> <input type=hidden name="ShopId" value="<%=ShopId%>">
			<%
Dim rdr as Data.SqlClient.SqlDataReader
rdr = conn.ExecuteReader("SELECT SubUnitId, su.[Desc], state, StartDate, EndDate FROM ProductionTasks AS pt JOIN SubUnits AS su ON pt.SubUnitId=su.Id WHERE OrderNumber=" & Number & " AND Year=" & Year & " AND ShopId='" & ShopId & "' ORDER BY state, SubUnitId")
If rdr.HasRows Then%>
			<table border="1">
				<caption>
					Подразделения, выполняющие заказ</caption>
				<thead>
					<tr>
						<th rowspan="2">
						</th>
						<th rowspan="2">
							подразделение</th><th rowspan="2">состояние</th><th colspan="2">даты</th></tr>
					<tr>
						<th>
							начала</th><th>завершения</th></tr>
				</thead>
				<tbody>
					<%
	While rdr.Read()
		Dim state$
		Dim color$
		Dim canselect As Boolean = False
		Select Case rdr(2)
			Case BusinessFacade.ProductionTasks.done
				state = "готов": color = "PaleGreen"
			Case BusinessFacade.ProductionTasks.executing
				state = "выполняется": color = "Gold"
			Case BusinessFacade.ProductionTasks.waiting
				state = "ожидает": color = "LightSkyBlue" : canselect = True
		End Select
		Dim SubUnitId$ = rdr(0)%>
					<TR bgcolor=<%=color%>>
						<td><%If canselect Then%><input type=checkbox name="cb-<%=SubUnitId%>"><%End If%></td>
						<td><%=SubUnitId & ": " & rdr(1)%></td>
						<td><%=state%></td>
						<td><%=String.Format("{0:d MMMM}",rdr(3))%></td>
						<td><%=String.Format("{0:d MMMM}",rdr(4))%></td>
					</TR>
					<%
	End While%>
				</tbody>
			</table>
			<a href='javascript:document.forms[0]["Action"].value="RemoveTasks";document.forms[0].submit();'>
				Удалить выбранные задания</a>
			<%
Else%>
<ul>Стандартные шаблоны
<li><a href='javascript:document.forms[0]["Action"].value="ApplyTemplateKitchen";document.forms[0].submit();'>Кухонная мебель</a></li>
<li><a href='javascript:document.forms[0]["Action"].value="ApplyTemplateOffice";document.forms[0].submit();'>Офисная мебель</a></li>
<li><a href='javascript:document.forms[0]["Action"].value="ApplyTemplateSofas";document.forms[0].submit();'>Мягкая мебель</a></li>
<li><a href='javascript:document.forms[0]["Action"].value="ApplyTemplateTables";document.forms[0].submit();'>Обеденные столы</a></li>
</ul>

<%
End If 'rdr.HasRows
conn.Close()%>
			<hr>
			<table cellpadding="0" cellspacing="0">
				<caption>
					Список подразделений для добавления</caption>
				<tbody>
					<%
rdr = conn.ExecuteReader("SELECT Id, [Desc] FROM SubUnits WHERE class='production' AND Id NOT IN (SELECT SubUnitId FROM ProductionTasks WHERE OrderNumber=" & Number & " AND Year=" & Year & " AND ShopId='" & ShopId & "') ORDER BY Id")
While rdr.Read()%>
					<tr valign=top>
						<td><input type=checkbox name='cb+<%=rdr(0)%>'></td>
						<td><%=rdr(0)%></td>
						<td><%=rdr(1)%></td>
					</tr>
					<%
End While
conn.Close()%>
				</tbody>
			</table>
			<a href='javascript:document.forms[0]["Action"].value="AddTasks";document.forms[0].submit();'>
				Добавить выбранные подразделения в исполнители заказа</a>
		</form>
		<table><tr><td><a href='OrdersWithEmptyTaskList.aspx'>Список заказов, не распределенных по подразделениям</a></td></tr></table>
	</body>
</HTML>
