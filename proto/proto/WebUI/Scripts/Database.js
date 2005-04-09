function query(q)
{
	var con = new ActiveXObject("ADODB.Connection");
	con.Open("Provider=SQLOLEDB.1;integrated security=SSPI;data source=(local)");
	//var x = new ActiveXObject("ADODB.Recordset");
	//x.MoveLast()
	return con.Execute(q);
}

function ParseHumanNumber(f)
{
	f.HumanNumber.value = String(f.HumanNumber.value).toUpperCase();
	var r1 = /[0-9]+/;
	var arr = r1.exec(f.HumanNumber.value);
	if (arr == null)
	{
		alert("Ошибка. Номер не содержит порядкового номера.");
		return;
	}
	f.Number.value = arr.toString();
		
	// определяем код магазина из номера
	var re = /[А-Яа-я]+/;
	re.ignoreCase = true;
	var arr = re.exec(f.HumanNumber.value)
	if (arr == null)
		return;
		
	// проверяем код магазина по базе данных
	var shopid = arr.toString().toUpperCase();
	var rc = query("SELECT Id FROM SubUnits WHERE Class='shop' AND Id='" + shopid + "'");
	if (rc.EOF)
	{
		alert("Ошибка: Код магазина, указанный в номере '" + shopid + "' неправильный.")
		return;
	}
	f.ShopId.value = shopid;
}