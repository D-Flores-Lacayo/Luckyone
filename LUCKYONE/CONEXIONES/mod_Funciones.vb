Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Module mod_Funciones

    ''' <summary>
    ''' Cargar y llena el Reporte
    ''' </summary>
    ''' <param name="sArchivo">Dirección física del archivo</param>
    ''' <param name="strSql">Consulta del Reporte</param>
    ''' <param name="strTítulo">Título</param>
    ''' <param name="strSubTítulo">Sub Título</param>
    ''' <param name="strFiltro">Filtro utilizado</param>
    ''' <returns></returns>
    ''' <remarks>Inlcuye fórmulas strEmpresa, strTítulo, strSubtítulo y strUsuario</remarks>
    Public Function Cargar_Rpt(ByRef myRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal sArchivo As String, ByVal strSql As String, ByVal strTítulo As String, ByVal strSubTítulo As String, ByVal strFiltro As String, Optional ByVal strPapel As String = "") As Boolean
        Try
            Dim rs As Boolean = False
            myRpt.Load(sArchivo, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            'se considera el caso aquel de reportes sin datos.
            If strSql.Trim.Length > 0 Then
                Dim _ds As New DataSet
                consql.consql.LlenarDataSet(strSql, _ds)
                myRpt.SetDataSource(_ds.Tables(0))
                _ds.Dispose()
            End If
            ''myRpt.DataDefinition.FormulaFields("strEmpresa").Text = String.Format("'{0}'", objEmpresa.Empresa.Replace("'", "''"))
            myRpt.DataDefinition.FormulaFields("strTítulo").Text = String.Format("'{0}'", strTítulo.Replace("'", "''"))
            myRpt.DataDefinition.FormulaFields("strSubTítulo").Text = String.Format("'{0}'", strSubTítulo.Replace("'", "''"))
            'El siguiente parámetro no se usará aún porque la plantilla CrystalReports no contiene aún a strFiltro
            'myRpt.DataDefinition.FormulaFields("strTítulo").Text = String.Format("'{0}'", strTítulo.Replace("'", "''"))
            ''myRpt.DataDefinition.FormulaFields("strUsuario").Text = String.Format("'{0}'", objSesión.Nombre.Replace("'", "''"))
            rs = True
            If strPapel.Length > 0 Then
                Dim doctoprint As New System.Drawing.Printing.PrintDocument
                For i As Short = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                    Dim rawKind As Integer
                    If UCase(doctoprint.PrinterSettings.PaperSizes(i).PaperName) = UCase(strPapel) Then
                        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                        myRpt.PrintOptions.PaperSize = rawKind
                        Exit For
                    End If
                Next
            End If
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    Public Function Cargar_SubRpt(ByRef myRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByRef mysRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal strNombreSubReporte As String, ByVal strSql As String) As Boolean
        Try
            Dim rs As Boolean = False
            mysRpt = myRpt.OpenSubreport(strNombreSubReporte)
            'se considera el caso aquel de reportes sin datos.
            If strSql.Trim.Length > 0 Then
                Dim _ds As New DataSet
                consql.consql.LlenarDataSet(strSql, _ds)
                mysRpt.SetDataSource(_ds.Tables(0))
                _ds.Dispose()
            End If
            rs = True
            Return rs
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Retorna Fecha y Hora en formato TSQL 'Año-Mes-Día Hora:Minutos:segundos'
    ''' </summary>
    ''' <param name="_dt"></param>
    ''' <param name="_dtt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function sqlDateTime(ByVal _dt As Date, ByVal _dtt As Date) As String
        Try
            Dim rs As String = ""
            rs = String.Format("'{0} {1}'", Format(_dt, "yyyy-MM-dd"), Format(_dtt, "HH:mm:ss"))
            Return rs
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function sqlDateTime(ByVal _dt As Date, ByVal sdtt As String) As String
        Try
            Dim rs As String = ""
            rs = String.Format("'{0} {1}'", Format(_dt, "yyyy-MM-dd"), sdtt)
            Return rs
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la hora en un datetime con formato HH:mm:ss
    ''' </summary>
    ''' <param name="_dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function sqlTime(ByVal _dt As Date) As String
        Try
            Dim rs As String = ""
            rs = String.Format("'{0}'", Format(_dt, "HH:mm:ss"))
            Return rs
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Devuelve verdadero si el dataset tiene datos
    ''' </summary>
    ''' <param name="_d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TieneDatos(ByVal tmpDs As DataSet) As Boolean
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
            Return False
        End Try
    End Function

    Public Function TieneDatos(ByVal tmpDs As DataTable) As Boolean
        Try
            Dim rs As Boolean = False
            If Not IsNothing(tmpDs) Then
                If tmpDs.Rows.Count > 0 Then
                    rs = True
                End If
            End If

            Return rs
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Recuperar_Hoja_Excel(ByVal strArchivo As String, ByVal strHoja As String, ByRef tmpDs As DataSet) As Boolean
        Try
            Using tmpCnExcel As New System.Data.OleDb.OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES';", SinComillas(strArchivo)))
                Using tmpDaExcel As New System.Data.OleDb.OleDbDataAdapter(String.Format("SELECT * FROM [{0}$]", strHoja), tmpCnExcel)
                    tmpDaExcel.Fill(tmpDs, "a")
                End Using
            End Using
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    Public Function Recuperar_Hoja_Excel(ByVal strArchivo As String, ByVal strCondicion As String, ByVal strHoja As String, ByRef _dds As DataSet) As Boolean
        Try
            Dim _cnExcel As New System.Data.OleDb.OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES';", SinComillas(strArchivo)))
            Dim _daExcel As New System.Data.OleDb.OleDbDataAdapter(String.Format("SELECT * FROM [{0}$] {1}", strHoja, strCondicion), _cnExcel)
            If Not IsNothing(_dds) Then _dds = Nothing
            _dds = New DataSet
            _daExcel.Fill(_dds, "a")
            _daExcel = Nothing
            _cnExcel = Nothing
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Exporta a Excel el contenido del grid recibido
    ''' </summary>
    ''' <param name="_dg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Enviar_Excel_xtraGrid(ByVal _dg As DevExpress.XtraGrid.GridControl) As Boolean
        Try
            Using frm As SaveFileDialog = New SaveFileDialog() With {.DefaultExt = "xls", .Filter = "Archivo Microsoft Excel|*.xlsx"}
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Dim myFile As New System.IO.FileInfo(frm.FileName)
                    Dim strF As String = myFile.FullName.Substring(myFile.DirectoryName.Length + 1)
                    strF = Strings.Left(strF, Strings.InStr(strF, ".xls") - 1)
                    Dim opts As New DevExpress.XtraPrinting.XlsxExportOptions With {.SheetName = strF}
                    _dg.ExportToXlsx(frm.FileName, opts)
                    Msg(String.Format("'{0}'", frm.FileName), "Se ha exportado la consulta al archivo:")
                End If
            End Using
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    Public Function Enviar_Excel_xtraGrid(ByVal _dg As DevExpress.XtraPivotGrid.PivotGridControl) As Boolean
        Try
            Dim f As SaveFileDialog = New SaveFileDialog
            f.DefaultExt = "xls"
            f.Filter = "Archivo Microsoft Excel|*.xls"
            If f.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                _dg.ExportToXlsx(f.FileName)
                Msg(String.Format("'{0}'", f.FileName), "Se ha exportado la consulta al archivo:")
            End If
            Return True
        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Exporta a Excel el resultado de la consulta SQL recibida
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <param name="blnOptimizado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Enviar_a_Excel(ByVal strSql As String, Optional ByVal blnOptimizado As Boolean = False) As Boolean
        Try
            If strSql.Trim.Length = 0 Then
                Return False
                Exit Function
            End If
            Dim f As New Form_uti_ExportarExcel
            Dim _dds As New DataSet
            Dim DLG As New System.Windows.Forms.SaveFileDialog
            Dim strArchivo As String
            DLG.AddExtension = True
            DLG.DefaultExt = "xls"
            DLG.Filter = "Archivo Microsoft Excel|*.xls"
            If DLG.ShowDialog = DialogResult.OK Then
                strArchivo = DLG.FileName
                Application.UseWaitCursor = True
                Application.DoEvents()
                consql.consql.LlenarDataSet(strSql, _dds)
                Application.DoEvents()
                f.dg.DataSource = _dds.Tables(0)
                _dds = Nothing
                Application.DoEvents()
                If blnOptimizado = True Then
                    f.dg.ExportToExcelOld(strArchivo)
                Else
                    Dim ox As New DevExpress.XtraPrinting.XlsExportOptions
                    Dim fn As New System.IO.FileInfo(strArchivo)
                    ox.SheetName = Strings.Left(fn.Name, fn.Name.Length - fn.Extension.Length)
                    ox.ShowGridLines = False
                    f.dg.ExportToXls(strArchivo, ox)
                End If
                Application.DoEvents()
                Application.UseWaitCursor = False
                Msg(String.Format("'{0}'", strArchivo), "Se ha exportado la consulta al archivo:")
                f = Nothing
                Return True
            Else
                ErrorMsg("No fue posible exportar la consulta a Excel")
                Return False
            End If
        Catch ex As Exception
            Application.UseWaitCursor = False
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Retorna True si el texto recibido tiene número, letra o guión únicamente
    ''' </summary>
    ''' <param name="strCuenta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function strValidarCodigo(ByVal strCuenta As String) As String
        Try
            Dim strC As String, str_Renamed As String
            Dim i, n As Short
            If strCuenta.Trim.Length = 0 Then strValidarCodigo = ""
            str_Renamed = ""
            n = Len(String.Format("{0};", strCuenta))
            For i = 1 To n - 1 Step 1
                strC = Strings.Mid(strCuenta, i, 1)
                If Strings.InStr(1, "-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", strC, CompareMethod.Text) > 0 Then
                    str_Renamed = String.Format("{0}{1}", str_Renamed, strC)
                End If
            Next i
            strValidarCodigo = str_Renamed
        Catch ex As Exception
            Return strCuenta
        End Try
    End Function

    ''' <summary>
    ''' Retorna la descripción del número: 1 = Uno, 2 = Dos, etc.
    ''' </summary>
    ''' <param name="Numero"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function strNumber(ByVal Numero As Double) As String
        Try
            If IsDBNull(Numero) Then
                Return ""
            Else
                Dim strDecimales As String, strNumero As String, strTres As String, x As Decimal
                Dim Cantidad As Int16, i As Integer, A As String, nDecimal As Single
                Numero = Format(Numero, "#,##0.00")
                nDecimal = (Numero - Int(Numero)) * 100
                strDecimales = IIf(nDecimal > 0, String.Format(" con {0}/100", Right(String.Format("0{0}", Str(nDecimal)), 2)), "")
                'strDecimales = Right(strDecimales, 6)
                strNumero = Math.Floor(Numero)
                strTres = strNumero
                x = strNumero.Length / 3
                Cantidad = Math.Floor(x)
                If (Len(strNumero) Mod 3) > 0 Then Cantidad = Cantidad + 1
                A = ""
                For i = 1 To Cantidad
                    strTres = Right(strNumero, 3)
                    If Val(strTres) > 0 Then
                        Select Case i
                            Case 1 : A = String.Format("{0}{1}", getCentena(strTres, i), A)
                            Case 2, 4 : A = String.Format("{0} mil{1}", getCentena(strTres, i), A)
                            Case 3 : If Val(strTres) > 1 Then A = String.Format("{0} millones{1}", getCentena(strTres, i), A) Else A = String.Format("{0} millon{1}", getCentena(strTres, i), A)
                        End Select
                    End If
                    If Len(strNumero) > 3 Then strNumero = Mid(strNumero, 1, Len(strNumero) - 3)
                Next
                If A = "" Then strNumber = " cero " Else strNumber = A
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Convierte un formato de modena a una cadena de caracteres
    ''' </summary>
    ''' <param name="Numero"></param>
    ''' <param name="Mon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function strCurrency(ByVal Numero As Decimal, Optional ByVal Mon As Int16 = 0) As String
        Try
            Dim strDecimales As String, strNumero As String, strTres As String
            Dim Cantidad As Decimal, i As Integer, A As String, nDecimal As Single, strMoneda As String
            'Numero = Format(Numero, "#,##0.00")
            If Mon = 0 Then strMoneda = " córdobas " Else strMoneda = " dólares "
            nDecimal = (Numero - Int(Numero)) * 100
            strDecimales = IIf(nDecimal > 0, String.Format(" con {0}/100", Right(String.Format("00{0}", CInt(nDecimal)), 2)), "")
            strNumero = Trim(Str(Int(Numero)))
            strTres = strNumero
            Cantidad = Decimal.Floor(Len(strNumero) / 3)
            If (Len(strNumero) Mod 3) > 0 Then Cantidad = Cantidad + 1
            A = ""
            For i = 1 To Cantidad
                strTres = Right(strNumero, 3)
                If Val(strTres) > 0 Then
                    Select Case i
                        Case 1 : A = String.Format("{0}{1}", getCentena(strTres, i), A)
                        Case 2, 4 : A = String.Format("{0} mil{1}", getCentena(strTres, i), A)
                        Case 3 : If Val(strTres) > 1 Then A = String.Format("{0} millones{1}", getCentena(strTres, i), A) Else A = String.Format("{0} millon{1}", getCentena(strTres, i), A)
                    End Select
                End If
                If Len(strNumero) > 3 Then strNumero = Mid(strNumero, 1, Len(strNumero) - 3)
            Next
            If A = "" Then strCurrency = String.Format(" cero {0}{1}", strDecimales, strMoneda) Else strCurrency = String.Format("{0} {1}{2}", A, strMoneda, strDecimales)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function getCentena(ByVal Centena As String, ByVal Orden As Byte) As String
        Try
            If Val(Centena) = 100 Then getCentena = " cien" : Exit Function
            Select Case Len(Centena)
                Case 1 : getCentena = strUnidad(Centena, Orden)
                Case 2 : getCentena = strDecena(Centena, Orden)
                Case 3 : getCentena = String.Format("{0}{1}", strCentena(Mid(Centena, 1, 1), Orden), strDecena(Right(Centena, 2), Orden))
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function strUnidad(ByVal Unidad As Int16, ByVal Orden As Byte) As String
        Try
            Select Case Unidad
                Case 0 : strUnidad = "cero"
                Case 1 : strUnidad = " un"
                Case 2 : strUnidad = " dos"
                Case 3 : strUnidad = " tres"
                Case 4 : strUnidad = " cuatro"
                Case 5 : strUnidad = " cinco"
                Case 6 : strUnidad = " seis"
                Case 7 : strUnidad = " siete"
                Case 8 : strUnidad = " ocho"
                Case 9 : strUnidad = " nueve"
                Case 10 : strUnidad = " diez"
                Case 11 : strUnidad = " once"
                Case 12 : strUnidad = " doce"
                Case 13 : strUnidad = " trece"
                Case 14 : strUnidad = " catorce"
                Case 15 : strUnidad = " quince"
                Case 16 : strUnidad = " dieciseis"
                Case 17 : strUnidad = " diecisiete"
                Case 18 : strUnidad = " dieciocho"
                Case 19 : strUnidad = " diecinueve"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function strDecena(ByVal Decena As Int16, ByVal Orden As Byte) As String
        Try
            Dim strT As String
            If Decena >= 1 And Decena <= 19 Then strDecena = strUnidad(Decena, Orden) : Exit Function
            strT = ""
            Select Case Val(Left(Trim(Str(Decena)), 1))
                Case 2 : strT = " veinte"
                Case 3 : strT = " treinta"
                Case 4 : strT = " cuarenta"
                Case 5 : strT = " cincuenta"
                Case 6 : strT = " sesenta"
                Case 7 : strT = " setenta"
                Case 8 : strT = " ochenta"
                Case 9 : strT = " noventa"
            End Select
            If strT <> "" And Val(Right(Trim(Str(Decena)), 1)) > 0 Then strT = String.Format("{0} y{1}", strT, strUnidad(Val(Right(Str(Decena), 1)), Orden))
            strDecena = strT
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function strCentena(ByVal Centena As Int16, ByVal Orden As Byte) As String
        Try
            Dim strT As String
            strT = ""
            Select Case Centena
                Case 1 : strCentena = " ciento" : Exit Function
                Case 5 : strCentena = " quinientos" : Exit Function
                Case 7 : strCentena = " setecientos" : Exit Function
                Case 9 : strCentena = " novecientos" : Exit Function
                Case 2 To 4, 6, 8 : strT = strUnidad(Centena, Orden)
            End Select
            If strT <> "" Then strT = String.Format("{0}cientos", strT)
            strCentena = strT
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' rellena de ceros a la izquierda
    ''' </summary>
    ''' <param name="Campo"></param>
    ''' <param name="largo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function lCeros(ByVal Campo As String, ByVal largo As String) As String
        Try
            Dim cero As Integer
            Dim nceros As Integer = 0
            Dim icampo As String = ""
            nceros = largo - Campo.Trim.Length
            For cero = 0 To nceros - 1
                icampo = String.Format("{0}0", icampo)
            Next
            lCeros = String.Format("{0}{1}", icampo, Campo)
        Catch ex As Exception
            Return CStr(Campo)
        End Try
    End Function

    'Public Function strSql_Buscar_Cod_Producto_Existencias(ByVal strCod_Producto As String,
    '    ByVal Es_Servicio As Boolean,
    '    ByVal bMostrar_Existencias As Boolean,
    '    Optional ByVal bSóloSucursal As Boolean = False,
    '    Optional ByVal sIdBodega As String = "",
    '    Optional ByVal bSóloAcopio As Boolean = False) As String
    '    Try
    '        Dim strSql As String = ""
    '        Using tmpDs As New DataSet()
    '            Dim i As Short = 0
    '            If bSóloSucursal = True Then
    '                If sIdBodega.Trim.Length = 0 Then
    '                    strSql = String.Format("select IdBodega, Bodega from qry_bodegas where IdSucursal = {0} order by idbodega", objSesión.IdSucursal)
    '                Else
    '                    strSql = String.Format("select IdBodega, Bodega from qry_bodegas where IdBodega = '{0}' order by idbodega", sIdBodega)
    '                End If
    '            Else
    '                strSql = "select IdBodega, Bodega from qry_bodegas order by idbodega"
    '            End If
    '            consql.consql.LlenarDataSet(strSql, tmpDs)
    '            If tmpDs.Tables(0).Rows.Count > 0 Then
    '                strSql = "SELECT 	p.COD_PRODUCTO AS CODIGO, 	p.[DESCRIPCIÓN PRODUCTO] AS PRODUCTO, 	p.COD_PROVEEDOR AS PROVEEDOR, p.RETENER_IVA AS IVA,  isnull(SUM(s.stock), 0) as [Existencia Global] "
    '                For i = 0 To tmpDs.Tables(0).Rows.Count - 1
    '                    strSql = String.Format("{0}, sum( case s.idbodega when '{1}' then s.stock else 0 end) as [{2}-{3}] ", strSql, SinComillas(tmpDs.Tables(0).Rows(i)("IdBodega")), SinComillas(tmpDs.Tables(0).Rows(i)("IdBodega")), SinComillas(tmpDs.Tables(0).Rows(i)("Bodega")))
    '                Next
    '                strSql = String.Format("{0} FROM QRY_PRODUCTOS p left outer join inventario.stock s on p.cod_producto = s.cod_producto ", strSql)
    '                strSql = String.Format("{0} WHERE p.[COD_PRODUCTO] LIKE '%{2}%'", strSql, Es_Servicio.ToString, strfill(SinComillas(strCod_Producto).Trim, " ", "%"))
    '                strSql += String.Format(" {0} ", IIf(bSóloAcopio, String.Format(" AND P.ES_ACOPIO=1 "), ""))
    '                strSql = String.Format("{0} group by 	p.COD_PRODUCTO,  	p.[DESCRIPCIÓN PRODUCTO],  	p.COD_PROVEEDOR,  	p.RETENER_IVA ", strSql)
    '                If bMostrar_Existencias = True Then strSql = String.Format("{0} HAVING SUM(s.stock) > 0 ", strSql)
    '                strSql = String.Format("{0} ORDER BY p.[DESCRIPCIÓN PRODUCTO]", strSql)
    '            Else
    '                strSql = String.Format("SELECT COD_PRODUCTO AS CODIGO, [DESCRIPCIÓN PRODUCTO] AS PRODUCTO, COD_PROVEEDOR AS PROVEEDOR, RETENER_IVA AS IVA FROM QRY_PRODUCTOS WHERE [cod_producto] LIKE '%{0}%' ORDER BY [DESCRIPCIÓN PRODUCTO]", strfill(SinComillas(strCod_Producto).Trim, " ", "%"))
    '            End If
    '        End Using

    '        Return strSql
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function

    'Public Function strSql_Buscar_Productos_Existencias(ByVal strDescripción_Producto As String,
    '    ByVal Es_Servicio As Boolean,
    '    ByVal blnMostrar_Existencias As Boolean,
    '    Optional ByVal bSóloSucursal As Boolean = False,
    '    Optional ByVal sIdBodega As String = "",
    '    Optional ByVal bSelMultiple As Boolean = False,
    '    Optional ByVal bSóloAcopio As Boolean = False) As String
    '    Try
    '        Dim strSql As String = ""
    '        Using tmpDds As New DataSet()
    '            Dim i As Short = 0
    '            If bSóloSucursal = True Then
    '                If sIdBodega.Trim.Length = 0 Then
    '                    strSql = String.Format("select IdBodega, Bodega from qry_bodegas where IdSucursal = {0} order by idbodega", objSesión.IdSucursal)
    '                Else
    '                    strSql = String.Format("select IdBodega, Bodega from qry_bodegas where IdBodega = '{0}' order by idbodega", sIdBodega)
    '                End If
    '            Else
    '                strSql = "select IdBodega, Bodega from qry_bodegas order by idbodega"
    '            End If
    '            consql.LlenarDataSet(strSql, tmpDds)
    '            If TieneDatos(tmpDds) Then
    '                strSql = String.Format("SELECT {0}	p.COD_PRODUCTO AS CODIGO, 	p.[DESCRIPCIÓN PRODUCTO] AS PRODUCTO, 	p.COD_PROVEEDOR AS PROVEEDOR, p.RETENER_IVA AS IVA,  isnull(SUM(s.stock), 0) as [Existencia Global] ", IIf(bSelMultiple = True, "cast(0 as bit) as Selección, ", ""))
    '                For Each row As DataRow In tmpDds.Tables(0).Rows
    '                    strSql = String.Format("{0}, sum( case s.idbodega when '{1}' then s.stock else 0 end) as [{2}-{3}] ", strSql, SinComillas(row("IdBodega")), SinComillas(row("IdBodega")), SinComillas(row("Bodega")))
    '                Next
    '                strSql = String.Format("{0} FROM QRY_PRODUCTOS p left outer join inventario.stock s on p.cod_producto COLLATE DATABASE_DEFAULT= s.cod_producto COLLATE DATABASE_DEFAULT ", strSql)
    '                strSql = String.Format("{0} WHERE [DESCRIPCIÓN PRODUCTO] LIKE '%{2}%'", strSql, Es_Servicio.ToString, strfill(SinComillas(strDescripción_Producto).Trim, " ", "%"))
    '                strSql += String.Format(" {0} ", IIf(bSóloAcopio, String.Format(" AND P.ES_ACOPIO=1 "), ""))
    '                strSql += String.Format(" and p.sucursal = {0}", objSesión.IdSucursal)
    '                strSql += " group by 	p.COD_PRODUCTO,  	p.[DESCRIPCIÓN PRODUCTO],  	p.COD_PROVEEDOR,  	p.RETENER_IVA , p.sucursal "
    '                If blnMostrar_Existencias = True Then strSql = String.Format("{0} HAVING SUM(s.stock) > 0 ", strSql)
    '                strSql = String.Format("{0} ORDER BY p.[DESCRIPCIÓN PRODUCTO]", strSql)
    '            Else
    '                strSql = String.Format("SELECT COD_PRODUCTO AS CODIGO, [DESCRIPCIÓN PRODUCTO] AS PRODUCTO, COD_PROVEEDOR AS PROVEEDOR, RETENER_IVA AS IVA FROM QRY_PRODUCTOS WHERE [DESCRIPCIÓN PRODUCTO] LIKE '%{0}%' ORDER BY [DESCRIPCIÓN PRODUCTO]", strfill(SinComillas(strDescripción_Producto).Trim, " ", "%"))
    '            End If
    '        End Using

    '        Return strSql
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function

    ''' <summary>
    ''' igual que lceros
    ''' </summary>
    ''' <param name="numero"></param>
    ''' <param name="nCeros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function strCeros(ByVal numero As Integer, ByVal nCeros As Short) As String
        Try
            strCeros = (Strings.Right(String.Format("{0}{1}", Strings.StrDup(nCeros, "0"), CStr(numero)), nCeros))
        Catch ex As Exception
            strCeros = "0"
        End Try
    End Function

    ''' <summary>
    ''' Convierte en comilla doble una comilla sencilla, delimitador de cadena T-SQL
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SinComillas(ByVal strSql As String) As String
        SinComillas = strSql.Replace("'", "''")
    End Function

    Public Function strfill(ByVal str1 As String, ByVal str2 As String, ByVal str As String) As String
        Try
            Return str1.Replace(str2, str)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Verificacion de productos por clasificacion pro bodegas
    ''' </summary>
    ''' <param name="strCod_producto">Prosucto a verificar clasificación GDM</param>
    ''' <param name="intIdSucursal">Sucursal de la cual se esta logado </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function Verificar_Productos(ByVal strCod_producto As String, ByVal intIdSucursal As Integer) As Boolean
    '    Try
    '        Dim i As Integer = 0
    '        Dim strSql As String = String.Format("dbo.Verificar_Producto   @cod_producto = '{0}', @Sucursal = {1}", strCod_producto, intIdSucursal)
    '        Dim _cmd As New System.Data.SqlClient.SqlCommand(strSql, consql.SQLCN)
    '        i = _cmd.ExecuteScalar()
    '        If i = 1 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        ErrorMsg(ex.Message)
    '        Return False
    '    End Try
    'End Function

End Module
