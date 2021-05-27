Public Class Cls_Cliente

    Implements IDisposable

#Region "ATRIBUTOS"

    Public Property ID_CLIENTE As Integer

    Public Property NOMBRES As String
    Public Property APELLIDOS As String

    Public Property PRECIO_BASE As Integer


#End Region


#Region "PROCEDIMIENTOS"
    Public Sub NUEVO()
        Try
            Me.ID_CLIENTE = 0
            Me.NOMBRES = ""
            Me.APELLIDOS = ""
            Me.PRECIO_BASE = 0



        Catch ex As Exception

        End Try
    End Sub


    Public Sub New()
        Try
            NUEVO()
        Catch ex As Exception

        End Try
    End Sub

    Public Function GUARDAR() As Integer
        Try
            Dim RS As Integer = 0
            Dim STRSQL As String = String.Format("EXEC CLIENTE_GUARDAR @ID_CLIENTE = {0},	@NOMBRES = '{1}',	@APELLIDOS = '{2}',	@PRECIO_BASE = {3}",
                                                 Me.ID_CLIENTE,
                                                 SinComillas(Me.NOMBRES),
                                                SinComillas(Me.APELLIDOS),
                                                 Me.PRECIO_BASE)

            consql.consql.Ejecutar(STRSQL, RS)
            Me.ID_CLIENTE = RS
            Return RS
        Catch ex As Exception
            Return 0
        End Try



    End Function
    Public Function UBICAR(ByVal CLIENTE As Integer) As Boolean
        Try

            Using TMPDS As DataSet = New DataSet
                Dim STRSQL = String.Format("EXEC RECUPERAR_CLIENTE @CLIENTE = {0}", CLIENTE)

                consql.consql.LlenarDataSet2(STRSQL, TMPDS)
                If TieneDatos(TMPDS) Then
                    For Each ROW As DataRow In TMPDS.Tables(0).Rows
                        Me.ID_CLIENTE = ROW("ID_CLIENTE")

                        Me.NOMBRES = ROW("NOMBRES")

                        Me.APELLIDOS = ROW("APELLIDOS")

                        Me.PRECIO_BASE = ROW("PRECIO_BASE")
                    Next
                Else
                    Return False
                End If


            End Using
            Return True



        Catch ex As Exception
            ErrorMsg(ex.Message)
            Return False
        End Try
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: elimine el estado administrado (objetos administrados).
            End If

            ' TODO: libere los recursos no administrados (objetos no administrados) y reemplace Finalize() a continuación.
            ' TODO: configure los campos grandes en nulos.
        End If
        disposedValue = True
    End Sub

    ' TODO: reemplace Finalize() solo si el anterior Dispose(disposing As Boolean) tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agrega este código para implementar correctamente el patrón descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: quite la marca de comentario de la siguiente línea si Finalize() se ha reemplazado antes.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region





#End Region

End Class
