Imports DevExpress.XtraGrid.Views.Grid
Imports OfficeOpenXml
Imports System.IO
Imports System

Public Class Frm_Master_Recorte
    Dim idticket As Integer
    Dim idmasterticket As Integer
    Dim idlista As Integer
    Dim IDRECORTE As Integer



    Public Sub Codigo_activo()
        Try
            Dim strsql As String = String.Format("SELECT t.ID_TICKET FROM TICKET AS t WHERE t.ID_USUARIO = {0} AND t.ACTIVO = 1", idusuairo)
            Me.idticket = consql.consql.numEscalar(strsql)


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub Codigo_activo2()
        Try
            Dim strsql As String

            strsql = String.Format("SELECT mt.ID_MASTER  FROM MC_TICKET AS mt WHERE mt.ID_TICKET = {0}  AND mt.ID_USUARIO = {1}", Me.idticket, idusuairo)
            Me.idmasterticket = consql.consql.numEscalar(strsql)

            strsql = String.Format("SELECT mt.ID_MASTER_LISTA  FROM MC_LISTA AS mt WHERE mt.ID_TICKET = {0}  AND mt.ID_USUARIO = {1}", Me.idticket, idusuairo)
            Me.idlista = consql.consql.numEscalar(strsql)

            strsql = String.Format("SELECT mr.ID_MASTER_RECORTE FROM MC_RECORTE AS mr WHERE mr.ID_MASTER_LISTA = {0} AND mr.ID_MASTER = {1} AND mr.ID_USUARIO= {2}", idlista, idmasterticket, idusuairo)
            Me.IDRECORTE = consql.consql.numEscalar(strsql)

            strsql = String.Format("SELECT T.FECHA FROM TICKET AS t WHERE t.ID_USUARIO = {0} AND t.ACTIVO = 1", idusuairo)
            Dim dia As DateTime = consql.consql.strEscalar(strsql)
            Dim fech As String = consql.consql.strEscalar(strsql)
            LBLFECHA.Text = dia.ToString("dddd") & " " & dia.Day & "-" & dia.ToString("MM") & "-" & dia.Year

            strsql = String.Format("SELECT T2.TURNO FROM TICKET AS t INNER JOIN TURNOS AS t2 ON t2.ID_TURNO = t.ID_TURNO WHERE T.ID_TICKET ={0} AND T.ID_USUARIO ={1} ", idticket, idusuairo)
            LBLTURNO.Text = consql.consql.strEscalar(strsql)


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub cargar_grd_recorte()

        Try
            Dim STRSQL As String
            STRSQL = String.Format("EXEC cargar_grd_recorte 	@idusuario = {0},	@idmcticket = {1},	@idlista = {2},	@idrecorte = {3}", idusuairo, idmasterticket, idlista, IDRECORTE)

            CargarDXGrid(STRSQL, GRD)
            HacerEditableDXGrid(GRV, False)
            If GRV.RowCount = 0 Then
                ErrorMsg("TICKET NO ENCONTRADA")
                Exit Sub
            End If
            Me.GRV.Columns(0).AppearanceCell.BackColor = Color.AliceBlue


            GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatString = "N0"


            Me.GRV.Columns(0).Width = 30


            Me.GRV.OptionsSelection.EnableAppearanceFocusedRow = False
            Me.GRV.OptionsSelection.EnableAppearanceFocusedCell = False

        Catch ex As Exception

        End Try
    End Sub
    Private Sub actualizar_recorte()
        Try
            Dim STRSQL As String

            STRSQL = String.Format("EXEC ACTUALIZAR_MC_RECORTE	@IDUSUARIO = {0}, 	@IDTICKET = {1}, 	@IDMC = {2}, 	@IDMC_LISTA = {3},	@IDMC_RECORTE = {4}", idusuairo, idticket, idmasterticket, idlista, IDRECORTE)
            consql.consql.Ejecutar(STRSQL)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub CALCULAR_GRUPOS()
        Try

            Me.TXTTICKET.Text = idticket
            Dim STRSQL As String = String.Format("SELECT ISNULL(SUM(mr.VENTA_GLOBAL),0)FROM MC_RECORTE mr	WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1} AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3}", IDRECORTE, idlista, idmasterticket, idusuairo)
            Me.TXTSUMG1.Text = consql.consql.numEscalar(STRSQL)
            If Convert.ToDecimal(TXTSUMG1.Text) > 0.00 Then
                Me.TXTG112.Text = Convert.ToDecimal(Me.TXTSUMG1.Text) * 12 / 1000
                Me.TXTG115.Text = Convert.ToDecimal(Me.TXTSUMG1.Text) * 15 / 1000
            End If
            STRSQL = String.Format("SELECT ISNULL(SUM(mr.VENTA_GLOBAL - MR.RECORTE_VENTA),0)FROM MC_RECORTE mr	WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1} AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3}and mr.venta_global> mr.recorte_venta", IDRECORTE, idlista, idmasterticket, idusuairo)
            Me.TXTSUMG2.Text = consql.consql.numEscalar(STRSQL)
            If Convert.ToDecimal(TXTSUMG2.Text) > 0.00 Then
                Me.TXTG212.Text = Convert.ToDecimal(Me.TXTSUMG2.Text) * 12 / 1000
                Me.TXTG215.Text = Convert.ToDecimal(Me.TXTSUMG2.Text) * 15 / 1000

            End If

            Me.TXTSUMG3.Text = Convert.ToDecimal(Me.TXTSUMG1.Text) - Convert.ToDecimal(Me.TXTSUMG2.Text)

            Me.TXTG312.Text = Convert.ToDecimal(Me.TXTSUMG3.Text) * 12 / 1000
            Me.TXTG315.Text = Convert.ToDecimal(Me.TXTSUMG3.Text) * 15 / 1000

            Me.TXTRESULTADO.Text = Convert.ToDecimal(Me.TXTSUMG3.Text) * 12 / 1000 - Convert.ToDecimal(Me.TXTRECORTE.Text)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub nuevo()
        Try
            Codigo_activo()
            Codigo_activo2()
            actualizar_recorte()
            cargar_grd_recorte()
            CALCULAR_GRUPOS()



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub ver015()
        Try
            GRV.BeginSort()
            Try
                Dim DataRowCount As Integer = GRV.DataRowCount
                ' Traverse data rows and change the Price field values.  

                GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatString = "N2"

                Dim I As Integer
                For I = 0 To DataRowCount - 1
                    Dim VALOR1 As Object = GRV.GetRowCellValue(I, "R. VENTA")
                    Dim VALOR2 As Object = GRV.GetRowCellValue(I, "Utilidad")
                    Dim VALOR3 As Object = GRV.GetRowCellValue(I, "VENTA_GLOBAL")

                    GRV.SetRowCellValue(I, "R. VENTA", Convert.ToDouble(VALOR1) * 15 / 1000)
                    GRV.SetRowCellValue(I, "Utilidad", Convert.ToDouble(VALOR2) * 15 / 1000)
                    GRV.SetRowCellValue(I, "VENTA_GLOBAL", Convert.ToDouble(VALOR3) * 15 / 1000)
                Next
            Finally
                GRV.EndSort()
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Frm_Master_Recorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            nuevo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTRECORTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTRECORTE.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    If Convert.ToDecimal(Me.TXTRECORTE.Text) > 0 Then

                        Dim strsql As String = String.Format("UPDATE MC_RECORTE SET RECORTE_VENTA = {0} WHERE ID_MASTER_RECORTE = {1} AND ID_MASTER_LISTA = {2} AND ID_MASTER = {3} AND ID_USUARIO = {4}", Convert.ToDecimal(Me.TXTRECORTE.Text), IDRECORTE, idlista, idmasterticket, idusuairo)
                        consql.consql.Ejecutar(strsql)
                        Me.Chkconvertir.Checked = True
                        cargar_grd_recorte()
                        CALCULAR_GRUPOS()

                        For i As Integer = 0 To GRV.DataRowCount - 1
                            Dim row As DataRow = GRV.GetDataRow(i)
                            Dim resultado As Decimal = Convert.ToDecimal(Me.TXTG312.Text) - Convert.ToDecimal(row("Utilidad"))
                            Me.GRV.SetRowCellValue(i, "Pérdida", resultado)
                            'row = GRV.GetDataRow(i)
                            'Dim resultado1 As Decimal = Convert.ToDecimal(row("Pérdida"))
                            'If resultado1 >= 0 Then
                            'End If

                        Next



                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkconvertir_CheckedChanged(sender As Object, e As EventArgs) Handles Chkconvertir.CheckedChanged
        Try
            If Me.Chkconvertir.Checked = False Then
                ver015()
            Else
                ver_premio()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ver_premio()
        Try
            GRV.BeginSort()
            Try
                Dim DataRowCount As Integer = GRV.DataRowCount
                ' Traverse data rows and change the Price field values.  

                GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GRV.Columns("VENTA_GLOBAL").DisplayFormat.FormatString = "N0"

                Dim I As Integer
                For I = 0 To DataRowCount - 1
                    Dim VALOR1 As Object = GRV.GetRowCellValue(I, "R. VENTA")
                    Dim VALOR2 As Object = GRV.GetRowCellValue(I, "Utilidad")
                    Dim VALOR3 As Object = GRV.GetRowCellValue(I, "VENTA_GLOBAL")

                    GRV.SetRowCellValue(I, "R. VENTA", Convert.ToDouble(VALOR1) * 1000 / 15)
                    GRV.SetRowCellValue(I, "Utilidad", Convert.ToDouble(VALOR2) * 1000 / 15)
                    GRV.SetRowCellValue(I, "VENTA_GLOBAL", Convert.ToDouble(VALOR3) * 1000 / 15)

                Next
            Finally
                GRV.EndSort()
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GRV_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GRV.RowCellStyle
        Try
            Dim vista As GridView = sender
            If e.Column.FieldName = "Pérdida" Then
                If Convert.ToDecimal(GRV.GetRowCellValue(e.RowHandle, "Pérdida")) >= 0 Then
                    e.Appearance.ForeColor = Color.Green
                Else
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTRESULTADO_EditValueChanged(sender As Object, e As EventArgs) Handles TXTRESULTADO.EditValueChanged
        Try
            If Convert.ToDecimal(Me.TXTRESULTADO.Text) >= 0 Then
                Me.TXTRESULTADO.ForeColor = Color.Green
            Else
                Me.TXTRESULTADO.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNEXCEL_Click(sender As Object, e As EventArgs) Handles BTNEXCEL.Click
        Try
            Using frm As SaveFileDialog = New SaveFileDialog() With {.DefaultExt = "xls", .Filter = "Archivo Microsoft Excel|*.xlsx", .FileName = LBLFECHA.Text}
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    Dim excelpag As ExcelPackage = New ExcelPackage(New FileInfo(frm.FileName))

                    Dim hoja As ExcelWorksheet = excelpag.Workbook.Worksheets.Add("Lista General")

                    Dim STRSQL As String = String.Format("SELECT u.USUARIO FROM USUARIO AS u WHERE U.ID_USUARIO = {0}", idusuairo)
                    hoja.Cells("A2").Value = "LISTA GENERAL"
                    hoja.Cells("A2").Style.Font.Size = 16
                    hoja.Cells("A3").Value = "Turno:"
                    hoja.Cells("B3").Value = LBLTURNO.Text
                    hoja.Cells("C3").Value = consql.consql.strEscalar(STRSQL)
                    hoja.Cells("E3").Value = LBLFECHA.Text
                    hoja.Cells("A2:F2").Merge = True
                    hoja.Cells("C3:D3").Merge = True
                    hoja.Cells("E3:F3").Merge = True
                    Dim columnWidth As Decimal = 11.45
                    hoja.Column(1).Width = columnWidth
                    hoja.Column(2).Width = columnWidth
                    hoja.Column(3).Width = columnWidth
                    hoja.Column(4).Width = columnWidth
                    hoja.Column(5).Width = columnWidth
                    hoja.Column(6).Width = columnWidth
                    Dim COLUMNA1 As Decimal = 0
                    Dim COLUMNA2 As Decimal = 0
                    Dim COLUMNA3 As Decimal = 0

                    GRV.BeginSort()
                    Try
                        Dim DataRowCount As Integer = GRV.DataRowCount
                        ' Traverse data rows and change the Price field values.  
                        Dim I As Integer
                        For I = 0 To DataRowCount - 1
                            Dim VALOR As Object = GRV.GetRowCellValue(I, "R. VENTA")
                            Dim numero As Object = GRV.GetRowCellValue(I, "NUMERO")



                            Select Case numero
                                Case "00"
                                    hoja.Cells("A4").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B4").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR

                                Case "01"
                                    hoja.Cells("A5").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B5").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "02"
                                    hoja.Cells("A6").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B6").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "03"
                                    hoja.Cells("A7").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B7").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "04"
                                    hoja.Cells("A8").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B8").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "05"
                                    hoja.Cells("A9").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B9").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "06"
                                    hoja.Cells("A10").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B10").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "07"
                                    hoja.Cells("A11").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B11").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "08"
                                    hoja.Cells("A12").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B12").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "09"
                                    hoja.Cells("A13").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B13").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "10"
                                    hoja.Cells("A14").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B14").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "11"
                                    hoja.Cells("A15").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B15").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "12"
                                    hoja.Cells("A16").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B16").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "13"
                                    hoja.Cells("A17").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B17").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "14"
                                    hoja.Cells("A18").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B18").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "15"
                                    hoja.Cells("A19").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B19").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "16"
                                    hoja.Cells("A20").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B20").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "17"
                                    hoja.Cells("A21").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B21").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "18"
                                    hoja.Cells("A22").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B22").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "19"
                                    hoja.Cells("A23").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B23").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "20"
                                    hoja.Cells("A24").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B24").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "21"
                                    hoja.Cells("A25").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B25").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "22"
                                    hoja.Cells("A26").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B26").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR

                                Case "23"
                                    hoja.Cells("A27").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B27").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "24"
                                    hoja.Cells("A28").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B28").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "25"
                                    hoja.Cells("A29").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B29").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "26"
                                    hoja.Cells("A30").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B30").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "27"
                                    hoja.Cells("A31").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B31").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "28"
                                    hoja.Cells("A32").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B32").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "29"
                                    hoja.Cells("A33").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B33").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "30"
                                    hoja.Cells("A34").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B34").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "31"
                                    hoja.Cells("A35").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B35").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "32"
                                    hoja.Cells("A36").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B36").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "33"
                                    hoja.Cells("A37").Value = Convert.ToInt16(numero)
                                    hoja.Cells("B37").Value = VALOR
                                    COLUMNA1 = COLUMNA1 + VALOR
                                Case "34"
                                    hoja.Cells("C4").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D4").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "35"
                                    hoja.Cells("C5").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D5").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "36"
                                    hoja.Cells("C6").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D6").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "37"
                                    hoja.Cells("C7").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D7").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "38"
                                    hoja.Cells("C8").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D8").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "39"
                                    hoja.Cells("C9").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D9").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "40"
                                    hoja.Cells("C10").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D10").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "41"
                                    hoja.Cells("C11").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D11").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "42"
                                    hoja.Cells("C12").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D12").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "43"
                                    hoja.Cells("C13").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D13").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "44"
                                    hoja.Cells("C14").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D14").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "45"
                                    hoja.Cells("C15").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D15").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "46"
                                    hoja.Cells("C16").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D16").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "47"
                                    hoja.Cells("C17").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D17").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "48"
                                    hoja.Cells("C18").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D18").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "49"
                                    hoja.Cells("C19").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D19").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "50"
                                    hoja.Cells("C20").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D20").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "51"
                                    hoja.Cells("C21").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D21").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "52"
                                    hoja.Cells("C22").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D22").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "53"
                                    hoja.Cells("C23").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D23").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "54"
                                    hoja.Cells("C24").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D24").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "55"
                                    hoja.Cells("C25").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D25").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "56"
                                    hoja.Cells("C26").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D26").Value = VALOR
                                Case "57"
                                    hoja.Cells("C27").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D27").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "58"
                                    hoja.Cells("C28").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D28").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "59"
                                    hoja.Cells("C29").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D29").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "60"
                                    hoja.Cells("C30").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D30").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "61"
                                    hoja.Cells("C31").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D31").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "62"
                                    hoja.Cells("C32").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D32").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "63"
                                    hoja.Cells("C33").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D33").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "64"
                                    hoja.Cells("C34").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D34").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "65"
                                    hoja.Cells("C35").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D35").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "66"
                                    hoja.Cells("C36").Value = Convert.ToInt16(numero)
                                    hoja.Cells("D36").Value = VALOR
                                    COLUMNA2 = COLUMNA2 + VALOR
                                Case "67"
                                    hoja.Cells("E4").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F4").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "68"
                                    hoja.Cells("E5").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F5").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "69"
                                    hoja.Cells("E6").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F6").Value = VALOR
                                Case "70"
                                    hoja.Cells("E7").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F7").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "71"
                                    hoja.Cells("E8").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F8").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "72"
                                    hoja.Cells("E9").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F9").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "73"
                                    hoja.Cells("E10").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F10").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "74"
                                    hoja.Cells("E11").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F11").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "75"
                                    hoja.Cells("E12").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F12").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "76"
                                    hoja.Cells("E13").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F13").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "77"
                                    hoja.Cells("E14").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F14").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "78"
                                    hoja.Cells("E15").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F15").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "79"
                                    hoja.Cells("E16").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F16").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "80"
                                    hoja.Cells("E17").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F17").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "81"
                                    hoja.Cells("E18").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F18").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "82"
                                    hoja.Cells("E19").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F19").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "83"
                                    hoja.Cells("E20").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F20").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "84"
                                    hoja.Cells("E21").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F21").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "85"
                                    hoja.Cells("E22").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F22").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "86"
                                    hoja.Cells("E23").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F23").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "87"
                                    hoja.Cells("E24").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F24").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "88"
                                    hoja.Cells("E25").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F25").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "89"
                                    hoja.Cells("E26").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F26").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "90"
                                    hoja.Cells("E27").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F27").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "91"
                                    hoja.Cells("E28").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F28").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "92"
                                    hoja.Cells("E29").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F29").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "93"
                                    hoja.Cells("E30").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F30").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "94"
                                    hoja.Cells("E31").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F31").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "95"
                                    hoja.Cells("E32").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F32").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "96"
                                    hoja.Cells("E33").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F33").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "97"
                                    hoja.Cells("E34").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F34").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "98"
                                    hoja.Cells("E35").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F35").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR
                                Case "99"
                                    hoja.Cells("E36").Value = Convert.ToInt16(numero)
                                    hoja.Cells("F36").Value = VALOR
                                    COLUMNA3 = COLUMNA3 + VALOR

                            End Select


                        Next
                    Finally
                        GRV.EndSort()
                    End Try


                    'STRSQL = String.Format("SELECT SUM(MR.VENTA_GLOBAL) FROM MC_RECORTE AS mr WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1}AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3} AND mr.NUMERO BETWEEN'00' AND '33'", IDRECORTE, idlista, idmasterticket, idusuairo)

                    'hoja.Cells("B38").Value = consql.consql.numEscalar(STRSQL)
                    'STRSQL = String.Format("SELECT SUM(MR.VENTA_GLOBAL) FROM MC_RECORTE AS mr WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1}AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3} AND mr.NUMERO BETWEEN'34' AND '66'", IDRECORTE, idlista, idmasterticket, idusuairo)

                    'hoja.Cells("D38").Value = consql.consql.numEscalar(STRSQL)
                    'STRSQL = String.Format("SELECT SUM(MR.VENTA_GLOBAL) FROM MC_RECORTE AS mr WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1}AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3} AND mr.NUMERO BETWEEN'67' AND '99'", IDRECORTE, idlista, idmasterticket, idusuairo)

                    'hoja.Cells("F38").Value = consql.consql.numEscalar(STRSQL)
                    'STRSQL = String.Format("SELECT SUM(MR.VENTA_GLOBAL) FROM MC_RECORTE AS mr WHERE mr.ID_MASTER_RECORTE = {0} AND mr.ID_MASTER_LISTA = {1}AND mr.ID_MASTER = {2} AND mr.ID_USUARIO = {3}", IDRECORTE, idlista, idmasterticket, idusuairo)

                    hoja.Cells("B38").Value = COLUMNA1
                    hoja.Cells("D38").Value = COLUMNA2
                    hoja.Cells("F38").Value = COLUMNA3
                    hoja.Cells("A39").Value = COLUMNA1 + COLUMNA2 + COLUMNA3

                    hoja.Cells("A39").Style.Font.Size = 16
                    hoja.Cells("B4:B38").Style.Font.Size = 14
                    hoja.Cells("D4:D38").Style.Font.Size = 14
                    hoja.Cells("F4:F38").Style.Font.Size = 14
                    hoja.Cells("A39:F39").Merge = True
                    hoja.Cells("A39:F39").Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center

                    hoja.Protection.IsProtected = False
                    hoja.Protection.AllowSelectLockedCells = False
                    excelpag.Save()

                    OkMsg("SE HA EXPORTADO EL DOCUMENTO CORRECTAMENTE")
                    'Dim myFile As New System.IO.FileInfo(frm.FileName)
                    'Dim strF As String = myFile.FullName.Substring(myFile.DirectoryName.Length + 1)
                    'strF = Strings.Left(strF, Strings.InStr(strF, ".xls") - 1)
                    'Dim opts As New DevExpress.XtraPrinting.XlsxExportOptions With {.SheetName = strF}
                    '_dg.ExportToXlsx(frm.FileName, opts)
                    'Msg(String.Format("'{0}'", frm.FileName), "Se ha exportado la consulta al archivo:")


                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTTICKET_EditValueChanged(sender As Object, e As EventArgs) Handles TXTTICKET.EditValueChanged

    End Sub

    Private Sub TXTTICKET_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTTICKET.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    If Char.IsDigit(TXTTICKET.Text) Then

                        If TXTTICKET.Text > 0 Then
                            Me.idticket = TXTTICKET.Text
                            Me.TXTRECORTE.Text = 0
                            Codigo_activo2()
                            actualizar_recorte()
                            cargar_grd_recorte()
                            CALCULAR_GRUPOS()




                        Else
                            ErrorMsg("FAVOR REVISAR NUM MAYOR A 0 ")
                        End If

                    Else
                        ErrorMsg("FAVOR REVISAR QUE EL CAMPO DE TICKET SEAN NUMEROS")
                    End If


            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNIMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTNIMPRIMIR.Click
        Try

            Dim STRSQL As String

            STRSQL = String.Format("EXEC inicializar_MC_RECORTE_TMP_TMP @IDTICKET={0},@IDRECORTE={1},@IDUSUARIO={2},@SESION='{3}',@HDWN={4}", idticket, IDRECORTE, idusuairo, SinComillas(sesion), Me.Handle.ToInt32)
            consql.consql.Ejecutar(STRSQL)

            STRSQL = String.Format("DELETE FROM RECORTE_TMP WHERE idticket ={0} AND idusuario = {1} AND idrecorte = {2}", idticket, idusuairo, IDRECORTE)
            consql.consql.Ejecutar(STRSQL)
            For i As Integer = 0 To GRV.DataRowCount - 1
                If GRV.GetRowCellValue(i, "R. VENTA") > 0.00 Then
                    Dim NUMERO As String = GRV.GetRowCellValue(i, "NUMERO")
                    Dim VALOR As Decimal = GRV.GetRowCellValue(i, "R. VENTA")
                    STRSQL = String.Format("EXEC RECORTE_TMP_GUARDAR @IDTICKET={0} ,@IDRECORTE={1},@IDUSUARIO={2},@NUMERO='{3}',@VALOR={4},@SESION='{5}',@HDWN={6}", idticket, IDRECORTE, idusuairo, NUMERO, VALOR, SinComillas(sesion), Me.Handle.ToInt32)
                    consql.consql.Ejecutar(STRSQL)
                End If
            Next
            STRSQL = String.Format("EXEC LLENAR_MC_RECORTE_TMP @IDTICKET={0},@IDRECORTE={1},@IDUSUARIO={2},@SESION='{3}',@HDWN={4}", idticket, IDRECORTE, idusuairo, SinComillas(sesion), Me.Handle.ToInt32)
            consql.consql.Ejecutar(STRSQL)

            Dim FRM As FRM_IMPRIMIR_LISTA = New FRM_IMPRIMIR_LISTA With {.IDRECORTE = IDRECORTE, .IDTICKET = idticket, .HDWN = Me.Handle.ToInt32}
            FRM.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub


    'Private Sub GRV_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GRV.CustomUnboundColumnData
    '    Try
    '        Dim index As Int16 = e.ListSourceRowIndex
    '        Dim Utilidad As Integer = Convert.ToInt32(GRV.GetListSourceRowCellValue(index, "Utilidad"))

    '        If e.Column.FieldName <> "TOTAL" Then
    '            Return
    '        End If
    '        If e.IsGetData Then
    '            e.Value = Convert.ToInt32(Me.TXTG312.Text) - Utilidad
    '        End If

    '    Catch ex As Exception
    '        ErrorMsg(ex.Message)
    '    End Try
    'End Sub
End Class