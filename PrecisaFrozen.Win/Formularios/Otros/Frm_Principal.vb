Imports System.Resources
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports System.Runtime.InteropServices
Imports System.Deployment
Imports System.Windows.Forms
Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.Text



Public Class Frm_Principal

    Implements IForm
    Public buscavalor = ""
    Public PuertoRFID As String = ""
    Dim minimizar_barra = True
    Dim fnc As New Funciones
    Dim verifica As Integer = 0
    Private Const REG_SZ = 1 'Constant for a string variable type. 
    Private Const HKEY_LOCAL_MACHINE = &H80000002


    Private Sub Frm_Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  CONECTARVARI = "LOCAL"  
        '
        '       VES NOV 2019
        '       DEFINIMOS EL TITULO DE LA VENTANA PRINCIPAL INCLUYENDO
        '       EL NOMBRE DE LA BD ACTIVA
        '
        Me.Text = "Order By WMS - Precisa Tech 31.03.2020.17.00 - BD: " + CONFIG.mainCatalog
        InfoUsuario.Text = "001"
        If Not My.Computer.Name = " PROGRAMACION-PC" Then
            Presentacion.ShowDialog()

            Frm_InicioSesion.ShowDialog()

        Else
            veri_conn.Start()
            Timer1.Start()
            verificaPrivilegios()
            VerifConectados.Start()
            PictureBox1.Image = Nothing
            cargaimg()

        End If
        'Odbc()
        nuevoodbc()
        If File.Exists("C:\Imagenlogo.jpg") Then
            My.Computer.FileSystem.DeleteFile("C:\Imagenlogo.jpg")
        End If
        If File.Exists("C:\Windows\Imagenlogo.jpg") Then

            My.Computer.FileSystem.DeleteFile("C:\Windows\Imagenlogo.jpg")
        End If

        Dim strr As String = "1"

        'Buscar Puerto COM Lector RFID
        Dim pathCOM = Directory.GetCurrentDirectory.Trim & "\RFIDCOMPORT.txt"
        'MessageBox.Show(pathCOM)

        If (File.Exists(pathCOM)) Then
            Using reader As New StreamReader(pathCOM)
                PuertoRFID = reader.ReadLine().Trim
            End Using
            'Else
            '    MessageBox.Show("No existe archivo!")
        End If
        'Fin buscar Puerto COM Lector RFID


        'veri_conn.Start()
        'Timer1.Start()
        'verificaPrivilegios()
        'VerifConectados.Start()
        'PictureBox1.Image = Nothing
        'cargaimg()
        'lblsucursal.Text = sucursalglo
    End Sub

    Public Sub ChangeTextBoxText(ByVal text As String) Implements IForm.ChangeTextBoxText
        buscavalor = text
    End Sub

#Region "--------------------------------- Menu --------------------------------------"
    Sub TabMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As New ContextMenuStrip
            Dim t As ToolStripItem = x.Items.Add("Close it", Nothing, AddressOf Closeit)
            t.Tag = sender
            x.Show(sender, e.Location)
        End If
    End Sub

    Sub Closeit(ByVal sender As Object, ByVal e As EventArgs)
        sender.tag.Form.close()
    End Sub

    Private Sub TabControl1_GetTabRegion(ByVal sender As Object, ByVal e As MdiTabControl.TabControl.GetTabRegionEventArgs)
        Array.Resize(e.Points, 4)
        If e.Selected Then
            e.Points(0) = New Point(0, e.TabHeight)
            e.Points(1) = New Point(0, 0)
            e.Points(2) = New Point(e.TabWidth, 0)
            e.Points(3) = New Point(e.TabWidth, e.TabHeight)
        Else
            e.Points(0) = New Point(0, e.TabHeight - 2)
            e.Points(1) = New Point(0, -1)
            e.Points(2) = New Point(e.TabWidth, -1)
            e.Points(3) = New Point(e.TabWidth, e.TabHeight - 2)
        End If
    End Sub

    Private Sub TabControl1_TabPaintBorder(ByVal sender As Object, ByVal e As MdiTabControl.TabControl.TabPaintEventArgs)
        If Not e.Selected Then
            e.Handled = True
            e.Graphics.DrawLine(Pens.Peru, e.ClipRectangle.Width - 1, 2, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 3)
        End If
    End Sub
#End Region

    Private Sub MinimizaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizaToolStripMenuItem.Click
        If minimizar_barra = True Then
            minimizar_barra = False
            MinimizaToolStripMenuItem.Checked = True
            AccesosDirectos.Visible = False
        Else
            minimizar_barra = True
            MinimizaToolStripMenuItem.Checked = False
            AccesosDirectos.Visible = True
        End If
    End Sub
    '--------------------- barra desplegable ----------------

    'Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addclientes = False Then
    '        Dim f As Form
    '        f = Frm_AddClientes
    '        TabControl1.TabPages.Add(f)
    '        f_addclientes = True
    '    Else
    '        TabControl1.TabPages(Frm_AddClientes).Select()
    '    End If

    'End Sub

    'Private Sub EnvasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addenvases = False Then
    '        Dim f As Form
    '        f = Frm_AddEnvases
    '        TabControl1.TabPages.Add(f)
    '        f_addenvases = True
    '    Else
    '        TabControl1.TabPages(Frm_AddEnvases).Select()
    '    End If
    'End Sub

    'Private Sub CamarasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addcamaras = False Then
    '        Dim f As Form
    '        f = Frm_AddCamaras
    '        TabControl1.TabPages.Add(f)
    '        f_addcamaras = True
    '    Else
    '        TabControl1.TabPages(Frm_AddCamaras).Select()
    '    End If
    'End Sub

    'Private Sub ChoferesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addchoferes = False Then
    '        Dim f As Form
    '        f = Frm_AddChoferes
    '        TabControl1.TabPages.Add(f)
    '        f_addchoferes = True
    '    Else
    '        TabControl1.TabPages(Frm_AddChoferes).Select()
    '    End If
    'End Sub

    'Private Sub FamiliasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addfamilias = False Then
    '        Dim f As Form
    '        f = Frm_AddFamilias
    '        TabControl1.TabPages.Add(f)
    '        f_addfamilias = True
    '    Else
    '        TabControl1.TabPages(Frm_AddFamilias).Select()
    '    End If
    'End Sub

    'Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addproductos = False Then
    '        Dim f As Form
    '        f = Frm_AddProductos
    '        TabControl1.TabPages.Add(f)
    '        f_addproductos = True
    '    Else
    '        TabControl1.TabPages(Frm_AddProductos).Select()
    '    End If
    'End Sub

    'Private Sub SoportantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If f_addsoportantes = False Then
    '        Dim f As Form
    '        f = Frm_AddSoportantes
    '        TabControl1.TabPages.Add(f)
    '        f_addsoportantes = True
    '    Else
    '        TabControl1.TabPages(Frm_AddSoportantes).Select()
    '    End If
    'End Sub

    Private Sub ClientesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Clientes.Click
        If f_addclientes = False Then
            Dim f As Form
            f = Frm_AddClientes
            TabControl1.TabPages.Add(f)
            f_addclientes = True
        Else
            TabControl1.TabPages(Frm_AddClientes).Select()
        End If
    End Sub

    Private Sub SoportantesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_MSoportantes.Click
        If f_lstSoportantes = False Then
            Dim f As Form
            f = Lst_soportantes
            TabControl1.TabPages.Add(f)
            f_lstSoportantes = True
        Else
            TabControl1.TabPages(Lst_soportantes).Select()
        End If
    End Sub

    Private Sub CamarasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Camaras.Click
        If f_lstCamaras = False Then
            Dim f As Form
            f = Lst_Camaras
            TabControl1.TabPages.Add(f)
            f_lstCamaras = True
        Else
            TabControl1.TabPages(Lst_Camaras).Select()
        End If
    End Sub

    Private Sub FamiliasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Familias.Click
        If f_lstFamilias = False Then
            Dim f As Form
            f = Lst_familias
            TabControl1.TabPages.Add(f)
            f_lstFamilias = True
        Else
            TabControl1.TabPages(Lst_familias).Select()
        End If
    End Sub

    Private Sub Frm_Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If f_addrecepcion = True Then
            Frm_GuiaRecepcionAgregar.Frm_AddRecepcion_FormClosing(sender, e)
        ElseIf f_addPredespacho = True Then
            Frm_GuiaPreDespachoAgregar.Frm_GuiaPreDespachoAgregar_FormClosing(sender, e)
        ElseIf f_addDespacho = True Then
            Frm_Despacho.Frm_Despacho_FormClosing(sender, e)
        ElseIf f_addservicios = True Then
            Frm_IngresoServicios.Frm_IngresoServicios_FormClosing(sender, e)
        ElseIf f_registrocamion = True Then
            Frm_CheckList.Frm_CheckList_FormClosing(sender, e)
        ElseIf f_etiquetado = True Then
            Frm_Etiquetado.Frm_Etiquetado_FormClosing(sender, e)
        Else
            veri_conn.Stop()
            Timer1.Stop()
            VerifConectados.Stop()
        End If
    End Sub

    Private Sub ChoferesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Choferes.Click
        If f_lstChoferes = False Then
            Dim f As Form
            f = Lst_Choferes
            TabControl1.TabPages.Add(f)
            f_lstChoferes = True
        Else
            TabControl1.TabPages(Lst_Choferes).Select()
        End If
    End Sub

    Private Sub EnvasesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Envases.Click
        If f_LstEnvases = False Then
            Dim f As Form
            f = Lst_Envases
            TabControl1.TabPages.Add(f)
            f_LstEnvases = True
        Else
            TabControl1.TabPages(Lst_Envases).Select()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_MProductos.Click
        If f_addproductos = False Then
            Dim f As Form
            f = Frm_AddProductos
            TabControl1.TabPages.Add(f)
            f.Show()
            f_addproductos = True
        Else
            TabControl1.TabPages(Frm_AddProductos).Select()
        End If

    End Sub

    Private Sub OrigenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Origenes.Click
        If f_LstOrigen = False Then
            Dim f As Form
            f = Lst_Origenes
            TabControl1.TabPages.Add(f)
            f_LstOrigen = True
        Else
            TabControl1.TabPages(Lst_Origenes).Select()
        End If
    End Sub

    Private Sub StockDetalladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_StockDetallado.Click
        If f_detallado = False Then
            Dim f As Form
            f = Rpt_StockDetallado
            TabControl1.TabPages.Add(f)
            f_detallado = True
        Else
            TabControl1.TabPages(Rpt_StockDetallado).Select()
        End If
    End Sub

    Private Sub StockResumidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_StockResumido.Click

        If f_resumido = False Then
            Dim f As Form
            f = Frm_ResumidoFecha
            TabControl1.TabPages.Add(f)
            f_resumido = True
        Else
            TabControl1.TabPages(Frm_ResumidoFecha).Select()
        End If

    End Sub

    Private Sub StockAcumuladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_StockAcumulado.Click
        If f_acumulado = False Then
            Dim f As Form
            f = Rpt_StockHistorico
            TabControl1.TabPages.Add(f)
            f.Show()
            f_acumulado = True
        Else
            TabControl1.TabPages(Rpt_StockHistorico).Select()
        End If

    End Sub

    Private Sub veri_conn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veri_conn.Tick
        Try
            If Not (My.Computer.Network.Ping(ip)) Then
                lblconexion.Image = My.Resources.con_no
                verifica += 1
            Else
                lblconexion.Image = My.Resources.conn_ok
                lblconexion.ForeColor = Color.Black
                verifica = 0
            End If
        Catch ex As Exception
            lblconexion.Image = My.Resources.con_no
            lblconexion.ForeColor = Color.Red
            verifica += 1
        End Try
        If verifica > 3 Then
            Me.Enabled = False
            lblconexion.ForeColor = Color.Red
            lblconexion.Text = "SIN CONEXION"
            ' Me.Opacity = 60
        ElseIf verifica = 0 Then
            Me.Enabled = True
            lblconexion.ForeColor = Color.Black
            lblconexion.Text = "CONECTADO"
            '   Me.Opacity = 100

        End If
        Me.buscavalor = ""

        'If InfoUsuario.Text = "001" Then

        'End If

    End Sub

   
    Private Sub cargaimg()
        If CONECTARVARI = "" Then

        Else
            Dim sqlImagen As String = "SELECT foto from usuimg where id= '" + InfoUsuario.Text + "'"

            Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)


            If tablaimagen.Rows.Count > 0 Then

                'Imagen1
                If tablaimagen.Rows(0)(0).ToString() <> "" Then
                    'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                    PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

                Else
                    PictureBox1.Image = Nothing
                End If

            End If
        End If
      

    End Sub
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function


    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" ( _
    ByVal hwndParent As Int32, _
    ByVal fRequest As Int32, _
    ByVal lpszDriver As String, _
    ByVal lpszAttributes As StringBuilder) As Int32
    '  ByVal hwndParent As Long, ByVal fRequest As Long, _
    'ByVal lpszDriver As String, ByVal lpszAttributes As String) As Long

    Private Sub nuevoodbc()

        Dim dl As Long                          ' Valor devuelto por la función API
        Dim attributes As StringBuilder = New StringBuilder           ' Aributos
        Dim sDriver As String                   ' Nombre del controlador
        Dim sDescription As String              ' Descripción del DSN
        Dim sDsnName As String                  ' Nombre del DSN

        Const ODBC_ADD_DSN As Int32 = 1      ' Se creará un DSN de sistema
        Const vbAPINull As Int32 = 0&            ' Puntero NULL

        ' Establecemos los atributos necesarios
        sDsnName = "Precisa_informes"
        sDescription = "orgen de datos orderby"
        sDriver = "SQL Server"

        ' Los pares de cadenas acabarán en valor Null
        attributes.Append("DSN=" & sDsnName & New Char)

        ' VES Sep 2019
        'attributes.Append("Server=" + ip.Trim() + "\PRECISABD" & New Char)
        attributes.Append("Server=" & CONFIG.lanIP & New Char)


        attributes.Append("Description=" & sDescription & New Char)

        attributes.Append("Database=" & CONFIG.mainCatalog & New Char)

        ' Si deseamos utilizar la autenticación de Windows NT, deberemos de
        ' especificarlo en la cadena de atributos
        ' attributes.Append("Trusted_Connection=True" & New Char)

        ' Creamos el nuevo origen de datos de usuario especificado.
        ' Si deseamos que aparezca el cuadro de diálogo, tendremos que
        ' especificar la propiedad «hWnd» del formulario donde se realiza
        ' la llamada a la función API.
        ' dl = SQLConfigDataSource(vbAPINull, ODBC_ADD_DSN, sDriver, sAttributes)
        Dim dl2 As Int32 = SQLConfigDataSource(0, ODBC_ADD_DSN, sDriver, attributes)
        If (dl2) Then
            ' MsgBox("Se ha creado el DSN de sistema.")
        Else
            'MsgBox("No se ha podido crear el DSN de sistema.")
        End If


    End Sub

    'Private Sub odbc()





    '    Dim dl As Long                          ' Valor devuelto por la función API
    '    Dim attributes As StringBuilder = New StringBuilder             ' Aributos
    '    Dim sDriver As String                   ' Nombre del controlador
    '    Dim sAttributes As String
    '    Dim sDescription As String              ' Descripción del DSN
    '    Dim sDsnName As String                  ' Nombre del DSN

    '    Const ODBC_ADD_DSN As Long = 10      ' Se creará un DSN de sistema
    '    Const vbAPINull As Long = 0&            ' Puntero NULL




    '    ' Establecemos los atributos necesarios
    '    sDsnName = "PRUEBAAODBCINFORMES"
    '    sDescription = ""
    '    sDriver = "SQL Server"

    '    attributes.Append("DSN=" & sDsnName & New Char)

    '    attributes.Append("Server=" + ip.Trim() + "\PRECISABD" & New Char)

    '    attributes.Append("Description=" & sDescription & New Char)

    '    attributes.Append("Database=Precisa" & New Char)

    '    attributes.Append("Uid=sa" & New Char)

    '    ' Si deseamos utilizar la autenticación de Windows NT,

    '    ' deberemos de especificarlo en la cadena de atributos

    '    '

    '    attributes.Append("Trusted_Connection=True" & New Char)
    '    ' Los pares de cadenas acabarán en valor Null
    '    sAttributes = "DSN=" & sDsnName & Chr(0)
    '    sAttributes = sAttributes & "Server=" + ip.Trim() + "\PRECISABD" & Chr(0)
    '    sAttributes = sAttributes & "Description=" & sDescription & Chr(0)
    '    sAttributes = sAttributes & "Database=precisa" & Chr(0)
    '    sAttributes = sAttributes & "Uid=sa" & Chr(0)
    '    ' Si deseamos utilizar la autenticación de Windows NT, deberemos de
    '    ' especificarlo en la cadena de atributos
    '    sAttributes = sAttributes & "Trusted_Connection=True" & Chr(0)

    '    ' Creamos el nuevo origen de datos de usuario especificado.
    '    ' Si deseamos que aparezca el cuadro de diálogo, tendremos que
    '    ' especificar la propiedad «hWnd» del formulario donde se realiza
    '    ' la llamada a la función API.
    '    '  dl = SQLConfigDataSource(vbAPINull, ODBC_ADD_SYS_DSN, sDriver, sAttributes)
    '    Dim dl2 As Int32 = SQLConfigDataSource(0, ODBC_ADD_DSN, sDriver, attributes)

    '    'If (dl) Then
    '    '    MsgBox("Se ha creado el DSN de sistema.")
    '    'Else
    '    '    MsgBox("No se ha podido crear el DSN de sistema.")
    '    'End If

    'End Sub



  

    Private Function GetReference(ByVal nombreControl As String) As Control

        ' Recorremos la colección de controles del formulario
        For Each ctrl As Control In Me.Controls

            If ctrl.Name.ToLower = nombreControl.ToLower Then
                ' Devolvemos la referencia y abandonamos la función
                Return ctrl
            End If
        Next
        Return Nothing
    End Function


    Sub verificaPrivilegios()

        For Each e As ToolStripMenuItem In MenuStrip1.Items
            'Console.WriteLine(e.Text)
            If e.Text <> "&Inicio" Then
                Console.WriteLine(e.GetType)

                For Each a As ToolStripItem In e.DropDownItems
                    If e.GetType.ToString() = "System.Windows.Forms.ToolStripMenuItem" Then
                        If a.Name <> "SeleccionarImpresoras" AndAlso a.Name <> "UltimaActualizaciones" Then
                            a.Enabled = False
                            Console.WriteLine(a.Name)
                        End If
                    End If
                Next

            End If
        Next



        'Exit Sub

        Dim sql As String = ""
        Dim tabla As DataTable = Nothing


        sql = "SELECT Spriv_Id, Spriv_PrivId FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " +
              "WHERE uf.Usu_Rut = Usuarios.usu_rut AND uf.Usu_SprivId = us.Spriv_Id  AND usu_codigo='" + InfoUsuario.Text + "'"

        tabla = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To tabla.Rows.Count - 1
            Console.WriteLine(tabla.Rows(i)(0).ToString() + " " + tabla.Rows(i)(1).ToString())
            If tabla.Rows(i)(1).ToString() = "001" Then
                M2_Productos.Enabled = True
                M3_Recepcion.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "002" Then
                M2_Productos.Enabled = True
                M3_Predespacho.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "003" Then
                M2_Productos.Enabled = True
                M3_Despacho.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "004" Then
                M2_Clientes.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "005" Then
                M2_Envases.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "006" Then
                M2_Camaras.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "007" Then
                M2_Choferes.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "008" Then
                M2_MSoportantes.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "009" Then
                M2_Familias.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "010" Then
                M2_Medidas.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "011" Then
                M2_MProductos.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "012" Then
                M2_Origenes.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "014" Then
                M2_PerfilesUsuario.Enabled = True
                M3_Usuarios.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "039" Then
                M3_Contratos.Enabled = True
            End If

            'If tabla.Rows(i)(0).ToString() = "016" Then
            '    M3_Servicios.Enabled = True
            'End If

            If tabla.Rows(i)(0).ToString() = "037" Then
                M2_Soportantes.Enabled = True
                M3_Posicionamiento.Enabled = True
            End If

            'If tabla.Rows(i)(0).ToString() = "042" Then
            '    M3_Servicios.Enabled = True
            'End If

            If tabla.Rows(i)(0).ToString() = "043" Then
                M2_Transportes.Enabled = True
                M3_RegistroDeCamiones.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "044" Then
                M2_Transportes.Enabled = True
                M3_MovimientoCamiones.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "045" Then
                M2_Transportes.Enabled = True
                M3_HistorialCamiones.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "047" Then
                M2_StockDetallado.Enabled = True
                M2_StockResumido.Enabled = True
                M2_StockAcumulado.Enabled = True
                '  DemoTomaTempToolStripMenuItem.Enabled = True
                'InformeCajasRepetidasToolStripMenuItem.Enabled = True
                ToolStripMenuItem1.Enabled = True
                InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.Enabled = True
                IinformeCuadraturaMovimientosToolStripMenuItem.Enabled = True
                InformePackingListToolStripMenuItem.Enabled = True
                ControlCamionesMovimientosToolStripMenuItem.Enabled = True
                InformaAperturaCierreAndenesToolStripMenuItem.Enabled = True
                M2_DocumentosEmitidos.Enabled = True
                M2_Trazabilidad.Enabled = True
                M2_TrazabilidadGuia.Enabled = True
                M2_TrazabilidadProductos.Enabled = True
                IngresoYSalidaTunelesToolStripMenuItem.Enabled = True
                M2_PedidosMensual.Enabled = True
                M2_PosicionesSoportantes.Enabled = True
                M2_CapacidadDeCamaras.Enabled = True
                M2_PosicionesLibres.Enabled = True
                InformeSoportantesEnCamarasToolStripMenuItem.Enabled = True
                M2_RevisionCamaras.Enabled = True
                M2_SoportantesVencidos.Enabled = True
                M2_SoportantesPorVencer.Enabled = True
                M2_ProcesosSinFinalizar.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "049" Then
                M2_ImpresionDeEtiquetas.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "055" Then
                M2_DesbloquearSoportantes.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "056" Then
                M2_Etiquetado.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "065" Then
                M2_Pedidos.Enabled = True
            End If

            'If tabla.Rows(i)(1).ToString() = "028" Then
            '    M3_Cotizaciones.Enabled = True
            'End If

            '*** MODULO CONTENEDORES ***

            If RealizarAccion("024", "072", False) = False AndAlso RealizarAccion("024", "073", False) = False Then
                M2_Contenedores.Enabled = False
            Else
                M2_Contenedores.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "074" Then
                M2_IngresoRCP.Enabled = True

            End If

            'If tabla.Rows(i)(0).ToString() = "068" Then
            '    M2_IngresoDeCobrosF.Enabled = True
            'End If

            'If tabla.Rows(i)(0).ToString() = "069" Then
            '    M2_IngresoDeCobrosA.Enabled = True
            'End If

            If tabla.Rows(i)(0).ToString() = "090" Then
                M2_PerfilesUsuario.Enabled = True
                M3_Categorias.Enabled = True
            End If

            If tabla.Rows(i)(1).ToString() = "022" Then
                M2_Pedidos.Enabled = True
                M3_ListadoDePedidos.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "091" Then
                M2_PerfilesUsuario.Enabled = True
                M3_SubCategorias.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "092" Then
                M2_Mantenedores.Enabled = True
                '  M3_Monedas.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "093" Then
                '   M2_Facturacion.Enabled = True
                '  M3_Facturacion.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "094" Then
                BloqueoDeSoportantes.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "100" Then
                CONTROLHOR.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "101" Then
                InformeSoportantesParaIngresoTúnelToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "102" Then
                ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "104" Then
                InformePedidosPorUsuarioToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "105" Then
                EnvioDeEmailToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "106" Then
                InformeToneladasKilosToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "107" Then
                PosicionesToolStripMenuItem.Enabled = True
                ProcesoJibiaToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "108" Then
                ProcesoJibiaToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "109" Then
                InformePalletsMalPosicionadosToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "110" Then
                SugerenciasAlmacenamientoToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "112" Then
                ConfiguraciónToolStripMenuItem.Enabled = True
                CamarasPlanoToolStripMenuItem.Enabled = True
                Plano2DToolStripMenuItem.Enabled = True
                ReglasAlmacenamientoToolStripMenuItem.Enabled = True
                PosicionesParaPickingToolStripMenuItem.Enabled = True
                FamiliasNoMezclablesToolStripMenuItem.Enabled = True
                ProgramarAuditoriasToolStripMenuItem.Enabled = True
                ' InformePosicionesToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "118" Then
                InformePosicionesToolStripMenuItem.Enabled = True
                ToolStripMenuItemInfoPos.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "114" Then
             
                TiempoTramosPedidosToolStripMenuItem.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "116" Then

                EtiquetaClientesToolStripMenuItem.Enabled = True
            End If

            If tabla.Rows(i)(0).ToString() = "117" Then

                ConfiguracionesGeneralesToolStripMenuItem.Enabled = True
            End If
            '

            If tabla.Rows(i)(0).ToString() = "120" Then
                M2_PlanRece.Enabled = True
            End If

            ' VES Sep 2019
            If tabla.Rows(i)(1).ToString() = "901" Then
                M2_Mercados.Enabled = True
            End If

            ' VES Oct 2019
            If tabla.Rows(i)(0).ToString() = "904" Then
                GuiasPorEntrarATunelToolStripMenuItem.Enabled = True
            End If

            ' VES Oct 2019
            If tabla.Rows(i)(0).ToString() = "905" Then
                EstadoDeTunelesToolStripMenuItem.Enabled = True
            End If
            If tabla.Rows(i)(0).ToString() = "906" Then
                ContenidoDeTunelesToolStripMenuItem.Enabled = True
            End If

        Next

        menLimPedExp.Enabled = True
        menLimPedExpFecha.Enabled = True
        menNumDia.Visible = True
        menNumDia.Enabled = True

        MenOrdenPallets.Enabled = True
        ChequeoCajasDuplicadasToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Salir.Click
        Me.Close()
    End Sub

    Private Sub PosicionamientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New Frm_PosicionamientoManual
        frm.ShowDialog()
    End Sub

    Private Sub TrazabilidadDePalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Trazabilidad.Click
        If f_trazabilidad = False Then
            Dim f As Form
            f = Frm_Trazabilidad
            TabControl1.TabPages.Add(f)
            f.Show()
            f_trazabilidad = True
        Else
            TabControl1.TabPages(Frm_Trazabilidad).Select()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TabControl1.TabPages.Count = 0 Then
            TabControl1.Visible = False
            Panel2.Visible = True
        Else
            Panel2.Visible = False
            TabControl1.Visible = True
        End If
    End Sub

    Private Sub RecepcionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Recepcion.Click
        If f_addrecepcion = False Then
            Dim f As Form
            f = Frm_GuiaRecepcionAgregar
            TabControl1.TabPages.Add(f)
            f_addrecepcion = True
        Else
            TabControl1.TabPages(Frm_GuiaRecepcionAgregar).Select()
        End If
    End Sub

    Private Sub PredespachoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Predespacho.Click
        If f_addPredespacho = False Then
            Dim f As Form
            f = Frm_GuiaPreDespachoAgregar
            TabControl1.TabPages.Add(f)
            f_addPredespacho = True
        Else
            TabControl1.TabPages(Frm_GuiaPreDespachoAgregar).Select()
        End If
    End Sub

    Private Sub DespachoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Despacho.Click
        If f_addDespacho = False Then
            Dim f As Form
            f = Frm_Despacho
            TabControl1.TabPages.Add(f)
            f_addDespacho = True
        Else
            TabControl1.TabPages(Frm_Despacho).Select()
        End If
    End Sub

    Private Sub MantenedorCategoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Categorias.Click
        If pf_categorias = False Then
            Dim f As Form
            f = Frm_Categorias
            TabControl1.TabPages.Add(f)
            pf_categorias = True
        Else
            TabControl1.TabPages(Frm_Categorias).Select()
        End If
    End Sub

    Private Sub MantenedorSubCategoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_SubCategorias.Click
        If pf_SubCategorias = False Then
            Dim f As Form
            f = Frm_SubCategorias
            TabControl1.TabPages.Add(f)
            pf_SubCategorias = True
        Else
            TabControl1.TabPages(Frm_SubCategorias).Select()
        End If
    End Sub

    Private Sub MantenedorDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Usuarios.Click
        If pf_usuarios = False Then
            Dim f As Form
            f = Frm_MantenedorUsuarios
            TabControl1.TabPages.Add(f)
            pf_usuarios = True
        Else
            TabControl1.TabPages(Frm_MantenedorUsuarios).Select()
        End If
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_CambiarUsuario.Click
        Dim frm As New Frm_InicioSesion
        frm.ShowDialog()
        verificaPrivilegios()
    End Sub

    Private Sub ServiciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_addservicios = False Then
            Dim f As Form = Frm_IngresoServicios
            TabControl1.TabPages.Add(f)
            f.Show()
            f_addservicios = True
        Else
            TabControl1.TabPages(Frm_IngresoServicios).Select()
        End If
    End Sub

    Private Sub ContratosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Contratos.Click
        If f_addcontrato = False Then
            Dim f As Form = Frm_Contratos
            TabControl1.TabPages.Add(f)
            f.Show()
            f_addcontrato = True
        Else
            TabControl1.TabPages(Frm_Cotizaciones).Select()
        End If
    End Sub

    Private Sub FacturacionQuincenalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_addfacturacion = False Then
            Dim f As Form = Frm_Facturacion
            TabControl1.TabPages.Add(f)
            f.Show()
            f_addfacturacion = True
        Else
            TabControl1.TabPages(Frm_Facturacion).Select()
        End If
    End Sub

    Private Sub IngresoDeCobrosVASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_addvas = False Then
            Dim f As Form = Frm_Vas
            TabControl1.TabPages.Add(f)
            Frm_Vas.tipo_vas = 0
            f.Show()
            f_addvas = True
        Else
            TabControl1.TabPages(Frm_Vas).Select()
        End If
    End Sub

    Private Sub RegistroDeCamionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_RegistroDeCamiones.Click
        If f_registrocamion = False Then
            Dim f As Form = Frm_CheckList
            TabControl1.TabPages.Add(f)
            f.Show()
            f_registrocamion = True
        Else
            TabControl1.TabPages(Frm_CheckList).Select()
        End If
    End Sub

    Private Sub IngresoDeCamionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_MovimientoCamiones.Click
        If f_listadocamion = False Then
            Dim f As Form = Frm_CheckListPendientes
            TabControl1.TabPages.Add(f)
            f.Show()
            f_listadocamion = True
        Else
            TabControl1.TabPages(Frm_CheckListPendientes).Select()
        End If
    End Sub

    Private Sub WToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Frm_GuiaRecepcionAgregar
        f.ShowDialog()
    End Sub

    Private Sub ImpresionDeEtiquetasRackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_ImpresionDeEtiquetas.Click
        Dim f As New Frm_IMPetiq  'Frm_UtilidadImprEtRack '
        f.ShowDialog()
    End Sub

    Private Sub SeleccionarImpresorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarImpresoras.Click
        Dim frm As New Frm_ConfImpresoras
        frm.ShowDialog()
    End Sub

    Private Sub RegistroDeIngresoYSalidaDeCamionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_HistorialCamiones.Click
        If f_IngresoSalida = False Then
            Dim frm As Form = Frm_ListadoChecklist
            TabControl1.TabPages.Add(frm)
            frm.Show()
            f_IngresoSalida = True
        Else
            TabControl1.TabPages(Frm_ListadoChecklist).Select()
        End If
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_CambiarContraseña.Click
        Dim f As New Frm_CambioClave
        f.ShowDialog()
    End Sub

    Private Sub PosicionamientoManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_Posicionamiento.Click
        If f_posicionamientomanual = False Then
            'Dim frm As Form = Frm_PosicionamientoManual
            Dim frm As Form = Frm_PosicionamientoManual
            TabControl1.TabPages.Add(frm)
            frm.Show()
            f_posicionamientomanual = True
        Else
            TabControl1.TabPages(Frm_PosicionamientoManual).Select()
        End If
    End Sub

    Private Sub SoportantesVencidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_SoportantesVencidos.Click
        Dim sql As String = "SELECT  cli_nomb, racd_codi, drec_sopocli, racd_codpro,mae_descr,convert(varchar,convert(date,racd_fecpro),105) AS fproduccion,convert(varchar,convert(date,dr.fechavencimiento),105) AS fvencimiento," +
                            "(DATEDIFF(day,convert(date,GETDATE()),convert(date,dr.fechavencimiento))*-1) AS diasvencidos " +
                            "FROM rackdeta, maeprod , detarece as dr, clientes " +
                            "WHERE racd_codpro=mae_codi AND drec_codi=racd_codi AND cli_rut=drec_rutcli AND " +
                            "DATEDIFF(day,convert(date,GETDATE()),convert(date,dr.fechavencimiento))< 0 AND cli_venc='0'"

        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then

            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "SopVencidos"
            Dim frm As New Frm_MuestraReporte
            Dim rpt As New Rpt_PalletVencidos
            rpt.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            frm.Contenedor.ReportSource = rpt
            frm.ShowDialog()
        Else
            MsgBox("No existen pallet vencidos", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Private Sub SoportantesPorVencerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_SoportantesPorVencer.Click

        Dim sql As String = "SELECT  cli_nomb, racd_codi, drec_sopocli, racd_codpro, convert(varchar,convert(date,racd_fecpro),105) AS fproduccion,convert(varchar,convert(date,dr.fechavencimiento),105) AS fvencimiento,  " +
            "DATEDIFF(day,convert(date,GETDATE()),convert(date,dr.fechavencimiento)) AS diasvencidos FROM rackdeta, maeprod , detarece as dr, clientes WHERE racd_codpro=mae_codi " +
            "AND drec_codi=racd_codi AND cli_rut=drec_rutcli AND DATEDIFF(day,convert(date,GETDATE()),convert(date,dr.fechavencimiento))> 0 " +
            "AND DATEDIFF(day,convert(date,GETDATE()), convert(date,dr.fechavencimiento))<30"

        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "SopPorVencer"
            Dim frm As New Frm_MuestraReporte
            Dim rpt As New Rpt_PalletPorVencer
            rpt.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            frm.Contenedor.ReportSource = rpt
            frm.ShowDialog()
        Else
            MsgBox("No existen pallet menor a 30 dias por vencer", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Private Sub StockAcumuladoSegúnSoportanteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_StockAcumuladoS.Click
        Dim frm As New Frm_MuestraReporte
        Dim rpt As New Rpt_StockTipoSoportante
        rpt.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        frm.Contenedor.ReportSource = rpt
        frm.ShowDialog()
    End Sub

    Private Sub STOCKRESUMIDOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New Frm_StockResumidoPar
        frm.ShowDialog()
    End Sub

    Private Sub BLOQToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frm_DesbloqImportacion.ShowDialog()
    End Sub

    Private Sub DesbloquearSoportantesDeImportacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_DesbloquearSoportantes.Click
        If f_procdesbloq = False Then
            Dim frm As Form = Frm_DesbloqImportacion
            TabControl1.TabPages.Add(frm)
            frm.Show()
            f_procdesbloq = True
        Else
            TabControl1.TabPages(Frm_DesbloqImportacion).Select()
        End If
    End Sub

    Private Sub EtiquetadoDeContenedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Etiquetado.Click

        If f_etiquetado = False Then
            Dim frm As Form = Frm_Etiquetado
            TabControl1.TabPages.Add(frm)
            frm.Show()
            f_etiquetado = True
        Else
            TabControl1.TabPages(Frm_Etiquetado).Select()
        End If

    End Sub

    Private Sub DocumentosEmitidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_DocumentosEmitidos.Click
        If f_emitidos = False Then
            Dim frm As Form = Frm_DocumentosEmitidos
            TabControl1.TabPages.Add(frm)
            frm.Show()
            f_emitidos = True
        Else
            TabControl1.TabPages(Frm_DocumentosEmitidos).Select()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Versión " & Application.ProductVersion)
    End Sub

    Private Sub Frm_Principal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            MsgBox(My.Application.Info.Version.ToString)
        End If
    End Sub

    Private Sub PedidosMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_PedidosMensual.Click
        If f_pedidosmensual = False Then
            Dim f As Form = Frm_PedidosMensualClientes
            TabControl1.TabPages.Add(f)
            f.Show()
            f_pedidosmensual = True
        Else
            TabControl1.TabPages(Frm_PedidosMensualClientes).Select()
        End If
    End Sub

    Private Sub UltimaActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frm_Actualizaciones.ShowDialog()
    End Sub

    Private Sub PosicionesSoportantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_PosicionesSoportantes.Click
        If f_posicionsopo = False Then
            Dim f As Form = Frm_PosicionesSopo
            TabControl1.TabPages.Add(f)
            f.Show()
            f_posicionsopo = True
        Else
            TabControl1.TabPages(Frm_PosicionesSopo).Select()
        End If
    End Sub

    Private Sub ListadoDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3_ListadoDePedidos.Click
        If f_pedidos = False Then
            Dim f As Form
            f = Frm_Pedidos
            TabControl1.TabPages.Add(f)
            f_pedidos = True
        Else
            TabControl1.TabPages(Frm_Pedidos).Select()
        End If

    End Sub

    Private Sub IngresoDeCobrosVASADMINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_addvas = False Then
            Dim f As Form = Frm_Vas
            TabControl1.TabPages.Add(f)
            Frm_Vas.tipo_vas = 1
            f.Show()
            f_addvas = True
        Else
            TabControl1.TabPages(Frm_Vas).Select()
        End If
    End Sub

    Private Sub ContenedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Contenedores.Click
        If f_contenedores = False Then
            Dim f As Form = Frm_Contenedores
            TabControl1.TabPages.Add(f)
            f.Show()
            f_contenedores = True
        Else
            TabControl1.TabPages(Frm_Contenedores).Select()
        End If
    End Sub

    Private Sub IngresoRCPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_IngresoRCP.Click
        If f_rcp = False Then
            Dim f As Form = Frm_ModificaSAG
            TabControl1.TabPages.Add(f)
            f.Show()
            f_rcp = True
        Else
            TabControl1.TabPages(Frm_ModificaSAG).Select()
        End If
    End Sub

    Private Sub CapacidadDeCamarasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_CapacidadDeCamaras.Click
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Posiciones en camaras"

        Dim report As New Rpt_Posiciones
        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Private Sub PosicionesLibresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_PosicionesLibres.Click
        If f_poslibres = False Then
            Dim f As Form = Frm_PosicionesLibres
            TabControl1.TabPages.Add(f)
            f.Show()
            f_poslibres = True
        Else
            TabControl1.TabPages(Frm_PosicionesLibres).Select()
        End If
    End Sub

    Private Sub Monedas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Frm_moneda
        f.ShowDialog()
    End Sub


    Private Sub rcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_RevisionCamaras.Click

        If f_revisiones = False Then
            Dim f As Form = Frm_Revisiones
            TabControl1.TabPages.Add(f)
            f.Show()
            f_revisiones = True
        Else
            TabControl1.TabPages(Frm_Revisiones).Select()
        End If
    End Sub

    Private Sub BloqueoDeSoportantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloqueoDeSoportantes.Click
        If f_bloqDesbloq = False Then
            Dim f As Form = Frm_BloqueoPallets
            TabControl1.TabPages.Add(f)
            f.Show()
            f_bloqDesbloq = True
        Else
            TabControl1.TabPages(Frm_BloqueoPallets).Select()
        End If
    End Sub

    Private Sub M3_Cotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_cotizaciones = False Then
            Dim f As Form = Frm_Cotizaciones
            TabControl1.TabPages.Add(f)
            f.Show()
            f_cotizaciones = True
        Else
            TabControl1.TabPages(Frm_Cotizaciones).Select()
        End If
    End Sub

    Private Sub ProcesosSinFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_ProcesosSinFinalizar.Click

        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "ProcesosSinFinalizar"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Procesos sin finalizar"

        Dim report As New Rpt_AnormalFrigo
        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Private Sub InformeCajasRepetidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_recuentoCjRPT = False Then
            Dim f As Frm_RecuentoCajRPT
            f = Frm_RecuentoCajRPT
            TabControl1.TabPages.Add(f)
            f_recuentoCjRPT = True
        Else
            TabControl1.TabPages(Frm_RecuentoCajRPT).Select()
        End If

    End Sub

    Private Sub InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.Click
        If f_MovSopUsu = False Then
            Dim f As Frm_MovimientoSoportanteUsuario
            f = Frm_MovimientoSoportanteUsuario
            TabControl1.TabPages.Add(f)
            f_MovSopUsu = True
        Else
            TabControl1.TabPages(Frm_MovimientoSoportanteUsuario).Select()
        End If
    End Sub

    Private Sub se1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub IinformeCuadraturaMovimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IinformeCuadraturaMovimientosToolStripMenuItem.Click
        If f_Cuadratura = False Then
            Dim f As Frm_cuadraturaFichasDetalles
            f = Frm_cuadraturaFichasDetalles
            TabControl1.TabPages.Add(f)
            f_Cuadratura = True
        Else
            TabControl1.TabPages(Frm_cuadraturaFichasDetalles).Select()
        End If
    End Sub

    Private Sub M2_TrazabilidadGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_TrazabilidadGuia.Click
        If f_TrazGuia = False Then
            Dim f As Frm_TrazabilidadGuia
            f = Frm_TrazabilidadGuia
            TabControl1.TabPages.Add(f)
            f_TrazGuia = True
        Else
            TabControl1.TabPages(Frm_TrazabilidadGuia).Select()
        End If
    End Sub

    Private Sub M2_TrazabilidadProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_TrazabilidadProductos.Click
        If f_TrazProd = False Then
            Dim f As Frm_TrazaProductos
            f = Frm_TrazaProductos
            TabControl1.TabPages.Add(f)
            f_TrazProd = True
        Else
            TabControl1.TabPages(Frm_TrazaProductos).Select()
        End If
    End Sub

    Private Sub InformaAperturaCierreAndenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformaAperturaCierreAndenesToolStripMenuItem.Click
        If f_Andenes = False Then
            Dim f As Frm_Andenes
            f = Frm_Andenes
            TabControl1.TabPages.Add(f)
            f_Andenes = True
        Else
            TabControl1.TabPages(Frm_Andenes).Select()
        End If
    End Sub

    Private Sub InformePackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformePackingListToolStripMenuItem.Click
        If f_plist = False Then
            Dim f As Frm_PackingList
            f = Frm_PackingList
            TabControl1.TabPages.Add(f)
            f_plist = True
        Else
            TabControl1.TabPages(Frm_PackingList).Select()
        End If
    End Sub

    Private Sub IngresoYSalidaTunelesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoYSalidaTunelesToolStripMenuItem.Click
        If f_tuneles = False Then
            Dim f As Frm_ListadoTuneles
            f = Frm_ListadoTuneles
            TabControl1.TabPages.Add(f)
            f_tuneles = True
        Else
            TabControl1.TabPages(Frm_ListadoTuneles).Select()
        End If
    End Sub

    Private Sub CruceInfPedidoRecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_control = False Then
            Dim f As Frm_ControlCamionRec
            f = Frm_ControlCamionRec
            TabControl1.TabPages.Add(f)
            f_control = True
        Else
            TabControl1.TabPages(Frm_ControlCamionRec).Select()
        End If
    End Sub

    Private Sub InfoUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoUsuario.TextChanged
        cargaimg()

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If f_cruce = False Then
            Dim f As Frm_CruceDESREC
            f = Frm_CruceDESREC
            TabControl1.TabPages.Add(f)
            f_tuneles = True
        Else
            TabControl1.TabPages(Frm_CruceDESREC).Select()
        End If
    End Sub

    Private Sub ControlCamionesMovimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlCamionesMovimientosToolStripMenuItem.Click
        If f_control = False Then
            Dim f As Frm_ControlCamionRec
            f = Frm_ControlCamionRec
            TabControl1.TabPages.Add(f)
            f_control = True
        Else
            TabControl1.TabPages(Frm_ControlCamionRec).Select()
        End If
    End Sub

    Private Sub CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTROLHOR.Click
        If f_controlHOR = False Then
            Dim f As Frm_horpedido
            f = Frm_horpedido
            TabControl1.TabPages.Add(f)
            f_controlHOR = True
        Else
            TabControl1.TabPages(Frm_horpedido).Select()
        End If
    End Sub

    Private Sub InformeSoportantesParaIngresoTúnelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeSoportantesParaIngresoTúnelToolStripMenuItem.Click
        If f_PalletTunel = False Then
            Dim f As Frm_PalletTunel
            f = Frm_PalletTunel
            TabControl1.TabPages.Add(f)
            f_PalletTunel = True
        Else
            TabControl1.TabPages(Frm_PalletTunel).Select()
        End If
    End Sub

    Private Sub DemoTomaTempToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If f_demo = False Then
            Dim f As CapturaTEM
            f = CapturaTEM
            TabControl1.TabPages.Add(f)
            f_demo = True
        Else
            TabControl1.TabPages(CapturaTEM).Select()
        End If
    End Sub

    Private Sub ControlServiciosExtraordinariosRecepcionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Click
        If f_servicios = False Then
            Dim f As Frm_ServiciosREC
            f = Frm_ServiciosREC
            TabControl1.TabPages.Add(f)
            f_servicios = True
        Else
            TabControl1.TabPages(Frm_ServiciosREC).Select()
        End If
    End Sub

    Private Sub M2_Mantenedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Mantenedores.Click

    End Sub

    Private Sub TabControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Load

    End Sub

    Private Sub InformePedidosPorUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformePedidosPorUsuarioToolStripMenuItem.Click
        If f_pusu = False Then
            Dim f As FrmPedidosUsuarios
            f = FrmPedidosUsuarios
            TabControl1.TabPages.Add(f)
            f_pusu = True
        Else
            TabControl1.TabPages(FrmPedidosUsuarios).Select()
        End If
    End Sub

    Private Sub EnvioDeEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvioDeEmailToolStripMenuItem.Click
        If f_envioemail = False Then
            Dim f As Frm_AddEnvioEmail

            f = Frm_AddEnvioEmail
            TabControl1.TabPages.Add(f)
            f_envioemail = True
        Else
            TabControl1.TabPages(Frm_AddEnvioEmail).Select()
        End If
    End Sub

    Private Sub InformeToneladasKilosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeToneladasKilosToolStripMenuItem.Click
        If f_tuneleskilos = False Then
            Dim f As Frm_InformeTunel

            f = Frm_InformeTunel
            TabControl1.TabPages.Add(f)
            f_tuneleskilos = True
        Else
            TabControl1.TabPages(Frm_InformeTunel).Select()
        End If
    End Sub

    Private Sub InformeSoportantesEnCamarasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeSoportantesEnCamarasToolStripMenuItem.Click
        If f_sopcam = False Then
            Dim f As Frm_soportantesEnCamara

            f = Frm_soportantesEnCamara
            TabControl1.TabPages.Add(f)
            f_sopcam = True
        Else
            TabControl1.TabPages(Frm_soportantesEnCamara).Select()
        End If
    End Sub

    Private Sub PosicionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosicionesToolStripMenuItem.Click
        If f_manpos = False Then
            Dim f As Frm_AddPosiciones

            f = Frm_AddPosiciones
            TabControl1.TabPages.Add(f)
            f_manpos = True
        Else
            TabControl1.TabPages(Frm_AddPosiciones).Select()
        End If
    End Sub

    Private Sub ProcesoJibiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesoJibiaToolStripMenuItem.Click
        If f_jibia = False Then
            Dim f As Frm_ProcesoBolsa


            f = Frm_ProcesoBolsa
            TabControl1.TabPages.Add(f)
            f_jibia = True
        Else
            TabControl1.TabPages(Frm_ProcesoBolsa).Select()
        End If
    End Sub

    Private Sub InformePalletsMalPosicionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformePalletsMalPosicionadosToolStripMenuItem.Click
        If f_avisopal = False Then
            Dim f As AvisoPalletMalPos


            f = AvisoPalletMalPos
            TabControl1.TabPages.Add(f)
            f_avisopal = True
        Else
            TabControl1.TabPages(AvisoPalletMalPos).Select()
        End If
    End Sub

    Private Sub M2_Medidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Medidas.Click

    End Sub

    Private Sub ReservasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CamarasPlanoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamarasPlanoToolStripMenuItem.Click

    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        If f_confcam = False Then
            Dim f As Frm_ConfInicialCamaras


            f = Frm_ConfInicialCamaras
            TabControl1.TabPages.Add(f)
            f_confcam = True
        Else
            TabControl1.TabPages(Frm_ConfInicialCamaras).Select()
        End If
    End Sub

    Private Sub ManualDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualDeUsuarioToolStripMenuItem.Click
        If f_manual = False Then
            Dim f As ayudaNEW

            f = ayudaNEW
            TabControl1.TabPages.Add(f)
            f_manual = True
        Else
            TabControl1.TabPages(ayudaNEW).Select()
        End If



        '  ayudaNEW.ShowDialog()
    End Sub

    Private Sub ReglasAlmacenamientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReglasAlmacenamientoToolStripMenuItem.Click

    End Sub

    Private Sub TiempoTramosPedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiempoTramosPedidosToolStripMenuItem.Click
        If f_tramos = False Then
            Dim f As Frm_AddPedidosxTramo


            f = Frm_AddPedidosxTramo
            TabControl1.TabPages.Add(f)
            f_tramos = True
        Else
            TabControl1.TabPages(Frm_AddPedidosxTramo).Select()
        End If
    End Sub

    Private Sub PickingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FamiliasNoMezclablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamiliasNoMezclablesToolStripMenuItem.Click
        If f_reglas = False Then
            Dim f As FrmAddReglas


            f = FrmAddReglas
            TabControl1.TabPages.Add(f)
            f_reglas = True
        Else
            TabControl1.TabPages(FrmAddReglas).Select()
        End If
    End Sub

    Private Sub PosicionesParaPickingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosicionesParaPickingToolStripMenuItem.Click
        If f_picking = False Then
            Dim f As Frm_AddPicking


            f = Frm_AddPicking
            TabControl1.TabPages.Add(f)
            f_picking = True
        Else
            TabControl1.TabPages(Frm_AddPicking).Select()
        End If
    End Sub

    Private Sub SugerenciasAlmacenamientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SugerenciasAlmacenamientoToolStripMenuItem.Click
        If f_reserv = False Then
            Dim f As Frm_AddReservas


            f = Frm_AddReservas
            TabControl1.TabPages.Add(f)
            f_avisopal = True
        Else
            TabControl1.TabPages(AvisoPalletMalPos).Select()
        End If
    End Sub

    Private Sub Plano2DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Plano2DToolStripMenuItem.Click
        If f_planocam = False Then
            Dim f As w


            f = w
            TabControl1.TabPages.Add(f)
            f_planocam = True
        Else
            TabControl1.TabPages(w).Select()
        End If
    End Sub

    Private Sub EtiquetaClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetaClientesToolStripMenuItem.Click
        If f_eticli = False Then
            Dim f As Frm_AddFormatoEtiqueta


            f = Frm_AddFormatoEtiqueta
            TabControl1.TabPages.Add(f)
            f_eticli = True
        Else
            TabControl1.TabPages(Frm_AddFormatoEtiqueta).Select()
        End If
    End Sub

    Private Sub ProgramarAuditoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramarAuditoriasToolStripMenuItem.Click
        If f_auditoria = False Then
            Dim f As GeneraAuditoria


            f = GeneraAuditoria
            TabControl1.TabPages.Add(f)
            f_auditoria = True
        Else
            TabControl1.TabPages(GeneraAuditoria).Select()
        End If
    End Sub

    'Private Sub ConfiguracionesGeneralesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConfiguracionesGeneralesToolStripMenuItem.Click
    '    If f_confgene = False Then
    '        Dim f As ConfGENE


    '        f = ConfGENE
    '        TabControl1.TabPages.Add(f)
    '        f_confgene = True
    '    Else
    '        TabControl1.TabPages(ConfGENE).Select()
    '    End If
    'End Sub

    Private Sub InformePosicionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformePosicionesToolStripMenuItem.Click
        If f_possss = False Then
            Dim f As FrmPosicionestotales


            f = FrmPosicionestotales
            TabControl1.TabPages.Add(f)
            f_possss = True
        Else
            TabControl1.TabPages(FrmPosicionestotales).Select()
        End If
    End Sub

    Private Sub menNumDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menNumDia.Click
        If (f_NumDia = False) Then
            Dim f As FRM_NumeralDiario
            f = FRM_NumeralDiario
            TabControl1.TabPages.Add(f)
            f_NumDia = True
        Else
            TabControl1.TabPages(FRM_NumeralDiario).Select()
        End If
    End Sub

    Private Sub ConfiguracionesGenelaresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionesGenelaresToolStripMenuItem.Click
        If f_confgene = False Then
            Dim f As ConfGENE


            f = ConfGENE
            TabControl1.TabPages.Add(f)
            f_confgene = True
        Else
            TabControl1.TabPages(ConfGENE).Select()
        End If
    End Sub

    Private Sub ReservaHorasPedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservaHorasPedidosToolStripMenuItem.Click
        If (f_bloqDias = False) Then
            Dim f As Frm_PedidosBloqueoDias

            f = Frm_PedidosBloqueoDias
            TabControl1.TabPages.Add(f)
            f_bloqDias = True
        Else
            TabControl1.TabPages(Frm_PedidosBloqueoDias).Select()
        End If
    End Sub

    Private Sub ActualizacionesDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionesDelSistemaToolStripMenuItem.Click
        If (f_actWms = False) Then
            Dim f As FRM_ACT_WMS

            f = FRM_ACT_WMS
            TabControl1.TabPages.Add(f)
            f_actWms = True
        Else
            TabControl1.TabPages(FRM_ACT_WMS).Select()
        End If
    End Sub

    Private Sub MenuArchPed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuArchPed.Click
        If (f_pedidos_xls = False) Then
            Dim f As Frm_Pedidos_Xls

            f = Frm_Pedidos_Xls
            TabControl1.TabPages.Add(f)
            f_pedidos_xls = True
        Else
            TabControl1.TabPages(Frm_Pedidos_Xls).Select()
        End If
    End Sub

    Private Sub MenuConfArchPed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConfArchPed.Click
        If (f_conf_pedidos_xls = False) Then
            Dim f As Frm_Conf_Pedidos_Xls

            f = Frm_Conf_Pedidos_Xls
            TabControl1.TabPages.Add(f)
            f_conf_pedidos_xls = True
        Else
            TabControl1.TabPages(Frm_Conf_Pedidos_Xls).Select()
        End If
    End Sub

    Private Sub menuLocPed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLocPed.Click
        If (f_locs_pedidos = False) Then
            Dim f As Frm_Locales_Pedidos

            f = Frm_Locales_Pedidos
            TabControl1.TabPages.Add(f)
            f_locs_pedidos = True
        Else
            TabControl1.TabPages(Frm_Locales_Pedidos).Select()
        End If
    End Sub

    Private Sub M2_PlanRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_PlanRece.Click
        'If F_PlanRece = False Then
        '    Dim f As Form
        '    f = Frm_PlanRece
        '    TabControl1.TabPages.Add(f)
        '    F_PlanRece = True
        'Else
        '    TabControl1.TabPages(Frm_PlanRece).Select()
        'End If
    End Sub

    Private Sub ToolStripMenuItemInfoPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemInfoPos.Click
        If f_possss = False Then
            Dim f As FrmPosicionestotales


            f = FrmPosicionestotales
            TabControl1.TabPages.Add(f)
            f_possss = True
        Else
            TabControl1.TabPages(FrmPosicionestotales).Select()
        End If
    End Sub

    Private Sub menLimPedExp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menLimPedExp.Click
        If f_LimPedExp = False Then
            Dim f As Form
            f = Limite_Pedidos_Exportacion
            TabControl1.TabPages.Add(f)
            f_LimPedExp = True
        Else
            TabControl1.TabPages(Limite_Pedidos_Exportacion).Select()
        End If
    End Sub

    Private Sub MenCtrPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenCtrPallet.Click
        If f_CtrPallet = False Then
            Dim f As Form
            f = Control_Pallets
            TabControl1.TabPages.Add(f)
            f_CtrPallet = True
        Else
            TabControl1.TabPages(Control_Pallets).Select()
        End If
    End Sub

    Private Sub MenCtrPalletArr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenCtrPalletArr.Click
        If f_CtrPalletArr = False Then
            Dim f As Form
            f = Control_Pallets_Arriendo
            TabControl1.TabPages.Add(f)
            f_CtrPalletArr = True
        Else
            TabControl1.TabPages(Control_Pallets_Arriendo).Select()
        End If
    End Sub

    Private Sub MenConfigHrsRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenConfigHrsRece.Click
        If f_ConfigHrsRece = False Then
            Dim f As Form
            f = Recepciones_Programacion_Horarios
            TabControl1.TabPages.Add(f)
            f_ConfigHrsRece = True
        Else
            TabControl1.TabPages(Recepciones_Programacion_Horarios).Select()
        End If
    End Sub

    Private Sub MenConfigBloqHrsRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenConfigBloqHrsRece.Click
        If f_ConfigBloqHrsRece = False Then
            Dim f As Form
            f = Recepciones_Programacion_Bloqueos
            TabControl1.TabPages.Add(f)
            f_ConfigBloqHrsRece = True
        Else
            TabControl1.TabPages(Recepciones_Programacion_Bloqueos).Select()
        End If
    End Sub

    Private Sub MenConfigTipCarRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenConfigTipCarRece.Click
        If f_ConfigBloqCargas = False Then
            Dim f As Form
            f = Recepciones_Programacion_Cargas
            TabControl1.TabPages.Add(f)
            f_ConfigBloqCargas = True
        Else
            TabControl1.TabPages(Recepciones_Programacion_Cargas).Select()
        End If
    End Sub

    Private Sub MenListRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenListRece.Click
        If F_PlanRece = False Then
            Dim f As Form
            'f = Recepcion_Programacion_Listado
            f = Frm_PlanRece
            TabControl1.TabPages.Add(f)
            F_PlanRece = True
        Else
            TabControl1.TabPages(Frm_PlanRece).Select()
        End If
    End Sub

    Private Sub M2_Mercados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2_Mercados.Click
        If f_lstMercados = False Then
            Dim f As Form
            f = Lst_Mercados
            TabControl1.TabPages.Add(f)
            f_lstMercados = True
        Else
            TabControl1.TabPages(Lst_Mercados).Select()
        End If
    End Sub

    Private Sub ProcesoDeTúnelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesoDeTúnelToolStripMenuItem.Click
        If f_confTunel = False Then
            Dim f As Form
            f = Frm_ConfProcesoTunel
            TabControl1.TabPages.Add(f)
            f_confTunel = True
        Else
            TabControl1.TabPages(Frm_ConfProcesoTunel).Select()
        End If
    End Sub

    Private Sub GuiasPorEntrarATunelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuiasPorEntrarATunelToolStripMenuItem.Click
        If f_guiasPendTunel = False Then
            Dim f As Form
            f = Frm_GuiasPendTunel
            TabControl1.TabPages.Add(f)
            f_guiasPendTunel = True
        Else
            TabControl1.TabPages(Frm_GuiasPendTunel).Select()
        End If
    End Sub

    Private Sub EstadoDeTunelesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDeTunelesToolStripMenuItem.Click
        If f_estadoTuneles = False Then
            Dim f As Form
            f = Frm_Tuneles
            TabControl1.TabPages.Add(f)
            f_estadoTuneles = True
        Else
            TabControl1.TabPages(Frm_Tuneles).Select()
        End If
    End Sub

    Private Sub ContenidoDeTunelesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContenidoDeTunelesToolStripMenuItem.Click
        If f_contenidoTuneles = False Then
            Dim f As Form
            f = Frm_ContenidoTuneles
            TabControl1.TabPages.Add(f)
            f_contenidoTuneles = True
        Else
            TabControl1.TabPages(Frm_ContenidoTuneles).Select()
        End If
    End Sub
    
    'Private Sub M2_Orden_Pallets_Click(sender As System.Object, e As System.EventArgs) Handles M2_Orden_Pallets.Click
    '    If (f_OrdPal = False) Then
    '    Else
    '        TabControl1.TabPages(Recepcion_Programacion_Listado).Select()
    '    End If
    'End Sub
    Private Sub MenOrdenPallets_Click(sender As System.Object, e As System.EventArgs) Handles MenOrdenPallets.Click
        If (f_OrdPal = False) Then
            Dim f As Form
            f = Frm_Orden_Pallets
            TabControl1.TabPages.Add(f)
            f_OrdPal = True
        Else
            TabControl1.TabPages(Frm_Orden_Pallets).Select()
        End If
    End Sub

    Private Sub menLimPedExpFecha_Click(sender As System.Object, e As System.EventArgs) Handles menLimPedExpFecha.Click
        If Not TabControl1.TabPages(LimiteFechaExportacionPedidos) Is Nothing Then
            TabControl1.TabPages(LimiteFechaExportacionPedidos).Show()
        ElseIf LimiteFechaExportacionPedidos.Visible = True Then
            TabControl1.TabPages(LimiteFechaExportacionPedidos).Select()
        Else
            TabControl1.TabPages.Add(LimiteFechaExportacionPedidos)
        End If
    End Sub

    Private Sub ChequeoCajasDuplicadasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequeoCajasDuplicadasToolStripMenuItem.Click
        If Not TabControl1.TabPages(ChequeoCajas) Is Nothing Then
            TabControl1.TabPages(ChequeoCajas).Show()
        ElseIf ChequeoCajas.Visible = True Then
            TabControl1.TabPages(ChequeoCajas).Select()
        Else
            TabControl1.TabPages.Add(ChequeoCajas)
        End If
    End Sub

End Class