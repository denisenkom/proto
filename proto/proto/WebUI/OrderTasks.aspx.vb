Public Class OrderTasks
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
    Protected Number%
    Protected Year%
    Protected ShopId$

    Private Const InsertQueryFmt = "INSERT INTO ProductionTasks(OrderNumber, Year, ShopId, SubUnitId, state) SELECT {0},{1},'{2}',Id,'waiting' FROM SubUnits WHERE Id IN ({3})"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Request.QueryString.Count > 0 Then
            Number = Request.QueryString("Number")
            Year = Request.QueryString("Year")
            ShopId = Request.QueryString("ShopId")
        End If
        If Request.Form.Count > 0 Then
            Number = Request.Form("Number")
            Year = Request.Form("Year")
            ShopId = Request.Form("ShopId")
            Dim Action$ = Request.Form("Action")
            Select Case Action
                Case "AddTasks"
                    AddRemoveTasks("+")
                Case "RemoveTasks"
                    AddRemoveTasks("-")
                Case Else
                    If Action.Substring(0, 13) = "ApplyTemplate" Then
                        Dim suid$
                        Select Case Action.Substring(13)
                            Case "Kitchen"
                                suid = "'«¿√',' ”’','“Œ '"
                            Case "Office"
                                suid = "'«¿√','Œ‘','“Œœ'"
                            Case "Sofas"
                                suid = "'—¡Ã','ÿ¬≈'"
                            Case "Tables"
                                suid = "'Œ¡ƒ','—¡Ã'"
                        End Select
                        Diagnostics.Debug.Assert(suid <> "")
                        conn.ExecuteScalar(String.Format(InsertQueryFmt, Number, Year, ShopId, suid))
                    End If
            End Select
        End If
    End Sub

    Private Sub AddRemoveTasks(ByVal pm As Char)
        Dim suid$
        Diagnostics.Debug.Assert(pm = "+" Or pm = "-")
        For Each nm As String In Request.Form.Keys
            If nm.Substring(0, 3) = "cb" & pm And Request.Form(nm) = "on" Then
                suid = suid & IIf(suid = "", "", ",") & "'" & nm.Substring(3) & "'"
            End If
        Next
        If suid = "" Then Exit Sub
        conn.ExecuteScalar(String.Format(IIf(pm = "+", _
            InsertQueryFmt, _
            "DELETE FROM ProductionTasks WHERE OrderNumber={0} AND Year={1} AND ShopId = '{2}' AND SubUnitId IN ({3})"), _
            Number, Year, ShopId, suid))
    End Sub

End Class
