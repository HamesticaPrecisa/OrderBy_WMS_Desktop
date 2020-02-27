IF OBJECT_ID('SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar','P') IS NOT NULL
	DROP PROCEDURE SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar
GO
create proc [dbo].[SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar](
	@ID int,
	@CodSopo varchar(9),
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
			@ID=ID
		from Control_Pallet_TMP_Recepcion_Dañado with(nolock)
		where Codigo_Soportante=@CodSopo;
	end

	if(@ID='')
	begin
		if(@Est='')
		begin
			set @Est='A'
		end

		insert into Control_Pallet_TMP_Recepcion_Dañado(
			Codigo_Soportante,Estado
		)values(
			@CodSopo,@Est
		);

		set @ID=@@IDENTITY

		insert into Control_Pallet_TMP_Recepcion_Dañado_Log
		select
			*,'I',@CodUsu,getdate()
		from Control_Pallet_TMP_Recepcion_Dañado with(nolock)
		where ID=@ID;

		set @Resp=@ID
	end
	else
	begin
		insert into Control_Pallet_TMP_Recepcion_Dañado_Log
		select
			*,'U',@CodUsu,getdate()
		from Control_Pallet_TMP_Recepcion_Dañado with(nolock)
		where ID=@ID;

		if(@Est<>'')
		begin
			update Control_Pallet_TMP_Recepcion_Dañado
			set Estado=@Est
			where ID=@ID;
		end

		set @Resp=@ID
	end

	select Resp=@Resp;
end
GO


