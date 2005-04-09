<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProducingSubunitsList.aspx.vb" Inherits="WebUITesting.ProducingSubunitsList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ProducingSubunitsList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type=text/css rel=stylesheet>
	</HEAD>
	<body>
	<table><tbody>
			<%
Dim Reader As Data.SqlClient.SqlDataReader = qry("SELECT Id, Name " _
	& "FROM SubUnits WHERE class='production' ORDER BY Name")
While Reader.Read()
	Response.Write("<tr><td><img src='images\redlevel.bmp'></td>" _
		& "<td><a href='TaskListMake.aspx?SubUnitId=" & Reader(0) & "'>" & Reader(0) & ": " & Reader(1) & "</td></tr>")
End While
%>
</tbody></table>
	</body>
</HTML>
