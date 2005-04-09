<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderRegister.aspx.vb" Inherits="WebUITesting.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="scripts\constraint.js"></script>
		<script src="scripts\database.js"></script>
		<script src="scripts\OrderScripts.js" charset="windows-1251"></script>
		function Form1_onsubmit() { if (!check_nz(Form1.Number, "����� ��������� ����� 
		������.") || !check_date(Form1.DateOfOrd, "����� ��������� ���� ������.") || 
		!check_date(Form1.DateOfRelease, "����� ��������� ���� ������.")) return false; 
		if (!Form1.DataValid.checked) { alert ("����� ��������� ������� \"������ 
		���������\""); Form1.DataValid.focus(); return false; } return true; }
	</HEAD>
	<body bgColor="ivory">
		<form name="Form1" onsubmit="return Form1_onsubmit()" method="post">
			<input type="hidden" name="SerialNumber" id="SerialNumber">
			<h1 align="center">����� ����������� �������</h1>
			<table>
				<tbody>
					<tr>
						<td>
							<P align="center"><STRONG>����� �</STRONG> <INPUT id="Number" type="text" onchange="return Number_onchange()" size="5" autocomplete="off">
								<STRONG>��</STRONG> <INPUT type="text" size="14" name="DateOfOrd" autocomplete="on">,
								<STRONG>���� ������</STRONG> <INPUT id="DateOfRelease" type="text" size="14" name="DateOfRelease" autocomplete="on"></P>
							<P>��������? <INPUT id="HaveDelivery" onclick="return HaveDelivery_onclick()" type="checkbox" name="HaveDelivery">, 
								����� �������� <INPUT id="DeliveryAddress" disabled type="text" size="72" name="DeliveryAddress" autocomplete="off"></P>
							<P>�������
								<SELECT id="ShopId" name="ShopId" disabled>
									<OPTION selected></OPTION>
									<%
Dim cmd As Data.SqlClient.SqlCommand = SqlConnection1.CreateCommand()
cmd.CommandText = "SELECT Id, Name FROM SubUnits WHERE class='shop'"
SqlConnection1.Open()
Dim Reader As Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
While Reader.Read()
	Response.Write("<OPTION value=" & Reader(0) & ">" & Reader(0) & ": " & Reader(1) & "</OPTION>")
End While
SqlConnection1.Close()
%>
									<!--<script>
// ���������� ������ ���������
var rc = query("SELECT Id, Name FROM SubUnits WHERE class='shop'");
while (!rc.EOF)
{
	var o = document.createElement("OPTION");
	o.value = rc(0);
	o.text = rc(0) + ": " + rc(1)
	Form1.ShopId.add(o);
	rc.MoveNext();
}
									</script>-->
								</SELECT>
								��������
								<SELECT id="SellerId" name="SellerId">
									<OPTION selected></OPTION>
								</SELECT>
							</P>
							<P>��������:</P>
							<P><TEXTAREA id="Description" name="Description" rows="5" cols="70"></TEXTAREA></P>
						</td>
						<td>
							�������� �������������, � ������� ������� ��������� ���� �����.<br>
							<SELECT name="SubUnitId" size="21" type="select-multiple" multiple>
								<%
cmd.CommandText = "SELECT Id, Name FROM SubUnits WHERE class='production'"
SqlConnection1.Open()
Reader = cmd.ExecuteReader()
While Reader.Read()
	Response.Write("<OPTION value=" & Reader(0) & ">" & Reader(0) & ": " & Reader(1) & "</OPTION>")
End While
SqlConnection1.Close()
%>
							</SELECT>
						</td>
					</tr>
				</tbody>
			</table>
			<P align="center">������ �����? <INPUT id="DataValid" onclick="Form1.Submit1.focus();" type="checkbox" name="DataValid"><INPUT id="Submit1" type="submit" value="�������" name="Submit1"></P>
		</form>
		<HR width="100%" SIZE="1">
		<FONT size="1">* ���������� ������� ������������ ��� ���������� ����.</FONT>
		<script>
<!--
document.Form1.Number.focus();
// ������������ ���� �� ��������� �����������
var date = new Date();
document.Form1.DateOfOrd.value = date.toLocaleDateString();

//-->
		</script>
	</body>
</HTML>
