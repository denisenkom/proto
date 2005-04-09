Public Class OrdersRegister
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected conn As New BusinessFacade.Component1
    Protected [Date] As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        [Date] = Date.Today
        If Request.Form.Count = 0 Then Exit Sub

        Select Case Request.Form("Action")
            Case "datechange"
                [Date] = Request.Form("Date")
            Case "register"
                conn.InsertOrder(Request.Form())
        End Select
    End Sub

End Class
