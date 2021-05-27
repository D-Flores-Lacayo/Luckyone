Public Class Cls_Turnos
    Implements IDisposable



#Region "ATRIBUTOS"

    Public Property ID_TICKET As Integer
    Public Property ID_TURNO As Integer
    Public Property ID_USUARIO As Integer
    Public Property FECHA As Date
    Public Property PRECIO_GENERAL As Decimal
    Public Property PRECIO_CASA As Decimal
    Public Property PRECIO_RECORTE As Decimal
    Public Property ACTIVO As Boolean

#End Region


#Region "PROCEDIMIENTOS"
    Public Sub NUEVO()
        Try
            Me.ID_USUARIO = 0
            Me.ID_TICKET = 0
            Me.ID_TURNO = 0
            Me.FECHA = Today
            Me.PRECIO_GENERAL = 0
            Me.PRECIO_CASA = 0
            Me.PRECIO_RECORTE = 0
            Me.ACTIVO = True



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
            Dim STRSQL As String = String.Format("EXEC TICKET_GUARDAR @IDTICKET = {0},@IDTURNO = {1},@IDUSUARIO = {2},@FECHA ='{3}',@PREMIO_GENERAL = {4},@PREMIO_CASA = {5},@PREMIO_RECORTE = {6}",
                                                 Me.ID_TICKET,
                                                 Me.ID_TURNO,
                                                 Me.ID_USUARIO,
                                                Me.FECHA,
                                                 Me.PRECIO_GENERAL,
                                                 Me.PRECIO_CASA,
                                                Me.PRECIO_RECORTE)

            consql.consql.Ejecutar(STRSQL, RS)
            Me.ID_TICKET = RS
            Return RS
        Catch ex As Exception
            Return 0
        End Try



    End Function





#End Region




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






End Class
