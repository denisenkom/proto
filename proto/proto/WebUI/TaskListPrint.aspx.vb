Public Class TaskListPrint
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

    Protected SubUnitId$
    Protected DateOfPakage$
    'Protected SubUnitName$
    Protected conn As New BusinessFacade.Component1

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' загрузка Кода бригады и даты из строки запроса
        SubUnitId = Request.QueryString("SubUnitId")
        DateOfPakage = Request.QueryString("DateOfPakage")

        ' определение названия подразделения
        'Dim cmd As Data.SqlClient.SqlCommand = SqlConnection1.CreateCommand()
        'cmd.CommandText = "SELECT Name FROM ProductionTasks WHERE Id=" & SubUnitId
        'SqlConnection1.Open()
        'Dim Reader As Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
        'SubUnitName = Reader(0)
        'SqlConnection1.Close()
    End Sub

End Class
