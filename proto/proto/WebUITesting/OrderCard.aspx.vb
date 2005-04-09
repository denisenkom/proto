Public Class OrderCard
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
    Protected Number%
    Protected Year%
    Protected ShopId$
    Protected Shadows [Page] As String

    Protected Structure OrderPage
        Public Id$
        Public href
        Public Menu$
    End Structure

    Protected OrderPages(2) As OrderPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OrderPages(0).Id = "Tasks"
        OrderPages(0).href = "OrderTasks.aspx"
        OrderPages(0).Menu = "Выполнение"
        OrderPages(1).Id = "Receipts"
        OrderPages(1).href = "OrderReceipts.aspx"
        OrderPages(1).Menu = "Оплата"
        OrderPages(2).Id = "Draft"
        OrderPages(2).href = "OrderDraft.aspx"
        OrderPages(2).Menu = "Эскиз"
        If Request.QueryString.Count > 0 Then
            [Page] = Request.QueryString("Page")
            Number = Request.QueryString("Number")
            Year = Request.QueryString("Year")
            ShopId = Request.QueryString("ShopId")
        End If
    End Sub

End Class
