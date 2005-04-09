Public Class ReceiptList
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
    Protected rdr As SqlClient.SqlDataReader

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdr = conn.ExecuteReader("SELECT STR(r.Number) + '-' + r.ShopId, r.Date, r.Income, STR(r.OrderNumber) + '-' + r.ShopId, o.Date, o.Cost FROM Receipts AS r JOIN Orders AS o ON r.OrderNumber=o.Number AND r.Year=o.Year AND r.ShopId=o.ShopId ORDER BY r.Date, r.Number")
    End Sub

End Class
