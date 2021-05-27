Public Class FRM_IMPRIMIR_LISTA
    Public HDWN As Integer
    Public IDTICKET As Integer
    Public IDRECORTE As Integer


    Private Sub nuevo()
        Try
            IR_CARGAR_GRD()
            cargar_totales_superiores()


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub cargar_totales_superiores()
        Try
            Dim STRSQL As String = String.Format("EXEC total_superior1_IMP @idticket = {0},	@idusuario = {1},@IDRECORTE={2},@SESION='{3}',@HDWN={4}", IDTICKET, idusuairo, IDRECORTE, SinComillas(sesion), HDWN)
            Me.TXTSUM1.Text = consql.consql.numEscalar(STRSQL)
            STRSQL = String.Format("EXEC total_superior2_IMP @idticket = {0},	@idusuario = {1},@IDRECORTE={2},@SESION='{3}',@HDWN={4}", IDTICKET, idusuairo, IDRECORTE, SinComillas(sesion), HDWN)
            Me.TXTSUM2.Text = consql.consql.numEscalar(STRSQL)
            STRSQL = String.Format("EXEC total_superior3_IMP @idticket = {0},	@idusuario = {1},@IDRECORTE={2},@SESION='{3}',@HDWN={4}", IDTICKET, idusuairo, IDRECORTE, SinComillas(sesion), HDWN)
            Me.TXTSUM3.Text = consql.consql.numEscalar(STRSQL)

            Me.txtsumtotal.Value = Convert.ToDecimal(TXTSUM1.Text) + Convert.ToDecimal(TXTSUM2.Text) + Convert.ToDecimal(TXTSUM3.Text)

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
    Private Sub IR_CARGAR_GRD()
        Try
            Dim strsql As String = String.Format("SELECT MRT.NUM1, MRT.VALOR1,MRT.NUM2, MRT.VALOR2, MRT.NUM3, MRT.VALOR3, MRT.NUM4, MRT.VALOR4, MRT.NUM5,MRT.VALOR5 FROM MC_RECORTE_TMP AS mrt WHERE mrt.SESION='{0}'AND mrt.HDWN = {1}and mrt.ID_RECORTE ={2} AND mrt.ID_TICKET={3} AND mrt.ID_USUARIO={4}", SinComillas(sesion), HDWN, IDRECORTE, IDTICKET, idusuairo)
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


    Private Sub BTNEXCEL_Click(sender As Object, e As EventArgs) Handles BTNEXCEL.Click
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ver015()
        Try


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ver_premio()
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkconvertir_CheckedChanged(sender As Object, e As EventArgs) Handles Chkconvertir.CheckedChanged
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub FRM_IMPRIMIR_LISTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            nuevo()
        Catch ex As Exception

        End Try
    End Sub
End Class