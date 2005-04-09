Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents OrdersRegisterDS1 As WinUI.OrdersRegisterDS
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.OrdersRegisterDS1 = New WinUI.OrdersRegisterDS
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdersRegisterDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.DataSource = Me.OrdersRegisterDS1.Orders
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(640, 312)
        Me.DataGrid1.TabIndex = 0
        '
        'OrdersRegisterDS1
        '
        Me.OrdersRegisterDS1.DataSetName = "OrdersRegisterDS"
        Me.OrdersRegisterDS1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=LOCAL;packet size=4096;integrated security=SSPI;data source=""(loca" & _
        "l)"";persist security info=False;initial catalog=main"
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Orders", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Number", "Number"), New System.Data.Common.DataColumnMapping("Year", "Year"), New System.Data.Common.DataColumnMapping("ShopId", "ShopId"), New System.Data.Common.DataColumnMapping("Date", "Date"), New System.Data.Common.DataColumnMapping("DateOfRelease", "DateOfRelease"), New System.Data.Common.DataColumnMapping("HaveDelivery", "HaveDelivery"), New System.Data.Common.DataColumnMapping("DeliveryAddress", "DeliveryAddress"), New System.Data.Common.DataColumnMapping("DesignerId", "DesignerId"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("Cost", "Cost"), New System.Data.Common.DataColumnMapping("Paid", "Paid")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Orders WHERE (Number = @Original_Number) AND (ShopId = @Original_Shop" & _
        "Id) AND (Year = @Original_Year) AND (Cost = @Original_Cost OR @Original_Cost IS " & _
        "NULL AND Cost IS NULL) AND (Date = @Original_Date) AND (DateOfRelease = @Origina" & _
        "l_DateOfRelease) AND (DeliveryAddress = @Original_DeliveryAddress OR @Original_D" & _
        "eliveryAddress IS NULL AND DeliveryAddress IS NULL) AND (Description = @Original" & _
        "_Description OR @Original_Description IS NULL AND Description IS NULL) AND (Desi" & _
        "gnerId = @Original_DesignerId OR @Original_DesignerId IS NULL AND DesignerId IS " & _
        "NULL) AND (HaveDelivery = @Original_HaveDelivery OR @Original_HaveDelivery IS NU" & _
        "LL AND HaveDelivery IS NULL) AND (Paid = @Original_Paid)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Number", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Number", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ShopId", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShopId", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Year", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Year", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Cost", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Date", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DateOfRelease", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DateOfRelease", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DeliveryAddress", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DeliveryAddress", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Description", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DesignerId", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DesignerId", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HaveDelivery", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HaveDelivery", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Paid", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Paid", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Orders(Number, Year, ShopId, Date, DateOfRelease, HaveDelivery, Deliv" & _
        "eryAddress, DesignerId, Description, Cost, Paid) VALUES (@Number, @Year, @ShopId" & _
        ", @Date, @DateOfRelease, @HaveDelivery, @DeliveryAddress, @DesignerId, @Descript" & _
        "ion, @Cost, @Paid); SELECT Number, Year, ShopId, Date, DateOfRelease, HaveDelive" & _
        "ry, DeliveryAddress, DesignerId, Description, Cost, Paid FROM Orders WHERE (Numb" & _
        "er = @Number) AND (ShopId = @ShopId) AND (Year = @Year)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Number", System.Data.SqlDbType.Int, 4, "Number"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Year", System.Data.SqlDbType.SmallInt, 2, "Year"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShopId", System.Data.SqlDbType.NVarChar, 3, "ShopId"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.DateTime, 4, "Date"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DateOfRelease", System.Data.SqlDbType.DateTime, 4, "DateOfRelease"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HaveDelivery", System.Data.SqlDbType.Bit, 1, "HaveDelivery"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DeliveryAddress", System.Data.SqlDbType.NVarChar, 255, "DeliveryAddress"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DesignerId", System.Data.SqlDbType.NVarChar, 15, "DesignerId"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 255, "Description"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 8, "Cost"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paid", System.Data.SqlDbType.Money, 8, "Paid"))
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT Number, Year, ShopId, Date, DateOfRelease, HaveDelivery, DeliveryAddress, " & _
        "DesignerId, Description, Cost, Paid FROM Orders"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Orders SET Number = @Number, Year = @Year, ShopId = @ShopId, Date = @Date," & _
        " DateOfRelease = @DateOfRelease, HaveDelivery = @HaveDelivery, DeliveryAddress =" & _
        " @DeliveryAddress, DesignerId = @DesignerId, Description = @Description, Cost = " & _
        "@Cost, Paid = @Paid WHERE (Number = @Original_Number) AND (ShopId = @Original_Sh" & _
        "opId) AND (Year = @Original_Year) AND (Cost = @Original_Cost OR @Original_Cost I" & _
        "S NULL AND Cost IS NULL) AND (Date = @Original_Date) AND (DateOfRelease = @Origi" & _
        "nal_DateOfRelease) AND (DeliveryAddress = @Original_DeliveryAddress OR @Original" & _
        "_DeliveryAddress IS NULL AND DeliveryAddress IS NULL) AND (Description = @Origin" & _
        "al_Description OR @Original_Description IS NULL AND Description IS NULL) AND (De" & _
        "signerId = @Original_DesignerId OR @Original_DesignerId IS NULL AND DesignerId I" & _
        "S NULL) AND (HaveDelivery = @Original_HaveDelivery OR @Original_HaveDelivery IS " & _
        "NULL AND HaveDelivery IS NULL) AND (Paid = @Original_Paid); SELECT Number, Year," & _
        " ShopId, Date, DateOfRelease, HaveDelivery, DeliveryAddress, DesignerId, Descrip" & _
        "tion, Cost, Paid FROM Orders WHERE (Number = @Number) AND (ShopId = @ShopId) AND" & _
        " (Year = @Year)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Number", System.Data.SqlDbType.Int, 4, "Number"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Year", System.Data.SqlDbType.SmallInt, 2, "Year"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShopId", System.Data.SqlDbType.NVarChar, 3, "ShopId"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.DateTime, 4, "Date"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DateOfRelease", System.Data.SqlDbType.DateTime, 4, "DateOfRelease"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HaveDelivery", System.Data.SqlDbType.Bit, 1, "HaveDelivery"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DeliveryAddress", System.Data.SqlDbType.NVarChar, 255, "DeliveryAddress"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DesignerId", System.Data.SqlDbType.NVarChar, 15, "DesignerId"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 255, "Description"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 8, "Cost"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paid", System.Data.SqlDbType.Money, 8, "Paid"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Number", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Number", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ShopId", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShopId", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Year", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Year", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Cost", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Date", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DateOfRelease", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DateOfRelease", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DeliveryAddress", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DeliveryAddress", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Description", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DesignerId", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DesignerId", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HaveDelivery", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HaveDelivery", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Paid", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Paid", System.Data.DataRowVersion.Original, Nothing))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(680, 408)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdersRegisterDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SqlDataAdapter1.Fill(OrdersRegisterDS1)
    End Sub
End Class
