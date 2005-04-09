<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControlTest.aspx.vb" Inherits="WebUITesting.ControlTest"%>
<%@ Register TagPrefix="Acme" TagName="Ctrl" Src="~\Controls\WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>ControlTest</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
    <form id="Form1" method="post" runat="server">
    here is control
		<Acme:Ctrl runat="server"></Acme:Ctrl>
    </form>

  </body>
</html>
