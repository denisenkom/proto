<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrdersList.aspx.vb" Inherits="WebUI.OrdersList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrdersList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>����� ��������� � ������ �������</h1>
		<form id="Form1" method="get">
			<P>�� ������ ��� �������� <INPUT id="Query" type="text" size="5" name="Query" value="<%=Query %>">
				<INPUT id="Search" type="submit" value="�����" name="Search"></P>
			<P>������ <INPUT id="FilterOn" type=checkbox name=FilterOn <%=IIf(FilterOn, "CHECKED", "") %>>: 
				�� ���� <INPUT id=FilterDate type=text size="14" name="FilterDate" value="<%=FilterDate %>">
				�������� <INPUT id="ByReceiveDate" type=radio name=ByReceiveDate onclick="ByReleaseDate.checked=false" <%=IIf(Not ByReleaseDate,"CHECKED","") %>>
				, ������ <INPUT id=ByReleaseDate type=radio name=ByReleaseDate onclick="ByReceiveDate.checked=false" <%=IIf(ByReleaseDate,"CHECKED","") %>>
				(&lt;<INPUT id=Lower type=checkbox name=Lower onclick="Greater.checked=false" <%=IIf(Lower,"CHECKED","") %>>
				&gt;<INPUT id=Greater type=checkbox name=Greater onclick="Lower.checked=false" <%=IIf(Greater,"CHECKED","") %>>
				=<INPUT id=Equal type=checkbox name=Equal <%=IIf(Equal,"CHECKED","") %>>)</P>
		</form>
		<TABLE width="100%">
			<thead>
				<TR>
					<TH>
						�����</TH>
					<TH>
						����</TH>
					<TH>
						���� ������</TH>
					<TH>
						��������</TH>
					<TH>
						�</TH>
					<TH>
						�����</TH>
					<TH>
						�</TH>
				</TR>
			</thead>
			<tbody>
				<%
Dim OrderCount = 0
While rdr.Read()
	Dim PayLevel = rdr(6)
	Dim color$
	Dim img$
	If Not IsDbNull(PayLevel) Then
		Dim x% = PayLevel
		PayLevel = x
		If PayLevel >= 100 Then
			color = "#c7ebd1"
			img = "green"
		ElseIf PayLevel >= 50 Then
			color = "#f2c368"
			img = "yellow"
		Else
			color = "#eeac7d"
			img = "red"
		End If
	Else
		color = "#dedede"
		img = "gray"
	End If%>
				<tr bgColor=<%=color%>>
					<td align="right"><a href='OrderTasks.aspx?Number=<%=rdr(7)%>&Year=<%=rdr(8)%>&ShopId=<%=rdr(9)%>'><%=rdr(0)%></a></td>
					<td><%=String.Format("{0:d MMMM}", rdr(1))%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(2))%></td>
					<td><%=rdr(3)%></td>
					<td><%If rdr(4) Then%><IMG src='images\<%=img%>level.bmp' alt='�������� ����'><%End If%></td>
					<td><%=rdr(5)%></td>
					<td><IMG src='images\<%=img%>level.bmp' alt='������ <%=IIf(Not IsDbNull(PayLevel), PayLevel & "%", "��� ������")%>'></td>
				</tr>
				<%
    OrderCount = OrderCount + 1
End While
conn.Close()%>
			</tbody>
			<tfoot>
				<tr>
					<td colspan="8">
						�����
						<%=OrderCount%>
						�������</td>
				</tr>
			</tfoot>
		</TABLE>
		<HR width="100%" SIZE="1">
		<table><tr><td><a href='OrdersRegister.aspx'>���� �������</a></td></tr></table>
	</body>
</HTML>
