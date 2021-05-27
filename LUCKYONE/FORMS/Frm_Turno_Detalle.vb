Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class Frm_Turno_Detalle

    Dim OBJCLIENTE As Cls_Cliente = New Cls_Cliente
    Dim IDTICKET_ACTIVO As Int16
    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txtClienteNom.EditValueChanged

    End Sub
    Private Sub recuperar_venta()
        Try
            Dim strsql As String = String.Format("exec recuperar_venta @idventa = {0},@idticket = {1},@idusuairo = {2}", Me.IDVENTA.Text, Me.IDTICKET.Text, idusuairo)

            CargarDXGrid(strsql, grd1)
            HacerEditableDXGrid(grv1, False)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub agregar_detalle()
        Try


            If Me.TXTNUM.Text.Trim.Length = 0 Then
                ErrorMsg("NUMERO NO PUEDE ESTAR VACÍO")
                Beep()
                Me.TXTNUM.Focus()
                Exit Sub
            End If
            If TXTNUM.Text.Trim.Length > 2 Then

                ErrorMsg("NUMERO DE DIGITOS MAYOR A 2")
                Beep()
                Me.TXTNUM.Focus()
                Exit Sub
            End If
            If TXTNUM.Text.Trim.Length < 2 Then

                ErrorMsg("NUMERO DE DIGITOS DEBE SER  2")
                Beep()
                Me.TXTNUM.Focus()
                Exit Sub
            End If
            If Me.TXTCANTIDAD.Value = 0 Then
                ErrorMsg("Cantidad no debe ser 0")
                Beep()
                TXTCANTIDAD.Focus()

                Exit Sub
            End If
            If Me.IDTICKET.Text <> IDTICKET_ACTIVO Then
                ErrorMsg("TICKET SELECCIONADO NO ES EL TICKET ACTIVO")
                Beep()
                Exit Sub
            End If
            If Me.IDVENTA.Text > 0 Then
                ErrorMsg("No se puede Modificar una Venta ya Realizada")
                Beep()
                Exit Sub
            End If
            Dim strsql As String = String.Format("EXEC TMP_TICKET_DETALLE_GUARDAR @SESION = '{0}',	@HNDW = {1},	@ID_TICKET = {2},	@NUMERO = '{3}',	@VALOR = {4},	@IDUSUARIO = {5},	@ITEM = {6}", SinComillas(sesion), Me.Handle.ToInt32, IDTICKET.Text, SinComillas(Me.TXTNUM.Text), TXTCANTIDAD.Value, idusuairo, txtitem.Text)

            consql.consql.Ejecutar(strsql)
            Me.TXTNUM.Text = ""
            Me.TXTCANTIDAD.Value = 0
            Me.txtitem.Text = 0
            Me.TXTNUM.Focus()
            cargar_grd_tmp()

            strsql = String.Format("SELECT SUM (ttd.VALOR)  FROM TMP_TICKET_DETALLE AS ttd WHERE ttd.SESION='{0}' AND ttd.HNDW={1} AND ttd.ID_TICKET={2} AND ttd.ID_USUAIRO={3} ", SinComillas(sesion), Me.Handle.ToInt32, Me.IDTICKET.Text, idusuairo)
            Me.txtventa.Value = consql.consql.numEscalar(strsql)
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BTNACEPTAR.Click
        Try
            agregar_detalle()
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Public Sub Codigo_activo()
        Try
            Dim strsql As String = String.Format("SELECT t.ID_TICKET FROM TICKET AS t WHERE t.ID_USUARIO = {0} AND t.ACTIVO = 1", idusuairo)
            Me.IDTICKET.Text = consql.consql.numEscalar(strsql)
            IDTICKET_ACTIVO = consql.consql.numEscalar(strsql)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub cargar_grd_tmp()
        Try
            '"67B9EA52-8EE8-45C0-9D8B-B53E9184853A"
            Dim strsql As String = String.Format("EXEC CARGAR_GRV_TMP	@ID_USUARIO = {0},	@IDTICKET = {1},	@SESIÓN = '{2}',	@HDWD ={3}", idusuairo, Me.IDTICKET.Text, SinComillas(sesion), Me.Handle.ToInt32)
            CargarDXGrid(strsql, grd1)
            HacerEditableDXGrid(grv1, False)
            grv1.Columns("VALOR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grv1.Columns("VALOR").DisplayFormat.FormatString = "N2"

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub


    Private Sub cargar_totales_superiores()
        Try
            Dim STRSQL As String = String.Format("EXEC total_superior1 @idticket = {0},	@idusuario = {1}", Me.IDTICKET.Text, idusuairo)
            Me.TXTSUM1.Text = consql.consql.numEscalar(STRSQL)
            STRSQL = String.Format("EXEC total_superior2 @idticket = {0},	@idusuario = {1}", Me.IDTICKET.Text, idusuairo)
            Me.TXTSUM2.Text = consql.consql.numEscalar(STRSQL)
            STRSQL = String.Format("EXEC total_superior3 @idticket = {0},	@idusuario = {1}", Me.IDTICKET.Text, idusuairo)
            Me.TXTSUM3.Text = consql.consql.numEscalar(STRSQL)

            Me.txtsumtotal.Value = Convert.ToDecimal(TXTSUM1.Text) + Convert.ToDecimal(TXTSUM2.Text) + Convert.ToDecimal(TXTSUM3.Text)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub CONVERTIR015()
        Try

            ' Obtain the Price column.  
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GRV.Columns.ColumnByFieldName("VALOR1")
            If Col Is Nothing Then Exit Sub
            GRV.BeginSort()
            Try
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
                ' Obtain the number of data rows.  
                Dim DataRowCount As Integer = GRV.DataRowCount
                ' Traverse data rows and change the Price field values.  
                Dim I As Integer
                For I = 0 To DataRowCount - 1
                    Dim VALOR1 As Object = GRV.GetRowCellValue(I, "VALOR1")
                    Dim VALOR2 As Object = GRV.GetRowCellValue(I, "VALOR2")
                    Dim VALOR3 As Object = GRV.GetRowCellValue(I, "VALOR3")
                    Dim VALOR4 As Object = GRV.GetRowCellValue(I, "VALOR4")
                    Dim VALOR5 As Object = GRV.GetRowCellValue(I, "VALOR5")
                    GRV.SetRowCellValue(I, "VALOR1", Convert.ToDouble(VALOR1) * 15 / 1000)
                    GRV.SetRowCellValue(I, "VALOR2", Convert.ToDouble(VALOR2) * 15 / 1000)
                    GRV.SetRowCellValue(I, "VALOR3", Convert.ToDouble(VALOR3) * 15 / 1000)
                    GRV.SetRowCellValue(I, "VALOR4", Convert.ToDouble(VALOR4) * 15 / 1000)
                    GRV.SetRowCellValue(I, "VALOR5", Convert.ToDouble(VALOR5) * 15 / 1000)
                Next
            Finally
                GRV.EndSort()
            End Try


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Public Sub CARGAR_GRD_ULTIMAS_VENTAS()
        Try
            Dim strsql As String = String.Format("SELECT th.ID_TICKET Turno, th.ID_TICKET_HEADER Venta,th.FECHA Fecha,th.ID_CLIENTE Id_Cliente, (c.NOMBRES + ' ' +c.APELLIDOS)Cliente, th.VENTA Total FROM TICKET_HEADER AS th INNER JOIN CLIENTE AS c ON c.ID_CLIENTE = th.ID_CLIENTE WHERE th.ID_TICKET = {0} AND th.ID_USUARIO = {1}", Me.IDTICKET.Text, idusuairo)
            CargarDXGrid(strsql, Grid)
            HacerEditableDXGrid(Gridv, False)



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub cargar_grd_master()
        Try
            Dim strsql As String = String.Format("EXEC CARGAR_GRV_MASTER	@ID_USUARIO = {0},	@IDTICKET = {1}", idusuairo, Me.IDTICKET.Text)
            CargarDXGrid(strsql, GRD)
            HacerEditableDXGrid(GRV, False)


            GRV.Columns("VALOR1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR1").DisplayFormat.FormatString = "N0"

            GRV.Columns("VALOR2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR2").DisplayFormat.FormatString = "N0"

            GRV.Columns("VALOR3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR3").DisplayFormat.FormatString = "N0"

            GRV.Columns("VALOR4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR4").DisplayFormat.FormatString = "N0"

            GRV.Columns("VALOR5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GRV.Columns("VALOR5").DisplayFormat.FormatString = "N0"
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



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub BORRAR_TMP()
        Try
            Dim strsql As String = String.Format("EXEC BORRAR_TMP	@ID_USUARIO = {0},	@IDTICKET = {1},	@SESIÓN = '{2}',	@HDWD ={3}", idusuairo, Me.IDTICKET.Text, SinComillas(sesion), Me.Handle.ToInt32)
            consql.consql.Ejecutar(strsql)
            Me.txtventa.Text = "0"

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub NUEVO()
        Try
            Codigo_activo()
            BORRAR_TMP()
            cargar_grd_tmp()
            cargar_grd_master()
            CARGAR_GRD_ULTIMAS_VENTAS()
            cargar_totales_superiores()
            txtitem.Text = "0"
            Me.IDCLIENTE.Enabled = True
            Me.txtClienteNom.Enabled = True
            Me.txtClienteNom.Text = ""
            Me.TXTNUM.Text = ""
            Me.TXTCANTIDAD.Value = 0
            Me.txtitem.Text = 0
            Me.txtventa.Text = "0"
            Me.IDVENTA.Text = "0"
            Me.IDCLIENTE.Text = ""

            Me.TXTNUM.Enabled = True
            Me.TXTCANTIDAD.Enabled = True
            Me.BTNACEPTAR.Enabled = True
            Me.BTNANULAR.Enabled = True
            Me.precio_cliente.Text = 0
            IDCLIENTE.Focus()



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try

    End Sub
    Private Sub guardar()
        Try
            If Me.IDCLIENTE.Text = "" Then
                ErrorMsg("Aun no ha Seleccionado un cliente")
                Exit Sub
            End If
            If Me.IDVENTA.Text >0 Then
                ErrorMsg("No se puede Modificar una venta realizada")
                Exit Sub
            End If

            Dim STRSQL As String = String.Format("EXEC TICKET_DETALLE_GUARDAR @IDTICKET = {0},	@IDUSUARIO = {1},	@FECHA ='{2}',	@IDCLIENTE = {3},	@SESION = '{4}',	@HDWN = {5}", IDTICKET.Text, idusuairo, SinComillas(Date.Now), Me.IDCLIENTE.Text, SinComillas(sesion), Me.Handle.ToInt32)

            If consql.consql.numEscalar(STRSQL) = 0 Then

                ErrorMsg("ERROR AL GUARDAR EL TICKETE")
                Exit Sub
            Else
                BORRAR_TMP()
                cargar_grd_master()
                CARGAR_GRD_ULTIMAS_VENTAS()
                cargar_grd_tmp()
                cargar_totales_superiores()
                OkMsg("TICKETE GUARDADO CON EXITO")

            End If


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub Frm_Turno_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            NUEVO()
            Me.KeyPreview = True




        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDVENTA_EditValueChanged(sender As Object, e As EventArgs) Handles IDVENTA.EditValueChanged

    End Sub

    Private Sub PanelControl4_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl4.Paint

    End Sub

    Private Sub IDM_GUARDAR_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_GUARDAR.ItemClick
        Try
            If Me.IDCLIENTE.Enabled = True Then
                ErrorMsg("NO HA SELECCIONADO CLIENTE AUN")
                Exit Sub
            End If
            If Me.grv1.RowCount = 0 Then

                ErrorMsg("NO HAY REGISTRO DE NUMEROS EN EL TICKETE")
                Exit Sub
            End If


            guardar()

        Catch ex As Exception
            ErrorMsg(ex.Message)

        End Try
    End Sub


    Private Sub IDCLIENTE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IDCLIENTE.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else e.Handled = True
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub TXTNUM_EditValueChanged(sender As Object, e As EventArgs) Handles TXTNUM.EditValueChanged

    End Sub

    Private Sub TXTNUM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNUM.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else e.Handled = True
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles IDCLIENTE.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Enter
                    If OBJCLIENTE.UBICAR(Me.IDCLIENTE.Text) = True Then

                        Me.IDCLIENTE.Enabled = False
                        Me.txtClienteNom.Enabled = False
                        Me.txtClienteNom.Text = OBJCLIENTE.NOMBRES
                        Me.precio_cliente.Text = OBJCLIENTE.PRECIO_BASE
                        Me.TXTNUM.Focus()

                    Else

                        ErrorMsg("ERROR AL CARGAR CLIENTE/CLIENTE NO ENCONTRADO")
                    End If

            End Select
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub TXTNUM_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles TXTNUM.EditValueChanging
        Try
            If Me.TXTNUM.Text.Trim.Length > 2 Then
                ErrorMsg("Cantidad de Digitos mayor a 2")
                Beep()
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try

    End Sub

    Private Sub TXTNUM_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNUM.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    Me.TXTNUM.EnterMoveNextControl = True

            End Select


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub TXTCANTIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCANTIDAD.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    agregar_detalle()
                    Me.TXTNUM.Focus()

            End Select

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub Frm_Turno_Detalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            BORRAR_TMP()

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDM_NEW_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_NEW.ItemClick
        Try
            NUEVO()

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub Frm_Turno_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.F4
                    Me.PictureEdit1.Visible = True
                Case Keys.F1
                    Me.NUEVO()
                Case Keys.F2
                    Me.guardar()
                Case Keys.F3
                    ''ENFOCA EL NO DE VENTA PARA RECUPERARLA

            End Select

            Select Case e.KeyData
                Case (Keys.Shift + Keys.F4)
                    Me.PictureEdit1.Visible = False
            End Select


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub txtventa_EditValueChanged(sender As Object, e As EventArgs) Handles txtventa.EditValueChanged
        Try

            Me.VentaX12.Text = (Me.txtventa.Value * Convert.ToInt16(precio_cliente.Text)) / 1000
            Me.VentaX15.Text = (Me.txtventa.Value * 15) / 1000


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub Chkconvertir_CheckedChanged(sender As Object, e As EventArgs) Handles Chkconvertir.CheckedChanged
        Try
            If Me.Chkconvertir.Checked Then

                Me.CONVERTIR015()

            Else
                Me.cargar_grd_master()

            End If

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub TXTCANTIDAD_Validating(sender As Object, e As CancelEventArgs) Handles TXTCANTIDAD.Validating
        Try

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub Gridv_DoubleClick(sender As Object, e As EventArgs) Handles Gridv.DoubleClick
        Try
            Dim fila As DataRow = Me.Gridv.GetDataRow(Me.Gridv.FocusedRowHandle())

            Me.IDVENTA.Text = fila("Venta")
            Me.IDCLIENTE.Text = fila("Id_Cliente")
            Me.txtClienteNom.Text = fila("Cliente")
            Me.txtventa.Value = fila("Total")
            recuperar_venta()




        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub BTNANULAR_Click(sender As Object, e As EventArgs) Handles BTNANULAR.Click
        Try
            If IDVENTA.Text = 0 And txtitem.Text > 0 Then
                Dim strsql As String = String.Format("DELETE FROM TMP_TICKET_DETALLE WHERE SESION = '{0}' AND HNDW = {1} AND ID_TICKET = {2} AND ID_USUAIRO = {3} AND ITEM = {4}", SinComillas(sesion), Me.Handle.ToInt32, IDTICKET.Text, idusuairo, Me.txtitem.Text)

                If consql.consql.Ejecutar(strsql) = True Then

                    cargar_grd_master()
                    CARGAR_GRD_ULTIMAS_VENTAS()
                    cargar_grd_tmp()
                    cargar_totales_superiores()

                    Me.TXTNUM.Text = ""
                    Me.TXTCANTIDAD.Value = 0
                    Me.txtitem.Text = 0

                    strsql = String.Format("SELECT SUM (ttd.VALOR)  FROM TMP_TICKET_DETALLE AS ttd WHERE ttd.SESION='{0}' AND ttd.HNDW={1} AND ttd.ID_TICKET={2} AND ttd.ID_USUAIRO={3} ", SinComillas(sesion), Me.Handle.ToInt32, Me.IDTICKET.Text, idusuairo)
                    Me.txtventa.Value = consql.consql.numEscalar(strsql)
                Else
                    ErrorMsg("Error al eliminar Número")

                End If
            Else
                ErrorMsg("Venta ya registrada o numero no recuperado")
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub grv1_DoubleClick(sender As Object, e As EventArgs) Handles grv1.DoubleClick
        Try
            Dim fila As DataRow = Me.grv1.GetDataRow(Me.grv1.FocusedRowHandle())

            Me.txtitem.Text = fila("ITEM")
            Me.TXTNUM.Text = fila("NUMERO")
            Me.TXTCANTIDAD.Value = fila("VALOR")

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDM_ANULAR_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_ANULAR.ItemClick
        Try
            If Me.IDVENTA.Text = 0 Then

                ErrorMsg("Favor recuperar Venta que desea anular")

                Exit Sub
            End If

            If MsgBox("¿Realmente desea Anular la Venta?", MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
                Dim strsql As String = String.Format("exec eliminar_venta_ticket @idticke_header = {0},@idticket = {1},@idusuario={2}", IDVENTA.Text, IDTICKET.Text, idusuairo)

                If consql.consql.Ejecutar(strsql) = True Then
                    OkMsg("Venta Anulada Correctamente")
                    NUEVO()
                Else
                    ErrorMsg("Error al momento de anular el documento")
                End If

            End If

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDTICKET_EditValueChanged(sender As Object, e As EventArgs) Handles IDTICKET.EditValueChanged

    End Sub

    Private Sub IDTICKET_KeyDown(sender As Object, e As KeyEventArgs) Handles IDTICKET.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    If Char.IsDigit(IDTICKET.Text) Then

                        If IDTICKET.Text > 0 Then
                            If IDTICKET.Text <> IDTICKET_ACTIVO Then

                                cargar_grd_master()
                                CARGAR_GRD_ULTIMAS_VENTAS()
                                cargar_totales_superiores()

                                OkMsg("TICKETE CARGADO CON EXITO")

                                Me.TXTNUM.Enabled = False
                                Me.TXTCANTIDAD.Enabled = False
                                Me.BTNACEPTAR.Enabled = False
                                Me.BTNANULAR.Enabled = False


                            Else
                                NUEVO()

                            End If

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

    Private Sub txtClienteNom_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClienteNom.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    txtClienteNom.EnterMoveNextControl = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTNUM_Validating(sender As Object, e As CancelEventArgs) Handles TXTNUM.Validating
        'Try
        '    If Me.TXTNUM.Text.Trim.Length < 2 Then
        '        ErrorMsg("Debe Escribir 2 Digitos")
        '        Beep()
        '        e.Cancel = True
        '    End If
        'Catch ex As Exception
        '    ErrorMsg(ex.Message)
        'End Try
    End Sub
End Class