IF OBJECT_ID('SP_Control_Pallet_Venta_Grabar','P') IS NOT NULL
	DROP PROCEDURE SP_Control_Pallet_Venta_Grabar
GO
CREATE proc [dbo].[SP_Control_Pallet_Venta_Grabar](
	@ID varchar(10),
	@CodSopo varchar(9),
	@TipDoc char(1),
	@DocAso varchar(15),
	@Obs varchar(200),
	@Est varchar(1),
	@CodUsu varchar(3)
)
as
begin
	declare @Resp int
	set @Resp=-1

	if(@ID='')
	begin
		select
			@ID=isnull(ID,'')
		from Control_Pallet_Venta with(nolock)
		where Codigo_Soportante=@CodSopo
			and Tipo_Documento=@TipDoc
			and Documento_Asociado=@DocAso;
	end

	if(@ID='')
	begin
		if(@Est='')
		begin
			set @Est='A'
		end
		
		insert into Control_Pallet_Venta(
			Codigo_Soportante,Fecha,Tipo_Documento,
			Documento_Asociado,Observacion,Estado
		)values(
			@CodSopo,getdate(),@TipDoc,
			@DocAso,@Obs,@Est
		);

		set @ID=@@IDENTITY

		insert into Control_Pallet_Venta_Log
		select
			*,'I',@CodUsu,getdate()
		from Control_Pallet_Venta with(nolock)
		where ID=@ID;

		set @Resp=@ID
	end
	else
	begin
		insert into Control_Pallet_Venta_Log
		select
			*,'U',@CodUsu,getdate()
		from Control_Pallet_Venta with(nolock)
		where ID=@ID;

		if(@Obs<>'')
		begin
			update a
			set a.Observacion=@Obs
			from Control_Pallet_Venta a with(nolock)
			where a.ID=@ID;
		end

		if(@Est<>'')
		begin
			update a
			set a.Estado=@Est
			from Control_Pallet_Venta a with(nolock)
			where a.ID=@ID;
		end

		set @Resp=@ID
	end

	select Resp=@Resp;
end
GO


