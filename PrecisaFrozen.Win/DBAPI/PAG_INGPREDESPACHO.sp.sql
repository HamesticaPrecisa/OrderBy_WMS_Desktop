IF OBJECT_ID('PAG_INGPREDESPACHO','P') IS NOT NULL
	DROP PROCEDURE PAG_INGPREDESPACHO
GO
CREATE PROCEDURE PAG_INGPREDESPACHO
(
	@fpre_codi AS VARCHAR(7),			-- CODIGO PRE-DESPACHO
	@fpre_rutcli as varchar(9),			-- RUT CLIENTE
	@fpre_totsopo as int,				-- TOTAL DE SOPORTANTES
	@fpre_totunidad as int,				-- TOTAL DE ENVASES
	@fpre_totpeso as float,				-- TOTAL DE KILOS
	@fpre_codienca as varchar(3),		-- ENCARGADO DE MOVIMIENTO
	@fpre_sello as varchar(50),			-- SELLO
	@fpre_contenedor as varchar(50),	-- CONTENEDOR
	@fpre_rampla as varchar(15),		-- RAMPLA
	@fpre_destino as varchar(20),		-- DESTINO
	@fpre_observacion as varchar(255),	-- OBSERVACIONES DEL MOVIMIENTO
	@fpre_nped as numeric(18,0),		-- NUMERO DE PEDIDO, SI NO TIENE OMISION 0
	@fpre_etiq as varchar(1),			-- SI VA A ETIQUETADO   1 A ETIQ    0 NORMAL
	@tipo as varchar(2),				-- TIPO DE MOVIMIENTO MOV_PALLET  PD|GESTION   PR|RADIO   PT|TABLET
	@TS as float,						-- TEMP 1
	@TM as float,						-- TEMP 2
	@TI as float,						-- TEMP 3
	@olor as varchar(10),               -- OLOR	
	@hig as varchar(10),                -- HIGIENE
	@cond as varchar(10),				-- CONDENSACION							
	@codbod as varchar(10)              -- BODEGA
)
AS BEGIN

DECLARE @error as  int
DECLARE @trans as VARCHAR(50)
DECLARE @PROMEDIO AS float
DECLARE @HoraInicio as varchar(5)

SET @error=0

SELECT @PROMEDIO=ROUND((@TS+@TM+@TI)/3,1) -- PROMEDIO AUTOMATICO, EVITAR PROBLEMAS DE CONFIG DE DISPOSITIVOS.
SELECT @HoraInicio=fpre_horades FROM TMPFICHPRED WHERE fpre_codi=@fpre_codi

IF(SELECT COUNT(*) FROM fichpred WHERE fpre_codi=@fpre_codi)=0

BEGIN 

BEGIN TRANSACTION @trans
	BEGIN TRY
			INSERT INTO fichpred(fpre_codi, fpre_rutcli, fpre_horades, fpre_horater, fpre_fecdes, fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_codienca, fpre_activa, fpre_fechact, fpre_codvig, fpre_gdespa, fpre_sello, fpre_tem, FPRE_USUCRE, fpre_contenedor, fpre_rampla, fpre_destino, fpre_Observacion, fpre_nped, fpre_etiq,estc_olor,estc_hig,estc_cond,cod_bod)
			VALUES(@fpre_codi, @fpre_rutcli, @HoraInicio, convert(varchar(5), getdate(), 8), convert(varchar(10), getdate(), 111), @fpre_totsopo, @fpre_totunidad, @fpre_totpeso, @fpre_codienca, 0, convert(varchar(10), getdate(), 111), 0, 0, @fpre_sello, @PROMEDIO,
 @fpre_codienca, @fpre_contenedor, @fpre_rampla, @fpre_destino, @fpre_observacion, @fpre_nped, @fpre_etiq,@olor,@hig,@cond,@codbod)
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @trans;
		SELECT 1;
		RETURN;
	END CATCH
	
	BEGIN TRY
			INSERT INTO detapred(dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, dpre_unidades, dpre_peso, dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, dpre_folio, dpre_activa, dpre_pallet, dpre_TS, dpre_TM, dpre_TI, dpre_CodPer, dpre_Hora, dpre_fecn, dpre_cajsel)
			SELECT fpre_codi+dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, dpre_unidades, dpre_peso, dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, dpre_folio, dpre_activa, dpre_pallet, dpre_TS, dpre_TM, dpre_TI, dpre_CodPer, dpre_Hora, dpre_fecn, dpre_cajsel FROM TMPDETAPRED WHERE fpre_codi=@fpre_codi
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @trans;
		SELECT 2;
		RETURN;
	END CATCH
	
	BEGIN TRY
			INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_Doc, mov_hora, mov_TS, mov_TM, mov_TI, mov_docdespa, Mov_Despacho, Mov_Saldo)
			SELECT dpre_folio, @fpre_codienca, dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, convert(varchar(10), getdate(), 111), @tipo, @fpre_codi, convert(varchar(5), getdate(), 8), @TS, @TM, @TI, 0, dpre_ActUni, dpre_TotUni FROM TMPDETAPRED WHERE
 fpre_codi=@fpre_codi
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @trans;
		SELECT 3;
		RETURN;
	END CATCH
		
	BEGIN TRY
			UPDATE pedcaja SET pc_estado='2' WHERE pc_codped=@fpre_nped
			DELETE FROM TMPDETAPRED WHERE fpre_codi=@fpre_codi
			DELETE FROM TMPFICHPRED WHERE fpre_codi=@fpre_codi
			UPDATE DetaReceCajas SET caj_ped='2' WHERE LEFT(caj_pcod,7)=@fpre_codi
		    --UPDATE Pedidos_ficha SET Ped_EstPred=3 WHERE Orden=@fpre_nped
			exec SP_Pedidos_Estados_Actualizar @fpre_nped,'P','3'
	END TRY
	BEGIN CATCH
			ROLLBACK TRANSACTION @trans;
			SELECT 5;
			RETURN;
	END CATCH


SELECT @error
	IF(@error=0)
	BEGIN
		COMMIT TRANSACTION @trans
		SELECT 0;
	END
END

ELSE
BEGIN
	SELECT 4
	RETURN;
END
-- RETORNA:
--1 ERROR DE FICHA
--2 ERROR DE DETALLE 
--3 ERROR DE MOVPALLET
--4 YA INGRESADO
--------------------------------
--0 EJECUTA CORRECTAMENTE
END
GO


