Public Class Frm_Login
    Private Sub cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        Try
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarFormulario()
        Try
            With conSqlite
                .ObtenerDatosSeguridad_Predeterminados()
                If .IniciarAutomaticamente = True Then
                    If .Usuario.Trim.Length > 0 Then
                        If .ServidorSQL.Trim.Length > 0 Then
                            If .BaseDatos.Trim.Length > 0 Then
                                consql.consql.Usuario = .Usuario
                                consql.consql.Contraseña = .Contraseña
                                consql.consql.BaseDatos = .BaseDatos
                                consql.consql.ServidorSQL = .ServidorSQL
                                If consql.consql.IniciarSesionSQL = False Then
                                    Using frm As New form_Sistema_ConSQL()
                                        If frm.ShowDialog = DialogResult.Cancel Then
                                            Me.Close()

                                        End If
                                        LimpiarMemoria()
                                    End Using
                         
                                End If

                            End If
                        End If
                    End If
                Else
                    Using frm As New form_Sistema_ConSQL()
                        If frm.ShowDialog = DialogResult.Cancel Then
                            Me.Close()
                        Else

                        End If
                        LimpiarMemoria()
                    End Using
                End If
            End With
            LimpiarMemoria()
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Try
            Dim strsql As String = String.Format("EXEC VERIFICAR_USUARIO @USUARIO='{0}', @PASS= '{1}'", SinComillas(txtusuario.Text), SinComillas(Me.txtpass.Text))

            Dim USUARIO As Int16 = consql.consql.numGet(strsql)
            If USUARIO > 0 Then

                Me.Hide()
                If idusuairo = 0 Then
                    Dim FRM As MDI_PARENT = New MDI_PARENT
                    FRM.Show()
                End If


                idusuairo = USUARIO
                Dim session As Guid = System.Guid.NewGuid


                sesion = session.ToString

                Me.txtusuario.Text = ""
                Me.txtpass.Text = ""


            Else

                ErrorMsg("USUAIRO/CONTRASEÑA INCORRECTA")
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtusuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusuario.KeyDown
        Try

            Select Case e.KeyValue
                Case Keys.Enter
                    txtusuario.EnterMoveNextControl = True

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpass_EditValueChanged(sender As Object, e As EventArgs) Handles txtpass.EditValueChanged

    End Sub

    Private Sub txtpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpass.KeyDown
        Try

            Select Case e.KeyValue
                Case Keys.Enter
                    txtpass.EnterMoveNextControl = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Frm_Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            conSqlite = New cls_Sistema_ConSQLite
            CargarFormulario()
            Me.txtusuario.Text = ""
            Me.txtpass.Text = ""
            Me.LblInformacion.Text = ProductName & "-" & ProductVersion


        Catch ex As Exception

        End Try
    End Sub
End Class