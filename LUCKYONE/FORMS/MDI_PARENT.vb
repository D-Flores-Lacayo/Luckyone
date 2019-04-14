Public Class MDI_PARENT
    Private Sub IDM_USUARIO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_USUARIO.ItemClick
        Try

            Dim frm As FRM_USUARIOS = New FRM_USUARIOS With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_CLIENTES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_CLIENTES.ItemClick
        Try

            Dim frm As Frm_Cliente = New Frm_Cliente With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_TURNOS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_TURNOS.ItemClick
        Try

            Dim frm As Frm_Turnos = New Frm_Turnos With {.MdiParent = Me}

            frm.Show()



        Catch ex As Exception

        End Try
    End Sub
End Class