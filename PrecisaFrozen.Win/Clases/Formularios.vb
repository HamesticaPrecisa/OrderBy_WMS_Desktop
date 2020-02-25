Module Formularios


    'listado de formularios
    Public f_addclientes As Boolean = False
    Public f_addenvases As Boolean = False
    Public f_addcamaras As Boolean = False
    Public f_addchoferes As Boolean = False
    Public f_addfamilias As Boolean = False
    Public f_addproductos As Boolean = False
    Public f_addsoportantes As Boolean = False
    Public f_addrecepcion As Boolean = False
    Public f_addPredespacho As Boolean = False
    Public f_addDespacho As Boolean = False
    Public f_posicionamientomanual As Boolean = False
    Public f_productos As Boolean = False
    Public f_addcontrato As Boolean = False
    Public f_recuentoCjRPT As Boolean = False
    Public clientesbusc As String = ""
    Public F_PlanRece As Boolean = False

    Public f_addmercados As Boolean = False ' VES Sep 2019

    'listado de datas
    Public f_lstClientes As Boolean = False
    Public f_lstSoportantes As Boolean = False
    Public f_lstCamaras As Boolean = False
    Public f_lstFamilias As Boolean = False
    Public f_lstChoferes As Boolean = False
    Public f_LstEnvases As Boolean = False
    Public f_LstMedidas As Boolean = False
    Public f_LstOrigen As Boolean = False
    Public f_detallado As Boolean = False
    Public Lst_Pedidos_Fecha As Boolean = False
    Public Lst_Pedidos_Clientes As Boolean = False
    Public f_lstMercados As Boolean = False   ' VES Sep 2019


    ' perfiles de usuario

    Public pf_categorias As Boolean = False
    Public pf_SubCategorias As Boolean = False
    Public pf_usuarios As Boolean = False




    ' Facturacion
    Public f_addservicios As Boolean = False
    Public f_addfacturacion As Boolean = False
    Public f_addvas As Boolean = False
    Public f_cotizaciones As Boolean = False


    ' Transportes
    Public f_registrocamion As Boolean = False
    Public f_listadocamion As Boolean = False
    Public f_IngresoSalida As Boolean = False


    'Informes
    Public f_acumulado As Boolean = False
    Public f_trazabilidad As Boolean = False
    Public f_resumido As Boolean = False
    Public f_emitidos As Boolean = False
    Public f_pedidosmensual As Boolean = False
    Public f_posicionsopo As Boolean = False
    Public f_poslibres As Boolean = False
    Public f_revisiones As Boolean = False
    Public f_MovSopUsu As Boolean = False
    Public f_TrazGuia As Boolean = False
    Public f_TrazProd As Boolean = False
    Public f_Cuadratura As Boolean = False
    Public f_Andenes As Boolean = False
    Public f_plist As Boolean = False
    Public f_tuneles As Boolean = False
    Public f_PalletTunel As Boolean = False
    Public f_cruce As Boolean = False
    Public f_control As Boolean = False
    Public f_demo As Boolean = False
    Public f_servicios As Boolean = False
    Public f_pusu As Boolean = False
    Public f_controlHOR
    Public f_envioemail As Boolean = False
    Public f_tuneleskilos As Boolean = False
    Public f_sopcam As Boolean = False
    Public f_manpos As Boolean = False
    Public f_jibia As Boolean = False
    Public f_avisopal As Boolean = False
    Public f_reserv As Boolean = False
    Public f_planocam As Boolean = False
    Public f_eticli As Boolean = False
    Public f_confcam As Boolean = False
    Public f_reglas As Boolean = False
    Public f_tramos As Boolean = False
    Public f_picking As Boolean = False
    Public f_auditoria As Boolean = False
    Public f_confgene As Boolean = False
    Public f_possss As Boolean = False
    Public f_NumDia As Boolean = False
    Public f_bloqDias As Boolean = False
    Public f_actWms As Boolean = False
    'PROCESOS
    Public f_procdesbloq As Boolean = False
    Public f_guiasPendTunel As Boolean = False ' VES Nov 2019
    Public f_estadoTuneles As Boolean = False ' VES Nov 2019
    Public f_contenidoTuneles As Boolean = False ' VES Nov 2019
    Public f_etiquetado As Boolean = False
    Public f_contenedores As Boolean = False
    Public f_pedidos As Boolean = False

    Public f_rcp As Boolean = False
    Public f_bloqDesbloq As Boolean = False
    Public f_manual As Boolean = False

    Public f_pedidos_xls As Boolean = False
    Public f_conf_pedidos_xls As Boolean = False
    Public f_locs_pedidos As Boolean = False

    Public f_LimPedExp As Boolean = False
    Public f_LimPedExpFecha As Boolean = False
    Public f_CtrPallet As Boolean = False


    Public f_CtrPalletArr As Boolean = False

    Public f_ConfigHrsRece As Boolean = False
    Public f_ConfigBloqHrsRece As Boolean = False

    Public f_ConfigBloqCargas As Boolean = False

    Public f_ReceProgList As Boolean = False
    Public f_confTunel As Boolean = False ' VES Oct 2019
    Public f_OrdPal As Boolean = False


    Public documentoimp As String = ""
End Module
