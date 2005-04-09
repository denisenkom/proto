<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReceiptList.aspx.vb" Inherits="WebUITesting.ReceiptList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ReceiptList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<TABLE width="100%" cellspacing="1" cellpadding="3">
			<THEAD>
				<tr>
					<TH colSpan="2">
						чек</TH>
					<TH rowspan="2">
						приход<br>(руб)</TH>
					<TH colSpan="2">
						к заказу</TH>
					<TH rowspan="2">
						стоимость<br>(руб)</TH>
				</tr>
				<tr>
					<TH>
						номер</TH>
					<TH>
						дата</TH>
					<TH>
						номер</TH>
					<TH>
						дата</TH>
				</tr>
			</THEAD>
			<tbody>
				<%
Dim colors$() = {"lavender", "lemonchiffon"}
Dim cur_col% = 0
While rdr.Read()%>
				<tr bgColor=<%=colors(cur_col)%>>
					<td align="right"><%=rdr(0)%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(1))%></td>
					<td align="right"><%=String.Format("{0:0.##}",rdr(2))%></td>
					<td align="right"><%=rdr(3)%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(4))%></td>
					<td align="right"><%=String.Format("{0:0.##}",rdr(5))%></td>
				</tr>
				<%
    cur_col = (cur_col + 1) Mod 2
End While
conn.Close()%>
			</tbody>
		</TABLE>
	</body>
</HTML>
