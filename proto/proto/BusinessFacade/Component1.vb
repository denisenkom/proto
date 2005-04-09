Public Class Component1
    Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SqlConnection.ConnectionString = Config.ConnectionString
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region
    Private SqlConnection As New SqlClient.SqlConnection

    Public Sub InsertOrder(ByVal f As System.collections.specialized.NameValueCollection)
        Dim cmd As SqlClient.SqlCommand = SqlConnection.CreateCommand()
        cmd.CommandText = "INSERT INTO Orders (Number,Date,DateOfRelease,HaveDelivery," _
            & "DeliveryAddress,ShopId,DesignerId,Description,Year)" _
            & "VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@Year)"

        Dim keys$() = {"Number", "Date", "DateOfRelease", "HaveDelivery", _
            "DeliveryAddress", "ShopId", "SellerId", "Description"}

        ' кодирование года
        Dim year% = Date.Parse(f("Date")).Year - 1970
        ' и добавление соотв параметра в команду
        Dim parcode As New SqlClient.SqlParameter("@Year", year)
        cmd.Parameters.Add(parcode)

        Dim i%
        For i% = 0 To keys.Length - 1
            Dim par As New SqlClient.SqlParameter(String.Concat("@", i), "")
            Dim s$ = f.Item(keys(i))
            If i = 1 Or i = 2 Then
                ' datetime
                par.SqlDbType = SqlDbType.DateTime
                par.Value = DateTime.Parse(s, Globalization.CultureInfo.CurrentCulture)
            ElseIf i = 3 Then
                ' bit
                par.SqlDbType = SqlDbType.Bit
                par.Value = String.Equals(s, "on")
            ElseIf i = 0 Then
                ' int
                par.SqlDbType = SqlDbType.Int
                If s <> "" Then par.Value = Integer.Parse(s) Else par.Value = DBNull.Value
            Else
                ' text 
                par.Value = IIf(s <> "", s, DBNull.Value)
            End If
            cmd.Parameters.Add(par)
        Next
        Open()
        cmd.ExecuteScalar()
        Close()
    End Sub

    Function CreateCommand() As SqlClient.SqlCommand
        CreateCommand = SqlConnection.CreateCommand
    End Function

    Function CreateCommand(ByVal CommandText As String) As SqlClient.SqlCommand
        Dim cmd As New SqlClient.SqlCommand(CommandText, SqlConnection)
        cmd.CommandText = CommandText
        CreateCommand = cmd
    End Function

    Function Open()
        SqlConnection.Open()
    End Function

    Function Close()
        SqlConnection.Close()
    End Function

    Function ExecuteReader(ByVal CommandText As String) As SqlClient.SqlDataReader
        Open()
        ExecuteReader = CreateCommand(CommandText).ExecuteReader()
    End Function

    Function ExecuteScalar(ByVal CommandText As String) As Object
        Open()
        ExecuteScalar = CreateCommand(CommandText).ExecuteScalar()
        Close()
    End Function
End Class
