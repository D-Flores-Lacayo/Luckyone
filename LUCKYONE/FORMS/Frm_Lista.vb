Imports OfficeOpenXml
Imports System.IO
Imports System


Public Class Frm_Lista

    Dim OBJCLIENTE As Cls_Cliente = New Cls_Cliente
    Public Sub Codigo_activo()
        Try
            Dim strsql As String = String.Format("SELECT t.ID_TICKET FROM TICKET AS t WHERE t.ID_USUARIO = {0} AND t.ACTIVO = 1", idusuairo)
            Me.IDTICKET.Text = consql.consql.numEscalar(strsql)

            strsql = String.Format("SELECT ISNULL(MAX(lh.ID_LISTA_HEADER),0) + 1 FROM LISTA_HEADER AS lh WHERE lh.ID_TICKET ={0} AND lh.ID_USUARIO={1}", Me.IDTICKET.Text, idusuairo)
            Me.IDVENTA.Text = consql.consql.numEscalar(strsql)


            strsql = String.Format("SELECT T.FECHA FROM TICKET AS t WHERE t.ID_USUARIO = {0} AND t.ACTIVO = 1", idusuairo)
            Dim dia As DateTime = consql.consql.strEscalar(strsql)
            Dim fech As String = consql.consql.strEscalar(strsql)
            LBLFECHA.Text = dia.ToString("dddd") & " " & dia.Day & "-" & dia.ToString("MM") & "-" & dia.Year

            strsql = String.Format("SELECT T2.TURNO FROM TICKET AS t INNER JOIN TURNOS AS t2 ON t2.ID_TURNO = t.ID_TURNO WHERE T.ID_TICKET ={0} AND T.ID_USUARIO ={1} AND t.ACTIVO=1", IDTICKET.Text, idusuairo)
            LBLTURNO.Text = consql.consql.strEscalar(strsql)
            lblIdlista.Text = 0
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub limpiar_tmp()
        Try
            Dim strsql As String = String.Format("DELETE FROM MC_LISTA_TMP WHERE SESIÓN = '{0}' AND ID_TICKET = {1} AND ID_USUARIO = {2}", SinComillas(sesion), Me.IDTICKET.Text, idusuairo)
            consql.consql.Ejecutar(strsql)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IR_CARGAR_GRD()
        Try
            Dim strsql As String = String.Format("EXEC CARGAR_GRV_LISTA	@ID_USUARIO = {0},	@IDTICKET = {1}", idusuairo, Me.IDTICKET.Text)
            CargarDXGrid(strsql, GRD)
            HacerEditableDXGrid(GRV, False)


            GRV.Columns("VALOR1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR1").DisplayFormat.FormatString = "N2"

            GRV.Columns("VALOR2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR2").DisplayFormat.FormatString = "N2"

            GRV.Columns("VALOR3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR3").DisplayFormat.FormatString = "N2"

            GRV.Columns("VALOR4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR4").DisplayFormat.FormatString = "N2"

            GRV.Columns("VALOR5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR5").DisplayFormat.FormatString = "N2"
            Me.GRV.Columns(0).AppearanceCell.BackColor = Color.AliceBlue
            Me.GRV.Columns(2).AppearanceCell.BackColor = Color.AliceBlue
            Me.GRV.Columns(4).AppearanceCell.BackColor = Color.AliceBlue
            Me.GRV.Columns(6).AppearanceCell.BackColor = Color.AliceBlue
            Me.GRV.Columns(8).AppearanceCell.BackColor = Color.AliceBlue

            'Me.GRV.Columns(1).AppearanceCell.BackColor = Color.White
            'Me.GRV.Columns(3).AppearanceCell.BackColor = Color.White
            'Me.GRV.Columns(5).AppearanceCell.BackColor = Color.White
            'Me.GRV.Columns(7).AppearanceCell.BackColor = Color.White
            'Me.GRV.Columns(9).AppearanceCell.BackColor = Color.White

            Me.GRV.Columns(0).Width = 30
            Me.GRV.Columns(2).Width = 30
            Me.GRV.Columns(4).Width = 30
            Me.GRV.Columns(6).Width = 30
            Me.GRV.Columns(8).Width = 30

            Me.GRV.Columns(1).Width = 100
            Me.GRV.Columns(3).Width = 100
            Me.GRV.Columns(5).Width = 100
            Me.GRV.Columns(7).Width = 100
            Me.GRV.Columns(9).Width = 100
            Me.GRV.OptionsSelection.EnableAppearanceFocusedRow = False
            Me.GRV.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GRV.VertScrollVisibility = False

            strsql = String.Format(" SELECT lh.ID_TICKET 'TURNO', lh.ID_LISTA_HEADER 'LISTA', lh.FECHA, lh.VENTA FROM LISTA_HEADER AS lh WHERE lh.ID_TICKET = {0} AND lh.ID_USUARIO = {1}", IDTICKET.Text, idusuairo)
            CargarDXGrid(strsql, grd1)
            HacerEditableDXGrid(grv1, False)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try

    End Sub
    Private Sub NUEVO()
        Try
            Codigo_activo()
            IR_CARGAR_GRD()




        Catch ex As Exception

        End Try
    End Sub
    Private Sub Frm_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            NUEVO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles IDCLIENTE.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Enter
                    If OBJCLIENTE.UBICAR(Me.IDCLIENTE.Text) = True Then

                        Me.IDCLIENTE.Enabled = False
                        Me.txtClienteNom.Text = OBJCLIENTE.NOMBRES

                    Else

                        ErrorMsg("ERROR AL CARGAR CLIENTE/CLIENTE NO ENCONTRADO")
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNEXCEL_Click(sender As Object, e As EventArgs) Handles BTNEXCEL.Click
        Try

            If Me.IDCLIENTE.Text = "" Then
                ErrorMsg("Favor Selecionar Cliente")
                Exit Sub
            End If
            Using frm As OpenFileDialog = New OpenFileDialog() With {.DefaultExt = "xls", .Filter = "Archivo Microsoft Excel|*.xls|Excel xlsx|*.xlsx"}
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Dim excelpag As ExcelPackage
                    If frm.FilterIndex = 1 Then
                        Dim app = New Microsoft.Office.Interop.Excel.Application()
                        Dim file As FileInfo = New FileInfo(frm.FileName)
                        Dim xlsFile = file.FullName
                        Dim wb = app.Workbooks.Open(xlsFile)
                        Dim xlsxFile = xlsFile + "x"
                        wb.SaveAs(xlsxFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)

                        wb.Close()
                        app.Quit()
                        excelpag = New ExcelPackage(New FileInfo(xlsxFile))
                    Else
                        excelpag = New ExcelPackage(New FileInfo(frm.FileName))
                    End If


                    Dim hoja As ExcelWorksheet = excelpag.Workbook.Worksheets("Lista General")

                    Dim STRSQL As String
                    limpiar_tmp()

                    GRV.BeginSort()
                    Try
                        Dim VAL As Decimal
                        'Case "00"
                        'hoja.Cells("A4").Value = Convert.ToInt16(numero)
                        'hoja.Cells("B4").Value = VALOR

                        If IsNumeric(hoja.Cells("B4").Value) And IsNumeric(hoja.Cells("B5").Value) And IsNumeric(hoja.Cells("B6").Value) And IsNumeric(hoja.Cells("B7").Value) And IsNumeric(hoja.Cells("B8").Value) And IsNumeric(hoja.Cells("B9").Value) And IsNumeric(hoja.Cells("B10").Value) And IsNumeric(hoja.Cells("B11").Value) And IsNumeric(hoja.Cells("B12").Value) And IsNumeric(hoja.Cells("B13").Value) And IsNumeric(hoja.Cells("B14").Value) And IsNumeric(hoja.Cells("B15").Value) And IsNumeric(hoja.Cells("B16").Value) And IsNumeric(hoja.Cells("B17").Value) And IsNumeric(hoja.Cells("B18").Value) And IsNumeric(hoja.Cells("B19").Value) And IsNumeric(hoja.Cells("B20").Value) And IsNumeric(hoja.Cells("B21").Value) And IsNumeric(hoja.Cells("B22").Value) And IsNumeric(hoja.Cells("B23").Value) And IsNumeric(hoja.Cells("B24").Value) And IsNumeric(hoja.Cells("B25").Value) And IsNumeric(hoja.Cells("B26").Value) And IsNumeric(hoja.Cells("B27").Value) And IsNumeric(hoja.Cells("B28").Value) And IsNumeric(hoja.Cells("B29").Value) And IsNumeric(hoja.Cells("B30").Value) And IsNumeric(hoja.Cells("B31").Value) And IsNumeric(hoja.Cells("B32").Value) And IsNumeric(hoja.Cells("B33").Value) And IsNumeric(hoja.Cells("B34").Value) And IsNumeric(hoja.Cells("B35").Value) And IsNumeric(hoja.Cells("B36").Value) And IsNumeric(hoja.Cells("B37").Value) And IsNumeric(hoja.Cells("D4").Value) And IsNumeric(hoja.Cells("D5").Value) And IsNumeric(hoja.Cells("D6").Value) And IsNumeric(hoja.Cells("D7").Value) And IsNumeric(hoja.Cells("D8").Value) And IsNumeric(hoja.Cells("D9").Value) And IsNumeric(hoja.Cells("D10").Value) And IsNumeric(hoja.Cells("D11").Value) And IsNumeric(hoja.Cells("D12").Value) And IsNumeric(hoja.Cells("D13").Value) And IsNumeric(hoja.Cells("D14").Value) And IsNumeric(hoja.Cells("D15").Value) And IsNumeric(hoja.Cells("D16").Value) And IsNumeric(hoja.Cells("D17").Value) And IsNumeric(hoja.Cells("D18").Value) And IsNumeric(hoja.Cells("D19").Value) And IsNumeric(hoja.Cells("D20").Value) And IsNumeric(hoja.Cells("D21").Value) And IsNumeric(hoja.Cells("D22").Value) And IsNumeric(hoja.Cells("D23").Value) And IsNumeric(hoja.Cells("D24").Value) And IsNumeric(hoja.Cells("D25").Value) And IsNumeric(hoja.Cells("D26").Value) And IsNumeric(hoja.Cells("D27").Value) And IsNumeric(hoja.Cells("D28").Value) And IsNumeric(hoja.Cells("D29").Value) And IsNumeric(hoja.Cells("D30").Value) And IsNumeric(hoja.Cells("D31").Value) And IsNumeric(hoja.Cells("D32").Value) And IsNumeric(hoja.Cells("D33").Value) And IsNumeric(hoja.Cells("D34").Value) And IsNumeric(hoja.Cells("D35").Value) And IsNumeric(hoja.Cells("D36").Value) And IsNumeric(hoja.Cells("F4").Value) And IsNumeric(hoja.Cells("F5").Value) And IsNumeric(hoja.Cells("F6").Value) And IsNumeric(hoja.Cells("F7").Value) And IsNumeric(hoja.Cells("F8").Value) And IsNumeric(hoja.Cells("F9").Value) And IsNumeric(hoja.Cells("F10").Value) And IsNumeric(hoja.Cells("F11").Value) And IsNumeric(hoja.Cells("F12").Value) And IsNumeric(hoja.Cells("F13").Value) And IsNumeric(hoja.Cells("F14").Value) And IsNumeric(hoja.Cells("F15").Value) And IsNumeric(hoja.Cells("F16").Value) And IsNumeric(hoja.Cells("F17").Value) And IsNumeric(hoja.Cells("F18").Value) And IsNumeric(hoja.Cells("F19").Value) And IsNumeric(hoja.Cells("F20").Value) And IsNumeric(hoja.Cells("F21").Value) And IsNumeric(hoja.Cells("F22").Value) And IsNumeric(hoja.Cells("F23").Value) And IsNumeric(hoja.Cells("F24").Value) And IsNumeric(hoja.Cells("F25").Value) And IsNumeric(hoja.Cells("F26").Value) And IsNumeric(hoja.Cells("F27").Value) And IsNumeric(hoja.Cells("F28").Value) And IsNumeric(hoja.Cells("F29").Value) And IsNumeric(hoja.Cells("F30").Value) And IsNumeric(hoja.Cells("F31").Value) And IsNumeric(hoja.Cells("F32").Value) And IsNumeric(hoja.Cells("F33").Value) And IsNumeric(hoja.Cells("F34").Value) And IsNumeric(hoja.Cells("F35").Value) And IsNumeric(hoja.Cells("F36").Value) Then
                            STRSQL = String.Format("EXEC INICIALIZAR_MC_LISTA_TMP 	@SESION = '{0}', 	@IDTICKET = {1}, 	@IDUSUARIO = {2}, 	@IDLISTA = {3}", SinComillas(sesion), Me.IDTICKET.Text, idusuairo, Me.IDVENTA.Text)
                            consql.consql.Ejecutar(STRSQL)
                            If hoja.Cells("B4").Value > 0 Then
                                VAL = hoja.Cells("B4").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 1", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B5").Value) > 0 Then
                                VAL = hoja.Cells("B5").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 2", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B6").Value) > 0 Then
                                VAL = hoja.Cells("B6").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 3", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B7").Value) > 0 Then
                                VAL = hoja.Cells("B7").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 4", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B8").Value) > 0 Then
                                VAL = hoja.Cells("B8").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 5", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B9").Value) > 0 Then
                                VAL = hoja.Cells("B9").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 6", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B10").Value) > 0 Then
                                VAL = hoja.Cells("B10").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 7", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B11").Value) > 0 Then
                                VAL = hoja.Cells("B11").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 8", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B12").Value) > 0 Then
                                VAL = hoja.Cells("B12").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 9", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B13").Value) > 0 Then
                                VAL = hoja.Cells("B13").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 10", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B14").Value) > 0 Then
                                VAL = hoja.Cells("B14").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 11", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B15").Value) > 0 Then
                                VAL = hoja.Cells("B15").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 12", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B16").Value) > 0 Then
                                VAL = hoja.Cells("B16").Value
                                STRSQL = String.Format("UPDATE  mlt SET MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 13", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B17").Value) > 0 Then
                                VAL = hoja.Cells("B17").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 14", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B18").Value) > 0 Then
                                VAL = hoja.Cells("B18").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 15", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B19").Value) > 0 Then
                                VAL = hoja.Cells("B19").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 16", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B20").Value) > 0 Then
                                VAL = hoja.Cells("B20").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 17", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B21").Value) > 0 Then
                                VAL = hoja.Cells("B21").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 18", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B22").Value) > 0 Then
                                VAL = hoja.Cells("B22").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 19", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B23").Value) > 0 Then
                                VAL = hoja.Cells("B23").Value
                                STRSQL = String.Format("UPDATE  mlt SET MLT.VALOR1 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 20", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B24").Value) > 0 Then
                                VAL = hoja.Cells("B24").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 1", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B25").Value) > 0 Then
                                VAL = hoja.Cells("B25").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 2", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B26").Value) > 0 Then
                                VAL = hoja.Cells("B26").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 3", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B27").Value) > 0 Then
                                VAL = hoja.Cells("B27").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 4", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B28").Value) > 0 Then
                                VAL = hoja.Cells("B28").Value
                                STRSQL = String.Format("UPDATE  mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 5", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B29").Value) > 0 Then
                                VAL = hoja.Cells("B29").Value
                                STRSQL = String.Format("UPDATE  mlt SET MLT.VALOR2= {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 6", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B30").Value) Then
                                VAL = hoja.Cells("B30").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 7", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B31").Value) > 0 Then
                                VAL = hoja.Cells("B31").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 8", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B32").Value) > 0 Then
                                VAL = hoja.Cells("B32").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 9", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B33").Value) > 0 Then
                                VAL = hoja.Cells("B33").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 10", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B34").Value) > 0 Then
                                VAL = hoja.Cells("B34").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 11", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B35").Value) > 0 Then
                                VAL = hoja.Cells("B35").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 12", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B36").Value) > 0 Then
                                VAL = hoja.Cells("B36").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 13", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("B37").Value) > 0 Then
                                VAL = hoja.Cells("B37").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 14", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D4").Value) > 0 Then
                                VAL = hoja.Cells("D4").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 15", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D5").Value) > 0 Then
                                VAL = hoja.Cells("D5").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 16", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If

                            If (hoja.Cells("D6").Value) > 0 Then
                                VAL = hoja.Cells("D6").Value

                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 17", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)

                            End If

                            If (hoja.Cells("D7").Value) > 0 Then
                                VAL = hoja.Cells("D7").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 18", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D8").Value) > 0 Then
                                VAL = hoja.Cells("D8").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 19", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D9").Value) > 0 Then
                                VAL = hoja.Cells("D9").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR2 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 20", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D10").Value) > 0 Then
                                VAL = hoja.Cells("D10").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 1", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D11").Value) > 0 Then
                                VAL = hoja.Cells("D11").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 2", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D12").Value) > 0 Then
                                VAL = hoja.Cells("D12").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 3", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D13").Value) > 0 Then
                                VAL = hoja.Cells("D13").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 4", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D14").Value) > 0 Then
                                VAL = hoja.Cells("D14").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 5", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D15").Value) > 0 Then
                                VAL = hoja.Cells("D15").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 6", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D16").Value) > 0 Then
                                VAL = hoja.Cells("D16").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 7", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D17").Value) > 0 Then
                                VAL = hoja.Cells("D17").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 8", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D18").Value) > 0 Then
                                VAL = hoja.Cells("D18").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 9", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D19").Value) > 0 Then
                                VAL = hoja.Cells("D19").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 10", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D20").Value) > 0 Then
                                VAL = hoja.Cells("D20").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 11", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D21").Value) > 0 Then
                                VAL = hoja.Cells("D21").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 12", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D22").Value) > 0 Then
                                VAL = hoja.Cells("D22").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 13", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D23").Value) > 0 Then
                                VAL = hoja.Cells("D23").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 14", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D24").Value) > 0 Then
                                VAL = hoja.Cells("D24").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 15", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D25").Value) > 0 Then
                                VAL = hoja.Cells("D25").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3= {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 16", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D26").Value) > 0 Then
                                VAL = hoja.Cells("D26").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 17", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D27").Value) > 0 Then
                                VAL = hoja.Cells("D27").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR3= {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 18", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D28").Value) > 0 Then
                                VAL = hoja.Cells("D28").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 19", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D29").Value) > 0 Then
                                VAL = hoja.Cells("D29").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR3= {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 20", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D30").Value) > 0 Then
                                VAL = hoja.Cells("D30").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 1", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D31").Value) > 0 Then
                                VAL = hoja.Cells("D31").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 2", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D32").Value) > 0 Then
                                VAL = hoja.Cells("D32").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 3", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D33").Value) > 0 Then
                                VAL = hoja.Cells("D33").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 4", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D34").Value) > 0 Then
                                VAL = hoja.Cells("D34").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 5", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D35").Value) > 0 Then
                                VAL = hoja.Cells("D35").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 6", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("D36").Value) > 0 Then
                                VAL = hoja.Cells("D36").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 7", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F4").Value) > 0 Then
                                VAL = hoja.Cells("F4").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 8", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F5").Value) > 0 Then
                                VAL = hoja.Cells("F5").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 9", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F6").Value) > 0 Then
                                VAL = hoja.Cells("F6").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 10", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F7").Value) > 0 Then
                                VAL = hoja.Cells("F7").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 11", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F8").Value) > 0 Then
                                VAL = hoja.Cells("F8").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 12", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F9").Value) > 0 Then
                                VAL = hoja.Cells("F9").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 13", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F10").Value) > 0 Then
                                VAL = hoja.Cells("F10").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 14", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F11").Value) > 0 Then
                                VAL = hoja.Cells("F11").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 15", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F12").Value) > 0 Then
                                VAL = hoja.Cells("F12").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 16", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F13").Value) > 0 Then
                                VAL = hoja.Cells("F13").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 17", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F14").Value) > 0 Then
                                VAL = hoja.Cells("F14").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 18", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F15").Value) > 0 Then
                                VAL = hoja.Cells("F15").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 19", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F16").Value) > 0 Then
                                VAL = hoja.Cells("F16").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR4 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 20", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F17").Value) > 0 Then
                                VAL = hoja.Cells("F17").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 1", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F18").Value) > 0 Then
                                VAL = hoja.Cells("F18").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI =2", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F19").Value) > 0 Then
                                VAL = hoja.Cells("F19").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 3", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F20").Value) > 0 Then
                                VAL = hoja.Cells("F20").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 4", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F21").Value) > 0 Then
                                VAL = hoja.Cells("F21").Value
                                STRSQL = String.Format("UPDATE mlt SET  MLT.VALOR5= {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 5", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F22").Value) > 0 Then
                                VAL = hoja.Cells("F22").Value
                                STRSQL = String.Format("UPDATE  mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 6", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F23").Value) > 0 Then
                                VAL = hoja.Cells("F23").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 7", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F24").Value) > 0 Then
                                VAL = hoja.Cells("F24").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 8", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F25").Value) > 0 Then
                                VAL = hoja.Cells("F25").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 9", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F26").Value) > 0 Then
                                VAL = hoja.Cells("F26").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 10", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F27").Value) > 0 Then
                                VAL = hoja.Cells("F27").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 11", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F28").Value) > 0 Then
                                VAL = hoja.Cells("F28").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 12", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F29").Value) > 0 Then
                                VAL = hoja.Cells("F29").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 13", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F30").Value) > 0 Then
                                VAL = hoja.Cells("F30").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 14", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F31").Value) > 0 Then
                                VAL = hoja.Cells("F31").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 15", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F32").Value) > 0 Then
                                VAL = hoja.Cells("F32").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 16", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F33").Value) > 0 Then
                                VAL = hoja.Cells("F33").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 17", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F34").Value) > 0 Then
                                VAL = hoja.Cells("F34").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 18", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F35").Value) > 0 Then
                                VAL = hoja.Cells("F35").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 19", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If (hoja.Cells("F36").Value) > 0 Then
                                VAL = hoja.Cells("F36").Value
                                STRSQL = String.Format("UPDATE mlt SET MLT.VALOR5 = {0} FROM MC_LISTA_TMP AS mlt WHERE mlt.SESIÓN = '{1}' AND mlt.ID_TICKET = {2} AND mlt.ID_LISTA = {3} AND mlt.ID_USUARIO = {4} AND CONTROLI = 20", VAL, SinComillas(sesion), IDTICKET.Text, Me.IDVENTA.Text, idusuairo)
                                consql.consql.Ejecutar(STRSQL)
                            End If
                            If IsNumeric(hoja.Cells("B38").Value) And IsNumeric(hoja.Cells("D38").Value) And IsNumeric(hoja.Cells("F38").Value) Then
                                Dim SSUM1 As Decimal = hoja.Cells("B38").Value
                                Dim SSUM2 As Decimal = hoja.Cells("D38").Value
                                Dim SSUM3 As Decimal = hoja.Cells("F38").Value


                                Dim form As Frm_Lista_tmp = New Frm_Lista_tmp With {.ticket = Me.IDTICKET.Text, .lista = Me.IDVENTA.Text, .client = Me.IDCLIENTE.Text, .SUM1 = SSUM1, .SUM2 = SSUM2, .SUM3 = SSUM3}

                                form.ShowDialog()
                                IR_CARGAR_GRD()
                                Codigo_activo()
                                Me.IDCLIENTE.Enabled = True
                                Me.IDCLIENTE.Text = ""

                            Else
                                ErrorMsg("ALGUNA DE LA SUMATORIA DE SUBTOTALES NO TIENE VALOR NUMÉRICO")
                                Exit Sub
                            End If


                        Else
                            ErrorMsg("UNO O VARIOS VALORES DE LOS NUMEROS NO TIENE VALOR NUMÉRICO")
                            Exit Sub
                        End If




                    Finally
                        GRV.EndSort()
                    End Try

                    'Dim myFile As New System.IO.FileInfo(frm.FileName)
                    'Dim strF As String = myFile.FullName.Substring(myFile.DirectoryName.Length + 1)
                    'strF = Strings.Left(strF, Strings.InStr(strF, ".xls") - 1)
                    'Dim opts As New DevExpress.XtraPrinting.XlsxExportOptions With {.SheetName = strF}
                    '_dg.ExportToXlsx(frm.FileName, opts)
                    'Msg(String.Format("'{0}'", frm.FileName), "Se ha exportado la consulta al archivo:")


                End If
            End Using

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btneliminarlista.Click
        Try
            If Me.lblIdlista.Text > 0 Then
                Dim strsql As String = String.Format("exec ANULAR_LISTA @IDTICKET = {0},@IDUSUARIO = {1},@IDLISTA = {2}", Me.IDTICKET.Text, idusuairo, lblIdlista.Text)

                If consql.consql.Ejecutar(strsql) = True Then
                    OkMsg("Lista Eliminada Correctamente")
                    Me.NUEVO()
                Else
                    ErrorMsg("Error al Eliminar Lista")
                End If

            Else
                ErrorMsg("No ha Cargado ninguna lista")

            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub grv1_DoubleClick(sender As Object, e As EventArgs) Handles grv1.DoubleClick
        Try
            Dim fila As DataRow = Me.grv1.GetDataRow(Me.grv1.FocusedRowHandle())

            Me.lblIdlista.Text = fila("LISTA")

        Catch ex As Exception

        End Try
    End Sub
End Class