Public Class WebUserControl1
	Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents EnterBtn As System.Web.UI.WebControls.Button
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label

	'NOTE: The following placeholder declaration is required by the Web Form Designer.
	'Do not delete or move it.
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: This method call is required by the Web Form Designer
		'Do not modify it using the code editor.
		InitializeComponent()
	End Sub

#End Region

	Public InnerHTML As String = ""

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		InnerHTML = "ddd"
	End Sub

	Private Sub EnterBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterBtn.Click
		MsgBox("sdfasdf")
		Label1.Text() = "afsdf"
	End Sub
End Class
