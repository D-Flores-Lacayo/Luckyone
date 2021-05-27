Public Class form_Sistema_ConSQL

#Region "Atributos"
    Public Property Es_Cerrar_Sistema_al_Salir As Boolean = True
#End Region

#Region "Procedimientos"

    Private Sub Restaurar()
        Try
            'verificaciones

            With consql.consql
                .Usuario = Me.txtUsuario.Text
                .Contraseña = Me.txtContraseña.Text
                .BaseDatos = Me.txtBaseDatos.Text
                .ServidorSQL = Me.txtServidorSQL.Text

                If .IniciarSesionSQL = False Then
                    MsgBox("Imposible Iniciar Sesión", MsgBoxStyle.OkOnly, "Error")
                Else
                    With conSqlite
                        .GuardarDatosSeguridad(Me.txtUsuario.Text, Me.txtContraseña.Text, Me.txtServidorSQL.Text, Me.txtServidorSQL.Text, Me.chkIniciarAutomáticamente.Checked)
                    End With

                    If Me.txtArchivo_BAK.Text.Trim.Length = 0 Then
                        Me.lst.Items.Add("Debe seleccionar archivo de BD-SQL a restaurar", 1)
                        ErrorMsg("Debe seleccionar archivo de BD-SQL a restaurar")
                        Me.txtArchivo_BAK.Focus()
                        Exit Sub
                    End If

                    If Me.txtCarpeta.Text.Trim.Length = 0 Then
                        Me.lst.Items.Add("Debe seleccionar carpeta destino", 1)
                        Me.txtCarpeta.Focus()
                        Exit Sub
                    End If

                    Dim strSQL As String = String.Format("restore database [{0}] ", Me.txtNombreBD.Text)
                    strSQL += String.Format("FROM DISK = '{0}' WITH  ", Me.txtArchivo_BAK.Text)
                    strSQL += String.Format("MOVE 'SIVC4_DATA' TO	'{0}\[{1}].MDF', ", Me.txtCarpeta.Text, Me.txtNombreBD.Text)

                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\ENE.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\FEB.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\MAR.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\ABR.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\MAY.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\JUN.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\JUL.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\AGO.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\SEP.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\OCT.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\NOV.MDF', ", Me.txtCarpeta.Text)
                    strSQL += String.Format("MOVE 'ENE' TO	'{0}\DIC.MDF', ", Me.txtCarpeta.Text)

                    strSQL += String.Format("MOVE 'SIVC4_LOG' TO	'{0}\[{1}].LDF'", Me.txtCarpeta.Text, Me.txtNombreBD.Text)
                    If consql.consql.Ejecutar(strSQL) = False Then
                        ErrorMsg("No fue posible Restaurar la BD-SQL")
                    Else
                        Me.lst.Items.Add(String.Format("Base de Datos [{0}] ha sido restaurada", Me.txtNombreBD.Text), 0)
                        MessageBox.Show(String.Format("Base de Datos [{0}] ha sido restaurada", Me.txtNombreBD.Text), "Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cmdRestaurar.Enabled = False
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
            End With


        Catch ex As Exception
            Me.lst.Items.Add(ex.Message, 1)
        End Try
    End Sub

    Private Sub CargarConfiguraciones(Optional nPerfil As Integer = 0)
        Try
            With conSqlite
                cargar_cmbPerfiles()
                If nPerfil > 0 Then
                    Me.cmbPerfil.EditValue = Long.Parse(nPerfil.ToString)
                End If
                .ObtenerDatosSeguridad(Me.cmbPerfil.EditValue)
                Me.txtUsuario.Text = .Usuario
                Me.txtBaseDatos.Text = .BaseDatos
                Me.txtServidorSQL.Text = .ServidorSQL
                Me.txtContraseña.Text = .Contraseña
                Me.chkIniciarAutomáticamente.Checked = .IniciarAutomaticamente
            End With
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub cargar_cmbPerfiles()
        Try
            Dim strsql As String = "SELECT IDPERFIL AS [#], PERFIL AS [PERFIL] FROM PERFILES_CONSQL ORDER BY ES_PREDETERMINADO DESC, IDPERFIL ASC;"
            conSqlite.FullComboBox(strsql, Me.cmbPerfil, "PERFIL", "#")
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub ir_eliminar_perfil()
        Try
            If Not IsNothing(Me.cmbPerfil.EditValue) Then
                If MessageBox.Show("¿Realmente desea eliminar este perfil de conexión?", "ELIMINAR PERFIL", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim strsql As String = String.Format("DELETE FROM PERFILES_CONSQL WHERE IDPERFIL={0};", Me.cmbPerfil.EditValue)
                    conSqlite.Ejecutar(strsql)
                    cargar_cmbPerfiles()
                End If
            End If

        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub IniciarSesion()
        Try
            With consql.consql
                .Usuario = Me.txtUsuario.Text
                .Contraseña = Me.txtContraseña.Text
                .BaseDatos = Me.txtBaseDatos.Text
                .ServidorSQL = Me.txtServidorSQL.Text

                If .IniciarSesionSQL = False Then
                    MsgBox("Imposible Iniciar Sesión", MsgBoxStyle.OkOnly, "Error")
                Else
                    With conSqlite
                        .GuardarDatosSeguridad(Me.txtUsuario.Text, Me.txtContraseña.Text, Me.txtBaseDatos.Text, Me.txtServidorSQL.Text, Me.chkIniciarAutomáticamente.Checked, Me.cmbPerfil.EditValue)
                    End With

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            End With
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub
#End Region

#Region "Eventos"

    Private Sub cmbPerfil_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmbPerfil.ButtonClick
        Try
            Select Case e.Button.Index
                Case 2 'Agregar un Perfil
                    Dim sPerfil As String = InputBox("Nombre del nuevo PERFIL", "Perfiles de Conexión MS-SQL", String.Empty)
                    If sPerfil.Trim.Length > 0 Then
                        Dim nPerfil As Integer = conSqlite.Guardar_Perfil(0, sPerfil)
                        CargarConfiguraciones(nPerfil)
                    End If
                Case 3 'Cargar el perfil
                    CargarConfiguraciones(Me.cmbPerfil.EditValue)
                Case 4 'eliminar perfil
                    ir_eliminar_perfil()
            End Select
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub txtCarpeta_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCarpeta.ButtonClick
        Try
            Dim dlg As New System.Windows.Forms.FolderBrowserDialog
            dlg.ShowNewFolderButton = True
            If dlg.ShowDialog = DialogResult.OK Then
                Me.txtCarpeta.Text = dlg.SelectedPath
                Me.lst.Items.Add("Carpeta destino seleccionada", 0)
            End If
            dlg = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtArchivo_BAK_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtArchivo_BAK.ButtonClick
        Try
            Dim dlg As New System.Windows.Forms.OpenFileDialog
            dlg.Filter = "Respaldos de BD-SQL|*.bak|Todos los archivos|*.*"
            If dlg.ShowDialog = DialogResult.OK Then
                Me.txtArchivo_BAK.Text = dlg.FileName
                Me.lst.Items.Add("Archivo de BD-SQL seleccionado", 0)
            End If
            dlg = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub formInicioSesionSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.CargarConfiguraciones()
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIniciar.Click
        Try
            Me.IniciarSesion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            If Es_Cerrar_Sistema_al_Salir Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub formInicioSesionSQL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyData
                Case (Keys.Shift + Keys.F9)
                    Me.lblBaseDatos.Visible = True
                    Me.lblServidorSQL.Visible = True
                    Me.txtBaseDatos.Visible = True
                    Me.txtBaseDatos.Enabled = True
                    Me.txtServidorSQL.Visible = True
                    Me.txtServidorSQL.Enabled = True
                    txtUsuario.Visible = True
                    txtContraseña.Visible = True
                    lblUsuario.Visible = True
                    lblContraseña.Visible = True

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestaurar.Click
        Try
            Me.Restaurar()
        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub


#End Region


End Class