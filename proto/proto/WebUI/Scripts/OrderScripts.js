function HaveDelivery_onclick()
{
	Form1.DeliveryAddress.disabled = !Form1.HaveDelivery.checked;
	if (Form1.HaveDelivery.checked)
		Form1.DeliveryAddress.select();
}

function HumanNumber_onchange()
{
	var f = Form1;
	ParseHumanNumber(f);
	ShopId_onchange();
	
	// �������� ���������� ������ � ����� �� �������
	//if (serial != null && year != null && shopid != null)
	//{
	//	rc = query("SELECT Id FROM Orders WHERE Number='" + serial + "' AND year='" & year & "' AND ShopId='" & shopid & "');
	//	if (!rc.EOF)
	//		alert("������: ����� � ����� ����� ��� ����������. ����� �� ����� ������ � ��.");
	//}
}

function ShopId_onchange()
{
	var s = Form1.SellerId;
	// ������� ��� ����� �� SellerId (����� ������ - 0-�)
	while (s.children.length > 1) s.removeChild(s.children.item(1));
	var rc = query("SELECT Id FROM Employees JOIN SubUnitsEmployees "+
		"ON Id=EmployeeId AND SubUnitId='" + Form1.ShopId.value + "'");
	while (!rc.EOF)
	{
		var o = document.createElement("OPTION");
		o.value = o.text = rc(0);
		s.add(o);
		rc.MoveNext();
	}
}