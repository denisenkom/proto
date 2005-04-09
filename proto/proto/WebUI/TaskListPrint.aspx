<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TaskListPrint.aspx.vb" Inherits="WebUI.TaskListPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TaskListPrint</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<%
Diagnostics.Debug.Assert (DateOfPakage <> "")
%>
		<table border rules="all" borderColor="black" cellSpacing="0" cellPadding="5">
			<caption>
				Пакет задания на <b>
					<%=DateOfPakage%>
				</b>для <b>
					<%=SubUnitID%>
				</b>
			</caption>
			<thead>
				<tr>
					<th rowspan="2">
						№<br>
						п.п.</th><th colspan="2">заказ</th><th rowspan="2">готовность</th>
				</tr>
				<tr>
					<th>
						номер</th><th>описание</th></tr>
			</thead>
			<tbody>
				<%
Dim rdr As Data.SqlClient.SqlDataReader = conn.ExecuteReader("SELECT STR(o.Number) + '-' + o.ShopId AS HumanNumber, o.Description " _
	& "FROM ProductionTasks AS pt JOIN Orders AS o ON pt.OrderNumber=o.Number AND pt.ShopId=o.ShopId AND pt.Year=o.Year " _
	& "WHERE state='executing' AND SubUnitId='" & SubUnitId & "' AND StartDate='" & DateOfPakage & "' ORDER BY o.DateOfRelease, HumanNumber")
Dim count% = 1
While rdr.Read()%>
				<TR>
					<TD align="right"><%=count%></TD>
					<TD align="right"><%=rdr(0)%></TD>
					<TD><%=rdr(1)%>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
					<%
	count = count + 1
End While
		%>
			</tbody>
		</table>
	</body>
</HTML>
