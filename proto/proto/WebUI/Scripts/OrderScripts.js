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
	
	// проверим отсутствие заказа с таким же номером
	//if (serial != null && year != null && shopid != null)
	//{
	//	rc = query("SELECT Id FROM Orders WHERE Number='" + serial + "' AND year='" & year & "' AND ShopId='" & shopid & "');
	//	if (!rc.EOF)
	//		alert("Ошибка: Заказ с таким кодом уже существует. Заказ не будет принят в БД.");
	//}
}

function ShopId_onchange()
{
	var s = Form1.SellerId;
	// Удаляем все опции из SellerId (кроме пустой - 0-й)
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