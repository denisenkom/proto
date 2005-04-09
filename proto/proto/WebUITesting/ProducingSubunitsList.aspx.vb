Public Class ProducingSubunitsList
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=LOCAL;packet size=4096;integrated security=SSPI;data source=""(loca" & _
        "l)"";persist security info=False;initial catalog=main"

    End Sub
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Public Function qry(ByVal sql As String) As Data.SqlClient.SqlDataReader
        Dim cmd As Data.SqlClient.SqlCommand = SqlConnection1.CreateCommand()
        cmd.CommandText = sql
        SqlConnection1.Open()
        qry = cmd.ExecuteReader()
    End Function
End Class
