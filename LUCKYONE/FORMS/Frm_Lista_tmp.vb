Public Class Frm_Lista_tmp

    Public Property lista As Int16
    Public Property ticket As Int16
    Public Property client As Int16
    Public Property SUM1 As Decimal
    Public Property SUM2 As Decimal
    Public Property SUM3 As Decimal

    Private Sub nuevo()
        Try
            IR_CARGAR_GRD()
            Me.TXTSUM1.Text = SUM1
            Me.TXTSUM2.Text = SUM2
            Me.TXTSUM3.Text = SUM3
            Me.txtsumtotal.Text = Convert.ToDecimal(Me.TXTSUM1.Text) + Convert.ToDecimal(Me.TXTSUM2.Text) + Convert.ToDecimal(Me.TXTSUM3.Text)


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IR_CARGAR_GRD()
        Try
            Dim strsql As String = String.Format("EXEC CARGAR_GRV_LISTA_tmp	@ID_USUARIO = {0},	@IDTICKET = {1},@sesion='{2}'", idusuairo, Me.ticket, SinComillas(sesion))
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




        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try

    End Sub
    Private Sub Frm_Lista_tmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            nuevo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTNEXCEL_Click(sender As Object, e As EventArgs) Handles BTNEXCEL.Click
        Try
            Dim strsql As String = String.Format("EXEC importar_datos	@idticket = {0},	@idlista = {1},	@idusuario = {2},	@Idcliente = {3},	@sesion = '{4}'", ticket, lista, idusuairo, client, SinComillas(sesion))
            If consql.consql.Ejecutar(strsql) Then
                OkMsg("DATOS IMPORTADOS CORRECTAMENTE")
                Me.Close()
            Else
                ErrorMsg("ERROR AL IMPORTAR DATOS")
            End If
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub ver015()
        Try
            Dim strsql As String = String.Format("exec ver015 @sesion = '{0}', @idticket = {1},@idlista = {2},@idusuario = {3}", SinComillas(sesion), Me.ticket, lista, idusuairo)
            consql.consql.Ejecutar(strsql)
            IR_CARGAR_GRD()


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ver_premio()
        Try
            Dim strsql As String = String.Format("exec ver_premio @sesion = '{0}', @idticket = {1},@idlista = {2},@idusuario = {3}", SinComillas(sesion), Me.ticket, lista, idusuairo)
            consql.consql.Ejecutar(strsql)
            IR_CARGAR_GRD()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkconvertir_CheckedChanged(sender As Object, e As EventArgs) Handles Chkconvertir.CheckedChanged
        Try
            If Me.Chkconvertir.Checked = False Then
                ver015()
                Me.TXTSUM1.Text = SUM1
                Me.TXTSUM2.Text = SUM2
                Me.TXTSUM3.Text = SUM3
                Me.txtsumtotal.Text = Convert.ToDecimal(Me.TXTSUM1.Text) + Convert.ToDecimal(Me.TXTSUM2.Text) + Convert.ToDecimal(Me.TXTSUM3.Text)

            Else
                ver_premio()
                Me.TXTSUM1.Text = TXTSUM1.Text * 1000 / 15

                Me.TXTSUM2.Text = TXTSUM2.Text * 1000 / 15
                Me.TXTSUM3.Text = TXTSUM3.Text * 1000 / 15
                Me.txtsumtotal.Text = Convert.ToDecimal(Me.TXTSUM1.Text) + Convert.ToDecimal(Me.TXTSUM2.Text) + Convert.ToDecimal(Me.TXTSUM3.Text)

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class