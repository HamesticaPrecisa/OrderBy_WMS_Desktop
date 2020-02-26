Public Class LimiteFechaExportacionPedidos

    Dim fnc As New Funciones
    Private Sub LimiteFechaExportacionPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ListarTabla()

        Dim sql As String = "Select Hora_Limite from Pedidos_Tipo_Exportacion_Hora_Limite"
        Dim hora As DataTable = fnc.ListarTablasSQL(sql)

        txthoralim.Text = hora.Rows(0)(0).ToString()
    End Sub

    Private Sub DgvLimiteClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLimiteClientes.CellClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If MsgBox("Seguro de eliminar el limite seleccionado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                Exit Sub
            Else
                Dim codigo As String = Me.DgvLimiteClientes.Rows(e.RowIndex).Cells(1).Value.ToString()
                Dim sql As String = "delete from Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes where ID='" + codigo + "'"
                fnc.MovimientoSQL(sql)
                MsgBox("Se ah Eliminado Correctamente", MsgBoxStyle.Information, "Aviso")
                ListarTabla()
            End If
        Else

        End If
    End Sub

    Sub ListarTabla()
        Dim fecha1 = DateTime.Now.ToString("dd/MM/yyyy")
        DgvLimiteClientes.DataSource = fnc.ListarTablasSQL("SELECT a.Id as Codigo, Fecha, Limite, (CASE WHEN a.Rut_Cliente='799842408' THEN '799842408 - 774763902' when a.Rut_Cliente='774763902' THEN '799842408 - 774763902' ELSE a.Rut_Cliente END) AS Rut_Cliente, Nombre " +
        "FROM Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes a " +
        "inner join Pedidos_Tipo_Exportacion_Limite_Fecha as b on a.ID_Limite=b.ID " +
        "inner join Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes as c on c.Rut_Cliente=a.Rut_Cliente " +
        "inner join Pedidos_Tipo_Exportacion_Limites_Grupo as d on c.ID_Limite_Grupo=d.ID where Fecha>='" + fecha1 + "' " +
        "order by Fecha desc")
    End Sub


    Private Sub Checkhora_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Checkhora.CheckedChanged
        If Checkhora.Checked = False Then
            txthoralim.Enabled = False
        End If
        If Checkhora.Checked = True Then
            txthoralim.Enabled = True
        End If
    End Sub

    Private Sub btnGrahor_Click(sender As System.Object, e As System.EventArgs) Handles btnGrahor.Click
        Dim sqlhora As String = "Update Pedidos_Tipo_Exportacion_Hora_Limite set Hora_Limite='" + txthoralim.Text + "'"
        fnc.MovimientoSQL(sqlhora)
        Dim sqlnew As String = "Select Hora_Limite from Pedidos_Tipo_Exportacion_Hora_Limite"
        Dim horanueva As DataTable = fnc.ListarTablasSQL(sqlnew)
        MsgBox("Hora Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")
        txthoralim.Text = horanueva.Rows(0)(0).ToString()
        txthoralim.Enabled = False
        Checkhora.Checked = False
    End Sub


    Private Sub txtlimite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlimite.KeyPress
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'End If
        SoloNumeros(sender, e)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sql1 As String = "select * from Pedidos_Tipo_Exportacion_Limite_Fecha where ID='" + txtcodigo.Text + "'"
        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql1)

        If tabla3.Rows.Count > 0 Then
            If txtlimite.Text > 8 Then
                MsgBox("La cantidad limite es de 1-8 dependiendo del Cliente.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
            If txtlimite.Text < 1 Then
                MsgBox("La cantidad limite es de 1-8 dependiendo del Cliente.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If

            Dim fecha2 = DateTime.Now.ToString("dd/MM/yyyy")
            If Convert.ToDateTime(fecha.Text) <= fecha2 Then
                MsgBox("La fecha tiene que ser para adelante.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If

            Dim sql4 As String = "SELECT a.Id as Codigo, Fecha, Limite, Nombre " +
                "FROM Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes a " +
                "inner join Pedidos_Tipo_Exportacion_Limite_Fecha as b on a.ID_Limite=b.ID " +
                "inner join Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes as c on c.Rut_Cliente=a.Rut_Cliente " +
                "inner join Pedidos_Tipo_Exportacion_Limites_Grupo as d on c.ID_Limite_Grupo=d.ID where Fecha>='30/01/2020 0:00:00' " +
                "and a.ID_Limite='" + txtcodigo.Text + "'  order by Fecha desc"
            Dim tabla4 As DataTable = fnc.ListarTablasSQL(sql4)

            If tabla4.Rows.Count > 0 Then
                If txtlimite.Text > tabla4.Rows(0)(2).ToString() Then
                    MsgBox("Asegurece que el limite que esta modificando, se complementa con el limite diario que tiene el cliente.", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                Else
                    Dim sql3 As String = "update Pedidos_Tipo_Exportacion_Limite_Fecha set Fecha='" + fecha.Text + "', Limite='" + txtlimite.Text + "' where ID='" + txtcodigo.Text + "'"
                    fnc.MovimientoSQL(sql3)
                    MsgBox("Se modifico con exito con exito.", MsgBoxStyle.Information, "Aviso")
                    txtlimite.Text = ""
                    fecha.Text = fecha2
                    ListarTabla()
                    Exit Sub
                End If
            Else
                Dim sql5 As String = "update Pedidos_Tipo_Exportacion_Limite_Fecha set Fecha='" + fecha.Text + "', Limite='" + txtlimite.Text + "' where ID='" + txtcodigo.Text + "'"
                fnc.MovimientoSQL(sql5)
                MsgBox("Se modifico con exito con exito.", MsgBoxStyle.Information, "Aviso")
                txtlimite.Text = ""
                fecha.Text = fecha2
                ListarTabla()
                Exit Sub
            End If

            


        End If


        Dim cantidad As String = "select COUNT(Nombre) as Cantidad from Pedidos_Tipo_Exportacion_Limites_Grupo;"
        Dim tabla As DataTable = fnc.ListarTablasSQL(cantidad)

        Dim cantidad2 As String = "select COUNT(Fecha) as cantidad from Pedidos_Tipo_Exportacion_Limite_Fecha where Fecha='" + fecha.Text + "';"
        Dim tabla2 As DataTable = fnc.ListarTablasSQL(cantidad2)

        If tabla.Rows(0)(0).ToString() = tabla2.Rows(0)(0).ToString() Then
            MsgBox("La Cantidad maxima de limites por fecha esta copada.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        If txtlimite.Text = "" Then
            MsgBox("Se requiere de un limite.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If txtlimite.Text > 8 Then
            MsgBox("La cantidad limite es de 1-8 dependiendo del Cliente.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If txtlimite.Text < 1 Then
            MsgBox("La cantidad limite es de 1-8 dependiendo del Cliente.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim fecha1 = DateTime.Now.ToString("dd/MM/yyyy")
        If Convert.ToDateTime(fecha.Text) <= fecha1 Then
            MsgBox("La fecha tiene que ser para adelante.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim sql As String = "Insert into Pedidos_Tipo_Exportacion_Limite_Fecha values ('" + fecha.Text + "', '" + txtlimite.Text + "')"
        fnc.MovimientoSQL(sql)
        MsgBox("Se grabo con exito.", MsgBoxStyle.Information, "Aviso")
        txtlimite.Text = ""
        fecha.Text = fecha1
        txtcodigo.Text = ""
        ListarTabla()
    End Sub

    Private Sub btnlst_Click(sender As System.Object, e As System.EventArgs) Handles btnlst.Click
        Dim f As New Lst_Pedidos_Fecha
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            txtcodigo.Text = Frm_Principal.buscavalor.ToString()
            busca_grupo(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub busca_grupo(ByVal cod As String)

        Dim where As String = ""


        Dim SqlBusca = "select Fecha, Limite from Pedidos_Tipo_Exportacion_Limite_Fecha where ID='" + cod + "';"

        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tabla.Rows.Count > 0 Then

            fecha.Text = tabla.Rows(0)(0).ToString()
            txtlimite.Text = tabla.Rows(0)(1).ToString()

        End If
    End Sub


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim fecha1 = DateTime.Now.ToString("dd/MM/yyyy")
        txtlimite.Text = ""
        txtcodigo.Text = ""
        fecha.Text = fecha1
    End Sub

    Private Sub GroupBox3_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub btnfechas_Click(sender As System.Object, e As System.EventArgs) Handles btnfechas.Click
        Dim f As New Lst_Pedidos_Fecha
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            txtidfechalimit.Text = Frm_Principal.buscavalor.ToString()
            busca_grupo2(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub busca_grupo2(ByVal cod As String)

        Dim where As String = ""


        Dim fechas = "select ID, Fecha, Limite from Pedidos_Tipo_Exportacion_Limite_Fecha where ID='" + cod + "';"

        Dim tblfechas As DataTable = fnc.ListarTablasSQL(fechas)

        If tblfechas.Rows.Count > 0 Then
            fechalimit.Text = tblfechas.Rows(0)(1).ToString()
            cantidadlimit.Text = tblfechas.Rows(0)(2).ToString()

        End If
    End Sub

    Private Sub BtnClientes_Click(sender As System.Object, e As System.EventArgs) Handles BtnClientes.Click
        Dim f As New Lst_Pedidos_Clientes
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            Dim sql As String = "select top(1) Rut_Cliente from Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes where Id_Limite_Grupo='" + Frm_Principal.buscavalor.ToString() + "' "
            Dim rut As DataTable = fnc.ListarTablasSQL(sql)
            If rut.Rows.Count = 0 Then
                Exit Sub
            End If
            txtidcliente.Text = rut.Rows(0)(0).ToString()
            busca_grupo3(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub busca_grupo3(ByVal cod As String)

        Dim where As String = ""


        Dim clientes = "select Nombre from Pedidos_Tipo_Exportacion_Limites_Grupo where ID='" + cod + "';"

        Dim tblciente As DataTable = fnc.ListarTablasSQL(clientes)

        If tblciente.Rows.Count > 0 Then
            cliente.Text = tblciente.Rows(0)(0).ToString()


        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtidcliente.Text = ""
        cliente.Text = ""
        txtidfechalimit.Text = ""
        fechalimit.Text = ""
        cantidadlimit.Text = ""
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If cliente.Text = "" Then
            MsgBox("Se Requiere de un Cliente.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If fechalimit.Text = "" Then
            MsgBox("Se Requiere de una Fecha con Limite.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If cantidadlimit.Text = "" Then
            MsgBox("Se Requiere de una Fecha con Limite.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim sql As String = "select * from V_Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes where Fecha='" + fechalimit.Text + "' and Rut_Cliente like '%" + txtidcliente.Text + "%';"

        Dim TablaCheck As DataTable = fnc.ListarTablasSQL(sql)

        If TablaCheck.Rows.Count > 0 Then
            MsgBox("Este Cliente ya tiene un limite para este dia, si lo desea puede modificarlo en la seccion anterior.", MsgBoxStyle.Information, "Aviso")
            limpiar()
            Exit Sub
        End If

        Dim sql2 As String = "select Nombre, Limite_Diario from Pedidos_Tipo_Exportacion_Limites_Grupo where Nombre like '%" + cliente.Text + "%'"
        Dim limitediario As DataTable = fnc.ListarTablasSQL(sql2)

        If cantidadlimit.Text > limitediario.Rows(0)(1).ToString() Then
            MsgBox("Asegurece que este cliente tenga ese numero de limite permitido en un dia.", MsgBoxStyle.Information, "Aviso")
            limpiar()
            Exit Sub
        End If

        Dim sql3 As String = "select * from Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes where ID_Limite='" + txtidfechalimit.Text + "'"
        Dim validarexist As DataTable = fnc.ListarTablasSQL(sql3)

        If validarexist.Rows.Count > 0 Then
            MsgBox("La Fecha y limite que ha seleccionado ya se encunetra con otro cliente.", MsgBoxStyle.Information, "Aviso")
            limpiar()
            Exit Sub
        End If

        If txtidcliente.Text = "799842408" Or txtidcliente.Text = "774763902" Then
            Dim sqlinsert As String = "insert into Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes values ('" + txtidfechalimit.Text + "','799842408');"
            fnc.MovimientoSQL(sqlinsert)
            Dim sqlinsert2 As String = "insert into Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes values ('" + txtidfechalimit.Text + "','774763902');"
            fnc.MovimientoSQL(sqlinsert2)
            MsgBox("El limite por fecha a sido grabado correctamente.", MsgBoxStyle.Information, "Aviso")
            limpiar()
            ListarTabla()
        Else
            Dim sqlinsert2 As String = "insert into Pedidos_Tipo_Exportacion_Limite_Fecha_Clientes values ('" + txtidfechalimit.Text + "','" + txtidcliente.Text + "');"
            fnc.MovimientoSQL(sqlinsert2)
            MsgBox("El limite por fecha a sido grabado correctamente.", MsgBoxStyle.Information, "Aviso")
            limpiar()
            ListarTabla()
        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim frm As New Limite_Pedidos_Exportacion_Buscar
        frm.ShowDialog(Frm_Principal)

        Dim valor As String = Frm_Principal.buscavalor

    End Sub

    Private Sub DgvLimiteClientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLimiteClientes.CellContentClick

    End Sub
End Class