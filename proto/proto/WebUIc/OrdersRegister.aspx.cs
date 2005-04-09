using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebUIc
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected BusinessFacade.Component1 conn = new BusinessFacade.Component1();
		protected string date;

		private void Page_Load(object sender, System.EventArgs e)
		{
			date = string.Format("{0:dd MMMM}", System.DateTime.Today);
			if (Request.Form.Count == 0) return;

			switch (Request.Form.GetValues("Action")[0])
			{
				case "datechange":
					date = Request.Form.GetValues("Date")[0];
					break;
				case "register":
					conn.InsertOrder(Request.Form);
					break;
			}
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
