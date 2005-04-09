function check_nz(el, msg)
{
	if (el.value)
		return true;
		
	alert (msg);
	el.focus();
	return false;
}

function check_date(el, msg)
{
	if (el.value)
	{
		Date.parse(el.value);
		return true;
	}
		
	alert (msg);
	el.focus();
	return false;
}
