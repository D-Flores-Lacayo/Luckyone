Public Class MDI_PARENT
    Private Sub IDM_USUARIO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_USUARIO.ItemClick
        Try

            Dim frm As FRM_USUARIOS = New FRM_USUARIOS With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDM_CLIENTES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_CLIENTES.ItemClick
        Try

            Dim frm As Frm_Cliente = New Frm_Cliente With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IDM_TURNOS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_TURNOS.ItemClick
        Try

            Dim frm As Frm_Turnos = New Frm_Turnos With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_TICKETES.ItemClick
        Try

            Dim frm As Frm_Turno_Detalle = New Frm_Turno_Detalle With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)

        End Try
    End Sub

    Private Sub MDI_PARENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RibbonControl.Minimized = True
            Me.KeyPreview = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDI_PARENT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.F1
                    For i As Integer = Me.XtraTabbedMdiManager1.Pages.Count To  0
                        Me.XtraTabbedMdiManager1.Pages(i).MdiChild.Close()
                    Next

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_RECORTE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_RECORTE.ItemClick
        Try

            Dim frm As Frm_Master_Recorte = New Frm_Master_Recorte With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)

        End Try
    End Sub

    Private Sub IDM_LISTAS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_LISTAS.ItemClick
        Try

            Dim frm As Frm_Lista = New Frm_Lista With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception
            ErrorMsg(ex.Message)

        End Try
    End Sub

    Private Sub MDI_PARENT_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_TICKET_GANADORAS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_TICKET_GANADORAS.ItemClick
        Try
            Dim frm As Frm_TICKETS_GANADORAS = New Frm_TICKETS_GANADORAS

            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_LIMPIAR_USUARIO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_LIMPIAR_USUARIO.ItemClick
        Try


            If MsgBox("¿Realmente desea limpiar sorteos?", MsgBoxStyle.Exclamation.YesNo, "Limpiar") = DialogResult.Yes Then

                Dim strsql As String = String.Format("EXEC LIMPIAR_SORTEO @USUARIO = {0}", idusuairo)

                If consql.consql.Ejecutar(strsql) Then
                    OkMsg("Se han Limpiado todos los sorteos")

                    For i As Integer = XtraTabbedMdiManager1.Pages.Count - 1 To 0 Step -1
                        XtraTabbedMdiManager1.Pages(i).MdiChild.Close()

                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_CAMBIAR_USUARIO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_CAMBIAR_USUARIO.ItemClick
        Try
            If XtraTabbedMdiManager1.Pages.Count > 0 Then
                For i As Integer = XtraTabbedMdiManager1.Pages.Count - 1 To 0 Step -1
                    XtraTabbedMdiManager1.Pages(i).MdiChild.Close()

                Next


            End If
            Frm_Login.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_CONFIG_SERVER_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_CONFIG_SERVER.ItemClick
        Try
            Dim frm As form_Sistema_ConSQL = New form_Sistema_ConSQL

            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class