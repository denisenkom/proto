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
        Response.Write(String.Format("<table><caption>{0:MMMM}</caption><thead><tr><th>ПН</th><th>ВТ</th><th>СР</th><th>ЧТ</th><th>ПТ</th><th style='COLOR: blue'>СБ</th><th style='COLOR: red'>ВС</th></tr></thead><tbody valign=top><tr>", d))
        ' если не понедельник (ПН=1, ВС=0), то пропустить дни из предыдущего месяца
        Dim scip% = d.DayOfWeek - 1
        If scip < 0 Then scip = 6
        If scip > 0 Then
            Response.Write(String.Format("<td colspan={0}></td>", scip))
        End If
        Dim LastDay% = Date.DaysInMonth(d.Year, d.Month)
        Diagnostics.Debug.Assert(LastDay = 28 Or LastDay = 29 Or LastDay = 30 Or LastDay = 31)
        Dim rdr As Data.SqlClient.SqlDataReader = conn.ExecuteReader(String.Format("SELECT STR(Number)+'-'+ShopId, DateOfRelease, Number, Year, ShopId FROM Orders WHERE MONTH(DateOfRelease)={0} ORDER BY DateOfRelease", d.Month))
        Dim rdrRead As Boolean = rdr.Read
        ' Цикл по дням
        Do
            Diagnostics.Debug.Assert(d.Day >= 1)
            ' Открытие ячейки с проверкой на сегодняшний день (если сегодня то выделяется рамкой)
            ' и вывод в ячейку номера дня, после которого <br>
            Response.Write(String.Format("<td bgcolor=MistyRose{0}>{1}<br>", IIf(d = Date.Today, " style='BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-STYLE: solid; BORDER-TOP-COLOR: red; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-RIGHT-COLOR: red; BORDER-BOTTOM-STYLE: solid'", ""), d.Day))
            ' Цикл по заказам с датой выдачи = d
            While rdrRead
                Dim cmp% = d.CompareTo(rdr(1))
                Diagnostics.Debug.Assert(cmp <= 0)
                If cmp < 0 Then Exit While
                ' вывод гиперссылок для заказов
                Response.Write(String.Format("<a href='..\OrderCard.aspx?page=Tasks&Number={0}&Year={1}&ShopId={2}'>{3}</a>", rdr(2), rdr(3), rdr(4), rdr(0)))
                rdrRead = rdr.Read
                ' если нет больше записей, то закрываем соединение
                If Not rdrRead Then conn.Close()
            End While
            Response.Write("</td>") ' закрытие ячейки
            d = d.AddDays(1) ' переход к следующему дню
            Diagnostics.Debug.Assert(d.Day >= 2)
            ' если новый день - ПН и не первый день нового месяца,
            ' то начинаем новую строку
            If d.DayOfWeek = 1 And d.Day <> 1 Then Response.Write("</tr><tr>")
        Loop While d.Day <> 1
        ' закрытие строки, и таблицы
        Response.Write("</tr></tbody></table>")
    End Sub

End Class
