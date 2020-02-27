IF OBJECT_ID('SP_Control_Pallet_Arriendo_Grabar','P') IS NOT NULL
	DROP PROCEDURE SP_Control_Pallet_Arriendo_Grabar
GO
create proc [dbo].[SP_Control_Pallet_Arriendo_Grabar](
	@ID varchar(10),
	@CodSopo varchar(9),
	@FecIni varchar(10),
	@FecFin varchar(10),
	@Est char(1),
	@CodUsuReg varchar(3)
)
as
begin
	declare @Resp int
	set @Resp=-1

	if(@ID='')
	begin
		select
			@ID=ID
		from Control_Pallet_Arriendo with(nolock)
		where Codigo_Soportante=@CodSopo;
	end

	if(@ID='')
	begin
		if(@Est='')
		begin
			set @Est='A'
		end
		
		insert into Control_Pallet_Arriendo(
			Codigo_Soportante,Fecha_Inicio,Estado_Arriendo
		)values(
			@CodSopo,CONVERT(SMALLDATETIME, @FecIni, 120),@Est
		);

		set @ID=@@IDENTITY

		insert into Control_Pallet_Arriendo_Log
		select
			*,'I',@CodUsuReg,getdate()
		from Control_Pallet_Arriendo with(nolock)
		where ID=@ID;

		set @Resp=@ID
	end
	else
	begin
		insert into Control_Pallet_Arriendo_Log
		select
			*,'U',@CodUsuReg,getdate()
		from Control_Pallet_Arriendo with(nolock)
		where ID=@ID;

		if(@FecIni<>'')
		begin
			update Control_Pallet_Arriendo
			set Fecha_Inicio=CONVERT(SMALLDATETIME, @FecIni, 120)
			where ID=@ID;
		end

		if(@FecFin<>'')
		begin
			update Control_Pallet_Arriendo
			set Fecha_Termino=CONVERT(SMALLDATETIME, @FecFin, 120)
			where ID=@ID;
		end

		if(@Est<>'')
		begin
			update Control_Pallet_Arriendo
			set Estado_Arriendo=@Est
			where ID=@ID;
		end

		set @Resp=@ID
	end

	select Resp=@Resp;
end
GO


