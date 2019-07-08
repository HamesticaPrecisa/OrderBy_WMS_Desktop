Module Ayuda_Codigo

    Dim fnc As New Funciones

    Public Function RetornaCliente(ByVal rut As String) As String

        Dim nombre_cliente As String = ""

        Dim sql As String = "SELECT cli_nomb FROM clientes WHERE cli_rut='" + rut + "'"

        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            nombre_cliente = fnc.ListarTablasSQL(sql).Rows(0)(0).ToString()
        End If

        Return nombre_cliente
    End Function

    Public Function RetornaContrato(ByVal codigo As String) As String

        Dim sql As String = "SELECT cont_descr FROM Contrato WHERE cont_codi='" + codigo + "'"
        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            Return fnc.ListarTablasSQL(sql).Rows(0)(0).ToString()
            Exit Function
        End If
        Return ""
    End Function

    Public Function RetornaProducto(ByVal codigo As String) As String
        Dim sql As String = "SELECT mae_descr FROM maeprod WHERE mae_codi='" + codigo + "'"
        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            Return fnc.ListarTablasSQL(sql).Rows(0)(0).ToString()
            Exit Function
        End If
        Return ""
    End Function

    Public Function RetornaEnvase(ByVal codigo As String) As String

        Dim sql As String = "SELECT tenv_descr FROM tipoenv WHERE tenv_codi='" + codigo + "'"
        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            Return fnc.ListarTablasSQL(sql).Rows(0)(0).ToString()
            Exit Function
        End If
        Return ""
    End Function

    Public Function retorna_Origen(ByVal codigo As String) As String
        retorna_Origen = ""
        Dim sql As String = "SELECT Ori_descr FROM Origen WHERE ori_codi='" + codigo.ToString() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            retorna_Origen = tabla.Rows(0)(0).ToString()
        End If
        Return retorna_Origen
    End Function

    Public Function retorna_Almacenamiento(ByVal codigo As String) As String
        retorna_Almacenamiento = ""
        Dim sql As String = "SELECT almacenamiento FROM P_tipoalmacenamiento WHERE id='" + codigo.ToString() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            retorna_Almacenamiento = tabla.Rows(0)(0).ToString()
        End If
        Return retorna_Almacenamiento
    End Function

    Public Function retorna_CargDesc(ByVal codigo As String) As String
        retorna_CargDesc = ""
        Dim sql As String = "SELECT tcar_descr FROM P_TipoCargaDescarga WHERE tcar_codi='" + codigo.ToString() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            retorna_CargDesc = tabla.Rows(0)(0).ToString()
        End If
        Return retorna_CargDesc
    End Function

    Public Function retorna_TipRece(ByVal codigo As String) As String
        retorna_TipRece = ""
        Dim sql As String = "SELECT DescripcionRecepcion FROM P_TipoRecepcion  WHERE IdRecepcion='" + codigo.ToString() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            retorna_TipRece = tabla.Rows(0)(0).ToString()
        End If
        Return retorna_TipRece
    End Function

End Module
