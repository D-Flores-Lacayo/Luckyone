Module Mod_Variables
    Public Property sesion As String
    Public Property idusuairo As Int16
    Public conSqlite As cls_Sistema_ConSQLite
    Public objCrypto As New Utilities.Encryption
    Public strMiRuta As String = CurDir()

    ''Me.Sesión = System.Guid.Parse(fila("Sesión").ToString)



End Module
