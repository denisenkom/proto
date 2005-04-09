

function Colapse_OnClick(uid)
{
	if (typeof(document.all[uid + "sw"]) == "undefined")
		this[uid + "sw"] = false;
		
	var sw     = document.all[uid + "sw"];
	var expDiv = document.all[uid + "ExposeDiv"];
	var expImg = document.all[uid + "ColapseExplodeImg"];
	
	expDiv.filters[0].Apply();
	if (!sw)
	{
		expImg.src = "images/winexpose.bmp";
		//expDiv.style.visibility = "hidden";
		expDiv.style.display = "none";
		expDiv.filters[0].motion = "reverse";
	}
	else
	{
		expImg.src = "images/wincolapse.bmp";
		//expDiv.style.visibility = "visible";
		expDiv.style.display = "";
		expDiv.filters[0].motion = "forward";
	}
	expDiv.filters[0].Play();
	document.all[uid + "sw"] = !sw;
}