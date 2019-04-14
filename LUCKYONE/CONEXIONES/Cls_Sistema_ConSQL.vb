Imports System.Data.SqlClient
Imports System.Data



Public Class Cls_Sistema_ConSQL

    Private cn As System.Data.SqlClient.SqlConnection
    Private cna As System.Data.SqlClient.SqlDataAdapter
    Private cmd As System.Data.SqlClient.SqlCommand
    Dim strconn As String = "data source = .; initial catalog = LUCKYONE; user id = SAS; password = ABC*123"



#Region "Métodos de la clase"



    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.LookUpEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.Properties.DataSource) Then cmb.Properties.DataSource = Nothing
            cmb.Properties.DataSource = _ds.Tables(0)
            cmb.Properties.DisplayMember = _strDisplayMember
            cmb.Properties.ValueMember = _strValueMember
            cmb.Refresh()
            cmb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
            If _ds.Tables(0).Rows.Count > 0 Then
                cmb.EditValue = _ds.Tables(0).Rows(0)(_strValueMember)
            End If
            _ds = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function FullComboBoxGLE(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.GridLookUpEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.Properties.DataSource) Then cmb.Properties.DataSource = Nothing
            cmb.Properties.DataSource = _ds.Tables(0)
            cmb.Properties.DisplayMember = _strDisplayMember
            cmb.Properties.ValueMember = _strValueMember
            cmb.Refresh()
            cmb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
            If _ds.Tables(0).Rows.Count > 0 Then
                cmb.EditValue = _ds.Tables(0).Rows(0)(_strValueMember)
            End If
            _ds = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.Properties.DataSource) Then cmb.Properties.DataSource = Nothing
            cmb.Properties.DataSource = _ds.Tables(0)
            cmb.Properties.DisplayMember = _strDisplayMember
            cmb.Properties.ValueMember = _strValueMember
            cmb.Properties.SelectAllItemCaption = "Seleccionar todo"
            cmb.Refresh()
            If _ds.Tables(0).Rows.Count > 0 Then
                cmb.SetEditValue(_ds.Tables(0).Rows(0)(_strValueMember))
            End If
            _ds = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.GridLookUpEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.Properties.DataSource) Then cmb.Properties.DataSource = Nothing
            cmb.Properties.DataSource = _ds.Tables(0)
            cmb.Properties.DisplayMember = _strDisplayMember
            cmb.Properties.ValueMember = _strValueMember
            cmb.Refresh()
            cmb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
            If _ds.Tables(0).Rows.Count > 0 Then
                cmb.EditValue = _ds.Tables(0).Rows(0)(_strValueMember)
            End If
            _ds = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Traslada el resultado de una consulta SQL en un ComboBox de Developer Xpress
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <param name="cmb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.ComboBoxEdit) As Boolean
        Try
            Dim t As DataSet = New DataSet
            Dim i As Short
            Me.LlenarDataSet(strSql, t)
            cmb.Properties.Items.Clear()
            For i = 0 To t.Tables(0).Rows.Count - 1
                cmb.Properties.Items.Add(t.Tables(0).Rows(i)(0))
            Next
            If i > 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedText = ""
                cmb.Text = ""
            End If
            t = Nothing
            FullComboBox = True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Traslada el resultado de una consulta SQL en un ComboBox de Microsoft.windows.forms.ComboBox
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <param name="cmb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As ComboBox) As Boolean
        Dim t As DataSet = New DataSet
        Dim i As Short
        Try
            Me.LlenarDataSet(strSql, t)
            cmb.Items.Clear()
            For i = 0 To t.Tables(0).Rows.Count - 1
                cmb.Items.Add(t.Tables(0).Rows(i)(0))
            Next
            If i > 0 Then cmb.SelectedIndex = 0
            t = Nothing
            FullComboBox = True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Para llenar repository Item
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <param name="cmb"></param>
    ''' <param name="_strDisplayMember"></param>
    ''' <param name="_strValueMember"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.DataSource) Then cmb.DataSource = Nothing
            cmb.DataSource = _ds.Tables(0)
            cmb.DisplayMember = _strDisplayMember
            cmb.ValueMember = _strValueMember
            cmb.View.RefreshData()
            cmb.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
            _ds = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub FullComboBox(strSql As String, ByRef cmb As ComboBox, _strDisplayMember As String, _strValueMember As String)
        Try
            Dim _ds As New DataSet
            Me.LlenarDataSet(strSql, _ds)
            If Not IsNothing(cmb.DataSource.DataSource) Then cmb.DataSource = Nothing
            cmb.DataSource = _ds.Tables(0)
            cmb.DisplayMember = _strDisplayMember
            cmb.ValueMember = _strValueMember
            cmb.Refresh()
            If _ds.Tables(0).Rows.Count > 0 Then
                cmb.SelectedValue = _ds.Tables(0).Rows(0)(_strValueMember)
            End If
            _ds = Nothing
        Catch ex As Exception
        End Try
    End Sub


    ''' <summary>
    ''' Devuelve verdadero si el dataset tiene datos
    ''' </summary>
    ''' <param name="_d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TieneDatos(ByVal tmpDs As System.Data.DataSet) As Boolean
        Try
            Dim rs As Boolean = False
            If Not IsNothing(tmpDs) Then
                If tmpDs.Tables.Count > 0 Then
                    If tmpDs.Tables(0).Rows.Count > 0 Then
                        rs = True
                    End If
                End If
            End If
            Return rs
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub reconectar()
        Try

            If IsNothing(Me.cn) Then
                cn = New System.Data.SqlClient.SqlConnection
            End If
            If Me.cn.State = ConnectionState.Open Then
                Me.cn.Close()
            End If
            Me.cn = Nothing
            Me.cn = New System.Data.SqlClient.SqlConnection(Me.strconn)
            Me.cn.Open()
            Me.cmd = Nothing
            Me.cmd = New System.Data.SqlClient.SqlCommand()
            Me.cmd.Connection = Me.cn
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    ''' <summary>
    ''' Obtener un valor numérico, primera columna del primer registro devuelto por la consulta recibida x parámetro
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function numGet(ByVal strSQL As String) As Decimal
        Try
            Me.reconectar()
            Me.cmd.CommandText = strSQL
            numGet = Me.cmd.ExecuteScalar

        Catch ex As Exception
            numGet = 0
        End Try
    End Function

    ''' <summary>
    ''' Obtener un valor cadena, primera columna del primer registro devuelto por la consulta recibida x parámetro
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function strGet(ByVal strSQL As String) As String
        Try
            Me.reconectar()
            Me.cmd.CommandText = strSQL
            strGet = CStr(Me.cmd.ExecuteScalar)
        Catch ex As Exception
            strGet = ""
        End Try
    End Function

    ''' <summary>
    ''' aplica un sqlDataAdapter.Fill en el dataset recibido por parámetro según la consulta recibida
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>

    Public Function numEscalar(ByVal strSql As String) As Decimal
        Try
            Me.reconectar()
            Me.cmd.CommandText = strSql
            numEscalar = Me.cmd.ExecuteScalar
        Catch ex As Exception
            ErrorMsg(ex.Source & "; " & ex.Message & ":numGet")
            Return 0
        End Try
    End Function

    Public Function dtEscalar(ByVal strSql As String) As Date
        Try
            Dim rs As Date = Now
            If strSql.Trim.Length = 0 Then
                strSql = "SELECT GETDATE() AS RS"
            End If
            Using ddsDt As New DataSet
                LlenarDataSet2(strSql, ddsDt)
                If TieneDatos(ddsDt) Then
                    rs = ddsDt.Tables(0).Rows(0)(0)
                End If
            End Using
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return Now
        End Try
    End Function
    Public Function strEscalar(ByVal strSql As String) As String
        Try
            Me.reconectar()
            Me.cmd.CommandText = strSql
            Dim rs As String = CStr(Me.cmd.ExecuteScalar)
            If rs Is Nothing Then
                rs = ""
            End If
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return ""
        End Try
    End Function
    Public Sub LlenarDataSet(ByVal conexion As String, ByVal strSql As String, ByRef tmpDs As DataSet)
        Try
            If (tmpDs Is Nothing) Then tmpDs = New DataSet
            tmpDs.Clear()
            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(conexion)
                Mytmp_cn.Open()
                Using Mytmp_cmd As New System.Data.SqlClient.SqlCommand(strSql, Mytmp_cn) With {.CommandTimeout = 600}
                    Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(Mytmp_cmd)
                        da.Fill(tmpDs, "A")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub LlenarDataSet(ByVal strSql As String, ByRef tmpDs As DataSet)
        Try
            If (tmpDs Is Nothing) Then tmpDs = New DataSet
            tmpDs.Clear()

            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(Me.strconn)
                Mytmp_cn.Open()
                Using Mytmp_cmd As New System.Data.SqlClient.SqlCommand(strSql, Mytmp_cn) With {.CommandTimeout = 600}
                    Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(Mytmp_cmd)
                        da.Fill(tmpDs, "A")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub LlenarDataSet(ByVal strSql As String, ByRef tbl As DataTable)
        Try
            If (tbl Is Nothing) Then tbl = New DataTable
            tbl.Clear()

            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(Me.strconn)
                Mytmp_cn.Open()
                Using Mytmp_cmd As New System.Data.SqlClient.SqlCommand(strSql, Mytmp_cn) With {.CommandTimeout = 600}
                    Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(Mytmp_cmd)
                        da.Fill(tbl)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub LlenarDataSet(ByVal strSql As String, ByRef ds As DataSet, ByVal i As String)
        Try
            Dim dtbl As DataTable = New DataTable(i)
            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(Me.strconn)
                Mytmp_cn.Open()
                ds.Tables.Add(i)
                Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(strSql, Mytmp_cn)
                    da.Fill(ds, i)
                End Using
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Retorna la cadena de conexión para sqlconnection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function strSQLCNstring() As String
    '    Try
    '        Dim strSQL As String
    '        'strSQL = String.Format("Data Source={0}\Configuraciones.SQLite;Version=3;;Password={1}", strMiRuta, Me.Clave_Base_Datos)
    '        strSQL = String.Format("Data Source={0}\Configuraciones.SQLite;Version=3;", strMiRuta)
    '        Return strSQL
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function

    ''' <summary>
    ''' Retorna True si fue posible establecer una conexión a la base de datos SQL Server
    ''' También inicia una sesión en la base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function AbrirBD() As Boolean
    '    Try
    '        If Not (Me.cn Is Nothing) Then Me.cn = Nothing
    '        If Not (Me.cna Is Nothing) Then Me.cna = Nothing
    '        If Not (Me.cmd Is Nothing) Then Me.cmd = Nothing
    '        Me.cn = New System.Data.SQLite.SQLiteConnection(Me.strSQLCNstring())

    '        Me.cn.Open()
    '        If Me.cn.State = ConnectionState.Open Then
    '            Obtener_Datos_Licencia()
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        ErrorMsg(ex.Message)
    '        AbrirBD = False
    '    End Try
    'End Function

    ''' <summary>
    ''' Inicia la sesión de la conexión establecida
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function IniciarSesionSQL() As Boolean
    '    Try
    '        IniciarSesionSQL = Me.AbrirBD()
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    ''' <summary>
    ''' Ejecuta cualquier T-SQL sentences y retorna True si tuvo éxito la ejecución de la consulta
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Ejecutar(ByVal strSQL As String, Optional ByVal cmdtype As System.Data.CommandType = CommandType.Text) As Boolean
        Try
            Me.reconectar()
            If Not IsNothing(Me.cmd) Then Me.cmd = Nothing
            Me.cmd = New System.Data.SqlClient.SqlCommand(strSQL, Me.cn)
            Me.cmd.CommandTimeout = 600
            Me.cmd.Connection = Me.cn
            Me.cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

    Public Function Ejecutar(ByVal strSQL As String, ByRef nReturn As Integer) As Integer
        Try
            Me.reconectar()
            If Not IsNothing(Me.cmd) Then Me.cmd = Nothing
            Me.cmd = New System.Data.SqlClient.SqlCommand(strSQL, Me.cn)
            Me.cmd.CommandTimeout = 600
            Me.cmd.Connection = Me.cn
            nReturn = Me.cmd.ExecuteScalar
            Me.cmd = Nothing
            Return nReturn
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Function EjecutarDS(ByVal strSql As String) As DataSet
        Try
            Dim rs As New DataSet

            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(Me.strconn)
                Mytmp_cn.Open()
                Using Mytmp_cmd As New System.Data.SqlClient.SqlCommand(strSql, Mytmp_cn) With {.CommandTimeout = 600}
                    Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(Mytmp_cmd)
                        da.Fill(rs, "A")
                    End Using
                End Using
            End Using

            Return rs
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub LlenarDataSet2(ByVal strSql As String, ByRef ds As DataSet)
        Try
            Using Mytmp_cn As New System.Data.SqlClient.SqlConnection(Me.strconn)
                Mytmp_cn.Open()
                Using Mytmp_cmd As New System.Data.SqlClient.SqlCommand(strSql, Mytmp_cn) With {.CommandTimeout = 600}
                    Using da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(Mytmp_cmd)
                        da.Fill(ds, "A")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

#End Region



End Class
