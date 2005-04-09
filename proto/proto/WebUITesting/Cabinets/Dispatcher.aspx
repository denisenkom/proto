<%@ Page language="vb" AutoEventWireup="false" Codebehind="Dispatcher.aspx.vb" Inherits="WebUITesting.Dispatcher" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Dispatcher</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="..\Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form>
			<%
Dim d As Date = Date.Today
d = d.AddMonths(-1)
RenderCalendar(d)
d = d.AddMonths(1)
RenderCalendar(d)
d = d.AddMonths(1)
RenderCalendar(d)
	%>
		</form>
	</body>
</HTML>
