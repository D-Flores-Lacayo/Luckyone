Public Class Frm_Cliente
    Dim OBJCLIENTE As Cls_Cliente = New Cls_Cliente

    Private Sub NUEVO()
        Try
            Me.IDCLIENTE.Text = 0
            Me.NOMBRES.Text = ""
            Me.APELLIDOS.Text = ""
            Me.PRECIO_BASE.EditValue = 0


            CARGAR_GRID()


        Catch ex As Exception

        End Try


    End Sub
    Private Sub IR_GUARDAR()

        Try
            OBJCLIENTE.ID_CLIENTE = IDCLIENTE.Text
            OBJCLIENTE.NOMBRES = NOMBRES.Text
            OBJCLIENTE.APELLIDOS = APELLIDOS.Text
            OBJCLIENTE.PRECIO_BASE = Me.PRECIO_BASE.EditValue
            If OBJCLIENTE.GUARDAR > 0 Then
                OkMsg("CLIENTE GUARDADO CORRECTAMENTE")
                CARGAR_GRID()
            End If

        Catch ex As Exception
            ErrorMsg("ERROR AL GUARDAR CLIENTE")
        End Try

    End Sub
    Private Sub CARGAR_GRID()
        Try
            Dim STRSQL As String = String.Format("SELECT c.ID_CLIENTE, c.NOMBRES, c.APELLIDOS, c.PRECIO_BASE FROM CLIENTE AS c")
            CargarDXGrid(STRSQL, GRD)
            HacerEditableDXGrid(GRV, False)
            Me.GRV.BestFitColumns()

        Catch ex As Exception

        End Try



    End Sub





    Private Sub Frm_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            NUEVO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_NEW_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_NEW.ItemClick
        Try
            NUEVO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_GUARDAR_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_GUARDAR.ItemClick
        Try
            IR_GUARDAR()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GRV_DoubleClick(sender As Object, e As EventArgs) Handles GRV.DoubleClick
        Try

            Dim ROW As DataRow = Me.GRV.GetDataRow(Me.GRV.FocusedRowHandle)
            If Not IsNothing(ROW) Then
                If OBJCLIENTE.UBICAR(ROW("ID_CLIENTE")) = True Then

                    Me.IDCLIENTE.Text = OBJCLIENTE.ID_CLIENTE
                    Me.NOMBRES.Text = OBJCLIENTE.NOMBRES
                    Me.APELLIDOS.Text = OBJCLIENTE.APELLIDOS
                    Me.PRECIO_BASE.Value = OBJCLIENTE.PRECIO_BASE
                Else
                    ErrorMsg("CLIENTE NO ENCONTRADO/CLIENTE NO EXISTE")

                End If


            End If

        Catch ex As Exception

        End Try
    End Sub
End Class