Imports System.Configuration

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ' VES Sep 2019
        ' Interceptamos el evento Startup de la aplicacion para cargar aqui configuraciones generales
        ' de la app.  La idea es que estos valores se lean desde app.config en lugar de estar quemados
        ' en el codigo de la app
        '
        ' Cualquier valor no indicado en app.config revertira su valor al valor por omision que tenia
        ' en el codigo original.
        '
        Private Sub IPL() Handles Me.Startup

            ' Asignamos los valores por omision
            CONFIG.lanIP = "192.168.1.90"
            CONFIG.wlanIP = "186.67.106.109"
            CONFIG.mainCatalog = "PRECISA"
            CONFIG.etiqCatalog = "ETIQUETADO"
            CONFIG.lanConnStr = ("Data Source={ip}\PRECISABD; USER=sa; PWD=precisa; Connection Timeout=3; ")
            CONFIG.wlanConnStr = ("Data Source={ip}\PRECISABD; USER=sa; PWD=precisa; Connection Timeout=3; ")

            Dim err As Exception = Nothing
            Try
                Dim connStrings = ConfigurationManager.ConnectionStrings
                Dim appSettings = ConfigurationManager.AppSettings

                CONFIG.lanConnStr = connStrings("app.connstrings.lan").ConnectionString
                CONFIG.wlanConnStr = connStrings("app.connstrings.wlan").ConnectionString

                CONFIG.lanIP = appSettings.Get("app.ip.lan")
                CONFIG.wlanIP = appSettings.Get("app.ip.wlan")
                CONFIG.mainCatalog = appSettings.Get("app.catalogs.main")
                CONFIG.etiqCatalog = appSettings.Get("app.catalogs.etiquetado")


            Catch ex As NullReferenceException
                err = ex

            Catch ex As ConfigurationErrorsException
                err = ex
            End Try

            If (err IsNot Nothing) Then
                ' TODO: Hacer una entrada en un log de errores
            End If

            CONFIG.lanConnStr = CONFIG.lanConnStr.Replace("{ip}", CONFIG.lanIP)
            CONFIG.wlanConnStr = CONFIG.wlanConnStr.Replace("{ip}", CONFIG.wlanIP)
            CONFIG.dbLANConnStr = CONFIG.lanConnStr + ";Initial Catalog=" + CONFIG.mainCatalog + ";"
            CONFIG.dbWLANConnStr = CONFIG.wlanConnStr + ";Initial Catalog=" + CONFIG.mainCatalog + ";"
        End Sub ' IPL

    End Class


End Namespace

