Public Class Receipt
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
    Protected [Date] As Date
    Protected ShopId$
    Protected OrderNumber$
    Protected OrderYear$

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As Collections.specialized.NameValueCollection

        f = Request.QueryString
        If f.Count > 0 Then
            OrderNumber = f("OrderNumber")
            OrderYear = f("OrderYear")
            ShopId = f("ShopId")
        End If

        [Date] = Date.Today

        f = Request.Form()
        If f.Count = 0 Then Exit Sub ' form empty (no form)

        [Date] = f("Date")
        ShopId = f("ShopId")

        Dim cmd As SqlClient.SqlCommand = conn.CreateCommand("InsertReceipt")
        cmd.CommandType = CommandType.StoredProcedure

        ' имена должны соответствовать именам элементов html формы
        ' должны соответствовать названию параметров процедуры InsertReceipt
        Dim keys$() = {"Number", "OrderNumber", "OrderYear", _
            "ShopId", "Date", "Income", "Cost"}

        For Each key As String In keys
            Dim par As System.Data.SqlClient.SqlParameter = cmd.CreateParameter()
            par.ParameterName = String.Concat("@", key)
            ' для различных типов параметров
            Dim s$ = f.Item(key)
            Select Case key
                Case "Number", "OrderNumber", "OrderYear"
                    par.Value = Integer.Parse(s)
                Case "Date"
                    par.Value = System.DateTime.Parse(s, System.Globalization.CultureInfo.CurrentCulture)
                Case "Income", "Cost"
                    ' именно так, если исп. IIf то Parse будет всегда вычисляться
                    par.SqlDbType = SqlDbType.Money
                    If Not s Is Nothing Then
                        par.Value = Double.Parse(s)
                    Else
                        par.Value = DBNull.Value
                    End If
                Case "ShopId"
                    par.Value = s
            End Select
            cmd.Parameters.Add(par)
        Next

        conn.Open()
        cmd.ExecuteScalar()
        conn.Close()
    End Sub

End Class
