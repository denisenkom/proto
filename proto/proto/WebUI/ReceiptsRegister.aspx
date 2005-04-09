<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReceiptsRegister.aspx.vb" Inherits="WebUI.Receipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Receipt</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" type="text/css" rel="stylesheet">
		<script src="scripts\constraint.js"></script>
		<script src="scripts\database.js" charset="windows-1251"></script>
		<script>

function FormatDate(date)
{
	var d = new Date(date);
	if (d == NaN)
		throw "Ошибка в формате даты";
		
	var ms = new Array("янв", "фев", "мар", "апр", "май", "июн", "июл", "авг", "сен", "окт", "ноя", "дек");
	return d.getDate() + " " + ms[d.getMonth()] + " " + d.getFullYear();
}

function Form1_onsubmit()
{
	var f = Form1
	if (!check_nz(f.HumanNumber, "Нужно заполнить номер чека.")
		|| !check_nz(f.ShopId, "Нужно выбрать магазин.")
		|| !check_date(f.Date, "Нужно заполнить дату чека.")
		|| !check_nz(f.OrderNumber, "Нужно заполнить номер заказа.")
		|| (f.Cost ? !check_nz(f.Cost, "Нужно заполнить стоимость заказа, она должна быть больше 0.") : false)
		|| !check_nz(f.Income, "Нужно заполнить сумму чека, она должна быть больше 0."))
		return false;

	return true;
}

// вызывается из 2-х мест
function Connect2Order()
{
	var f = Form1
	try {
		var rc = query("SELECT Cost, Paid, Year FROM Orders WHERE Number='" + f.OrderNumber.value + "' AND ShopId='" + f.ShopId.value + "'");
	}
	catch (e) {
		return alert("Произошла ошибка при запросе заказов из БД: " + e.description);
	}
	if (rc.EOF) {
		f.OrderNumber.focus();
		return alert("Нет заказов с таким номером и датой");
	}

	var cost = rc(0).Value;
	var paid = rc(1).Value;
	f.OrderYear.value = rc(2).Value;
	if (cost != null)
	{
		document.all["CostSpan"].innerText = cost;
	}
	else
	{
		document.all["CostSpan"].innerHTML = "<INPUT id=Cost type=text name=Cost size=5 onchange='return IncomeCost_onchange()' autocomplete=off>"
		f.Cost.focus();
	}
	document.all["Paid"].innerText = paid;
	document.all["Remain"].innerText = Number(cost) - paid
}

function DropConnect2Order()
{
	f.OrderNumber.value = "";
	f.Income.value = "";
	document.all["CostSpan"].innerHtml = "";
	document.all["Paid"].innerText = "";
	document.all["Remain"].innerText = ""
}

function HumanNumber_onchange()
{
	var f = Form1
	var empty = (f.HumanNumber.value == "");
	if (!empty)
		ParseHumanNumber(f);
	else
		DropConnect2Order();
	f.OrderNumber.readOnly = f.Income.readOnly = empty;
}

function OrderNumber_onchange()
{
	var f = Form1
	if (f.OrderNumber.value == "")
		return DropConnect2Order();
	else if (Number(f.OrderNumber.value) == NaN)
	{
		alert("В номер заказа вводите только число, без кода магазина.");
		return;
	}

	Connect2Order();
}

function IncomeCost_onchange()
{
	var Remain = document.all["Remain"];
	Remain.innerText = Number(f.Cost ? f.Cost.value : document.all["CostSpan"].innerText) - Number(document.all["Paid"].innerText) - Number(f.Income.value);
	Remain.style.color = Remain.innerText < 0 ? "red" : "black";
}

		</script>
	</HEAD>
	<body>
		<form id="Form1" onsubmit="return Form1_onsubmit()" method="post">
			<input type="hidden" name="Number" id="Number">
			<input type="hidden" name="OrderYear" id="OrderYear" value=<%=OrderYear%>>
			<h2>Форма регистрации оплат для заказов на <INPUT type="text" id="Date" name="Date" size="14" value="<%=String.Format("{0:d MMMM}",[Date])%>">
				для магазина
				<SELECT name="ShopId" id="ShopId">
					<OPTION selected></OPTION>
					<%
Dim rdr As Data.SqlClient.SqlDataReader
rdr = conn.ExecuteReader("SELECT Id, [Desc] FROM SubUnits WHERE class='shop'")
While rdr.Read()%>
					<OPTION value=<%=rdr(0)%> <%=IIf(rdr(0)=ShopId,"selected","")%>><%=rdr(0) & ": " & rdr(1)%></OPTION>
					<%
End While
conn.Close()%>
				</SELECT></h2>
			<table>
				<tr>
					<td align=left valign=top>
						Номер чека <INPUT type="text" id="HumanNumber" name="HumanNumber" size="5" autocomplete="off" onchange="return HumanNumber_onchange()">
						к заказу № <INPUT id="OrderNumber" type="text" onchange="return OrderNumber_onchange()" size="5"
								name="OrderNumber" autocomplete="off" value="<%=OrderNumber%>" readonly>
					</td>
					<td align=right valign=top>
						<table style="BORDER-RIGHT: black thin double; BORDER-TOP: black thin double; BORDER-LEFT: black thin double; BORDER-BOTTOM: black thin double">
							<tr>
								<td>
								стоимость
								<td align="right"><span id="CostSpan" style="FONT-WEIGHT: bolder"></span></td>
							</tr>
							<tr>
								<td>
									оплачено</td>
								<td align="right"><span id="Paid" style="FONT-WEIGHT: bolder"></span></td>
							</tr>
							<tr>
								<td>
									cумма оплаты</td>
								<td align="right"><INPUT id="Income" type="text" onchange="return IncomeCost_onchange()" size="6" name="Income"
										autocomplete="off" style="TEXT-ALIGN: right; FONT-WEIGHT: bold; FONT-FAMILY: Verdana, Helvetica, sans-serif; FONT-SIZE: .8em;" readonly></td>
							</tr>
							<tr>
								<td colspan="2"><hr>
								</td>
							</tr>
							<tr>
								<td>остаток</td>
								<td align="right"><span id="Remain" style="FONT-WEIGHT: bolder"> </span>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT type="submit" value="Регист...">
		</form>
		<script>
var f = Form1;
if (f.OrderNumber.value != "" && f.ShopId.value != "")
	Connect2Order();
if (f.ShopId.value == "") f.ShopId.focus(); else f.HumanNumber.focus();
//f.Date.value = FormatDate(new Date());

		</script>
		<TABLE width="100%" cellspacing="1" cellpadding="3">
			<THEAD>
				<tr>
					<TH colSpan="2">
						чек</TH>
					<TH rowspan="2">
						приход<br>
						(руб)</TH>
					<TH colSpan="2">
						к заказу</TH>
					<TH rowspan="2">
						стоимость<br>
						(руб)</TH>
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
rdr = conn.ExecuteReader(String.Format("SELECT STR(r.Number) + '-' + r.ShopId, r.Date, r.Income, STR(r.OrderNumber) + '-' + r.ShopId, o.Date, o.Cost FROM Receipts AS r JOIN Orders AS o ON r.OrderNumber=o.Number AND r.Year=o.Year AND r.ShopId=o.ShopId WHERE r.Date='{0}' ORDER BY r.Date, r.Number", [Date]))
While rdr.Read()%>
				<tr bgcolor="Silver">
					<td align="right"><%=rdr(0)%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(1))%></td>
					<td align="right"><%=String.Format("{0:0.##}",rdr(2))%></td>
					<td align="right"><%=rdr(3)%></td>
					<td><%=String.Format("{0:d MMMM}", rdr(4))%></td>
					<td align="right"><%=String.Format("{0:0.##}",rdr(5))%></td>
				</tr>
				<%
End While
conn.Close()%>
			</tbody>
		</TABLE>
	</body>
</HTML>
