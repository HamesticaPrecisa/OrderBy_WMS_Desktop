' VES Sep 2019
' Configuracion general de la app.  Los valores para las propiedades
' de esta clase se leen desde app.config
'
Public Class appConfig

    Public currentSet As String            ' Set actual de configuracion (DEV, QAS, PRD)
    Public lanIP As String                 ' IP para coneixon local
    Public wlanIP As String                ' IP para conexion remota
    Public dbUID As String                 ' UserID para la conexion con la BD
    Public dbPWD As String                 ' Pwd para la conexion con la BD
    Public lanConnStr As String            ' Cadena de conexion para conexion local. Puede usar el placeholder {ip} para refererirse al IP de conexion local, {uid} para el usuario y {pwd} para el password (NO INCLUIR Initial Catalog)
    Public wlanConnStr As String           ' Cadena de conexion para conexion remota. Puede usar el placeholder {ip} para refererirse al IP de conexion remota, {uid} para el usuario y {pwd} para el password (NO INCLUIR Initial Catalog)
    Public mainCatalog As String           ' Nombre de la base de datos a usar en conexiones locales
    Public etiqCatalog As String           ' Nombre de la base de dawtos a usar en conexiones remotas

    Public dbLANConnStr As String          ' Cadena de conexion local para el catalogo principal
    Public dbWLANConnStr As String         ' Cadeba de conexion remota para el catalogo principal

End Class
