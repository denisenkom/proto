<%@ Control Language="VB" AutoEventWireup="false" Codebehind="WebUserControl1.ascx.vb" Inherits="WebUITesting.WebUserControl1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript" src="controls/client.js"></script>
<TABLE cellSpacing="0" cellpadding="0" width="200" style="FILTER: progid:DXImageTransform.Microsoft.Gradient(startColorStr='#FFFFFF', endColorStr='#D7D8E1', gradientType='1')">
	<TR>
		<TD><IMG src="images/i-t-ugbr.bmp"></TD>
		<TD></TD>
		<TD></TD>
		<TD align="right"><IMG src="images/i-t-ugbl.bmp"></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD><A style="FONT-SIZE: x-small" href="javascript:Colapse_OnClick('<%=UniqueID()%>')">Задачи</A></TD>
		<TD align="right"><A href="javascript:Colapse_OnClick('<%=UniqueID()%>')"><IMG id="<%=UniqueID()%>ColapseExplodeImg" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" src="images/wincolapse.bmp"></A></TD>
		<TD></TD>
	</TR>
</TABLE>
<DIV id="<%=UniqueID()%>ExposeDiv" style="FILTER: progid:DXImageTransform.Microsoft.GradientWipe(Duration=0.3,Overlap=1.0,WipeStyle=1,GradientSize=0.1); WIDTH: 200px; HEIGHT: 400px">
	<TABLE cellSpacing="0" cellpadding="0" width="200" height="400" bgColor="#f0f1f5" border="1" borderColor="#ffffff">
		<TR>
			<TD>
				<asp:Button id="EnterBtn" Text="Button" runat="server"></asp:Button>
				<asp:Label id="Label1" runat="server">Label</asp:Label></TD>
		</TR>
	</TABLE>
</DIV>
