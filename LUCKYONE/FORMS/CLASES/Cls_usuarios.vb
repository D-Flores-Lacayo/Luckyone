Public Class Cls_usuarios
    Implements IDisposable

#Region "ATRIBUTOS"

    Public Property ID_USUARIO As Integer
    Public Property USUARIO As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property CONTRASEÑA As String

    Public Property UNIDAD As Integer
    Public Property ACTIVO As Boolean

#End Region


#Region "PROCEDIMIENTOS"
    Public Sub NUEVO()
        Try
            Me.ID_USUARIO = 0
            Me.USUARIO = ""
            Me.NOMBRES = ""
            Me.APELLIDOS = ""
            Me.CONTRASEÑA = ""
            Me.UNIDAD = 0
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
            Dim STRSQL As String = String.Format("EXEC USUARIO_GUARDAR	@ID_USUARIO = {0},	@USUARIO = '{1}',	@NOMBRE = '{2}',	@APELLIDOS = '{3}',	@CONTRASEÑA = '{4}',	@ID_UNIDAD = {5},	@ACTIVO = '{5}'",
                                                 Me.ID_USUARIO,
                                                 SinComillas(USUARIO),
                                                 SinComillas(Me.NOMBRES),
                                                SinComillas(Me.APELLIDOS),
                                                 SinComillas(Me.CONTRASEÑA),
                                                 Me.UNIDAD,
                                                SinComillas(Me.ACTIVO))

            consql.consql.Ejecutar(STRSQL, RS)
            Me.ID_USUARIO = RS
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
