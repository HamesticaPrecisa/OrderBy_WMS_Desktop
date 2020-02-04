/*
	SP_Control_Pallet_Grabar
	Genera movimientos de custodia de pallets


	14/01/2020	VES		Modificacion para descontar arriendos activos al cargar nuevos pallets en custodia

*/
IF OBJECT_ID('SP_Control_Pallet_Grabar','P') IS NOT NULL
	DROP PROCEDURE SP_Control_Pallet_Grabar
GO
CREATE proc SP_Control_Pallet_Grabar(
	@ID varchar(10),
	@RutCli varchar(9),
	@CodCont varchar(7),
	@Fec varchar(10),
	@TipPal varchar(3),
	@Doc varchar(10),
	@Ent int,
	@Sal int,
	@Obs varchar(500),
	@Est int,
	@CodUsu varchar(3)
)
as
begin
	declare @Resp int
	declare @addMode BIT = CASE @id WHEN '' THEN 1 ELSE 0 END
	set @Resp=-1

	if(@ID='')
	begin
		insert into Control_Pallet(
			Rut_Cliente,Contrato,Fecha,Tipo_Pallet,
			Documento,Entradas,Salidas,Estado,Observacion
		)values(
			@RutCli,@CodCont,@Fec,@TipPal,
			@Doc,@Ent,@Sal,@Est,@Obs
		);

		set @ID=@@IDENTITY

		insert into Control_Pallet_Log
		select
			*,'I',@CodUsu,getdate()
		from Control_Pallet with(nolock)
		where ID=@ID;

		set @Resp=@ID
	end
	else
	begin
		insert into Control_Pallet_Log
		select
			*,'U',@CodUsu,getdate()
		from Control_Pallet with(nolock)
		where ID=@ID;

		update Control_Pallet
		set Fecha=@Fec,Documento=@Doc,Entradas=@Ent,Salidas=@Sal,
			Tipo_Pallet=@TipPal,Estado=@Est,Observacion=@Obs
		where ID=@ID;

		set @Resp=@ID
	end

	exec SP_Control_Pallet_Calcular_Saldos @RutCli,@CodCont,@TipPal,@Est

	/*

		VES 14 ENE 2020
		SI SE ESTAN INCLUYENDO NUEVOS PALLETS EN CUSTODIA, SE VERIFICA SI EL CLIENTE
		TIENE PALLETS EN ARRIENDO EN CUALQUIER CONTRATO. SI ES ASI, SE FINALIZA LA 
		MAYOR CANTIDAD DE ARRIENDOS POSIBLES Y SE GENERAN LAS SALIDAS NECESARIAS
		PARA AJUSTAR EL SALDO DE PALLETS EN CUSTODIA

	*/
	SELECT @addMode, @ent
	IF @addMode = 1 AND @ent > 0 BEGIN
		DECLARE @pallets_disp INT = @ent
		DECLARE @pallet VARCHAR(10)
		DECLARE @codcont_arriendo VARCHAR(7)
		DECLARE @idarriendo INT
		DECLARE @exitLoop BIT = 0 
		DECLARE @now VARCHAR(10) = CONVERT(VARCHAR, GETDATE(), 102)
	    DECLARE @Obs_arriendo varchar(500)
		WHILE @exitLoop = 0 BEGIN
			
			
			-- BUSCAMOS PRIMERO PALLETS EN ARRIENDO DENTRO DEL CONTRATO AFECTADO
			SET @pallet = NULL
			SET @codcont_arriendo = @codcont
			SELECT TOP 1 @pallet = codigo_soportante
			  FROM v_control_pallet_arriendo
			 WHERE rut_cliente = @rutcli
			   AND codigo_contrato = @codcont
			   AND codigo_tipo_soportante = @tippal
			   AND fecha_termino  IS NULL
			 ORDER BY fecha_inicio

			-- SI NO CONSEGUIMOS NADA, BUSCAMOS DE NUEVO EN CUALQUIER OTRO CONTRATO
			IF @pallet IS NULL BEGIN
				SELECT TOP 1 @pallet = codigo_soportante, @codcont_arriendo = codigo_contrato
				  FROM v_control_pallet_arriendo
				 WHERE rut_cliente = @rutcli
			  	   AND codigo_tipo_soportante = @tippal
				   AND fecha_termino  IS NULL
				 ORDER BY fecha_inicio
			END

			-- SI CONSEGUIMOS UN PALLET ARRENDADO, SE FINALIZA EL ARRIENDO
			SELECT @pallet, @codcont_arriendo
			IF @pallet IS NOT NULL BEGIN
			    SET @idarriendo = NULL
			    SELECT TOP 1 @idarriendo = id
				  FROM control_pallet_arriendo
				 WHERE codigo_soportante = @pallet
				   AND estado_arriendo = 'A'
				   AND fecha_termino IS NULL

				SELECT @idarriendo AS idarriendo
			    IF @idarriendo IS NOT NULL BEGIN
				    SET @obs_arriendo = 'Sustituye arriendo de pallet #' + @pallet
					EXEC SP_Control_Pallet_Arriendo_Grabar @idarriendo, @pallet, '', @now, 'A', @codusu
					EXEC SP_Control_Pallet_Grabar '',@rutcli,@codcont_arriendo,@fec,@tipPal,@pallet,0,1,@obs_arriendo,'1',@codusu
					SET @pallets_disp = @pallets_disp - 1
				END
			END


			-- SI NO CONSEGUIMOS UN PALLET O YA NO QUEDAN PALLETS NUEVOS DISPONIBLES
			-- FINALIZAMOS EL CICLO
			IF @pallet IS NULL OR @pallets_disp = 0 SET @exitLoop = 1
			SET @exitLoop = 1
		END

	END


	select Resp=@Resp;
end
GO


