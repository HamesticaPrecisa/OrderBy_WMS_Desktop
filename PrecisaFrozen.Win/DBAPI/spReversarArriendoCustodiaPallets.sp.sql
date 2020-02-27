
IF OBJECT_ID('spReversarArriendoCustodiaPallets','P') IS NOT NULL
	DROP PROCEDURE spReversarArriendoCustodiaPallets
GO
CREATE PROCEDURE spReversarArriendoCustodiaPallets(
	@frec_codi NVARCHAR(7),
	@fdes_codi NVARCHAR(7)
) AS BEGIN
	/*
		spReversarArriendoCustodiaPallets
		Reversa los movimientos de arriendo/custodia realizados por
		una recepcion o despacho


	*/
	SET NOCOUNT ON
	DECLARE @rows CURSOR
	DECLARE @ex VARCHAR(max)

	DECLARE @cliente NVARCHAR(9),
	        @contrato NVARCHAR(7)

    SELECT TOP 1 @cliente = frec_rutcli, @contrato = frec_contcli
	  FROM fichrece
	 WHERE frec_codi = @frec_codi

	BEGIN TRANSACTION
	BEGIN TRY


		-- 
		--  PASO 1
		--  ELIMINAMOS TODO MOVIMIENTO REGISTRADO POR LA GUIA EN
		--  EL CONTROL DE PALLETS EN CUSTODIA Y SE RECALCULAN LOS
		--  SALDOS
		--
		IF @frec_codi IS NOT NULL BEGIN
			DECLARE @lista TABLE (estado INT, tipo_pallet NVARCHAR(3))
			INSERT INTO @lista
				 SELECT DISTINCT estado, tipo_pallet
				   FROM control_pallet
		  
			DELETE FROM control_pallet 
			 WHERE rut_cliente = @cliente
			   AND contrato = @contrato
			   AND documento = @frec_codi

			SET @rows = CURSOR FOR SELECT estado, tipo_pallet
									 FROM @lista

			DECLARE @estado INT,
					@tipo_pallet NVARCHAR(3)

			OPEN @rows
			FETCH NEXT FROM @rows INTO @estado, @tipo_pallet
			WHILE @@FETCH_STATUS = 0 BEGIN
			  EXEC SP_Control_Pallet_Calcular_Saldos @cliente,@contrato,@tipo_pallet,@estado
			  FETCH NEXT FROM @rows INTO @estado, @tipo_pallet
			END
			CLOSE @rows
		DEALLOCATE @rows
		END



		--
		--  PASO 2
		--  ELIMINAMOS CUALQUIER ARRIENDO CREADO POR ESTE DOCUMENTO
		--
		IF @frec_codi IS NOT NULL BEGIN
			DELETE FROM control_pallet_arriendo
			 WHERE codigo_soportante IN (SELECT drec_codi 
										   FROM detarece 
										  WHERE frec_codi1 = @frec_codi)
		END



		--
		--  PASO 3
		--  ELIMINAMOS CUALQUIER VENTA DE PALLET CREADA POR ESTE DOCUMENTO
		--
		IF @frec_codi IS NOT NULL BEGIN
			DELETE FROM control_pallet_venta
			 WHERE tipo_documento = 'R' 
			   AND documento_asociado = @frec_codi
		END
		IF @fdes_codi IS NOT NULL BEGIN
			DELETE FROM control_pallet_venta
			 WHERE tipo_documento = 'D' 
			   AND documento_asociado = @fdes_codi
		END

		COMMIT
	END TRY
	BEGIN CATCH
		SET @ex = ERROR_MESSAGE()
		ROLLBACK
	END CATCH	

	IF @ex IS NOT NULL RAISERROR(@ex,11,1)
	  

END
GO