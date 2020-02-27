
IF OBJECT_ID('SP_Control_Pallet_Calcular_Saldos','P') IS NOT NULL
	DROP PROCEDURE SP_Control_Pallet_Calcular_Saldos
GO
CREATE proc [dbo].[SP_Control_Pallet_Calcular_Saldos](
	@RutCli varchar(9),
	@CodCont varchar(7),
	@TipPal varchar(3),
	@Est int
)
as
begin

	/*
		SP_Control_Pallet_Calcular_Saldos
		Recalcula el saldo de pallets en custodia para el cliente/contrato/soportante indicado. 

		NOTA IMPORTANTE
		Por alguna razon el saldo se lleva de forma duplicada. Se actualiza en la columna SALDO de
		la tabla CONTROL_PALLETS, por cada movimiento, y se mantiene por contrato dentro de la tabla
		CONTROL_PALLET_SALDOS.

		@est
			1: Normal
			2: Cambio de pallet


	*/

	declare @ID int
	declare @Ent int
	declare @Sal int
	
	declare @Sald int
	set @Sald=0

	declare movimientos_cursor cursor for
	select
		ID,Entradas,Salidas
	from Control_Pallet a with(nolock)
	where a.Rut_Cliente=@RutCli
		and a.Contrato=@CodCont
		and a.Tipo_Pallet=@TipPal
		and a.Estado=@Est
	order by convert(date,a.Fecha) asc,a.ID asc;

	open movimientos_cursor
	fetch next from movimientos_cursor
	into @ID,@Ent,@Sal
	
	while @@FETCH_STATUS=0
	begin
		select
			@Sald=@Sald+(a.Entradas-a.Salidas)
		from Control_Pallet a with(nolock)
		where a.ID=@ID;

		update Control_Pallet
		set Saldo=@Sald
		where ID=@ID;

		fetch next from movimientos_cursor
		into @ID,@Ent,@Sal
	end

	close movimientos_cursor
	deallocate movimientos_cursor

	update Control_Pallet_Saldos
	set Saldo=@Sald
	where Rut_Cliente=@RutCli
		and Contrato=@CodCont
		and Tipo_Pallet=@TipPal
		and Estado=@Est;

	if(@@ROWCOUNT=0)
	begin
		insert into Control_Pallet_Saldos(
			Rut_Cliente,Contrato,Tipo_Pallet,
			Estado,Saldo
		)values(
			@RutCli,@CodCont,@TipPal,
			@Est,@Sald
		);
	end
end
GO

