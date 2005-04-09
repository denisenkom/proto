<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrdersWithEmptyTaskList.aspx.vb" Inherits="WebUITesting.OrdersWithEmptyTaskList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>OrdersWithEmptyTaskList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</head>
	<body>
		<TABLE width="100%">
			<thead>
				<TR>
					<TH>
						Номер</TH>
					<TH>
						Дата</TH>
					<TH>
						Дата выдачи</TH>
					<TH>
						Описание</TH>
				</TR>
			</thead>
			<tbody bgcolor=lavender>
				<%
Dim rdr as Data.SqlClient.SqlDataReader = conn.ExecuteReader("SELECT STR(Number)+'-'+ShopId AS ShortHumanNumber, Date, DateOfRelease, Description, Number, Year, ShopId FROM Orders WHERE (STR(Number) + STR(Year) + ShopId) NOT IN (SELECT STR(OrderNumber) + STR(Year) + ShopId FROM ProductionTasks)")
While rdr.Read()%>
				<tr>
					<td align="right"><a href='OrderCard.aspx?page=Tasks&Number=<%=rdr(4)%>&Year=<%=rdr(5)%>&ShopId=<%=rdr(6)%>'><%=rdr(0)%></a></td>
					<td><%=String.Format("{0:d MMMM}", rdr(1))%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(2))%></td>
					<td><%=rdr(3)%></td>
				</tr>
				<%
End While
conn.Close()%>
			</tbody>
		</TABLE>
		<table><tr><td><a href='TaskList.aspx'>Работать со списком заданий</a></td></tr></table>
	</body>
</html>
