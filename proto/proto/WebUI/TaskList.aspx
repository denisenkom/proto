<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TaskList.aspx.vb" Inherits="WebUI.TaskListReturn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TaskListMake</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post">
			<input type="hidden" name="Action" id="Action">
			<h2>����� �������� � ������������ ������ �������</h2>
			�������������
			<SELECT name="SubUnitId" onchange="forms[0].submit()">
				<option selected></option>
				<%
Dim rdr As Data.SqlClient.SqlDataReader = conn.ExecuteReader("SELECT ID, [Desc] " _
	& "FROM SubUnits WHERE class='production' ORDER BY ID")
While rdr.Read()
	Dim id$ = rdr(0)%>
				<OPTION value=<%=id%> <%=IIf(SubUnitId = id, " selected ", "")%>><%=rdr(0) & ": " & rdr(1)%></OPTION>
				<%
End While
conn.Close()%>
			</SELECT>
			���� <input type=text name=DateOfPakage size=10 value="<%=DateOfPakage%>">
			<%
If SubUnitId <> "" Then
	Dim colors$() = {"lavender", "lemonchiffon"}
	Dim tasks_query$ = "SELECT Serial, StartDate, DateOfRelease, STR(Number) + '-' + o.ShopId AS ShortHumanNumber, Date, Description, o.Number, o.Year, o.ShopId " _
		& "FROM ProductionTasks AS pt JOIN Orders AS o ON pt.OrderNumber=o.Number AND pt.Year=o.Year AND pt.ShopId=o.ShopId " _
		& "WHERE state='{0}' AND SubUnitId='{1}' " _
		& "ORDER BY StartDate, DateOfRelease, Number, Date"
		
	rdr = conn.ExecuteReader(String.Format(tasks_query, _
		BusinessFacade.ProductionTasks.executing, SubUnitId))
	If rdr.HasRows Then%>
			<table>
				<caption>
					������������� �������</caption>
				<thead bgColor=Gold>
					<tr>
						<th colspan="2">
							�������</th>
						<th colspan="4">
							�����</th>
					</tr>
					<tr>
						<th>
							�</th>
						<th>
							����� ������</th>
						<th>
							���� ������</th>
						<th>
							�����</th>
						<th>
							����</th>
						<th>
							������� ��������</th></tr>
				</thead>
				<tbody>
					<%
		Dim cur_col% = 0
		While rdr.Read()
		%>
					<tr bgColor=<%=colors(cur_col)%>>
						<td><INPUT type=checkbox name=cb-<%=rdr(0)%> checked></td>
						<td><%=String.Format("{0:d MMMM}",rdr(1))%></td>
						<td><%=String.Format("{0:d MMMM}",rdr(2))%></td>
						<td align="right"><a href="OrderCard.aspx?page=Tasks&Number=<%=rdr(6)%>&Year=<%=rdr(7)%>&ShopId=<%=rdr(8)%>"><%=rdr(3)%></a></td>
						<td><%=String.Format("{0:d MMMM}",rdr(4))%></td>
						<td><%=rdr(5)%></td>
					</tr>
					<%
			cur_col = (cur_col + 1) Mod 2'��� ����������� ������
		End While
%>
				</tbody>
			</table>
			<ul>
				�������� ��� ���������� �������������� ���������
				<li>
					<a href='javascript:document.forms[0].Action.value="InputDoneUndone"; document.forms[0].submit()'>
						��������� ����������
						<%=DateOfPakage%>
						������</a>
				<li>
					<a href='javascript:document.forms[0].Action.value="RemoveTasks"; document.forms[0].submit()'>
						������ � ���������</a></li>
			</ul>
			<ul>
				������ ��������
				<li>
					<a href='TaskListPrint.aspx?SubUnitId=<%=SubUnitId%>&DateOfPakage=<%=DateOfPakage%>'>
						������</a>
					<%
		Dim s1$, s2$
		If DisplayWaitingTasks Then
			s1 = "HideAddWaiting" : s2 = "������ ���������"
		Else
			s1 = "ShowAddWaiting" : s2 = "�������� ���������"
		End If%>
				<li>
					<a href='javascript:document.forms[0].Action.value="<%=s1%>"; document.forms[0].submit()'>
						<%=s2%>
					</a>
				</li>
			</ul>
			<%
	Else%>
			<br>
			<strong style="COLOR: red">������������� ������� ���</strong>
			<%
		DisplayWaitingTasks = True ' ���� ��� ������������� ������� �� ����� ���������� ���������, �.�. ����� �����
	End If
	conn.Close()

	If DisplayWaitingTasks Then
		' �� �������������� �������
		rdr = conn.ExecuteReader(String.Format(tasks_query, _
			BusinessFacade.ProductionTasks.waiting, SubUnitId))
		If rdr.HasRows Then%>
			<hr width="100%">
			<ul>
				�������� ��� ���������� ���������� ���������
				<li>
					<a href='javascript:document.forms[0].Action.value="AddTasks"; document.forms[0].submit()'>
						��������� � ������ ������������� ��
						<%=DateOfPakage%>
						�����</a></li>
			</ul>
			<table>
				<caption>
					��������� �������</caption>
				<thead bgColor=LightSkyBlue>
					<tr>
						<th />
						<th colspan="4">
							�����</th>
					</tr>
					<tr>
						<th />
						<th>
							���� ������</th>
						<th>
							�����</th>
						<th>
							����</th>
						<th>
							������� ��������</th>
					</tr>
				</thead>
				<tbody>
					<%
			Dim cur_col% = 0
			While rdr.Read()%>
					<TR bgColor=<%=colors(cur_col)%>>
						<TD><INPUT type=checkbox name='cb+<%=rdr(0)%>'></TD>
						<TD><%=String.Format("{0: d MMMM}", rdr(2))%></TD>
						<td align="right"><%=rdr(3)%></td>
						<TD><%=String.Format("{0: d MMMM}", rdr(4))%></TD>
						<td><%=rdr(5)%></td>
					</TR>
					<%
					cur_col = (cur_col + 1) Mod 2
			End While%>
				</tbody>
			</table>
			<%
		Else 'Reader.HasRows%>
			<br>
			<strong style="COLOR: red">��������� ������� ���</strong>
			<%
		End If 'Reader.HasRows
		conn.Close()
	End If 'DisplayWaitingTasks
Else ' SubUnitId <> ""%>
			<br>
			<strong style="COLOR: red">����� ������� �������������</strong>
			<%
End If	' SubUnitId <> ""%>
		</form>
	</body>
</HTML>
