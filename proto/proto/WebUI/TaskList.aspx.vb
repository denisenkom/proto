Imports BusinessFacade.ProductionTasks

Public Class TaskListReturn
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

    Protected SubUnitId$
    Protected DateOfPakage$
    Protected DisplayWaitingTasks As Boolean

    Private Sub update_tasks_state(ByVal ctrl As String, ByVal newstate As String)
        Dim serials$
        Dim nm$
        For Each nm In Request.Form.Keys
            If nm.Substring(0, 3) = ctrl And Request.Form(nm) = "on" Then
                serials = serials & IIf(serials = "", "", ",") & nm.Substring(3)
            End If
        Next
        If serials = "" Then Exit Sub
        conn.ExecuteScalar(String.Format("UPDATE ProductionTasks SET state='{0}', {1}={2} WHERE SubUnitId='{3}' AND Serial IN ({4})", _
            newstate, IIf(newstate = done, "EndDate", "StartDate"), _
            IIf(newstate = waiting, "NULL", "'" & DateOfPakage & "'"), _
            SubUnitId, serials))
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayWaitingTasks = False
        DateOfPakage = Date.Today
        If Request.QueryString.Count > 0 Then
            SubUnitId = Request.QueryString("SubUnitId")
        End If
        Dim f As Collections.Specialized.NameValueCollection = Request.Form
        If f.Count > 0 Then
            SubUnitId = f("SubUnitId")
            DateOfPakage = f("DateOfPakage")
            Select Case (f("Action"))
                Case "ShowAddWaiting"
                    DisplayWaitingTasks = True

                Case "InputDoneUndone"
                    update_tasks_state("cb-", done)

                Case "AddTasks"
                    update_tasks_state("cb+", executing)

                Case "RemoveTasks"
                    update_tasks_state("cb-", waiting)
            End Select
        End If
    End Sub

End Class
