<%@ Control Language="vb" AutoEventWireup="false" Codebehind="WebUserControl1.ascx.vb" Inherits="WebUITesting.WebUserControl1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
var sw = 0;
function Colapse_OnClick()
{
    ExposeDiv.filters[1].Apply();
    ExposeDiv.filters[0].Apply();
	switch (sw)
	{
	case 0:
		ColapseExplodeImg.src = "images/winexpose.bmp";
		ExposeDiv.style.visibility = "hidden";
		ExposeDiv.filters[0].motion = "reverse";
		sw = 1;
		break;
	case 1:
		ColapseExplodeImg.src = "images/wincolapse.bmp";
		ExposeDiv.style.visibility = "visible";
		ExposeDiv.filters[0].motion = "forward";
		sw = 0;
		break;
	}
    ExposeDiv.filters[1].Play();
	ExposeDiv.filters[0].Play();
}
</script>
<table bgcolor="#b8bbcd">
	<tr>
		<td>
			<table cellspacing="0" cellpadding="0" width="200" bgcolor="#d7d8e1" style="FILTER: progid: DXImageTransform.Microsoft.Gradient(startColorStr='#FFFFFF', endColorStr='#D7D8E1', gradientType='1')">
				<tr>
					<td><img src="images/i-t-ugbr.bmp"></td>
					<td></td>
					<td></td>
					<td align="right"><img src="images/i-t-ugbl.bmp"></td>
				</tr>
				<tr>
					<td></td>
					<td><a href="javascript:Colapse_OnClick()" style="FONT-SIZE: x-small">Задачи</a></td>
					<td align="right"><a href="javascript:Colapse_OnClick()"><img id="ColapseExplodeImg" src="images/wincolapse.bmp" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></a></td>
					<td></td>
				</tr>
			</table>
			<div id="ExposeDiv" style="FILTER: progid: DXImageTransform.Microsoft.GradientWipe(Duration=0.5,Overlap=1.0,WipeStyle=1,GradientSize=0.1)progid: DXImageTransform.Microsoft.Fade(Duration=0.5,Overlap=1.0); VISIBILITY: visible; WIDTH: 200px; HEIGHT: 400px">
				<table id="Table1" cellspacing="0" cellpadding="0" width="200" bgcolor="#f0f1f5" bordercolor="#ffffff"
					border="1">
					<tr height="300">
						<td>
						</td>
					</tr>
				</table>
			</div>
		</td>
	</tr>
</table>
