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
		alert("������. ����� �� �������� ����������� ������.");
		return;
	}
	f.Number.value = arr.toString();
		
	// ���������� ��� �������� �� ������
	var re = /[�-��-�]+/;
	re.ignoreCase = true;
	var arr = re.exec(f.HumanNumber.value)
	if (arr == null)
		return;
		
	// ��������� ��� �������� �� ���� ������
	var shopid = arr.toString().toUpperCase();
	var rc = query("SELECT Id FROM SubUnits WHERE Class='shop' AND Id='" + shopid + "'");
	if (rc.EOF)
	{
		alert("������: ��� ��������, ��������� � ������ '" + shopid + "' ������������.")
		return;
	}
	f.ShopId.value = shopid;
}