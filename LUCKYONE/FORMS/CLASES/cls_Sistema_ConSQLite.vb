Public Class cls_Sistema_ConSQLite
    Implements IDisposable

#Region "Variable de Conexión sql"
    Private cn As System.Data.SQLite.SQLiteConnection
    Private cna As System.Data.SQLite.SQLiteDataAdapter
    Private cmd As System.Data.SQLite.SQLiteCommand
#End Region


#Region "Variables de Conexión proporcionadas por el Usuario"

    Public ReadOnly Property Clave_Base_Datos As String
        Get
            Dim strContraseña As String = "YdXRoUrdse2FSoKsYOYKYGWpMHR55v8qx7EFSkSO9gg="
            objCrypto.FraseOrigen = strContraseña
            Dim sClave As String = objCrypto.Decrypt
            Return sClave
        End Get
    End Property

    Private _Usuario As String
    Public ReadOnly Property Usuario As String
        Get
            Return _Usuario
        End Get
    End Property

    Private _Contraseña As String
    Public ReadOnly Property Contraseña As String
        Get
            Return _Contraseña
        End Get
    End Property

    Private _ServidorSQL As String
    Public ReadOnly Property ServidorSQL As String
        Get
            Return _ServidorSQL
        End Get
    End Property

    Private _BaseDatos As String
    Public ReadOnly Property BaseDatos As String
        Get
            Return _BaseDatos
        End Get
    End Property


    Public IniciarAutomaticamente As Boolean


#End Region

#Region "Variables obtenidas después de conectarse"
    Private _IdLogin As Integer
    Public Property Licencia As String
    Public Property Verificador As String
#End Region

#Region "Propiedades de los atributos"

    Public Sub Guardar_Sistema_Configuraciones(ByRef _str As String, ByRef _n As String)
        Try
            objCrypto.FraseOrigen = _str
            Dim strSql As String = String.Format("DELETE  from Sistema_Configuraciones WHERE Variable = '{0}';", SinComillas(objCrypto.Encrypt))
            Ejecutar(strSql)


            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo ) VALUES ('{0}', '{1}', 1);", SinComillas(objCrypto.Encrypt), _n)
            Ejecutar(strSql)
        Catch ex As Exception
            'ErrorMsg("Error en guardado de Configuración")
        End Try
    End Sub

    Public Sub Guardar_nConfig(ByRef _str As String, ByRef _n As Int16)
        Try
            Dim strSql As String = String.Format("DELETE Sistema_nConfiguraciones from Sistema_nConfiguraciones WHERE Variable = '{0}';", _str)
            Ejecutar(strSql)
            strSql = String.Format("INSERT INTO Sistema_nConfiguraciones( VARIABLE, VALOR ) VALUES ('{0}', {1});", SinComillas(_str), _n)
            Ejecutar(strSql)
        Catch ex As Exception
            'ErrorMsg("Error en guardado de Configuración")
        End Try
    End Sub

    Public Sub Recuperar_Sistema_Configuraciones(ByVal strClave As String, ByRef strValor As String, Optional rsDefault As String = "")
        Try
            objCrypto.FraseOrigen = strClave
            Dim strSql As String = String.Format("SELECT ifnull(valor,'') valor FROM Sistema_Configuraciones WHERE VARIABLE = '{0}';", objCrypto.Encrypt)
            Dim sRN As String = strGet(strSql)
            If IsNothing(sRN) Then
                strValor = rsDefault
            Else
                If sRN.Trim.Length = 0 Then
                    strValor = rsDefault
                Else
                    strValor = sRN
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Recuperar_nConfig(ByVal _str As String, ByRef _n As Integer)
        Try
            Dim strSql As String = String.Format("SELECT valor FROM Sistema_nConfiguraciones WHERE VARIABLE = '{0}';", _str)
            _n = numGet(strSql)

        Catch ex As Exception
            _n = 0
            'ErrorMsg("No se pudo recuperar configuración")
        End Try
    End Sub

    Public Sub GuardarDatosSeguridad(sUsuario As String,
                                     sContraseña As String,
                                     sBaseDatos As String,
                                     sServidorSql As String,
                                     bIniciarAutomaticamente As Boolean,
                                     Optional nIdPerfil As Integer = 0)
        Try
            _Usuario = sUsuario
            _Contraseña = sContraseña
            _BaseDatos = sBaseDatos
            _ServidorSQL = sServidorSql
            IniciarAutomaticamente = bIniciarAutomaticamente
            Dim strSql As String = String.Format("DELETE FROM Sistema_Configuraciones WHERE [IdMódulo] = 1 and IdPerfil={0};", nIdPerfil)
            Ejecutar(strSql)

            strSql = "UPDATE Perfiles_ConSQL SET ES_PREDETERMINADO = 0"
            Ejecutar(strSql)

            strSql = String.Format("UPDATE Perfiles_ConSQL SET ES_PREDETERMINADO = 1 where IdPerfil={0}", nIdPerfil)
            Ejecutar(strSql)

            objCrypto.FraseOrigen = sUsuario
            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo, IdPerfil ) VALUES ('USUARIO', '{0}', 1, {1});", objCrypto.Encrypt.Replace("'", "''"), nIdPerfil)
            Ejecutar(strSql)

            objCrypto.FraseOrigen = sContraseña
            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo, IdPerfil ) VALUES ('CONTRASEÑA', '{0}', 1, {1});", objCrypto.Encrypt.Replace("'", "''"), nIdPerfil)
            Ejecutar(strSql)

            objCrypto.FraseOrigen = sBaseDatos
            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo, IdPerfil) VALUES ('BASE DATOS', '{0}', 1, {1});", objCrypto.Encrypt.Replace("'", "''"), nIdPerfil)
            Ejecutar(strSql)

            objCrypto.FraseOrigen = sServidorSql
            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo, IdPerfil) VALUES ('SERVIDOR SQL', '{0}', 1, {1});", objCrypto.Encrypt.Replace("'", "''"), nIdPerfil)
            Ejecutar(strSql)

            objCrypto.FraseOrigen = bIniciarAutomaticamente.ToString
            strSql = String.Format("INSERT INTO Sistema_Configuraciones( VARIABLE, VALOR, IdMódulo, IdPerfil) VALUES ('INICIAR AUTOMATICAMENTE', '{0}', 1, {1});", objCrypto.Encrypt.Replace("'", "''"), nIdPerfil)
            Ejecutar(strSql)
        Catch ex As Exception
            'ErrorMsg("Error en guardado de información de seguridad")
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene datos guardados en la tabla Sistema_Configuraciones con IdMódulo = 1
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ObtenerDatosSeguridad(Optional nIdPerfil As Integer = 0)
        Try
            Dim strSql As String = String.Format("SELECT * FROM Sistema_Configuraciones WHERE IdMódulo = 1 AND IDPERFIL= {0}", nIdPerfil)
            Using dds As DataSet = New DataSet
                Me.LlenarDataSet(strSql, dds)
                If TieneDatos(dds) Then
                    For Each row As DataRow In dds.Tables(0).Rows
                        objCrypto.FraseOrigen = row("Valor")
                        Select Case UCase(row("Variable"))
                            Case "CONTRASEÑA"
                                _Contraseña = objCrypto.Decrypt
                            Case "USUARIO"
                                _Usuario = objCrypto.Decrypt
                            Case "BASE DATOS"
                                _BaseDatos = objCrypto.Decrypt
                            Case "SERVIDOR SQL"
                                _ServidorSQL = objCrypto.Decrypt
                            Case "INICIAR AUTOMATICAMENTE"
                                IniciarAutomaticamente = CBool(objCrypto.Decrypt)
                            Case Else
                        End Select
                    Next
                Else
                    _Contraseña = String.Empty
                    _Usuario = String.Empty
                    _BaseDatos = String.Empty
                    _ServidorSQL = String.Empty
                    IniciarAutomaticamente = True
                End If
            End Using
        Catch ex As Exception
            'ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Sub ObtenerDatosSeguridad_Predeterminados()
        Try
            Dim strsql As String = "SELECT IDPERFIL FROM PERFILES_CONSQL WHERE ES_PREDETERMINADO = 1"
            Dim nIdPerfil As Integer = conSqlite.numGet(strsql)
            strsql = String.Format("SELECT * FROM Sistema_Configuraciones WHERE IdMódulo = 1 AND idperfil= {0}", nIdPerfil)
            Using dds As DataSet = New DataSet
                Me.LlenarDataSet(strsql, dds)
                If TieneDatos(dds) Then
                    For Each row As DataRow In dds.Tables(0).Rows
                        objCrypto.FraseOrigen = row("Valor")
                        Select Case UCase(row("Variable"))
                            Case "CONTRASEÑA"
                                _Contraseña = objCrypto.Decrypt
                            Case "USUARIO"
                                _Usuario = objCrypto.Decrypt
                            Case "BASE DATOS"
                                _BaseDatos = objCrypto.Decrypt
                            Case "SERVIDOR SQL"
                                _ServidorSQL = objCrypto.Decrypt
                            Case "INICIAR AUTOMATICAMENTE"
                                IniciarAutomaticamente = CBool(objCrypto.Decrypt)
                            Case Else
                        End Select
                    Next
                Else
                    _Contraseña = String.Empty
                    _Usuario = String.Empty
                    _BaseDatos = String.Empty
                    _ServidorSQL = String.Empty
                    IniciarAutomaticamente = True
                End If
            End Using
        Catch ex As Exception
            'ErrorMsg(ex.Message)
        End Try
    End Sub


    Public Sub Obtener_Datos_Licencia()
        Try
            Dim strSql As String = "SELECT * FROM LICENCIA WHERE NUM = 1"
            Using tmpDs As New DataSet
                Me.LlenarDataSet(strSql, tmpDs)
                If TieneDatos(tmpDs) Then
                    For Each row As DataRow In tmpDs.Tables(0).Rows
                        Me.Licencia = row("Licencia")
                        Me.Verificador = row("Verificador")
                    Next
                Else
                    Me.Licencia = String.Empty
                    Me.Verificador = String.Empty
                End If
            End Using
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Sub Guardar_strLicencia(strText As String, strVerificador As String)
        Try
            Dim strSql As String = String.Format("INSERT OR REPLACE INTO Licencia(Num, Licencia, Verificador) VALUES(1, '{0}', '{1}')", strText.Replace("'", "''"), strVerificador.Replace("'", "''"))
            Me.Ejecutar(strSql)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub



    Public Sub Guardar_strConsql(strText As String)
        Try
            Dim strSql As String = String.Format("INSERT OR REPLACE INTO seguridad_consql(ITEM, SERVIDORSQL) VALUES(1, '{0}')", strText)
            Me.Ejecutar(strSql)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Function obtenerStrConSQL_Encryptado() As String
        Try
            Dim rs As String = String.Empty
            Dim strSql As String = "SELECT ServidorSQL from seguridad_consql where item = 1"
            rs = Me.strGet(strSql)
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Function obtenerStrConSQL() As String
        Try
            Dim rs As String = String.Empty
            Dim strSql As String = "SELECT ServidorSQL from seguridad_consql where item = 1"
            objCrypto.FraseOrigen = Me.strGet(strSql)
            rs = objCrypto.Decrypt
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return String.Empty
        End Try
    End Function


    ''' <summary>
    ''' Retorna la conexión principal del Sistema, tipo ADO.NET
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SQLCN() As System.Data.SQLite.SQLiteConnection
        Get
            SQLCN = Me.cn
        End Get
        Set(ByVal value As System.Data.SQLite.SQLiteConnection)
            Me.cn = value
        End Set
    End Property

#End Region

#Region "Métodos de la clase"


    Public Function FullComboBox(ByVal strSql As String, ByRef cmb As DevExpress.XtraEditors.LookUpEdit, ByVal _strDisplayMember As String, ByVal _strValueMember As String) As Boolean
        Try
            Using _ds As New DataSet
                Me.LlenarDataSet(strSql, _ds)
                If Not IsNothing(cmb.Properties.DataSource) Then cmb.Properties.DataSource = Nothing
                cmb.Properties.DataSource = _ds.Tables(0)
                cmb.Properties.DisplayMember = _strDisplayMember
                cmb.Properties.ValueMember = _strValueMember
                cmb.Refresh()
                cmb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
                If TieneDatos(_ds) Then
                    If _ds.Tables(0).Rows.Count > 0 Then
                        cmb.EditValue = _ds.Tables(0).Rows(0)(_strValueMember)
                    End If
                End If

            End Using
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    Public Function Guardar_Perfil(nIdPerfil As Integer, sPerfil As String) As Integer
        Try
            Dim rs As Integer = 0
            Dim strSQL As String = "select * from Perfiles_ConSQL order by IdPerfil desc LIMIT 1;"
            If nIdPerfil = 0 Then
                Using tmpds As New DataSet
                    LlenarDataSet(strSQL, tmpds)
                    If TieneDatos(tmpds) Then
                        For Each row As DataRow In tmpds.Tables(0).Rows
                            rs = row("IdPerfil") + 1
                        Next
                    End If
                    strSQL = String.Format("INSERT OR REPLACE INTO Perfiles_ConSQL values({0}, '{1}', 0)", rs, sPerfil.Replace("'", "''"))
                    Ejecutar(strSQL)
                End Using
            End If
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return 0
        End Try
    End Function

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
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    Public Sub reconectar()
        Try
            If IsNothing(Me.cn) Then
                cn = New System.Data.SQLite.SQLiteConnection
            End If
            If Me.cn.State = ConnectionState.Open Then
                Me.cn.Close()
            End If
            Me.cn = Nothing
            Me.cn = New System.Data.SQLite.SQLiteConnection(Me.strSQLCNstring())
            Me.cn.Open()
            Me.cmd = Nothing
            Me.cmd = New System.Data.SQLite.SQLiteCommand()
            Me.cmd.Connection = Me.cn
            'End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Método constructor sin parámetros
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me._IdLogin = 0
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
            Dim sRN As String = CStr(Me.cmd.ExecuteScalar)
            If IsNothing(sRN) Then
                strGet = String.Empty
            Else
                strGet = sRN
            End If
        Catch ex As Exception
            strGet = String.Empty
        End Try
    End Function

    ''' <summary>
    ''' aplica un sqlDataAdapter.Fill en el dataset recibido por parámetro según la consulta recibida
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub LlenarDataSet(ByVal strSQL As String, ByRef ds As System.Data.DataSet)
        Try
            If Not (ds Is Nothing) Then
                ds.Clear()
            End If
            Using tmpConSQL As New System.Data.SQLite.SQLiteConnection(Me.strSQLCNstring)
                tmpConSQL.Open()
                Using tmpCmdSQL As New System.Data.SQLite.SQLiteCommand(strSQL, tmpConSQL) With {.CommandTimeout = 600}
                    Using tmpDaSQL As System.Data.SQLite.SQLiteDataAdapter = New System.Data.SQLite.SQLiteDataAdapter(tmpCmdSQL)
                        tmpDaSQL.Fill(ds, "A")
                    End Using
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
    Public Function strSQLCNstring() As String
        Try
            Dim strSQL As String
            'strSQL = String.Format("Data Source={0}\Configuraciones.SQLite;Version=3;;Password={1}", strMiRuta, Me.Clave_Base_Datos)
            strSQL = String.Format("Data Source={0}\Configuraciones.SQLite;Version=3;", strMiRuta)
            Return strSQL
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Retorna True si fue posible establecer una conexión a la base de datos SQL Server
    ''' También inicia una sesión en la base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AbrirBD() As Boolean
        Try
            If Not (Me.cn Is Nothing) Then Me.cn = Nothing
            If Not (Me.cna Is Nothing) Then Me.cna = Nothing
            If Not (Me.cmd Is Nothing) Then Me.cmd = Nothing
            Me.cn = New System.Data.SQLite.SQLiteConnection(Me.strSQLCNstring())

            Me.cn.Open()
            If Me.cn.State = ConnectionState.Open Then
                Obtener_Datos_Licencia()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
            AbrirBD = False
        End Try
    End Function

    ''' <summary>
    ''' Inicia la sesión de la conexión establecida
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IniciarSesionSQL() As Boolean
        Try
            IniciarSesionSQL = Me.AbrirBD()
        Catch ex As Exception
            Return False
        End Try
    End Function

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
            Me.cmd = New System.Data.SQLite.SQLiteCommand(strSQL, Me.cn)
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
            Me.cmd = New System.Data.SQLite.SQLiteCommand(strSQL, Me.cn)
            Me.cmd.CommandTimeout = 600
            Me.cmd.Connection = Me.cn
            nReturn = Me.cmd.ExecuteScalar
            Me.cmd = Nothing
            Return nReturn
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return 0
        End Try
    End Function

#End Region

#Region "Crear tablas"
    Public Sub Crear_Tabla_Sistema_Origenes_Actualizaciones()
        Try
            Dim strsql As String = "CREATE TABLE 'Sistema_Origenes_Actualizaciones' ( 'item'	INTEGER PRIMARY KEY AUTOINCREMENT, 'Servidor'	TEXT, 'Login'	TEXT, 'Contraseña'	TEXT, 'BaseDatos'	TEXT, 'Predeterminado'	TEXT, 'Modo' TEXT );"
            Me.Ejecutar(strsql)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class
