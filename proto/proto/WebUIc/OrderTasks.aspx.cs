using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace WebUIc
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
		protected BusinessFacade.Component1 conn;
		protected int Number;
		protected int Year;
		protected string ShopId;

		private const string InsertQueryFmt = "INSERT INTO ProductionTasks(OrderNumber, Year, ShopId, SubUnitId, state) SELECT {0},{1},'{2}',Id,'waiting' FROM SubUnits WHERE Id IN ({3})";

		private void Page_Load(object sender, System.EventArgs e)
		{
			NameValueCollection nv = null;
			if (Request.QueryString.Count > 0)
				nv = Request.QueryString;
			if (Request.Form.Count > 0)
				nv = Request.Form;
			if (nv != null)
				return;

			Number = int.Parse(nv.GetValues("Number")[0]);
			Year = int.Parse(nv.GetValues("Year")[0]);
			ShopId = nv.GetValues("ShopId")[0];
			string Action = nv.GetValues("Action")[0];
			if (Action == "AddTasks")
				AddRemoveTasks('+');
			else if (Action == "RemoveTasks")
				AddRemoveTasks('-');
			else if (Action.Substring(0, 13) == "ApplyTemplate")
			{
				string suid = "";
				switch (Action.Substring(13))
				{
					case "Kitchen":
						suid = "'«¿√',' ”’','“Œ '";
						break;
					case "Office":
						suid = "'«¿√','Œ‘','“Œœ'";
						break;
					case "Sofas":
						suid = "'—¡Ã','ÿ¬≈'";
						break;
					case "Tables":
						suid = "'Œ¡ƒ','—¡Ã'";
						break;
				}
				Debug.Assert(suid != "");
				conn.ExecuteScalar(String.Format(InsertQueryFmt, Number, Year, ShopId, suid));
			}
		}

		private void AddRemoveTasks(char pm)
		{
			string suid = "";
			Debug.Assert(pm == '+' || pm == '-');
			foreach (string nm in Request.Form.Keys)
				if (nm.Substring(0, 3) == "cb" + pm && Request.Form.GetValues(nm)[0] == "on")
					suid = suid + (suid == "" ? "" : ",") + "'" + nm.Substring(3) + "'";

			if (suid == "") return;
			conn.ExecuteScalar(String.Format(pm == '+' ? InsertQueryFmt : "DELETE FROM ProductionTasks WHERE OrderNumber={0} AND Year={1} AND ShopId = '{2}' AND SubUnitId IN ({3})", Number, Year, ShopId, suid));
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
