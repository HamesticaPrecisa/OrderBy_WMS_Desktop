<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Principal))
        Dim ToolStripProfessionalRenderer1 As System.Windows.Forms.ToolStripProfessionalRenderer = New System.Windows.Forms.ToolStripProfessionalRenderer()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MinimizaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccesosDirectos = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.veri_conn = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.VerifConectados = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblseccion = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblnombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InfoUsuario = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New MdiTabControl.TabControl()
        Me.CachedRpt_AcumuladoContrato1 = New PrecisaFrozen.Win.CachedRpt_AcumuladoContrato()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.M1_Inicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_CambiarUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_CambiarContraseña = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Movimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Productos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Recepcion = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Predespacho = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Despacho = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Soportantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenCtrPallet = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenCtrPalletArr = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Posicionamiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Transportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_RegistroDeCamiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_MovimientoCamiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_HistorialCamiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Pedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_ListadoDePedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.TiempoTramosPedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuImpPed = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuArchPed = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConfArchPed = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLocPed = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_PlanRece = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenListRece = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenConfigHrsRece = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenConfigBloqHrsRece = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenConfigTipCarRece = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Mantenedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Clientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Envases = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Camaras = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Choferes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_MSoportantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Familias = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Medidas = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_MProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtiquetaClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Origenes = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvioDeEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosicionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CamarasPlanoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Plano2DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramarAuditoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformePosicionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReglasAlmacenamientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FamiliasNoMezclablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosicionesParaPickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SugerenciasAlmacenamientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menLimPedExp = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Mercados = New System.Windows.Forms.ToolStripMenuItem()
        Me.menLimPedExpFecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Procesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_DesbloquearSoportantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Etiquetado = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Contenedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_IngresoRCP = New System.Windows.Forms.ToolStripMenuItem()
        Me.BloqueoDeSoportantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesoJibiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Facturacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Mantenedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Contratos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Informes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_StockDetallado = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_StockResumido = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_StockAcumulado = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_StockAcumuladoS = New System.Windows.Forms.ToolStripMenuItem()
        Me.IinformeCuadraturaMovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformaAperturaCierreAndenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformeSoportantesEnCamarasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlCamionesMovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformePedidosPorUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformeToneladasKilosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformePalletsMalPosicionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONTROLHOR = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_DocumentosEmitidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_Trazabilidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_TrazabilidadProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_TrazabilidadGuia = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_PedidosMensual = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_PosicionesSoportantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_CapacidadDeCamaras = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_PosicionesLibres = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_ProcesosSinFinalizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_RevisionCamaras = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_SoportantesVencidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_SoportantesPorVencer = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformePackingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_ImpresionDeEtiquetas = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoYSalidaTunelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menNumDia = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuiasPorEntrarATunelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeTunelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContenidoDeTunelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemInfoPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChequeoCajasDuplicadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1_Otros = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2_PerfilesUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Categorias = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_SubCategorias = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3_Usuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarImpresoras = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionesGeneralesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionesGenelaresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReservaHorasPedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizacionesDelSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesoDeTúnelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenOrdenPallets = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualDeUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblconexion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblNombre2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBLSU = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblsucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBLSUCU = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.AccesosDirectos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MinimizaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(212, 26)
        Me.ContextMenuStrip1.Text = "Minimizar Barra de iconos"
        '
        'MinimizaToolStripMenuItem
        '
        Me.MinimizaToolStripMenuItem.Checked = True
        Me.MinimizaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MinimizaToolStripMenuItem.Name = "MinimizaToolStripMenuItem"
        Me.MinimizaToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.MinimizaToolStripMenuItem.Text = "Minimizar Barra de iconos"
        '
        'AccesosDirectos
        '
        Me.AccesosDirectos.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.AccesosDirectos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.AccesosDirectos.Location = New System.Drawing.Point(0, 24)
        Me.AccesosDirectos.Name = "AccesosDirectos"
        Me.AccesosDirectos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.AccesosDirectos.Size = New System.Drawing.Size(928, 39)
        Me.AccesosDirectos.TabIndex = 3
        Me.AccesosDirectos.Text = "Menu"
        Me.AccesosDirectos.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 36)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'veri_conn
        '
        Me.veri_conn.Interval = 1000
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'VerifConectados
        '
        Me.VerifConectados.Interval = 5000
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 509)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblseccion)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblnombre)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.InfoUsuario)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel2.Location = New System.Drawing.Point(48, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 391)
        Me.Panel2.TabIndex = 11
        Me.Panel2.Visible = False
        '
        'lblseccion
        '
        Me.lblseccion.AutoSize = True
        Me.lblseccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblseccion.Location = New System.Drawing.Point(143, 290)
        Me.lblseccion.Name = "lblseccion"
        Me.lblseccion.Size = New System.Drawing.Size(59, 15)
        Me.lblseccion.TabIndex = 6
        Me.lblseccion.Text = "SECLBL"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.usuario_anonimo
        Me.PictureBox1.Location = New System.Drawing.Point(138, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 176)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblnombre
        '
        Me.lblnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombre.Location = New System.Drawing.Point(143, 247)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(296, 19)
        Me.lblnombre.TabIndex = 5
        Me.lblnombre.Text = "USULBL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 248)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USUARIO"
        '
        'InfoUsuario
        '
        Me.InfoUsuario.AutoSize = True
        Me.InfoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoUsuario.Location = New System.Drawing.Point(143, 330)
        Me.InfoUsuario.Name = "InfoUsuario"
        Me.InfoUsuario.Size = New System.Drawing.Size(31, 15)
        Me.InfoUsuario.TabIndex = 4
        Me.InfoUsuario.Text = "001"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 291)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SECCIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 331)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "COD. USUARIO"
        '
        'TabControl1
        '
        Me.TabControl1.AutoScroll = True
        Me.TabControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TabControl1.BackHighColor = System.Drawing.Color.Transparent
        Me.TabControl1.BackLowColor = System.Drawing.Color.Transparent
        Me.TabControl1.BorderColor = System.Drawing.Color.White
        Me.TabControl1.BorderColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.ControlButtonBackHighColor = System.Drawing.Color.Transparent
        Me.TabControl1.ControlButtonBackLowColor = System.Drawing.Color.Transparent
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.KeyTabEnabled = False
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        ToolStripProfessionalRenderer1.RoundedEdges = True
        Me.TabControl1.MenuRenderer = ToolStripProfessionalRenderer1
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Size = New System.Drawing.Size(928, 509)
        Me.TabControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Me.TabControl1.TabBackHighColor = System.Drawing.Color.Transparent
        Me.TabControl1.TabBackHighColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.TabBackLowColor = System.Drawing.Color.Transparent
        Me.TabControl1.TabBackLowColorDisabled = System.Drawing.Color.Transparent
        Me.TabControl1.TabBorderEnhanced = True
        Me.TabControl1.TabCloseButtonImage = Nothing
        Me.TabControl1.TabCloseButtonImageDisabled = Nothing
        Me.TabControl1.TabCloseButtonImageHot = Nothing
        Me.TabControl1.TabGlassGradient = True
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.TabOffset = 1
        Me.TabControl1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.MenuStrip1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1_Inicio, Me.M1_Movimientos, Me.M1_Mantenedores, Me.M1_Procesos, Me.M1_Facturacion, Me.M1_Informes, Me.M1_Otros, Me.ManualDeUsuarioToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(928, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'M1_Inicio
        '
        Me.M1_Inicio.BackColor = System.Drawing.Color.Transparent
        Me.M1_Inicio.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.M1_Inicio.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_Salir, Me.M2_CambiarUsuario, Me.M2_CambiarContraseña})
        Me.M1_Inicio.ForeColor = System.Drawing.Color.Black
        Me.M1_Inicio.Name = "M1_Inicio"
        Me.M1_Inicio.Size = New System.Drawing.Size(48, 20)
        Me.M1_Inicio.Text = "&Inicio"
        '
        'M2_Salir
        '
        Me.M2_Salir.BackColor = System.Drawing.Color.Transparent
        Me.M2_Salir.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Salir.Name = "M2_Salir"
        Me.M2_Salir.Size = New System.Drawing.Size(182, 22)
        Me.M2_Salir.Text = "Salir"
        '
        'M2_CambiarUsuario
        '
        Me.M2_CambiarUsuario.BackColor = System.Drawing.Color.Transparent
        Me.M2_CambiarUsuario.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_CambiarUsuario.Name = "M2_CambiarUsuario"
        Me.M2_CambiarUsuario.Size = New System.Drawing.Size(182, 22)
        Me.M2_CambiarUsuario.Text = "Cambiar Usuario"
        '
        'M2_CambiarContraseña
        '
        Me.M2_CambiarContraseña.BackColor = System.Drawing.Color.Transparent
        Me.M2_CambiarContraseña.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_CambiarContraseña.Name = "M2_CambiarContraseña"
        Me.M2_CambiarContraseña.Size = New System.Drawing.Size(182, 22)
        Me.M2_CambiarContraseña.Text = "Cambiar Contraseña"
        '
        'M1_Movimientos
        '
        Me.M1_Movimientos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M1_Movimientos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_Productos, Me.M2_Soportantes, Me.M2_Transportes, Me.M2_Pedidos, Me.M2_PlanRece})
        Me.M1_Movimientos.Name = "M1_Movimientos"
        Me.M1_Movimientos.Size = New System.Drawing.Size(89, 20)
        Me.M1_Movimientos.Text = "Movimientos"
        '
        'M2_Productos
        '
        Me.M2_Productos.BackColor = System.Drawing.Color.Transparent
        Me.M2_Productos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Productos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3_Recepcion, Me.M3_Predespacho, Me.M3_Despacho})
        Me.M2_Productos.Name = "M2_Productos"
        Me.M2_Productos.Size = New System.Drawing.Size(211, 22)
        Me.M2_Productos.Text = "Productos"
        '
        'M3_Recepcion
        '
        Me.M3_Recepcion.BackColor = System.Drawing.Color.Transparent
        Me.M3_Recepcion.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Recepcion.Enabled = False
        Me.M3_Recepcion.Name = "M3_Recepcion"
        Me.M3_Recepcion.Size = New System.Drawing.Size(147, 22)
        Me.M3_Recepcion.Text = "Recepcion "
        '
        'M3_Predespacho
        '
        Me.M3_Predespacho.BackColor = System.Drawing.Color.Transparent
        Me.M3_Predespacho.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Predespacho.Enabled = False
        Me.M3_Predespacho.Name = "M3_Predespacho"
        Me.M3_Predespacho.Size = New System.Drawing.Size(147, 22)
        Me.M3_Predespacho.Text = "Pre-despacho"
        '
        'M3_Despacho
        '
        Me.M3_Despacho.BackColor = System.Drawing.Color.Transparent
        Me.M3_Despacho.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Despacho.Enabled = False
        Me.M3_Despacho.Name = "M3_Despacho"
        Me.M3_Despacho.Size = New System.Drawing.Size(147, 22)
        Me.M3_Despacho.Text = "Despacho"
        '
        'M2_Soportantes
        '
        Me.M2_Soportantes.BackColor = System.Drawing.Color.Transparent
        Me.M2_Soportantes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Soportantes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenCtrPallet, Me.MenCtrPalletArr, Me.M3_Posicionamiento})
        Me.M2_Soportantes.Name = "M2_Soportantes"
        Me.M2_Soportantes.Size = New System.Drawing.Size(211, 22)
        Me.M2_Soportantes.Text = "Soportantes"
        '
        'MenCtrPallet
        '
        Me.MenCtrPallet.BackColor = System.Drawing.Color.Transparent
        Me.MenCtrPallet.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenCtrPallet.Name = "MenCtrPallet"
        Me.MenCtrPallet.Size = New System.Drawing.Size(206, 22)
        Me.MenCtrPallet.Text = "Custodia"
        '
        'MenCtrPalletArr
        '
        Me.MenCtrPalletArr.BackColor = System.Drawing.Color.Transparent
        Me.MenCtrPalletArr.BackgroundImage = CType(resources.GetObject("MenCtrPalletArr.BackgroundImage"), System.Drawing.Image)
        Me.MenCtrPalletArr.Name = "MenCtrPalletArr"
        Me.MenCtrPalletArr.Size = New System.Drawing.Size(206, 22)
        Me.MenCtrPalletArr.Text = "Arriendo"
        '
        'M3_Posicionamiento
        '
        Me.M3_Posicionamiento.BackColor = System.Drawing.Color.Transparent
        Me.M3_Posicionamiento.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Posicionamiento.Enabled = False
        Me.M3_Posicionamiento.Name = "M3_Posicionamiento"
        Me.M3_Posicionamiento.Size = New System.Drawing.Size(206, 22)
        Me.M3_Posicionamiento.Text = "Posicionamiento manual"
        '
        'M2_Transportes
        '
        Me.M2_Transportes.BackColor = System.Drawing.Color.Transparent
        Me.M2_Transportes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Transportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3_RegistroDeCamiones, Me.M3_MovimientoCamiones, Me.M3_HistorialCamiones})
        Me.M2_Transportes.Name = "M2_Transportes"
        Me.M2_Transportes.Size = New System.Drawing.Size(211, 22)
        Me.M2_Transportes.Text = "Transportes"
        '
        'M3_RegistroDeCamiones
        '
        Me.M3_RegistroDeCamiones.BackColor = System.Drawing.Color.Transparent
        Me.M3_RegistroDeCamiones.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_RegistroDeCamiones.Enabled = False
        Me.M3_RegistroDeCamiones.Name = "M3_RegistroDeCamiones"
        Me.M3_RegistroDeCamiones.Size = New System.Drawing.Size(287, 22)
        Me.M3_RegistroDeCamiones.Text = "Registro de Camiones"
        '
        'M3_MovimientoCamiones
        '
        Me.M3_MovimientoCamiones.BackColor = System.Drawing.Color.Transparent
        Me.M3_MovimientoCamiones.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_MovimientoCamiones.Enabled = False
        Me.M3_MovimientoCamiones.Name = "M3_MovimientoCamiones"
        Me.M3_MovimientoCamiones.Size = New System.Drawing.Size(287, 22)
        Me.M3_MovimientoCamiones.Text = "Movimiento de Camiones"
        '
        'M3_HistorialCamiones
        '
        Me.M3_HistorialCamiones.BackColor = System.Drawing.Color.Transparent
        Me.M3_HistorialCamiones.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_HistorialCamiones.Enabled = False
        Me.M3_HistorialCamiones.Name = "M3_HistorialCamiones"
        Me.M3_HistorialCamiones.Size = New System.Drawing.Size(287, 22)
        Me.M3_HistorialCamiones.Text = "Registro de ingreso y salida de camiones"
        '
        'M2_Pedidos
        '
        Me.M2_Pedidos.BackColor = System.Drawing.Color.Transparent
        Me.M2_Pedidos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Pedidos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3_ListadoDePedidos, Me.TiempoTramosPedidosToolStripMenuItem, Me.MenuImpPed})
        Me.M2_Pedidos.Name = "M2_Pedidos"
        Me.M2_Pedidos.Size = New System.Drawing.Size(211, 22)
        Me.M2_Pedidos.Text = "Pedidos"
        '
        'M3_ListadoDePedidos
        '
        Me.M3_ListadoDePedidos.BackColor = System.Drawing.Color.Transparent
        Me.M3_ListadoDePedidos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_ListadoDePedidos.Enabled = False
        Me.M3_ListadoDePedidos.Name = "M3_ListadoDePedidos"
        Me.M3_ListadoDePedidos.Size = New System.Drawing.Size(234, 22)
        Me.M3_ListadoDePedidos.Text = "Listado de pedidos pendientes"
        '
        'TiempoTramosPedidosToolStripMenuItem
        '
        Me.TiempoTramosPedidosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.TiempoTramosPedidosToolStripMenuItem.Enabled = False
        Me.TiempoTramosPedidosToolStripMenuItem.Name = "TiempoTramosPedidosToolStripMenuItem"
        Me.TiempoTramosPedidosToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.TiempoTramosPedidosToolStripMenuItem.Text = "Tiempo Tramos Pedidos"
        '
        'MenuImpPed
        '
        Me.MenuImpPed.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.MenuImpPed.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuArchPed, Me.MenuConfArchPed, Me.menuLocPed})
        Me.MenuImpPed.Name = "MenuImpPed"
        Me.MenuImpPed.Size = New System.Drawing.Size(234, 22)
        Me.MenuImpPed.Text = "Importar Pedidos"
        '
        'MenuArchPed
        '
        Me.MenuArchPed.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.MenuArchPed.Name = "MenuArchPed"
        Me.MenuArchPed.Size = New System.Drawing.Size(194, 22)
        Me.MenuArchPed.Text = "Archivo Pedido"
        '
        'MenuConfArchPed
        '
        Me.MenuConfArchPed.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.MenuConfArchPed.Name = "MenuConfArchPed"
        Me.MenuConfArchPed.Size = New System.Drawing.Size(194, 22)
        Me.MenuConfArchPed.Text = "Configuracion Archivo"
        '
        'menuLocPed
        '
        Me.menuLocPed.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.menuLocPed.Name = "menuLocPed"
        Me.menuLocPed.Size = New System.Drawing.Size(194, 22)
        Me.menuLocPed.Text = "Locales Clientes"
        '
        'M2_PlanRece
        '
        Me.M2_PlanRece.BackColor = System.Drawing.Color.Transparent
        Me.M2_PlanRece.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_PlanRece.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenListRece, Me.MenConfigHrsRece, Me.MenConfigBloqHrsRece, Me.MenConfigTipCarRece})
        Me.M2_PlanRece.Name = "M2_PlanRece"
        Me.M2_PlanRece.Size = New System.Drawing.Size(211, 22)
        Me.M2_PlanRece.Text = "Planificación Recepciones"
        '
        'MenListRece
        '
        Me.MenListRece.BackColor = System.Drawing.Color.Transparent
        Me.MenListRece.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenListRece.Name = "MenListRece"
        Me.MenListRece.Size = New System.Drawing.Size(268, 22)
        Me.MenListRece.Text = "Listado Recepciones Pendientes"
        '
        'MenConfigHrsRece
        '
        Me.MenConfigHrsRece.BackColor = System.Drawing.Color.Transparent
        Me.MenConfigHrsRece.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenConfigHrsRece.Name = "MenConfigHrsRece"
        Me.MenConfigHrsRece.Size = New System.Drawing.Size(268, 22)
        Me.MenConfigHrsRece.Text = "Configurar Horarios"
        '
        'MenConfigBloqHrsRece
        '
        Me.MenConfigBloqHrsRece.BackColor = System.Drawing.Color.Transparent
        Me.MenConfigBloqHrsRece.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenConfigBloqHrsRece.Name = "MenConfigBloqHrsRece"
        Me.MenConfigBloqHrsRece.Size = New System.Drawing.Size(268, 22)
        Me.MenConfigBloqHrsRece.Text = "Configurar Bloqueos"
        '
        'MenConfigTipCarRece
        '
        Me.MenConfigTipCarRece.BackColor = System.Drawing.Color.Transparent
        Me.MenConfigTipCarRece.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenConfigTipCarRece.Name = "MenConfigTipCarRece"
        Me.MenConfigTipCarRece.Size = New System.Drawing.Size(268, 22)
        Me.MenConfigTipCarRece.Text = "Configurar Capacidad Tipo Descarga"
        '
        'M1_Mantenedores
        '
        Me.M1_Mantenedores.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_Clientes, Me.M2_Envases, Me.M2_Camaras, Me.M2_Choferes, Me.M2_MSoportantes, Me.M2_Familias, Me.M2_Medidas, Me.M2_MProductos, Me.EtiquetaClientesToolStripMenuItem, Me.M2_Origenes, Me.EnvioDeEmailToolStripMenuItem, Me.PosicionesToolStripMenuItem, Me.CamarasPlanoToolStripMenuItem, Me.ReglasAlmacenamientoToolStripMenuItem, Me.menLimPedExp, Me.M2_Mercados, Me.menLimPedExpFecha})
        Me.M1_Mantenedores.Name = "M1_Mantenedores"
        Me.M1_Mantenedores.Size = New System.Drawing.Size(95, 20)
        Me.M1_Mantenedores.Text = "Mantenedores"
        '
        'M2_Clientes
        '
        Me.M2_Clientes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Clientes.Enabled = False
        Me.M2_Clientes.Name = "M2_Clientes"
        Me.M2_Clientes.Size = New System.Drawing.Size(227, 22)
        Me.M2_Clientes.Text = "Clientes"
        '
        'M2_Envases
        '
        Me.M2_Envases.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Envases.Enabled = False
        Me.M2_Envases.Name = "M2_Envases"
        Me.M2_Envases.Size = New System.Drawing.Size(227, 22)
        Me.M2_Envases.Text = "Envases"
        '
        'M2_Camaras
        '
        Me.M2_Camaras.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Camaras.Enabled = False
        Me.M2_Camaras.Name = "M2_Camaras"
        Me.M2_Camaras.Size = New System.Drawing.Size(227, 22)
        Me.M2_Camaras.Text = "Camaras"
        '
        'M2_Choferes
        '
        Me.M2_Choferes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Choferes.Enabled = False
        Me.M2_Choferes.Name = "M2_Choferes"
        Me.M2_Choferes.Size = New System.Drawing.Size(227, 22)
        Me.M2_Choferes.Text = "Choferes"
        '
        'M2_MSoportantes
        '
        Me.M2_MSoportantes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_MSoportantes.Enabled = False
        Me.M2_MSoportantes.Name = "M2_MSoportantes"
        Me.M2_MSoportantes.Size = New System.Drawing.Size(227, 22)
        Me.M2_MSoportantes.Text = "Soportantes"
        '
        'M2_Familias
        '
        Me.M2_Familias.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Familias.Enabled = False
        Me.M2_Familias.Name = "M2_Familias"
        Me.M2_Familias.Size = New System.Drawing.Size(227, 22)
        Me.M2_Familias.Text = "Familias"
        '
        'M2_Medidas
        '
        Me.M2_Medidas.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Medidas.Enabled = False
        Me.M2_Medidas.Name = "M2_Medidas"
        Me.M2_Medidas.Size = New System.Drawing.Size(227, 22)
        Me.M2_Medidas.Text = "Medidas"
        Me.M2_Medidas.Visible = False
        '
        'M2_MProductos
        '
        Me.M2_MProductos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_MProductos.Enabled = False
        Me.M2_MProductos.Name = "M2_MProductos"
        Me.M2_MProductos.Size = New System.Drawing.Size(227, 22)
        Me.M2_MProductos.Text = "Productos"
        '
        'EtiquetaClientesToolStripMenuItem
        '
        Me.EtiquetaClientesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.EtiquetaClientesToolStripMenuItem.Name = "EtiquetaClientesToolStripMenuItem"
        Me.EtiquetaClientesToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.EtiquetaClientesToolStripMenuItem.Text = "Etiqueta Clientes"
        '
        'M2_Origenes
        '
        Me.M2_Origenes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Origenes.Enabled = False
        Me.M2_Origenes.Name = "M2_Origenes"
        Me.M2_Origenes.Size = New System.Drawing.Size(227, 22)
        Me.M2_Origenes.Text = "Origenes"
        '
        'EnvioDeEmailToolStripMenuItem
        '
        Me.EnvioDeEmailToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.EnvioDeEmailToolStripMenuItem.Enabled = False
        Me.EnvioDeEmailToolStripMenuItem.Name = "EnvioDeEmailToolStripMenuItem"
        Me.EnvioDeEmailToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.EnvioDeEmailToolStripMenuItem.Text = "Envio de E-mail"
        '
        'PosicionesToolStripMenuItem
        '
        Me.PosicionesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.PosicionesToolStripMenuItem.Name = "PosicionesToolStripMenuItem"
        Me.PosicionesToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.PosicionesToolStripMenuItem.Text = "Posiciones"
        Me.PosicionesToolStripMenuItem.Visible = False
        '
        'CamarasPlanoToolStripMenuItem
        '
        Me.CamarasPlanoToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.CamarasPlanoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.Plano2DToolStripMenuItem, Me.ProgramarAuditoriasToolStripMenuItem, Me.InformePosicionesToolStripMenuItem})
        Me.CamarasPlanoToolStripMenuItem.Enabled = False
        Me.CamarasPlanoToolStripMenuItem.Name = "CamarasPlanoToolStripMenuItem"
        Me.CamarasPlanoToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CamarasPlanoToolStripMenuItem.Text = "Camaras/Plano"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.ConfiguraciónToolStripMenuItem.Enabled = False
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
        '
        'Plano2DToolStripMenuItem
        '
        Me.Plano2DToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Plano2DToolStripMenuItem.Enabled = False
        Me.Plano2DToolStripMenuItem.Name = "Plano2DToolStripMenuItem"
        Me.Plano2DToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.Plano2DToolStripMenuItem.Text = "Plano 2D"
        '
        'ProgramarAuditoriasToolStripMenuItem
        '
        Me.ProgramarAuditoriasToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.ProgramarAuditoriasToolStripMenuItem.Name = "ProgramarAuditoriasToolStripMenuItem"
        Me.ProgramarAuditoriasToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ProgramarAuditoriasToolStripMenuItem.Text = "Programar Auditorias"
        '
        'InformePosicionesToolStripMenuItem
        '
        Me.InformePosicionesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.InformePosicionesToolStripMenuItem.Enabled = False
        Me.InformePosicionesToolStripMenuItem.Name = "InformePosicionesToolStripMenuItem"
        Me.InformePosicionesToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.InformePosicionesToolStripMenuItem.Text = "Informe Posiciones"
        '
        'ReglasAlmacenamientoToolStripMenuItem
        '
        Me.ReglasAlmacenamientoToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.ReglasAlmacenamientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FamiliasNoMezclablesToolStripMenuItem, Me.PosicionesParaPickingToolStripMenuItem, Me.SugerenciasAlmacenamientoToolStripMenuItem})
        Me.ReglasAlmacenamientoToolStripMenuItem.Name = "ReglasAlmacenamientoToolStripMenuItem"
        Me.ReglasAlmacenamientoToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ReglasAlmacenamientoToolStripMenuItem.Text = "Reglas Almacenamiento"
        '
        'FamiliasNoMezclablesToolStripMenuItem
        '
        Me.FamiliasNoMezclablesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.FamiliasNoMezclablesToolStripMenuItem.Name = "FamiliasNoMezclablesToolStripMenuItem"
        Me.FamiliasNoMezclablesToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.FamiliasNoMezclablesToolStripMenuItem.Text = "Familias No Mezclables"
        '
        'PosicionesParaPickingToolStripMenuItem
        '
        Me.PosicionesParaPickingToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.PosicionesParaPickingToolStripMenuItem.Name = "PosicionesParaPickingToolStripMenuItem"
        Me.PosicionesParaPickingToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.PosicionesParaPickingToolStripMenuItem.Text = "Posiciones Para Picking"
        '
        'SugerenciasAlmacenamientoToolStripMenuItem
        '
        Me.SugerenciasAlmacenamientoToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.SugerenciasAlmacenamientoToolStripMenuItem.Name = "SugerenciasAlmacenamientoToolStripMenuItem"
        Me.SugerenciasAlmacenamientoToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.SugerenciasAlmacenamientoToolStripMenuItem.Text = "Sugerencias Almacenamiento"
        '
        'menLimPedExp
        '
        Me.menLimPedExp.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.menLimPedExp.Name = "menLimPedExp"
        Me.menLimPedExp.Size = New System.Drawing.Size(227, 22)
        Me.menLimPedExp.Text = "Límite Pedidos Exportación"
        '
        'M2_Mercados
        '
        Me.M2_Mercados.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.M2_Mercados.Name = "M2_Mercados"
        Me.M2_Mercados.Size = New System.Drawing.Size(227, 22)
        Me.M2_Mercados.Text = "Mercados"
        '
        'menLimPedExpFecha
        '
        Me.menLimPedExpFecha.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.menLimPedExpFecha.Name = "menLimPedExpFecha"
        Me.menLimPedExpFecha.Size = New System.Drawing.Size(227, 22)
        Me.menLimPedExpFecha.Text = "Limite Exportacion por Fecha"
        '
        'M1_Procesos
        '
        Me.M1_Procesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_DesbloquearSoportantes, Me.M2_Etiquetado, Me.M2_Contenedores, Me.M2_IngresoRCP, Me.BloqueoDeSoportantes, Me.ProcesoJibiaToolStripMenuItem})
        Me.M1_Procesos.Name = "M1_Procesos"
        Me.M1_Procesos.Size = New System.Drawing.Size(66, 20)
        Me.M1_Procesos.Text = "Procesos"
        '
        'M2_DesbloquearSoportantes
        '
        Me.M2_DesbloquearSoportantes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_DesbloquearSoportantes.Enabled = False
        Me.M2_DesbloquearSoportantes.Name = "M2_DesbloquearSoportantes"
        Me.M2_DesbloquearSoportantes.Size = New System.Drawing.Size(216, 22)
        Me.M2_DesbloquearSoportantes.Text = "Desbloqueo importaciones"
        '
        'M2_Etiquetado
        '
        Me.M2_Etiquetado.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Etiquetado.Enabled = False
        Me.M2_Etiquetado.Name = "M2_Etiquetado"
        Me.M2_Etiquetado.Size = New System.Drawing.Size(216, 22)
        Me.M2_Etiquetado.Text = "Etiquetado de soportantes"
        '
        'M2_Contenedores
        '
        Me.M2_Contenedores.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Contenedores.Enabled = False
        Me.M2_Contenedores.Name = "M2_Contenedores"
        Me.M2_Contenedores.Size = New System.Drawing.Size(216, 22)
        Me.M2_Contenedores.Text = "Estado de Contenedores"
        '
        'M2_IngresoRCP
        '
        Me.M2_IngresoRCP.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_IngresoRCP.Enabled = False
        Me.M2_IngresoRCP.Name = "M2_IngresoRCP"
        Me.M2_IngresoRCP.Size = New System.Drawing.Size(216, 22)
        Me.M2_IngresoRCP.Text = "Mantencion de RCP"
        '
        'BloqueoDeSoportantes
        '
        Me.BloqueoDeSoportantes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.BloqueoDeSoportantes.Enabled = False
        Me.BloqueoDeSoportantes.Name = "BloqueoDeSoportantes"
        Me.BloqueoDeSoportantes.Size = New System.Drawing.Size(216, 22)
        Me.BloqueoDeSoportantes.Text = "Bloqueo de soportantes"
        '
        'ProcesoJibiaToolStripMenuItem
        '
        Me.ProcesoJibiaToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ProcesoJibiaToolStripMenuItem.Name = "ProcesoJibiaToolStripMenuItem"
        Me.ProcesoJibiaToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ProcesoJibiaToolStripMenuItem.Text = "Proceso Jibia"
        Me.ProcesoJibiaToolStripMenuItem.Visible = False
        '
        'M1_Facturacion
        '
        Me.M1_Facturacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_Mantenedores})
        Me.M1_Facturacion.Name = "M1_Facturacion"
        Me.M1_Facturacion.Size = New System.Drawing.Size(81, 20)
        Me.M1_Facturacion.Text = "Facturacion"
        '
        'M2_Mantenedores
        '
        Me.M2_Mantenedores.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Mantenedores.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3_Contratos})
        Me.M2_Mantenedores.Name = "M2_Mantenedores"
        Me.M2_Mantenedores.Size = New System.Drawing.Size(150, 22)
        Me.M2_Mantenedores.Text = "Mantenedores"
        '
        'M3_Contratos
        '
        Me.M3_Contratos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Contratos.Enabled = False
        Me.M3_Contratos.Name = "M3_Contratos"
        Me.M3_Contratos.Size = New System.Drawing.Size(126, 22)
        Me.M3_Contratos.Text = "Contratos"
        '
        'M1_Informes
        '
        Me.M1_Informes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_StockDetallado, Me.M2_StockResumido, Me.M2_StockAcumulado, Me.M2_StockAcumuladoS, Me.IinformeCuadraturaMovimientosToolStripMenuItem, Me.InformaAperturaCierreAndenesToolStripMenuItem, Me.InformeSoportantesEnCamarasToolStripMenuItem, Me.ControlCamionesMovimientosToolStripMenuItem, Me.InformePedidosPorUsuarioToolStripMenuItem, Me.InformeToneladasKilosToolStripMenuItem, Me.InformePalletsMalPosicionadosToolStripMenuItem, Me.CONTROLHOR, Me.ToolStripMenuItem1, Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem, Me.M2_DocumentosEmitidos, Me.M2_Trazabilidad, Me.M2_TrazabilidadProductos, Me.M2_TrazabilidadGuia, Me.M2_PedidosMensual, Me.M2_PosicionesSoportantes, Me.M2_CapacidadDeCamaras, Me.M2_PosicionesLibres, Me.M2_ProcesosSinFinalizar, Me.M2_RevisionCamaras, Me.M2_SoportantesVencidos, Me.M2_SoportantesPorVencer, Me.InformePackingListToolStripMenuItem, Me.M2_ImpresionDeEtiquetas, Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem, Me.IngresoYSalidaTunelesToolStripMenuItem, Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem, Me.menNumDia, Me.GuiasPorEntrarATunelToolStripMenuItem, Me.EstadoDeTunelesToolStripMenuItem, Me.ContenidoDeTunelesToolStripMenuItem, Me.ToolStripMenuItemInfoPos, Me.ChequeoCajasDuplicadasToolStripMenuItem})
        Me.M1_Informes.Name = "M1_Informes"
        Me.M1_Informes.Size = New System.Drawing.Size(66, 20)
        Me.M1_Informes.Text = "Informes"
        '
        'M2_StockDetallado
        '
        Me.M2_StockDetallado.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_StockDetallado.Enabled = False
        Me.M2_StockDetallado.Name = "M2_StockDetallado"
        Me.M2_StockDetallado.Size = New System.Drawing.Size(330, 22)
        Me.M2_StockDetallado.Text = "&Stock detallado"
        '
        'M2_StockResumido
        '
        Me.M2_StockResumido.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_StockResumido.Enabled = False
        Me.M2_StockResumido.Name = "M2_StockResumido"
        Me.M2_StockResumido.Size = New System.Drawing.Size(330, 22)
        Me.M2_StockResumido.Text = "&Stock resumido"
        '
        'M2_StockAcumulado
        '
        Me.M2_StockAcumulado.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_StockAcumulado.Enabled = False
        Me.M2_StockAcumulado.Name = "M2_StockAcumulado"
        Me.M2_StockAcumulado.Size = New System.Drawing.Size(330, 22)
        Me.M2_StockAcumulado.Text = "&Stock acumulado"
        '
        'M2_StockAcumuladoS
        '
        Me.M2_StockAcumuladoS.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_StockAcumuladoS.Enabled = False
        Me.M2_StockAcumuladoS.Name = "M2_StockAcumuladoS"
        Me.M2_StockAcumuladoS.Size = New System.Drawing.Size(330, 22)
        Me.M2_StockAcumuladoS.Text = "Stock acumulado según soportante"
        Me.M2_StockAcumuladoS.Visible = False
        '
        'IinformeCuadraturaMovimientosToolStripMenuItem
        '
        Me.IinformeCuadraturaMovimientosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.IinformeCuadraturaMovimientosToolStripMenuItem.Name = "IinformeCuadraturaMovimientosToolStripMenuItem"
        Me.IinformeCuadraturaMovimientosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.IinformeCuadraturaMovimientosToolStripMenuItem.Text = "Iinforme Cuadratura Movimientos "
        Me.IinformeCuadraturaMovimientosToolStripMenuItem.Visible = False
        '
        'InformaAperturaCierreAndenesToolStripMenuItem
        '
        Me.InformaAperturaCierreAndenesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformaAperturaCierreAndenesToolStripMenuItem.Name = "InformaAperturaCierreAndenesToolStripMenuItem"
        Me.InformaAperturaCierreAndenesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformaAperturaCierreAndenesToolStripMenuItem.Text = "Informe Apertura Cierre Andenes"
        '
        'InformeSoportantesEnCamarasToolStripMenuItem
        '
        Me.InformeSoportantesEnCamarasToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformeSoportantesEnCamarasToolStripMenuItem.Name = "InformeSoportantesEnCamarasToolStripMenuItem"
        Me.InformeSoportantesEnCamarasToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformeSoportantesEnCamarasToolStripMenuItem.Text = "Informe Soportantes En Camaras Por Clientes"
        '
        'ControlCamionesMovimientosToolStripMenuItem
        '
        Me.ControlCamionesMovimientosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ControlCamionesMovimientosToolStripMenuItem.Name = "ControlCamionesMovimientosToolStripMenuItem"
        Me.ControlCamionesMovimientosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.ControlCamionesMovimientosToolStripMenuItem.Text = "Control Camiones/Movimientos "
        '
        'InformePedidosPorUsuarioToolStripMenuItem
        '
        Me.InformePedidosPorUsuarioToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformePedidosPorUsuarioToolStripMenuItem.Name = "InformePedidosPorUsuarioToolStripMenuItem"
        Me.InformePedidosPorUsuarioToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformePedidosPorUsuarioToolStripMenuItem.Text = "Informe Pedidos Por Usuario"
        '
        'InformeToneladasKilosToolStripMenuItem
        '
        Me.InformeToneladasKilosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformeToneladasKilosToolStripMenuItem.Name = "InformeToneladasKilosToolStripMenuItem"
        Me.InformeToneladasKilosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformeToneladasKilosToolStripMenuItem.Text = "Informe Toneladas/Tuneles"
        '
        'InformePalletsMalPosicionadosToolStripMenuItem
        '
        Me.InformePalletsMalPosicionadosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformePalletsMalPosicionadosToolStripMenuItem.Name = "InformePalletsMalPosicionadosToolStripMenuItem"
        Me.InformePalletsMalPosicionadosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformePalletsMalPosicionadosToolStripMenuItem.Text = "Informe Pallets Mal Posicionados"
        '
        'CONTROLHOR
        '
        Me.CONTROLHOR.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.CONTROLHOR.Name = "CONTROLHOR"
        Me.CONTROLHOR.Size = New System.Drawing.Size(330, 22)
        Me.CONTROLHOR.Text = "Control Pedidos/Horas"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(330, 22)
        Me.ToolStripMenuItem1.Text = "Cruce Inf. Pedido/Rec"
        Me.ToolStripMenuItem1.Visible = False
        '
        'ControlServiciosExtraordinariosRecepcionToolStripMenuItem
        '
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Name = "ControlServiciosExtraordinariosRecepcionToolStripMenuItem"
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Text = "Control Servicios Extraordinarios "
        Me.ControlServiciosExtraordinariosRecepcionToolStripMenuItem.Visible = False
        '
        'M2_DocumentosEmitidos
        '
        Me.M2_DocumentosEmitidos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_DocumentosEmitidos.Enabled = False
        Me.M2_DocumentosEmitidos.Name = "M2_DocumentosEmitidos"
        Me.M2_DocumentosEmitidos.Size = New System.Drawing.Size(330, 22)
        Me.M2_DocumentosEmitidos.Text = "Documentos emitidos"
        '
        'M2_Trazabilidad
        '
        Me.M2_Trazabilidad.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_Trazabilidad.Enabled = False
        Me.M2_Trazabilidad.Name = "M2_Trazabilidad"
        Me.M2_Trazabilidad.Size = New System.Drawing.Size(330, 22)
        Me.M2_Trazabilidad.Text = "Trazabilidad de soportantes y envases"
        '
        'M2_TrazabilidadProductos
        '
        Me.M2_TrazabilidadProductos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_TrazabilidadProductos.Enabled = False
        Me.M2_TrazabilidadProductos.Name = "M2_TrazabilidadProductos"
        Me.M2_TrazabilidadProductos.Size = New System.Drawing.Size(330, 22)
        Me.M2_TrazabilidadProductos.Text = "Trazabilidad de Productos"
        '
        'M2_TrazabilidadGuia
        '
        Me.M2_TrazabilidadGuia.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_TrazabilidadGuia.Name = "M2_TrazabilidadGuia"
        Me.M2_TrazabilidadGuia.Size = New System.Drawing.Size(330, 22)
        Me.M2_TrazabilidadGuia.Text = "Trazabilidad de Guias"
        '
        'M2_PedidosMensual
        '
        Me.M2_PedidosMensual.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_PedidosMensual.Enabled = False
        Me.M2_PedidosMensual.Name = "M2_PedidosMensual"
        Me.M2_PedidosMensual.Size = New System.Drawing.Size(330, 22)
        Me.M2_PedidosMensual.Text = "Pedidos mensual"
        Me.M2_PedidosMensual.Visible = False
        '
        'M2_PosicionesSoportantes
        '
        Me.M2_PosicionesSoportantes.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_PosicionesSoportantes.Enabled = False
        Me.M2_PosicionesSoportantes.Name = "M2_PosicionesSoportantes"
        Me.M2_PosicionesSoportantes.Size = New System.Drawing.Size(330, 22)
        Me.M2_PosicionesSoportantes.Text = "Posiciones soportantes"
        '
        'M2_CapacidadDeCamaras
        '
        Me.M2_CapacidadDeCamaras.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_CapacidadDeCamaras.Enabled = False
        Me.M2_CapacidadDeCamaras.Name = "M2_CapacidadDeCamaras"
        Me.M2_CapacidadDeCamaras.Size = New System.Drawing.Size(330, 22)
        Me.M2_CapacidadDeCamaras.Text = "Posiciones en camaras"
        Me.M2_CapacidadDeCamaras.Visible = False
        '
        'M2_PosicionesLibres
        '
        Me.M2_PosicionesLibres.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_PosicionesLibres.Enabled = False
        Me.M2_PosicionesLibres.Name = "M2_PosicionesLibres"
        Me.M2_PosicionesLibres.Size = New System.Drawing.Size(330, 22)
        Me.M2_PosicionesLibres.Text = "Posiciones Libres"
        '
        'M2_ProcesosSinFinalizar
        '
        Me.M2_ProcesosSinFinalizar.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_ProcesosSinFinalizar.Enabled = False
        Me.M2_ProcesosSinFinalizar.Name = "M2_ProcesosSinFinalizar"
        Me.M2_ProcesosSinFinalizar.Size = New System.Drawing.Size(330, 22)
        Me.M2_ProcesosSinFinalizar.Text = "Procesos sin finalizar"
        '
        'M2_RevisionCamaras
        '
        Me.M2_RevisionCamaras.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_RevisionCamaras.Enabled = False
        Me.M2_RevisionCamaras.Name = "M2_RevisionCamaras"
        Me.M2_RevisionCamaras.Size = New System.Drawing.Size(330, 22)
        Me.M2_RevisionCamaras.Text = "Revisión control camaras"
        '
        'M2_SoportantesVencidos
        '
        Me.M2_SoportantesVencidos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_SoportantesVencidos.Enabled = False
        Me.M2_SoportantesVencidos.Name = "M2_SoportantesVencidos"
        Me.M2_SoportantesVencidos.Size = New System.Drawing.Size(330, 22)
        Me.M2_SoportantesVencidos.Text = "&Soportantes vencidos"
        '
        'M2_SoportantesPorVencer
        '
        Me.M2_SoportantesPorVencer.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_SoportantesPorVencer.Enabled = False
        Me.M2_SoportantesPorVencer.Name = "M2_SoportantesPorVencer"
        Me.M2_SoportantesPorVencer.Size = New System.Drawing.Size(330, 22)
        Me.M2_SoportantesPorVencer.Text = "&Soportantes por vencer menor a 30 dias"
        '
        'InformePackingListToolStripMenuItem
        '
        Me.InformePackingListToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformePackingListToolStripMenuItem.Name = "InformePackingListToolStripMenuItem"
        Me.InformePackingListToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformePackingListToolStripMenuItem.Text = "Informe Packing List"
        Me.InformePackingListToolStripMenuItem.Visible = False
        '
        'M2_ImpresionDeEtiquetas
        '
        Me.M2_ImpresionDeEtiquetas.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_ImpresionDeEtiquetas.Enabled = False
        Me.M2_ImpresionDeEtiquetas.Name = "M2_ImpresionDeEtiquetas"
        Me.M2_ImpresionDeEtiquetas.Size = New System.Drawing.Size(330, 22)
        Me.M2_ImpresionDeEtiquetas.Text = "&Impresion de etiquetas rack"
        '
        'InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem
        '
        Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.Name = "InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem"
        Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem.Text = "Informe Movimiento de Soportantes Por Usuario"
        '
        'IngresoYSalidaTunelesToolStripMenuItem
        '
        Me.IngresoYSalidaTunelesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.IngresoYSalidaTunelesToolStripMenuItem.Name = "IngresoYSalidaTunelesToolStripMenuItem"
        Me.IngresoYSalidaTunelesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.IngresoYSalidaTunelesToolStripMenuItem.Text = "Ingreso y Salida Tuneles"
        '
        'InformeSoportantesParaIngresoTúnelToolStripMenuItem
        '
        Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem.Name = "InformeSoportantesParaIngresoTúnelToolStripMenuItem"
        Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.InformeSoportantesParaIngresoTúnelToolStripMenuItem.Text = "Informe Soportantes Para Ingreso Túnel"
        '
        'menNumDia
        '
        Me.menNumDia.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.menNumDia.Name = "menNumDia"
        Me.menNumDia.Size = New System.Drawing.Size(330, 22)
        Me.menNumDia.Text = "Numeral Diario"
        Me.menNumDia.Visible = False
        '
        'GuiasPorEntrarATunelToolStripMenuItem
        '
        Me.GuiasPorEntrarATunelToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.GuiasPorEntrarATunelToolStripMenuItem.Name = "GuiasPorEntrarATunelToolStripMenuItem"
        Me.GuiasPorEntrarATunelToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.GuiasPorEntrarATunelToolStripMenuItem.Text = "Guias por entrar a tunel"
        '
        'EstadoDeTunelesToolStripMenuItem
        '
        Me.EstadoDeTunelesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.EstadoDeTunelesToolStripMenuItem.Name = "EstadoDeTunelesToolStripMenuItem"
        Me.EstadoDeTunelesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.EstadoDeTunelesToolStripMenuItem.Text = "Estado de tuneles"
        '
        'ContenidoDeTunelesToolStripMenuItem
        '
        Me.ContenidoDeTunelesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ContenidoDeTunelesToolStripMenuItem.Name = "ContenidoDeTunelesToolStripMenuItem"
        Me.ContenidoDeTunelesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.ContenidoDeTunelesToolStripMenuItem.Text = "Contenido de tuneles"
        '
        'ToolStripMenuItemInfoPos
        '
        Me.ToolStripMenuItemInfoPos.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.ToolStripMenuItemInfoPos.Enabled = False
        Me.ToolStripMenuItemInfoPos.Name = "ToolStripMenuItemInfoPos"
        Me.ToolStripMenuItemInfoPos.Size = New System.Drawing.Size(330, 22)
        Me.ToolStripMenuItemInfoPos.Text = "Informe Posiciones"
        '
        'ChequeoCajasDuplicadasToolStripMenuItem
        '
        Me.ChequeoCajasDuplicadasToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.ChequeoCajasDuplicadasToolStripMenuItem.Name = "ChequeoCajasDuplicadasToolStripMenuItem"
        Me.ChequeoCajasDuplicadasToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.ChequeoCajasDuplicadasToolStripMenuItem.Text = "Chequeo Cajas Duplicadas"
        '
        'M1_Otros
        '
        Me.M1_Otros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2_PerfilesUsuario, Me.SeleccionarImpresoras, Me.ConfiguracionesGeneralesToolStripMenuItem, Me.MenOrdenPallets})
        Me.M1_Otros.Name = "M1_Otros"
        Me.M1_Otros.Size = New System.Drawing.Size(48, 20)
        Me.M1_Otros.Text = "Otros"
        '
        'M2_PerfilesUsuario
        '
        Me.M2_PerfilesUsuario.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M2_PerfilesUsuario.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3_Categorias, Me.M3_SubCategorias, Me.M3_Usuarios})
        Me.M2_PerfilesUsuario.Name = "M2_PerfilesUsuario"
        Me.M2_PerfilesUsuario.Size = New System.Drawing.Size(198, 22)
        Me.M2_PerfilesUsuario.Text = "Perfiles de usuario"
        '
        'M3_Categorias
        '
        Me.M3_Categorias.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Categorias.Enabled = False
        Me.M3_Categorias.Name = "M3_Categorias"
        Me.M3_Categorias.Size = New System.Drawing.Size(221, 22)
        Me.M3_Categorias.Text = "Mantenedor Categorias"
        '
        'M3_SubCategorias
        '
        Me.M3_SubCategorias.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_SubCategorias.Enabled = False
        Me.M3_SubCategorias.Name = "M3_SubCategorias"
        Me.M3_SubCategorias.Size = New System.Drawing.Size(221, 22)
        Me.M3_SubCategorias.Text = "Mantenedor Sub Categorias"
        '
        'M3_Usuarios
        '
        Me.M3_Usuarios.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.M3_Usuarios.Name = "M3_Usuarios"
        Me.M3_Usuarios.Size = New System.Drawing.Size(221, 22)
        Me.M3_Usuarios.Text = "Mantenedor de Usuarios"
        '
        'SeleccionarImpresoras
        '
        Me.SeleccionarImpresoras.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.SeleccionarImpresoras.Name = "SeleccionarImpresoras"
        Me.SeleccionarImpresoras.Size = New System.Drawing.Size(198, 22)
        Me.SeleccionarImpresoras.Text = "Seleccionar Impresoras "
        '
        'ConfiguracionesGeneralesToolStripMenuItem
        '
        Me.ConfiguracionesGeneralesToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ConfiguracionesGeneralesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionesGenelaresToolStripMenuItem, Me.ReservaHorasPedidosToolStripMenuItem, Me.ActualizacionesDelSistemaToolStripMenuItem, Me.ProcesoDeTúnelToolStripMenuItem})
        Me.ConfiguracionesGeneralesToolStripMenuItem.Name = "ConfiguracionesGeneralesToolStripMenuItem"
        Me.ConfiguracionesGeneralesToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConfiguracionesGeneralesToolStripMenuItem.Text = "Configuraciones"
        '
        'ConfiguracionesGenelaresToolStripMenuItem
        '
        Me.ConfiguracionesGenelaresToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ConfiguracionesGenelaresToolStripMenuItem.Name = "ConfiguracionesGenelaresToolStripMenuItem"
        Me.ConfiguracionesGenelaresToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ConfiguracionesGenelaresToolStripMenuItem.Text = "Configuraciones Genelares"
        '
        'ReservaHorasPedidosToolStripMenuItem
        '
        Me.ReservaHorasPedidosToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ReservaHorasPedidosToolStripMenuItem.Name = "ReservaHorasPedidosToolStripMenuItem"
        Me.ReservaHorasPedidosToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ReservaHorasPedidosToolStripMenuItem.Text = "Reserva Horas Pedidos"
        '
        'ActualizacionesDelSistemaToolStripMenuItem
        '
        Me.ActualizacionesDelSistemaToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ActualizacionesDelSistemaToolStripMenuItem.Name = "ActualizacionesDelSistemaToolStripMenuItem"
        Me.ActualizacionesDelSistemaToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ActualizacionesDelSistemaToolStripMenuItem.Text = "Actualizaciones del Sistema"
        '
        'ProcesoDeTúnelToolStripMenuItem
        '
        Me.ProcesoDeTúnelToolStripMenuItem.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.ProcesoDeTúnelToolStripMenuItem.Name = "ProcesoDeTúnelToolStripMenuItem"
        Me.ProcesoDeTúnelToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ProcesoDeTúnelToolStripMenuItem.Text = "Proceso de túnel"
        '
        'MenOrdenPallets
        '
        Me.MenOrdenPallets.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.cuadrado
        Me.MenOrdenPallets.Name = "MenOrdenPallets"
        Me.MenOrdenPallets.Size = New System.Drawing.Size(198, 22)
        Me.MenOrdenPallets.Text = "Config. Orden Pallets"
        '
        'ManualDeUsuarioToolStripMenuItem
        '
        Me.ManualDeUsuarioToolStripMenuItem.Name = "ManualDeUsuarioToolStripMenuItem"
        Me.ManualDeUsuarioToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
        Me.ManualDeUsuarioToolStripMenuItem.Text = "Manual De Usuario"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblconexion, Me.LblNombre2, Me.ToolStripStatusLabel2, Me.LBLSU, Me.lblsucursal, Me.LBLSUCU})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(928, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'lblconexion
        '
        Me.lblconexion.BackColor = System.Drawing.Color.Transparent
        Me.lblconexion.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblconexion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconexion.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.conn_ok
        Me.lblconexion.Name = "lblconexion"
        Me.lblconexion.Size = New System.Drawing.Size(113, 17)
        Me.lblconexion.Text = "CONECTADO"
        '
        'LblNombre2
        '
        Me.LblNombre2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre2.Name = "LblNombre2"
        Me.LblNombre2.Size = New System.Drawing.Size(67, 17)
        Me.LblNombre2.Text = "                    "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(22, 17)
        Me.ToolStripStatusLabel2.Text = "     "
        '
        'LBLSU
        '
        Me.LBLSU.BackColor = System.Drawing.Color.Transparent
        Me.LBLSU.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LBLSU.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSU.Name = "LBLSU"
        Me.LBLSU.Size = New System.Drawing.Size(0, 17)
        '
        'lblsucursal
        '
        Me.lblsucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsucursal.Name = "lblsucursal"
        Me.lblsucursal.Size = New System.Drawing.Size(67, 17)
        Me.lblsucursal.Text = "                    "
        '
        'LBLSUCU
        '
        Me.LBLSUCU.Name = "LBLSUCU"
        Me.LBLSUCU.Size = New System.Drawing.Size(0, 17)
        '
        'Frm_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(928, 555)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.AccesosDirectos)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(944, 593)
        Me.Name = "Frm_Principal"
        Me.ShowIcon = False
        Me.Text = "Order By WMS - Pecisa Tech 28.02.20.11.40 - BD: Precisa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.AccesosDirectos.ResumeLayout(False)
        Me.AccesosDirectos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents M1_Inicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1_Movimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MinimizaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents AccesosDirectos As System.Windows.Forms.ToolStrip
    Friend WithEvents M1_Mantenedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Clientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Envases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Camaras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Choferes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_MSoportantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Familias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Medidas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_MProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Origenes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents M1_Informes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_StockDetallado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_StockResumido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_StockAcumulado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblconexion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents veri_conn As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents M2_Salir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1_Otros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Trazabilidad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_CambiarUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblseccion As System.Windows.Forms.Label
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents InfoUsuario As System.Windows.Forms.Label
    Friend WithEvents M2_ImpresionDeEtiquetas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Productos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Soportantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Recepcion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Predespacho As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Despacho As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_PerfilesUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Categorias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_SubCategorias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Usuarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1_Facturacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Mantenedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Contratos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Transportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_MovimientoCamiones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_RegistroDeCamiones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As MdiTabControl.TabControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SeleccionarImpresoras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_HistorialCamiones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_CambiarContraseña As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_Posicionamiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_SoportantesVencidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_SoportantesPorVencer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_StockAcumuladoS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1_Procesos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_DesbloquearSoportantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Etiquetado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_DocumentosEmitidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_PedidosMensual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblNombre2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents M2_PosicionesSoportantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents M2_Pedidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3_ListadoDePedidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerifConectados As System.Windows.Forms.Timer
    Friend WithEvents M2_Contenedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_IngresoRCP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_CapacidadDeCamaras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_PosicionesLibres As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_RevisionCamaras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BloqueoDeSoportantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_ProcesosSinFinalizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeMovimientoDeSoportantesPorUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IinformeCuadraturaMovimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_TrazabilidadGuia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformaAperturaCierreAndenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformePackingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoYSalidaTunelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlCamionesMovimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONTROLHOR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeSoportantesParaIngresoTúnelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlServiciosExtraordinariosRecepcionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformePedidosPorUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnvioDeEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeToneladasKilosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeSoportantesEnCamarasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PosicionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesoJibiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformePalletsMalPosicionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CachedRpt_AcumuladoContrato1 As PrecisaFrozen.Win.CachedRpt_AcumuladoContrato
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CamarasPlanoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsucursal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBLSU As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBLSUCU As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ManualDeUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReglasAlmacenamientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TiempoTramosPedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FamiliasNoMezclablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PosicionesParaPickingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SugerenciasAlmacenamientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Plano2DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EtiquetaClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramarAuditoriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionesGeneralesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformePosicionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menNumDia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionesGenelaresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReservaHorasPedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizacionesDelSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuImpPed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuArchPed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConfArchPed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLocPed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_TrazabilidadProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_PlanRece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemInfoPos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menLimPedExp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenCtrPallet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenCtrPalletArr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenConfigHrsRece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenListRece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenConfigBloqHrsRece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenConfigTipCarRece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2_Mercados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesoDeTúnelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuiasPorEntrarATunelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadoDeTunelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContenidoDeTunelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenOrdenPallets As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menLimPedExpFecha As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChequeoCajasDuplicadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
