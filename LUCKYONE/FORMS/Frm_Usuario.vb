Imports DevExpress.XtraEditors.Controls

Public Class FRM_USUARIOS
    Dim OBJUSUARIO As Cls_usuarios = New Cls_usuarios
    Private Sub NUEVO()
        Try
            Me.IDUSUARIO.Text = 0
            Me.USUARIO.Text = ""
            Me.CONTRASEÑA.Text = ""
            Me.NOMBRES.Text = ""
            Me.APELLIDOS.Text = ""
            Me.ChkActivo.Checked = True

            CARGAR_GRID()


        Catch ex As Exception

        End Try


    End Sub
    Private Sub IR_GUARDAR()

        Try
            OBJUSUARIO.ID_USUARIO = IDUSUARIO.Text
            OBJUSUARIO.NOMBRES = NOMBRES.Text
            OBJUSUARIO.UNIDAD = 1
            OBJUSUARIO.USUARIO = USUARIO.Text
            OBJUSUARIO.CONTRASEÑA = CONTRASEÑA.Text
            OBJUSUARIO.APELLIDOS = APELLIDOS.Text
            OBJUSUARIO.ACTIVO = ChkActivo.Checked
            If OBJUSUARIO.GUARDAR > 0 Then
                OkMsg("USUARIO GUARDADO CORRECTAMENTE")
                CARGAR_GRID()
            End If

        Catch ex As Exception
            ErrorMsg("ERROR AL GUARDAR USUARIO")
        End Try

    End Sub

    Private Sub CARGAR_GRID()
        Try
            Dim STRSQL As String = String.Format("SELECT u.ID_USUARIO, u.USUARIO, u.NOMBRE, u.APELLIDOS, u.[CONTRASEÑA], u.ACTIVO FROM USUARIO AS u")
            CargarDXGrid(STRSQL, GRD)
            HacerEditableDXGrid(GRV, False)
            Me.GRV.BestFitColumns()

        Catch ex As Exception

        End Try



    End Sub

    Private Sub FRM_USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub IDM_ANULAR_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_ANULAR.ItemClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDM_NEW_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IDM_NEW.ItemClick
        Try
            NUEVO()

        Catch ex As Exception

        End Try
    End Sub
End Class