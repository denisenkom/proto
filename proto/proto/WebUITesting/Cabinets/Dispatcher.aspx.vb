Public Class Dispatcher
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Protected Sub RenderCalendar(ByVal MonthYear As Date)
        Dim d As Date = MonthYear
        d = d.AddDays(1 - d.Day)
        Diagnostics.Debug.Assert(d.Day = 1)
        Response.Write(String.Format("<table><caption>{0:MMMM}</caption><thead><tr><th>��</th><th>��</th><th>��</th><th>��</th><th>��</th><th style='COLOR: blue'>��</th><th style='COLOR: red'>��</th></tr></thead><tbody valign=top><tr>", d))
        ' ���� �� ����������� (��=1, ��=0), �� ���������� ��� �� ����������� ������
        Dim scip% = d.DayOfWeek - 1
        If scip < 0 Then scip = 6
        If scip > 0 Then
            Response.Write(String.Format("<td colspan={0}></td>", scip))
        End If
        Dim LastDay% = Date.DaysInMonth(d.Year, d.Month)
        Diagnostics.Debug.Assert(LastDay = 28 Or LastDay = 29 Or LastDay = 30 Or LastDay = 31)
        Dim rdr As Data.SqlClient.SqlDataReader = conn.ExecuteReader(String.Format("SELECT STR(Number)+'-'+ShopId, DateOfRelease, Number, Year, ShopId FROM Orders WHERE MONTH(DateOfRelease)={0} ORDER BY DateOfRelease", d.Month))
        Dim rdrRead As Boolean = rdr.Read
        ' ���� �� ����
        Do
            Diagnostics.Debug.Assert(d.Day >= 1)
            ' �������� ������ � ��������� �� ����������� ���� (���� ������� �� ���������� ������)
            ' � ����� � ������ ������ ���, ����� �������� <br>
            Response.Write(String.Format("<td bgcolor=MistyRose{0}>{1}<br>", IIf(d = Date.Today, " style='BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-STYLE: solid; BORDER-TOP-COLOR: red; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-RIGHT-COLOR: red; BORDER-BOTTOM-STYLE: solid'", ""), d.Day))
            ' ���� �� ������� � ����� ������ = d
            While rdrRead
                Dim cmp% = d.CompareTo(rdr(1))
                Diagnostics.Debug.Assert(cmp <= 0)
                If cmp < 0 Then Exit While
                ' ����� ����������� ��� �������
                Response.Write(String.Format("<a href='..\OrderCard.aspx?page=Tasks&Number={0}&Year={1}&ShopId={2}'>{3}</a>", rdr(2), rdr(3), rdr(4), rdr(0)))
                rdrRead = rdr.Read
                ' ���� ��� ������ �������, �� ��������� ����������
                If Not rdrRead Then conn.Close()
            End While
            Response.Write("</td>") ' �������� ������
            d = d.AddDays(1) ' ������� � ���������� ���
            Diagnostics.Debug.Assert(d.Day >= 2)
            ' ���� ����� ���� - �� � �� ������ ���� ������ ������,
            ' �� �������� ����� ������
            If d.DayOfWeek = 1 And d.Day <> 1 Then Response.Write("</tr><tr>")
        Loop While d.Day <> 1
        ' �������� ������, � �������
        Response.Write("</tr></tbody></table>")
    End Sub

End Class
