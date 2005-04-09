Imports System.Text.RegularExpressions
Imports System.Diagnostics

Public Class OrdersList
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

    Protected conn As New BusinessFacade.Component1
    Protected rdr As Data.SqlClient.SqlDataReader

    Protected FilterDate$
    Protected FilterOn As Boolean
    Protected ByReleaseDate As Boolean
    Protected Query$
    Protected Lower As Boolean
    Protected Greater As Boolean
    Protected Equal As Boolean

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Query = ""
        ByReleaseDate = True
        FilterOn = True
        FilterDate = Date.Today.ToLongDateString()
        Lower = False
        Greater = True
        Equal = True

        Dim nv As Collections.Specialized.NameValueCollection = Request.QueryString
        If nv.HasKeys Then
            Query = nv("Query")
            ByReleaseDate = String.Equals(nv("ByReleaseDate"), "on")
            FilterOn = String.Equals(nv("FilterOn"), "on")
            FilterDate = nv("FilterDate")
            Lower = String.Equals(nv("Lower"), "on")
            Greater = String.Equals(nv("Greater"), "on")
            Equal = String.Equals(nv("Equal"), "on")
        End If

        Dim q$
        q = "SELECT STR(Number)+'-'+ShopId AS ShortHumanNumber, Date, DateOfRelease, Description, " _
            & "HaveDelivery, DeliveryAddress, PaidPercent, Number, Year, ShopId FROM OrdersPaidPercentage "

        If Query <> "" Then
            Dim r As New Regex("")
            Dim m1 As Match = r.Match(Query, "\d") ' числа
            Dim m2 As Match = r.Match(Query, "\D")  ' не числа
            Debug.Assert(m1.Success Or m2.Success) ' хотя бы одно должно быть
            q = q & "WHERE "
            If m1.Success Then q = q & String.Format("Number={0}", m1.Value)
            If m2.Success Then
                If m1.Success Then q = q & " AND "
                q = q & String.Format("(Description LIKE '%{0}%' OR ShopId LIKE'%{0}%')", m2.Value)
            End If
            FilterOn = False
        ElseIf FilterOn Then
            q = q & "WHERE " & IIf(ByReleaseDate, _
                "DateOfRelease", "Date") & IIf(Lower, "<", "") & IIf(Greater, ">", "") _
                    & IIf(Equal, "=", "") & "'" & Date.Parse(FilterDate) & "'"
        End If
        q = q & " ORDER BY Date, Number"

        rdr = conn.ExecuteReader(q)
    End Sub

End Class
