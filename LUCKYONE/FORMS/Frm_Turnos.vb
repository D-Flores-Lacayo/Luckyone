Public Class Frm_Turnos
    Dim OBJTURNOS As Cls_Turnos = New Cls_Turnos

    Private Sub CARGAR_TURNOS()
        Try

            Dim STRSQL As String = String.Format("SELECT t.ID_TURNO, t.TURNO FROM TURNOS AS t")
            consql.consql.FullComboBox(STRSQL, LETURNOS, "TURNO", "ID_TURNO")


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try



    End Sub


    Private Sub NUEVO()
        Try
            Me.IDTICKET.Text = 0
            Me.DtFecha.DateTime = Today
            Me.PRECIO_GENERAL.EditValue = 0
            Me.PREMIO_CASA.EditValue = 0
            Me.PREMIO_RECORTE.EditValue = 0
            Me.CARGAR_TURNOS()
            CARGAR_GRID()


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try


    End Sub
    Private Sub IR_GUARDAR()

        Try
            OBJTURNOS.ID_TICKET = IDTICKET.Text
            OBJTURNOS.ID_TURNO = Me.LETURNOS.EditValue

            OBJTURNOS.ID_USUARIO = idusuairo
            OBJTURNOS.PRECIO_GENERAL = Me.PRECIO_GENERAL.EditValue
            OBJTURNOS.PRECIO_CASA = Me.PREMIO_CASA.EditValue
            OBJTURNOS.PRECIO_RECORTE = Me.PREMIO_RECORTE.EditValue
            OBJTURNOS.FECHA = Me.DtFecha.EditValue
            If OBJTURNOS.GUARDAR > 0 Then
                OkMsg("TURNO GUARDADO CORRECTAMENTE")
                CARGAR_GRID()
            End If

        Catch ex As Exception
            ErrorMsg("ERROR AL GUARDAR TURNO")
        End Try

    End Sub
    Private Sub CARGAR_GRID()
        Try
            Dim STRSQL As String = String.Format("SELECT t.ID_TICKET, t.ID_TURNO, t.ID_USUARIO, t.FECHA, t.PREMIO_GENERAL,t.PREMIO_CASA, t.PREMIO_RECORTE, t.ACTIVO FROM TICKET AS t WHERE t.ID_USUARIO = {0}", idusuairo)
            CargarDXGrid(STRSQL, GRD)
            HacerEditableDXGrid(GRV, False)
            Me.GRV.BestFitColumns()

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try



    End Sub


    Private Sub Frm_Turnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            NUEVO()
            KeyPreview = True
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDM_GUARDAR_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_GUARDAR.ItemClick
        Try
            IR_GUARDAR()

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

    Private Sub Frm_Turnos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.F1
                    Me.NUEVO()
                Case Keys.F2
                    Me.IR_GUARDAR()
                Case Keys.F3
                    ''ENFOCA EL NO DE VENTA PARA RECUPERARLA

            End Select




        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
End Class