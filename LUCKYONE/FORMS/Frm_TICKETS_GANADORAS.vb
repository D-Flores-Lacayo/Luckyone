Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Public Class Frm_TICKETS_GANADORAS
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim strsql As String

            If TXTTURNO.Value = 0 Then
                ErrorMsg("TURNO DEBE SER MAYOR QUE 0")
                Exit Sub
            End If

            strsql = String.Format("exec TICKETS_GANADORAS @IDTICKET = {0},@IDUSUARIO={1},@NUMERO1='{2}'", TXTTURNO.Value, idusuairo, SinComillas(TXTNUM.Text))

            Using DDS As New DataSet
                consql.consql.LlenarDataSet2(strsql, DDS)
                If TieneDatos(DDS) Then
                    Using XTRARPT As New Ticket_Ganadora With {.DataSource = DDS.Tables(0), .ShowPrintMarginsWarning = False, .ShowPrintStatusDialog = False}

                        'If CBool(row("Impreso")) Then
                        '    XTRARPT.txtoriginal.Text = "COPIA DE FACTURA"
                        'Else
                        '    XTRARPT.txtoriginal.Text = "*** ORIGINAL ***"
                        'End If
                        'XTRARPT.txtRucCliente.Text = String.Format("  Cédula/RUC: {0}", Me.txtIDENTIFICACION.Text)
                        'XTRARPT.txtnodoc.Text = String.Format("Factura: {1}-{0}", lCeros(row("NoDoc"), 9), row("Serie"))
                        'XTRARPT.PageHeight = 1400 + 100 * DDS.Tables(0).Rows.Count
                        'XTRARPT.CreatePrintingSystem()
                        'XTRARPT.ShowPreviewDialog()

                        XTRARPT.CreatePrintingSystem()
                        XTRARPT.ShowPreviewDialog
                    End Using


                Else
                    ErrorMsg("NO SE ENCONTRARON DATOS EN LA SOLICITUD")


                End If


            End Using


        Catch ex As Exception
            ErrorMsg(ex.Message)
        End Try
    End Sub

    Private Sub TXTNUM_Validating(sender As Object, e As CancelEventArgs) Handles TXTNUM.Validating
        Try
            If TXTNUM.Text.Trim.Length > 2 Then

                ErrorMsg("NUMERO DE DIGITOS MAYOR A 2")
                e.Cancel = True

                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTNUM_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNUM.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    Me.TXTNUM.EnterMoveNextControl = True

            End Select
        Catch ex As Exception

        End Try
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

    Private Sub TXTTURNO_EditValueChanged(sender As Object, e As EventArgs) Handles TXTTURNO.EditValueChanged

    End Sub

    Private Sub TXTTURNO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTTURNO.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    TXTTURNO.EnterMoveNextControl = True

            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class