Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module mod_Procedimientos
    'Declaración de la API
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Function EjecutarTsql(strsql As String) As Boolean
        Try
            Return consql.consql.Ejecutar(strsql)
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function Guardar_archivo_binario(ByVal aByte() As Byte, ByVal fileName As String) As Boolean


        ' El procedimiento creará un archivo con la secuencia de bytes
        ' especificada en el argumento.

        ' Compruebo los distintos parámetros pasados a la función.
        '
        If (aByte Is Nothing) OrElse (fileName = "") Then Return False

        Try
            ' Compruebo si existe el archivo especificado.
            '
            If System.IO.File.Exists(fileName) Then
                ' Elimino el archivo
                System.IO.File.Delete(fileName)
            End If

            ' Número de bytes que se van a escribir
            Dim data As Int64 = aByte.Length

            ' Obtengo el nombre de un archivo temporal, donde
            ' primeramente se guardará el documento.
            '
            Dim tempFileName As String = System.IO.Path.GetTempFileName

            ' Abrimos o creamos el archivo.
            Dim fs As New System.IO.FileStream(tempFileName, IO.FileMode.OpenOrCreate)

            ' Crea el escritor para los datos.
            Dim bw As New System.IO.BinaryWriter(fs)

            ' Escribimos en el archivo los datos realmente leídos.
            bw.Write(aByte, 0, Convert.ToInt32(data))

            ' Borra todos los búferes del sistema de escritura actual y hace
            ' que todos los datos almacenados en el búfer se escriban en el
            ' dispositivo subyacente.
            bw.Flush()

            ' Cerramos los distintos objetos.
            bw.Close()
            fs.Close()
            bw = Nothing
            fs = Nothing
            System.IO.File.Move(tempFileName, fileName)
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try

    End Function


    Public Sub HacerEditableDXGrid(ByVal dg As DevExpress.XtraGrid.Views.Grid.GridView, ByVal bAllowEdit As Boolean)
        Try
            For Each columna As DevExpress.XtraGrid.Columns.GridColumn In dg.Columns
                columna.OptionsColumn.AllowEdit = bAllowEdit
            Next
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try

    End Sub



    ''' <summary>
    ''' Liberar memoria
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LimpiarMemoria()
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Sub OkMsg(ByVal strMsg As String)
        Try

            MDI_PARENT.xtrOkMsg.Show(MDI_PARENT, "Aviso", strMsg, Global.LUCKYONE.My.Resources.accept)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub Msg(ByVal strMsg As String, ByVal strTítulo As String)
        Try
            MDI_PARENT.xtrerrormsg.Show(MDI_PARENT, strTítulo, strMsg)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub



    Public Sub ErrorMsg(ByVal strError As String)
        Try
            MDI_PARENT.xtrerrormsg.Show(MDI_PARENT, "Ha ocurrido un error", strError)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Sub CargarDXGrid(ByVal strSql As String, ByVal dg As DevExpress.XtraGrid.GridControl)
        Try
            Dim dds As New DataSet
            consql.consql.LlenarDataSet(strSql, dds)
            With dg
                .DataSource = Nothing
                .DataSource = dds.Tables(0)
            End With
            dds = Nothing
        Catch ex As Exception
            'ErrorMsg(ex.Message)
        End Try
    End Sub


    'Función para formatear una fecha a 'yyyy-mm-dd'
    Public Function sqlDateMedia(ByVal dt As Date) As String
        Try
            sqlDateMedia = String.Format("'{0}-{1}-{2} 12:00:00'", DateAndTime.Year(dt), DateAndTime.Month(dt), DateAndTime.Day(dt))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqldate(ByVal dt As System.DBNull)
        Return "NULL"
    End Function

    Public Function sqlDate(ByVal dt As Date) As String
        Try
            Return String.Format("'{0}-{1}-{2}'", DateAndTime.Year(dt), DateAndTime.Month(dt), DateAndTime.Day(dt))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqlDateHasta(ByVal dt As DateTimePicker) As String
        Try
            sqlDateHasta = String.Format("'{0}-{1}-{2}  23:59:59'", dt.Value.Year, dt.Value.Month, dt.Value.Day)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqlDateHasta(ByVal dt As Date) As String
        Try
            sqlDateHasta = String.Format("'{0}-{1}-{2} 23:59:59'", DateAndTime.Year(dt), DateAndTime.Month(dt), DateAndTime.Day(dt))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqlDateMedia(ByVal dt As DateTimePicker) As String
        Try
            sqlDateMedia = String.Format("'{0}-{1}-{2} 12:00:00'", dt.Value.Year, dt.Value.Month, dt.Value.Day)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqlDate(ByVal dt As DateTimePicker) As String
        Try
            sqlDate = String.Format("'{0}-{1}-{2}'", dt.Value.Year, dt.Value.Month, dt.Value.Day)
        Catch ex As Exception
            Return ""
        End Try
    End Function


    ''' <summary>
    ''' Recupera la configuración del DevExpress.XtraGrid.GridView guardada en archivo XML
    ''' </summary>
    ''' <param name="sFrm">Nombre del Formulario propietario del GridView. Me.Name (recomendado)</param>
    ''' <param name="Grv">GridView</param>
    ''' <remarks>Verifica la existencia del archivo antes de abrir</remarks>
    'Public Sub Cargar_Configuracion_XTRA_GRV(ByVal sFrm As String, ByVal Grv As DevExpress.XtraGrid.Views.Grid.GridView)
    '    Try
    '        Dim strArchivo As String = String.Format("{0}\{1}_{2}.xml", strMiRuta, sFrm, Grv.Name)
    '        If System.IO.File.Exists(strArchivo) Then
    '            Grv.RestoreLayoutFromXml(strArchivo)
    '        End If
    '    Catch ex As Exception
    '        ErrorMsg(ex.Message)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Guarda en un archivo XML la configuración del DevExpress.XtraGrid.GridView
    ''' </summary>
    ''' <param name="sFrm">Nombre del Formulario propietario del GridView. Me.Name (recomendado)</param>
    ''' <param name="Grv">GridView</param>
    ''' <remarks>Reescribe siempre el contenido del archivo</remarks>
    'Public Sub Guardar_Configuracion_XTRA_GRV(ByVal sFrm As String, ByRef Grv As DevExpress.XtraGrid.Views.Grid.GridView)
    '    Try
    '        Dim strArchivo As String = String.Format("{0}\{1}_{2}.xml", strMiRuta, sFrm, Grv.Name)
    '        Grv.SaveLayoutToXml(strArchivo)
    '    Catch ex As Exception
    '        ErrorMsg(ex.Message)
    '    End Try
    'End Sub
End Module
